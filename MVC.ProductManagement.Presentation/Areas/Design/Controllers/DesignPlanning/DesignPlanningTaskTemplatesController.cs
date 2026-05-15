using DesignPlanning.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Design.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers.DesignPlanning;

[Area("Design")]
public class DesignPlanningTaskTemplatesController : DesignBaseController
{
    private readonly AppDbContext _context;

    public DesignPlanningTaskTemplatesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(Guid? projectTypeId)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        await LoadProjectTypes(projectTypeId);
        var query = _context.DesignPlanningTaskTemplates.Include(x => x.ProjectType).AsQueryable();
        if (projectTypeId.HasValue) query = query.Where(x => x.ProjectTypeId == projectTypeId.Value);
        return View(await query.OrderBy(x => x.ProjectType!.Name).ThenBy(x => x.SequenceNo).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        await LoadProjectTypes(null);
        return View(new TaskTemplate { IsActive = true, DurationUnit = DurationUnit.Hour });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskTemplate template)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        if (!ModelState.IsValid)
        {
            await LoadProjectTypes(template.ProjectTypeId);
            return View(template);
        }

        template.Id = Guid.NewGuid();
        _context.Add(template);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { projectTypeId = template.ProjectTypeId });
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var item = await _context.DesignPlanningTaskTemplates.FindAsync(id);
        if (item == null) return NotFound();
        await LoadProjectTypes(item.ProjectTypeId);
        return View(item);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, TaskTemplate template)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        if (id != template.Id) return NotFound();
        if (!ModelState.IsValid)
        {
            await LoadProjectTypes(template.ProjectTypeId);
            return View(template);
        }

        _context.Update(template);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { projectTypeId = template.ProjectTypeId });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var item = await _context.DesignPlanningTaskTemplates.FindAsync(id);
        if (item != null)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index), new { projectTypeId = item?.ProjectTypeId });
    }

    private async Task LoadProjectTypes(Guid? selected)
    {
        ViewBag.ProjectTypes = new SelectList(await _context.DesignPlanningProjectTypes.OrderBy(x => x.Name).ToListAsync(), "Id", "Name", selected);
    }

    private async Task<bool> CanAccessPlanningAsync()
    {
        return User.IsInRole("DesignManager") || await CanManageStockCodePermissionsAsync();
    }
}
