using DesignPlanning.Entities;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using TaskStatus = DesignPlanning.Entities.TaskStatus;

namespace MVC.ProductManagement.Infrastructure.Repositories.DesignPlanningRepositories;

public class PlanningRepository : IPlanningRepository
{
    private readonly AppDbContext _context;

    public PlanningRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Project?> GetProjectByIdAsync(Guid projectId)
    {
        return await _context.DesignPlanningProjects.FindAsync(projectId);
    }

    public async Task<Project?> GetProjectWithTypeAsync(Guid projectId)
    {
        return await _context.DesignPlanningProjects
            .Include(x => x.ProjectType)
            .FirstOrDefaultAsync(x => x.Id == projectId);
    }

    public async Task<bool> HasProjectTasksAsync(Guid projectId)
    {
        return await _context.DesignPlanningProjectTasks.AnyAsync(x => x.ProjectId == projectId);
    }

    public async Task<IReadOnlyList<TaskTemplate>> GetActiveTaskTemplatesAsync(Guid projectTypeId)
    {
        return await _context.DesignPlanningTaskTemplates
            .AsNoTracking()
            .Where(x => x.ProjectTypeId == projectTypeId && x.IsActive)
            .OrderBy(x => x.SequenceNo)
            .ToListAsync();
    }

    public async Task AddProjectTasksAsync(IEnumerable<ProjectTask> tasks)
    {
        await _context.DesignPlanningProjectTasks.AddRangeAsync(tasks);
    }

    public async Task<IReadOnlyList<ProjectTask>> GetProjectTasksOrderedAsync(Guid projectId)
    {
        return await _context.DesignPlanningProjectTasks
            .Where(x => x.ProjectId == projectId)
            .OrderBy(x => x.SequenceNo)
            .ToListAsync();
    }

    public async Task<ProjectTask?> GetProjectTaskWithProjectTasksAsync(Guid projectTaskId)
    {
        return await _context.DesignPlanningProjectTasks
            .Include(x => x.Project)
            .ThenInclude(x => x!.Tasks)
            .FirstOrDefaultAsync(x => x.Id == projectTaskId);
    }

    public async Task<IReadOnlyList<ProjectTask>> GetPlannedTasksForRangeAsync(DateTime start, DateTime end, bool orderByEmployee)
    {
        return await GetPlannedTasksForRangeAsync(start, end, orderByEmployee, matchStartOnly: false);
    }

    public async Task<IReadOnlyList<ProjectTask>> GetPlannedTasksStartingInRangeAsync(DateTime start, DateTime end, bool orderByEmployee)
    {
        return await GetPlannedTasksForRangeAsync(start, end, orderByEmployee, matchStartOnly: true);
    }

    private async Task<IReadOnlyList<ProjectTask>> GetPlannedTasksForRangeAsync(DateTime start, DateTime end, bool orderByEmployee, bool matchStartOnly)
    {
        IQueryable<ProjectTask> query = _context.DesignPlanningProjectTasks
            .AsNoTracking()
            .Include(x => x.Project).ThenInclude(x => x!.ProjectType)
            .Include(x => x.AssignedEmployee);

        query = matchStartOnly
            ? query.Where(x => x.PlannedStart >= start && x.PlannedStart < end)
            : query.Where(x => x.PlannedStart < end && x.PlannedEnd >= start);

        query = orderByEmployee
            ? query.OrderBy(x => x.PlannedStart).ThenBy(x => x.AssignedEmployee!.FullName)
            : query.OrderBy(x => x.PlannedStart).ThenBy(x => x.SequenceNo);

        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<Employee>> GetActiveEmployeesByExpertiseAsync(IReadOnlyCollection<string> expertiseNames)
    {
        return await _context.DesignPlanningEmployees
            .Include(x => x.Expertises)
            .Where(x => x.IsActive && x.Expertises.Any(e => expertiseNames.Contains(e.ExpertiseName)))
            .ToListAsync();
    }

    public async Task<IDictionary<Guid, decimal>> GetEmployeeLoadsByWeekAsync(DateTime weekStart, DateTime weekEnd)
    {
        return await _context.DesignPlanningProjectTasks
            .Where(x => x.AssignedEmployeeId != null && !x.IsPassive && x.PlannedStart < weekEnd && x.PlannedEnd >= weekStart && x.Status != TaskStatus.Completed)
            .GroupBy(x => x.AssignedEmployeeId!.Value)
            .Select(g => new
            {
                EmployeeId = g.Key,
                Hours = g.Sum(x => x.DurationUnit == DurationUnit.Hour ? x.DurationValue : x.DurationUnit == DurationUnit.Day ? x.DurationValue * 8 : x.DurationValue * 40)
            })
            .ToDictionaryAsync(x => x.EmployeeId, x => x.Hours);
    }

    public async Task<decimal> GetUsedHoursAsync(Guid employeeId, DateTime dayStart, DateTime dayEnd)
    {
        return await _context.DesignPlanningProjectTasks
            .Where(x => x.AssignedEmployeeId == employeeId && !x.IsPassive && x.Status != TaskStatus.Completed && x.PlannedStart < dayEnd && x.PlannedEnd >= dayStart)
            .SumAsync(x => x.DurationUnit == DurationUnit.Hour ? x.DurationValue : x.DurationUnit == DurationUnit.Day ? x.DurationValue * 8 : x.DurationValue * 40);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
