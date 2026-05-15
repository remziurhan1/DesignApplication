using DesignPlanning.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Design.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers.DesignPlanning;

[Area("Design")]
public class DesignPlanningProjectTypesController : DesignBaseController
{
    private readonly AppDbContext _context;

    public DesignPlanningProjectTypesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        return View(await _context.DesignPlanningProjectTypes.OrderBy(x => x.Name).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        return View(new ProjectType());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectType projectType)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        if (!ModelState.IsValid) return View(projectType);
        projectType.Id = Guid.NewGuid();
        _context.Add(projectType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var item = await _context.DesignPlanningProjectTypes.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ProjectType projectType)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        if (id != projectType.Id) return NotFound();
        if (!ModelState.IsValid) return View(projectType);
        _context.Update(projectType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var item = await _context.DesignPlanningProjectTypes.FindAsync(id);
        if (item != null)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> CanAccessPlanningAsync()
    {
        return User.IsInRole("DesignManager") || await CanManageStockCodePermissionsAsync();
    }
}
