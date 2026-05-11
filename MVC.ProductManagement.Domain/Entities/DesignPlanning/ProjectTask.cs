namespace DesignPlanning.Entities;

public class ProjectTask
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid TaskTemplateId { get; set; }
    public Guid? AssignedEmployeeId { get; set; }
    public int SequenceNo { get; set; }
    public string ResponsibleRole { get; set; } = string.Empty;
    public string TaskName { get; set; } = string.Empty;
    public decimal DurationValue { get; set; }
    public DurationUnit DurationUnit { get; set; }
    public bool IsPassive { get; set; }
    public DateTime PlannedStart { get; set; }
    public DateTime PlannedEnd { get; set; }
    public DateTime? ActualStart { get; set; }
    public DateTime? ActualEnd { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Waiting;
    public virtual Project? Project { get; set; }
    public virtual TaskTemplate? TaskTemplate { get; set; }
    public virtual Employee? AssignedEmployee { get; set; }
}
