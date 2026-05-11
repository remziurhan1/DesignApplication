namespace DesignPlanning.Entities;

public class TaskTemplate
{
    public Guid Id { get; set; }
    public Guid ProjectTypeId { get; set; }
    public int SequenceNo { get; set; }
    public string ResponsibleRole { get; set; } = string.Empty;
    public string TaskName { get; set; } = string.Empty;
    public decimal DurationValue { get; set; }
    public DurationUnit DurationUnit { get; set; }
    public bool IsPassive { get; set; }
    public bool IsActive { get; set; } = true;
    public ProjectType? ProjectType { get; set; }
    public ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
}
