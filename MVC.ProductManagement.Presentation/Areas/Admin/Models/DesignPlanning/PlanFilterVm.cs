using DesignPlanning.Entities;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.DesignPlanning;

public class PlanFilterVm
{
    public DateTime Date { get; set; } = DateTime.Today;
    public IReadOnlyList<ProjectTask> Tasks { get; set; } = Array.Empty<ProjectTask>();
}
