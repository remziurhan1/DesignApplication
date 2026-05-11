using DesignPlanning.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers.DesignPlanning;

[Area("Admin")]
public class DesignPlanningEmployeesController : AdminBaseController
{
    private readonly AppDbContext _context;
    public DesignPlanningEmployeesController(AppDbContext context) => _context = context;

    public async Task<IActionResult> Index() => View(await _context.DesignPlanningEmployees.Include(x => x.Expertises).OrderBy(x => x.FullName).ToListAsync());
    public IActionResult Create() => View(new Employee { DailyCapacityHours = 8, IsActive = true });

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee)
    {
        if (!ModelState.IsValid) return View(employee);
        employee.Id = Guid.NewGuid();
        _context.DesignPlanningEmployees.Add(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var employee = await _context.DesignPlanningEmployees.Include(x => x.Expertises).FirstOrDefaultAsync(x => x.Id == id);
        return employee == null ? NotFound() : View(employee);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Employee employee)
    {
        if (id != employee.Id) return NotFound();
        if (!ModelState.IsValid) return View(employee);
        _context.Update(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var employee = await _context.DesignPlanningEmployees.FindAsync(id);
        if (employee != null)
        {
            _context.DesignPlanningEmployees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
