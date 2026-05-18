using DesignPlanning.Entities;
using MVC.ProductManagement.Infrastructure.Repositories.DesignPlanningRepositories;
using TaskStatus = DesignPlanning.Entities.TaskStatus;

namespace DesignPlanning.Business;

public class PlanningService : IPlanningService
{
    private const string DesignEngineerRole = "Dizayn Mühendisi";
    private static readonly TimeSpan WorkStart = new(8, 0, 0);
    private readonly IPlanningRepository _planningRepository;

    public PlanningService(IPlanningRepository planningRepository)
    {
        _planningRepository = planningRepository;
    }

    public async Task GenerateProjectTasksAsync(Guid projectId)
    {
        var project = await _planningRepository.GetProjectByIdAsync(projectId) ?? throw new InvalidOperationException("Proje bulunamadı.");
        var hasTasks = await _planningRepository.HasProjectTasksAsync(projectId);
        if (hasTasks) return;

        var templates = await _planningRepository.GetActiveTaskTemplatesAsync(project.ProjectTypeId);

        var projectTasks = templates.Select(template => new ProjectTask
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

        await _planningRepository.AddProjectTasksAsync(projectTasks);
        await _planningRepository.CommitAsync();
    }

    public async Task AutoAssignAndPlanAsync(Guid projectId)
    {
        await GenerateProjectTasksAsync(projectId);

        var project = await _planningRepository.GetProjectWithTypeAsync(projectId) ?? throw new InvalidOperationException("Proje bulunamadı.");

        var tasks = await _planningRepository.GetProjectTasksOrderedAsync(projectId);

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
                var employee = await SelectEmployeeAsync(task.ResponsibleRole, project.ProjectType?.Name, cursor, inMemoryLoads);
                task.AssignedEmployeeId = employee?.Id;
                task.PlannedStart = await FindStartWithCapacityAsync(employee, cursor, inMemoryLoads);
                task.PlannedEnd = await PlanActiveTaskAsync(employee, task.PlannedStart, ToHours(task.DurationValue, task.DurationUnit, employee), inMemoryLoads);
            }

            task.Status = task.PlannedEnd.Date < DateTime.Today && task.Status != TaskStatus.Completed ? TaskStatus.Delayed : TaskStatus.Planned;
            cursor = task.PlannedEnd;
        }

        project.Status = ProjectStatus.Planned;
        await _planningRepository.CommitAsync();
    }

    public async Task CompleteTaskAsync(Guid projectTaskId)
    {
        var task = await _planningRepository.GetProjectTaskWithProjectTasksAsync(projectTaskId) ?? throw new InvalidOperationException("Görev bulunamadı.");

        task.ActualStart ??= DateTime.Now;
        task.ActualEnd = DateTime.Now;
        task.Status = TaskStatus.Completed;

        if (task.Project != null && task.Project.Tasks.All(x => x.Id == task.Id || x.Status == TaskStatus.Completed))
        {
            task.Project.Status = ProjectStatus.Completed;
        }

        await _planningRepository.CommitAsync();
    }

    public async Task<IReadOnlyList<ProjectTask>> GetDailyPlanAsync(DateTime date)
    {
        var dayStart = date.Date;
        var dayEnd = dayStart.AddDays(1);
        return await _planningRepository.GetPlannedTasksForRangeAsync(dayStart, dayEnd, orderByEmployee: false);
    }

    public async Task<IReadOnlyList<ProjectTask>> GetWeeklyPlanAsync(DateTime weekStartDate)
    {
        var start = StartOfWeek(weekStartDate);
        var end = start.AddDays(7);
        return await _planningRepository.GetPlannedTasksStartingInRangeAsync(start, end, orderByEmployee: true);
    }


    private async Task<Employee?> SelectEmployeeAsync(string role, string? projectTypeName, DateTime plannedDate, Dictionary<(Guid EmployeeId, DateTime Date), decimal> inMemoryLoads)
    {
        var candidates = await GetCandidatesByPriorityAsync(role, projectTypeName);

        if (!candidates.Any()) return null;

        var expertiseKeys = GetSelectionExpertiseKeys(role, projectTypeName, candidates);
        var weekStart = StartOfWeek(plannedDate);
        var weekEnd = weekStart.AddDays(7);
        var loads = await _planningRepository.GetEmployeeLoadsByWeekAsync(weekStart, weekEnd);

        return candidates
            .OrderBy(x => GetExpertiseRank(x, expertiseKeys))
            .ThenBy(x => (loads.TryGetValue(x.Id, out var hours) ? hours : 0) + GetInMemoryLoadForWeek(x.Id, weekStart, weekEnd, inMemoryLoads))
            .ThenBy(x => GetExpertisePriority(x, expertiseKeys))
            .ThenBy(x => x.FullName)
            .First();
    }

    private async Task<IReadOnlyList<Employee>> GetCandidatesByPriorityAsync(string role, string? projectTypeName)
    {
        var roleCandidates = string.IsNullOrWhiteSpace(role)
            ? new List<Employee>()
            : await _planningRepository.GetActiveEmployeesByExpertiseAsync(new[] { role });

        var projectTypeCandidates = string.IsNullOrWhiteSpace(projectTypeName)
            ? new List<Employee>()
            : await _planningRepository.GetActiveEmployeesByExpertiseAsync(new[] { projectTypeName });

        if (IsDesignEngineerRole(role) && projectTypeCandidates.Any())
        {
            return projectTypeCandidates
                .Concat(roleCandidates)
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
        }

        if (roleCandidates.Any())
        {
            return roleCandidates;
        }

        return projectTypeCandidates;
    }

    private static IReadOnlyCollection<string> GetSelectionExpertiseKeys(string role, string? projectTypeName, IReadOnlyList<Employee> candidates)
    {
        if (IsDesignEngineerRole(role) && !string.IsNullOrWhiteSpace(projectTypeName) && candidates.Any(x => x.Expertises.Any(e => e.ExpertiseName == projectTypeName)))
        {
            return new[] { projectTypeName, role };
        }

        var roleMatches = candidates.Any(x => x.Expertises.Any(e => e.ExpertiseName == role));
        if (roleMatches)
        {
            return new[] { role };
        }

        return string.IsNullOrWhiteSpace(projectTypeName) ? Array.Empty<string>() : new[] { projectTypeName };
    }

    private static int GetExpertiseRank(Employee employee, IReadOnlyCollection<string> expertiseKeys)
    {
        if (!expertiseKeys.Any()) return int.MaxValue;

        return expertiseKeys
            .Select((key, index) => employee.Expertises.Any(e => e.ExpertiseName == key) ? index : int.MaxValue)
            .Min();
    }

    private static int GetExpertisePriority(Employee employee, IReadOnlyCollection<string> expertiseKeys)
    {
        return employee.Expertises
            .Where(e => expertiseKeys.Contains(e.ExpertiseName))
            .Min(e => (int?)e.Priority) ?? int.MaxValue;
    }

    private static decimal GetInMemoryLoadForWeek(Guid employeeId, DateTime weekStart, DateTime weekEnd, Dictionary<(Guid EmployeeId, DateTime Date), decimal> inMemoryLoads)
    {
        return inMemoryLoads
            .Where(x => x.Key.EmployeeId == employeeId && x.Key.Date >= weekStart && x.Key.Date < weekEnd)
            .Sum(x => x.Value);
    }

    private static bool IsDesignEngineerRole(string role)
    {
        return string.Equals(role, DesignEngineerRole, StringComparison.OrdinalIgnoreCase);
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
        return await _planningRepository.GetUsedHoursAsync(employeeId, dayStart, dayEnd);
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
