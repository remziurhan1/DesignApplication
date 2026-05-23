using DesignPlanning.Entities;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.DesignPlanning;

public class PlanFilterVm
{
    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime? WeekStart { get; set; }
    public DateTime? WeekEnd { get; set; }
    public string WeekInput { get; set; } = string.Empty;
    public IReadOnlyList<ProjectTask> Tasks { get; set; } = Array.Empty<ProjectTask>();
}
