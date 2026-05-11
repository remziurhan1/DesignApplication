using DesignPlanning.Entities;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using TaskStatus = DesignPlanning.Entities.TaskStatus;

namespace DesignPlanning.Business;

public class PlanningService : IPlanningService
{
    private static readonly TimeSpan WorkStart = new(8, 0, 0);
    private readonly AppDbContext _context;

    public PlanningService(AppDbContext context)
    {
        _context = context;
    }

    public async Task GenerateProjectTasksAsync(Guid projectId)
    {
        var project = await _context.DesignPlanningProjects.FindAsync(projectId) ?? throw new InvalidOperationException("Proje bulunamadı.");
        var hasTasks = await _context.DesignPlanningProjectTasks.AnyAsync(x => x.ProjectId == projectId);
        if (hasTasks) return;

        var templates = await _context.DesignPlanningTaskTemplates
            .AsNoTracking()
            .Where(x => x.ProjectTypeId == project.ProjectTypeId && x.IsActive)
            .OrderBy(x => x.SequenceNo)
            .ToListAsync();

        foreach (var template in templates)
        {
            _context.DesignPlanningProjectTasks.Add(new ProjectTask
            {
                Id = Guid.NewGuid(),
                ProjectId = project.Id,
                TaskTemplateId = template.Id,
                SequenceNo = template.SequenceNo,
                ResponsibleRole = template.ResponsibleRole,
                TaskName = template.TaskName,
                DurationValue = template.DurationValue,
                DurationUnit = template.DurationUnit,
                IsPassive = template.IsPassive,
                PlannedStart = project.StartDate.Date.Add(WorkStart),
                PlannedEnd = project.StartDate.Date.Add(WorkStart),
                Status = TaskStatus.Waiting
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task AutoAssignAndPlanAsync(Guid projectId)
    {
        await GenerateProjectTasksAsync(projectId);

        var project = await _context.DesignPlanningProjects
            .Include(x => x.ProjectType)
            .FirstOrDefaultAsync(x => x.Id == projectId) ?? throw new InvalidOperationException("Proje bulunamadı.");

        var tasks = await _context.DesignPlanningProjectTasks
            .Where(x => x.ProjectId == projectId)
            .OrderBy(x => x.SequenceNo)
            .ToListAsync();

        var cursor = NextWorkStart(project.StartDate);
        var inMemoryLoads = new Dictionary<(Guid EmployeeId, DateTime Date), decimal>();
        foreach (var task in tasks)
        {
            if (task.Status == TaskStatus.Completed)
            {
                cursor = task.PlannedEnd == default ? cursor : task.PlannedEnd;
                continue;
            }

            cursor = NextWorkStart(cursor);
            task.PlannedStart = cursor;

            if (task.IsPassive)
            {
                task.AssignedEmployeeId = null;
                task.PlannedEnd = NextWorkStart(AddPassiveDuration(cursor, task.DurationValue, task.DurationUnit));
            }
            else
            {
                var employee = await SelectEmployeeAsync(task.ResponsibleRole, project.ProjectType?.Name, cursor);
                task.AssignedEmployeeId = employee?.Id;
                task.PlannedStart = await FindStartWithCapacityAsync(employee, cursor, inMemoryLoads);
                task.PlannedEnd = await PlanActiveTaskAsync(employee, task.PlannedStart, ToHours(task.DurationValue, task.DurationUnit, employee), inMemoryLoads);
            }

            task.Status = task.PlannedEnd.Date < DateTime.Today && task.Status != TaskStatus.Completed ? TaskStatus.Delayed : TaskStatus.Planned;
            cursor = task.PlannedEnd;
        }

        project.Status = ProjectStatus.Planned;
        await _context.SaveChangesAsync();
    }

    public async Task CompleteTaskAsync(Guid projectTaskId)
    {
        var task = await _context.DesignPlanningProjectTasks
            .Include(x => x.Project)
            .ThenInclude(x => x!.Tasks)
            .FirstOrDefaultAsync(x => x.Id == projectTaskId) ?? throw new InvalidOperationException("Görev bulunamadı.");

        task.ActualStart ??= DateTime.Now;
        task.ActualEnd = DateTime.Now;
        task.Status = TaskStatus.Completed;

        if (task.Project != null && task.Project.Tasks.All(x => x.Id == task.Id || x.Status == TaskStatus.Completed))
        {
            task.Project.Status = ProjectStatus.Completed;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<ProjectTask>> GetDailyPlanAsync(DateTime date)
    {
        var dayStart = date.Date;
        var dayEnd = dayStart.AddDays(1);
        return await QueryPlannedTasks()
            .Where(x => x.PlannedStart < dayEnd && x.PlannedEnd >= dayStart)
            .OrderBy(x => x.PlannedStart)
            .ThenBy(x => x.SequenceNo)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<ProjectTask>> GetWeeklyPlanAsync(DateTime weekStartDate)
    {
        var start = StartOfWeek(weekStartDate);
        var end = start.AddDays(7);
        return await QueryPlannedTasks()
            .Where(x => x.PlannedStart < end && x.PlannedEnd >= start)
            .OrderBy(x => x.PlannedStart)
            .ThenBy(x => x.AssignedEmployee!.FullName)
            .ToListAsync();
    }

    private IQueryable<ProjectTask> QueryPlannedTasks() => _context.DesignPlanningProjectTasks
        .AsNoTracking()
        .Include(x => x.Project).ThenInclude(x => x!.ProjectType)
        .Include(x => x.AssignedEmployee);

    private async Task<Employee?> SelectEmployeeAsync(string role, string? projectTypeName, DateTime plannedDate)
    {
        var keys = new[] { role, projectTypeName ?? string.Empty }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var candidates = await _context.DesignPlanningEmployees
            .Include(x => x.Expertises)
            .Where(x => x.IsActive && x.Expertises.Any(e => keys.Contains(e.ExpertiseName)))
            .ToListAsync();

        if (!candidates.Any()) return null;

        var weekStart = StartOfWeek(plannedDate);
        var weekEnd = weekStart.AddDays(7);
        var loads = await _context.DesignPlanningProjectTasks
            .Where(x => x.AssignedEmployeeId != null && !x.IsPassive && x.PlannedStart < weekEnd && x.PlannedEnd >= weekStart && x.Status != TaskStatus.Completed)
            .GroupBy(x => x.AssignedEmployeeId!.Value)
            .Select(g => new { EmployeeId = g.Key, Hours = g.Sum(x => x.DurationUnit == DurationUnit.Hour ? x.DurationValue : x.DurationUnit == DurationUnit.Day ? x.DurationValue * 8 : x.DurationValue * 40) })
            .ToDictionaryAsync(x => x.EmployeeId, x => x.Hours);

        return candidates
            .OrderBy(x => loads.TryGetValue(x.Id, out var hours) ? hours : 0)
            .ThenBy(x => x.Expertises.Where(e => keys.Contains(e.ExpertiseName)).Min(e => (int?)e.Priority) ?? int.MaxValue)
            .ThenBy(x => x.FullName)
            .First();
    }

    private async Task<DateTime> FindStartWithCapacityAsync(Employee? employee, DateTime start, Dictionary<(Guid EmployeeId, DateTime Date), decimal> inMemoryLoads)
    {
        if (employee == null) return NextWorkStart(start);
        var cursor = NextWorkStart(start);
        while (await GetTotalUsedHoursAsync(employee.Id, cursor.Date, inMemoryLoads) >= employee.DailyCapacityHours)
        {
            cursor = NextWorkStart(cursor.Date.AddDays(1).Add(WorkStart));
        }
        return cursor;
    }

    private async Task<DateTime> PlanActiveTaskAsync(Employee? employee, DateTime start, decimal totalHours, Dictionary<(Guid EmployeeId, DateTime Date), decimal> inMemoryLoads)
    {
        if (employee == null) return NextWorkStart(start.AddHours((double)totalHours));

        var remaining = totalHours;
        var cursor = NextWorkStart(start);
        while (remaining > 0)
        {
            var used = await GetTotalUsedHoursAsync(employee.Id, cursor.Date, inMemoryLoads);
            var capacity = Math.Max(0, employee.DailyCapacityHours - used);
            if (capacity <= 0)
            {
                cursor = NextWorkStart(cursor.Date.AddDays(1).Add(WorkStart));
                continue;
            }

            var block = Math.Min(capacity, remaining);
            inMemoryLoads[(employee.Id, cursor.Date)] = (inMemoryLoads.TryGetValue((employee.Id, cursor.Date), out var current) ? current : 0) + block;
            cursor = cursor.AddHours((double)block);
            remaining -= block;
            if (remaining > 0)
            {
                cursor = NextWorkStart(cursor.Date.AddDays(1).Add(WorkStart));
            }
        }
        return cursor;
    }

    private async Task<decimal> GetTotalUsedHoursAsync(Guid employeeId, DateTime date, Dictionary<(Guid EmployeeId, DateTime Date), decimal> inMemoryLoads)
    {
        var persisted = await GetUsedHoursAsync(employeeId, date);
        return persisted + (inMemoryLoads.TryGetValue((employeeId, date.Date), out var planned) ? planned : 0);
    }

    private async Task<decimal> GetUsedHoursAsync(Guid employeeId, DateTime date)
    {
        var dayStart = date.Date;
        var dayEnd = dayStart.AddDays(1);
        return await _context.DesignPlanningProjectTasks
            .Where(x => x.AssignedEmployeeId == employeeId && !x.IsPassive && x.Status != TaskStatus.Completed && x.PlannedStart < dayEnd && x.PlannedEnd >= dayStart)
            .SumAsync(x => x.DurationUnit == DurationUnit.Hour ? x.DurationValue : x.DurationUnit == DurationUnit.Day ? x.DurationValue * 8 : x.DurationValue * 40);
    }

    private static decimal ToHours(decimal duration, DurationUnit unit, Employee? employee) => unit switch
    {
        DurationUnit.Hour => duration,
        DurationUnit.Day => duration * (employee?.DailyCapacityHours ?? 8),
        DurationUnit.Week => duration * (employee?.DailyCapacityHours ?? 8) * 5,
        _ => duration
    };

    private static DateTime AddPassiveDuration(DateTime start, decimal value, DurationUnit unit)
    {
        var result = start;
        var days = unit switch
        {
            DurationUnit.Hour => value / 8,
            DurationUnit.Day => value,
            DurationUnit.Week => value * 5,
            _ => value
        };
        for (var i = 0; i < Math.Ceiling(days); i++) result = NextWorkStart(result.Date.AddDays(1).Add(WorkStart));
        return unit == DurationUnit.Hour ? NextWorkStart(start.AddHours((double)value)) : result;
    }

    private static DateTime NextWorkStart(DateTime value)
    {
        var date = value.Date;
        while (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) date = date.AddDays(1);
        var result = value.Date == date && value.TimeOfDay > WorkStart ? value : date.Add(WorkStart);
        while (result.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) result = result.Date.AddDays(1).Add(WorkStart);
        return result;
    }

    private static DateTime StartOfWeek(DateTime value)
    {
        var diff = (7 + (value.DayOfWeek - DayOfWeek.Monday)) % 7;
        return value.Date.AddDays(-diff);
    }
}
