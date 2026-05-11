using DesignPlanning.Entities;

namespace DesignPlanning.Business;

public interface IPlanningService
{
    Task GenerateProjectTasksAsync(Guid projectId);
    Task AutoAssignAndPlanAsync(Guid projectId);
    Task CompleteTaskAsync(Guid projectTaskId);
    Task<IReadOnlyList<ProjectTask>> GetDailyPlanAsync(DateTime date);
    Task<IReadOnlyList<ProjectTask>> GetWeeklyPlanAsync(DateTime weekStartDate);
}
