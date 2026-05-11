using DesignPlanning.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers.DesignPlanning;

[Area("Admin")]
public class DesignPlanningTaskTemplatesController : AdminBaseController
{
    private readonly AppDbContext _context;
    public DesignPlanningTaskTemplatesController(AppDbContext context) => _context = context;

    public async Task<IActionResult> Index(Guid? projectTypeId)
    {
        await LoadProjectTypes(projectTypeId);
        var query = _context.DesignPlanningTaskTemplates.Include(x => x.ProjectType).AsQueryable();
        if (projectTypeId.HasValue) query = query.Where(x => x.ProjectTypeId == projectTypeId.Value);
        return View(await query.OrderBy(x => x.ProjectType!.Name).ThenBy(x => x.SequenceNo).ToListAsync());
    }

    public async Task<IActionResult> Create() { await LoadProjectTypes(null); return View(new TaskTemplate { IsActive = true, DurationUnit = DurationUnit.Hour }); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskTemplate template)
    {
        if (!ModelState.IsValid) { await LoadProjectTypes(template.ProjectTypeId); return View(template); }
        template.Id = Guid.NewGuid();
        _context.Add(template);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { projectTypeId = template.ProjectTypeId });
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await _context.DesignPlanningTaskTemplates.FindAsync(id);
        if (item == null) return NotFound();
        await LoadProjectTypes(item.ProjectTypeId);
        return View(item);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, TaskTemplate template)
    {
        if (id != template.Id) return NotFound();
        if (!ModelState.IsValid) { await LoadProjectTypes(template.ProjectTypeId); return View(template); }
        _context.Update(template);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { projectTypeId = template.ProjectTypeId });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _context.DesignPlanningTaskTemplates.FindAsync(id);
        if (item != null) { _context.Remove(item); await _context.SaveChangesAsync(); }
        return RedirectToAction(nameof(Index), new { projectTypeId = item?.ProjectTypeId });
    }

    private async Task LoadProjectTypes(Guid? selected) => ViewBag.ProjectTypes = new SelectList(await _context.DesignPlanningProjectTypes.OrderBy(x => x.Name).ToListAsync(), "Id", "Name", selected);
}
