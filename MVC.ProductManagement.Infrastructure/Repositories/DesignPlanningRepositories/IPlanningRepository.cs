using DesignPlanning.Entities;

namespace MVC.ProductManagement.Infrastructure.Repositories.DesignPlanningRepositories;

public interface IPlanningRepository
{
    Task<Project?> GetProjectByIdAsync(Guid projectId);
    Task<Project?> GetProjectWithTypeAsync(Guid projectId);
    Task<bool> HasProjectTasksAsync(Guid projectId);
    Task<IReadOnlyList<TaskTemplate>> GetActiveTaskTemplatesAsync(Guid projectTypeId);
    Task AddProjectTasksAsync(IEnumerable<ProjectTask> tasks);
    Task<IReadOnlyList<ProjectTask>> GetProjectTasksOrderedAsync(Guid projectId);
    Task<ProjectTask?> GetProjectTaskWithProjectTasksAsync(Guid projectTaskId);
    Task<IReadOnlyList<ProjectTask>> GetPlannedTasksForRangeAsync(DateTime start, DateTime end, bool orderByEmployee);
    Task<IReadOnlyList<ProjectTask>> GetPlannedTasksStartingInRangeAsync(DateTime start, DateTime end, bool orderByEmployee);
    Task<IReadOnlyList<Employee>> GetActiveEmployeesByExpertiseAsync(IReadOnlyCollection<string> expertiseNames);
    Task<IDictionary<Guid, decimal>> GetEmployeeLoadsByWeekAsync(DateTime weekStart, DateTime weekEnd);
    Task<decimal> GetUsedHoursAsync(Guid employeeId, DateTime dayStart, DateTime dayEnd);
    Task CommitAsync();
}
