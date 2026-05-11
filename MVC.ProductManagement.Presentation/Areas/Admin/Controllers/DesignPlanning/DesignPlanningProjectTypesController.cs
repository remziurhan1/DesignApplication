using DesignPlanning.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers.DesignPlanning;

[Area("Admin")]
public class DesignPlanningProjectTypesController : AdminBaseController
{
    private readonly AppDbContext _context;
    public DesignPlanningProjectTypesController(AppDbContext context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.DesignPlanningProjectTypes.OrderBy(x => x.Name).ToListAsync());
    public IActionResult Create() => View(new ProjectType());
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectType projectType) { if (!ModelState.IsValid) return View(projectType); projectType.Id = Guid.NewGuid(); _context.Add(projectType); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(Guid id) { var item = await _context.DesignPlanningProjectTypes.FindAsync(id); return item == null ? NotFound() : View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ProjectType projectType) { if (id != projectType.Id) return NotFound(); if (!ModelState.IsValid) return View(projectType); _context.Update(projectType); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id) { var item = await _context.DesignPlanningProjectTypes.FindAsync(id); if (item != null) { _context.Remove(item); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}
