using DesignPlanning.Business;
using DesignPlanning.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Design.Controllers;
using TaskStatus = DesignPlanning.Entities.TaskStatus;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers.DesignPlanning;

[Area("Design")]
public class DesignPlanningProjectsController : DesignBaseController
{
    private readonly AppDbContext _context;
    private readonly IPlanningService _planningService;

    public DesignPlanningProjectsController(AppDbContext context, IPlanningService planningService)
    {
        _context = context;
        _planningService = planningService;
    }

    public async Task<IActionResult> Index()
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        return View(await _context.DesignPlanningProjects.Include(x => x.ProjectType).OrderByDescending(x => x.StartDate).ThenBy(x => x.ProjectCode).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        await LoadProjectTypes(null);
        return View(new Project { StartDate = DateTime.Today, Priority = 1, Status = ProjectStatus.Waiting });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Project project)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        if (!ModelState.IsValid)
        {
            await LoadProjectTypes(project.ProjectTypeId);
            return View(project);
        }

        project.Id = Guid.NewGuid();
        project.Status = ProjectStatus.Waiting;
        _context.Add(project);
        await _context.SaveChangesAsync();
        await _planningService.GenerateProjectTasksAsync(project.Id);
        await _planningService.AutoAssignAndPlanAsync(project.Id);
        return RedirectToAction(nameof(Details), new { id = project.Id });
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var project = await _context.DesignPlanningProjects.FindAsync(id);
        if (project == null) return NotFound();
        await LoadProjectTypes(project.ProjectTypeId);
        return View(project);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Project project)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        if (id != project.Id) return NotFound();
        if (!ModelState.IsValid)
        {
            await LoadProjectTypes(project.ProjectTypeId);
            return View(project);
        }

        _context.Update(project);
        await _context.SaveChangesAsync();
        await _planningService.AutoAssignAndPlanAsync(project.Id);
        return RedirectToAction(nameof(Details), new { id = project.Id });
    }

    public async Task<IActionResult> Details(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var project = await _context.DesignPlanningProjects
            .Include(x => x.ProjectType)
            .Include(x => x.Tasks.OrderBy(t => t.SequenceNo)).ThenInclude(x => x.AssignedEmployee)
            .FirstOrDefaultAsync(x => x.Id == id);
        return project == null ? NotFound() : View(project);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Plan(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        await _planningService.AutoAssignAndPlanAsync(id);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CompleteTask(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var task = await _context.DesignPlanningProjectTasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (task == null) return NotFound();
        await _planningService.CompleteTaskAsync(id);
        return RedirectToAction(nameof(Details), new { id = task.ProjectId });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await CanAccessPlanningAsync()) return Forbid();

        var project = await _context.DesignPlanningProjects.FindAsync(id);
        if (project != null)
        {
            _context.Remove(project);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
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
