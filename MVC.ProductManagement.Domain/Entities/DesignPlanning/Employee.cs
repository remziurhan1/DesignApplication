namespace DesignPlanning.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public decimal DailyCapacityHours { get; set; } = 8;
    public bool IsActive { get; set; } = true;
    public virtual ICollection<EmployeeExpertise> Expertises { get; set; } = new List<EmployeeExpertise>();
    public virtual ICollection<ProjectTask> AssignedTasks { get; set; } = new List<ProjectTask>();
}
