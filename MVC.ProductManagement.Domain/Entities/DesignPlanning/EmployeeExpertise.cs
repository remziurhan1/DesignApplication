namespace DesignPlanning.Entities;

public class EmployeeExpertise
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string ExpertiseName { get; set; } = string.Empty;
    public int Priority { get; set; } = 1;
    public virtual Employee? Employee { get; set; }
}
