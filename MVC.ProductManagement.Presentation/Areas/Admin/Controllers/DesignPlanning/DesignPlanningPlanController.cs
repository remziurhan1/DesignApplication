using DesignPlanning.Business;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.DesignPlanning;
using MVC.ProductManagement.Presentation.Areas.Admin.Controllers;
using MVC.ProductManagement.Presentation.Services.DesignPlanning;
using System.Globalization;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers.DesignPlanning;

[Area("Admin")]
public class DesignPlanningPlanController : AdminBaseController
{
    private readonly IPlanningService _planningService;
    public DesignPlanningPlanController(IPlanningService planningService) => _planningService = planningService;

    public async Task<IActionResult> Daily(DateTime? date)
    {
        var selected = date?.Date ?? DateTime.Today;
        return View(new PlanFilterVm
        {
            Date = selected,
            Tasks = await _planningService.GetDailyPlanAsync(selected)
        });
    }

    public async Task<IActionResult> Weekly(DateTime? date, string? week)
    {
        var selected = ResolveWeeklySelectionDate(date, week);
        var weekStart = StartOfWeekMonday(selected);

        return View(new PlanFilterVm
        {
            Date = selected,
            WeekStart = weekStart,
            WeekEnd = weekStart.AddDays(6),
            WeekInput = ToIsoWeekInput(weekStart),
            Tasks = await _planningService.GetWeeklyPlanAsync(selected)
        });
    }

    public async Task<IActionResult> ExportDaily(DateTime? date)
    {
        var selected = date?.Date ?? DateTime.Today;
        var tasks = await _planningService.GetDailyPlanAsync(selected);
        var file = DesignPlanningPlanExcelExporter.Export("Günlük Dizayn Planı", selected, tasks, groupByEmployee: false);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"gunluk-dizayn-plani-{selected:yyyyMMdd}.xlsx");
    }

    public async Task<IActionResult> ExportWeekly(DateTime? date, string? week)
    {
        var selected = ResolveWeeklySelectionDate(date, week);
        var tasks = await _planningService.GetWeeklyPlanAsync(selected);
        var file = DesignPlanningPlanExcelExporter.Export("Haftalık Dizayn Planı", selected, tasks, groupByEmployee: true);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"haftalik-dizayn-plani-{selected:yyyyMMdd}.xlsx");
    }

    private static DateTime ResolveWeeklySelectionDate(DateTime? date, string? week)
    {
        if (!string.IsNullOrWhiteSpace(week) && TryParseIsoWeek(week, out var weekStart))
        {
            return weekStart;
        }

        return date?.Date ?? DateTime.Today;
    }

    private static DateTime StartOfWeekMonday(DateTime date)
    {
        var diff = ((int)date.DayOfWeek + 6) % 7;
        return date.Date.AddDays(-diff);
    }

    private static string ToIsoWeekInput(DateTime date)
    {
        var week = ISOWeek.GetWeekOfYear(date);
        var year = ISOWeek.GetYear(date);
        return $"{year}-W{week:00}";
    }

    private static bool TryParseIsoWeek(string weekInput, out DateTime weekStart)
    {
        weekStart = default;
        if (weekInput.Length != 8 || weekInput[4] != '-' || weekInput[5] != 'W')
        {
            return false;
        }

        if (!int.TryParse(weekInput.AsSpan(0, 4), out var year) || !int.TryParse(weekInput.AsSpan(6, 2), out var week))
        {
            return false;
        }

        if (week < 1 || week > 53)
        {
            return false;
        }

        weekStart = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
        return true;
    }
}
