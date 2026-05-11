namespace DesignPlanning.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public decimal DailyCapacityHours { get; set; } = 8;
    public bool IsActive { get; set; } = true;
    public ICollection<EmployeeExpertise> Expertises { get; set; } = new List<EmployeeExpertise>();
    public ICollection<ProjectTask> AssignedTasks { get; set; } = new List<ProjectTask>();
}
