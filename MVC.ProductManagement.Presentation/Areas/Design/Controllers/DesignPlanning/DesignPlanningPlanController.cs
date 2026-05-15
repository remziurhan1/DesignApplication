using DesignPlanning.Business;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.DesignPlanning;
using MVC.ProductManagement.Presentation.Areas.Design.Controllers;
using MVC.ProductManagement.Presentation.Services.DesignPlanning;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers.DesignPlanning;

[Area("Design")]
public class DesignPlanningPlanController : DesignBaseController
{
    private readonly IPlanningService _planningService;

    public DesignPlanningPlanController(IPlanningService planningService)
    {
        _planningService = planningService;
    }

    public async Task<IActionResult> Daily(DateTime? date)
    {
        if (!await CanAccessPlanningAsync())
        {
            return Forbid();
        }

        var selected = date?.Date ?? DateTime.Today;
        return View(new PlanFilterVm { Date = selected, Tasks = await _planningService.GetDailyPlanAsync(selected) });
    }

    public async Task<IActionResult> Weekly(DateTime? date)
    {
        if (!await CanAccessPlanningAsync())
        {
            return Forbid();
        }

        var selected = date?.Date ?? DateTime.Today;
        return View(new PlanFilterVm { Date = selected, Tasks = await _planningService.GetWeeklyPlanAsync(selected) });
    }

    public async Task<IActionResult> ExportDaily(DateTime? date)
    {
        if (!await CanAccessPlanningAsync())
        {
            return Forbid();
        }

        var selected = date?.Date ?? DateTime.Today;
        var tasks = await _planningService.GetDailyPlanAsync(selected);
        var file = DesignPlanningPlanExcelExporter.Export("Günlük Dizayn Planı", selected, tasks, groupByEmployee: false);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"gunluk-dizayn-plani-{selected:yyyyMMdd}.xlsx");
    }

    public async Task<IActionResult> ExportWeekly(DateTime? date)
    {
        if (!await CanAccessPlanningAsync())
        {
            return Forbid();
        }

        var selected = date?.Date ?? DateTime.Today;
        var tasks = await _planningService.GetWeeklyPlanAsync(selected);
        var file = DesignPlanningPlanExcelExporter.Export("Haftalık Dizayn Planı", selected, tasks, groupByEmployee: true);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"haftalik-dizayn-plani-{selected:yyyyMMdd}.xlsx");
    }

    private async Task<bool> CanAccessPlanningAsync()
    {
        return User.IsInRole("DesignManager") || await CanManageStockCodePermissionsAsync();
    }
}
