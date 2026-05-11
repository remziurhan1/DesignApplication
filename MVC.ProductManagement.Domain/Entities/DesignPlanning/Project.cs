namespace DesignPlanning.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string ProjectCode { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public Guid ProjectTypeId { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Today;
    public int Priority { get; set; } = 1;
    public ProjectStatus Status { get; set; } = ProjectStatus.Waiting;
    public ProjectType? ProjectType { get; set; }
    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
