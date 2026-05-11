namespace DesignPlanning.Entities;

public class ProjectType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<TaskTemplate> TaskTemplates { get; set; } = new List<TaskTemplate>();
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
