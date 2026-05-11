namespace DesignPlanning.Entities;

public class ProjectType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<TaskTemplate> TaskTemplates { get; set; } = new List<TaskTemplate>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
