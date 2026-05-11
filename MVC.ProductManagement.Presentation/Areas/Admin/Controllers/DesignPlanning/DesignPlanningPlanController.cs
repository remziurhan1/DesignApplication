using DesignPlanning.Business;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.DesignPlanning;
using MVC.ProductManagement.Presentation.Areas.Admin.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers.DesignPlanning;

[Area("Admin")]
public class DesignPlanningPlanController : AdminBaseController
{
    private readonly IPlanningService _planningService;
    public DesignPlanningPlanController(IPlanningService planningService) => _planningService = planningService;

    public async Task<IActionResult> Daily(DateTime? date)
    {
        var selected = date?.Date ?? DateTime.Today;
        return View(new PlanFilterVm { Date = selected, Tasks = await _planningService.GetDailyPlanAsync(selected) });
    }

    public async Task<IActionResult> Weekly(DateTime? date)
    {
        var selected = date?.Date ?? DateTime.Today;
        return View(new PlanFilterVm { Date = selected, Tasks = await _planningService.GetWeeklyPlanAsync(selected) });
    }
}
