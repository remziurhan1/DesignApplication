using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Permissions;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class StockCodePermissionsController : DesignBaseController
    {
        private readonly AppDbContext _context;

        public StockCodePermissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!await CanManageStockCodePermissionsAsync())
            {
                return Forbid();
            }

            var employees = await _context.EmployeeProfiles
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.CanAccessDesignArea)
                .OrderByDescending(x => x.DepartmentRole.Contains("Müdür") || x.DepartmentRole.Contains("Şef"))
                .ThenBy(x => x.FullName)
                .Select(x => new StockCodePermissionItemVm
                {
                    EmployeeProfileId = x.Id,
                    FullName = x.FullName,
                    DepartmentRole = x.DepartmentRole,
                    Title = x.Title,
                    Email = x.Email,
                    CanCreateStockCodes = x.CanCreateStockCodes,
                    CanEditStockCodes = x.CanEditStockCodes,
                    CanManageStockCodeDefinitions = x.CanManageStockCodeDefinitions,
                    CanAccessMaterialGroups = x.CanAccessMaterialGroups,
                    CanManageMaterials = x.CanManageMaterials
                })
                .ToListAsync();

            return View(new StockCodePermissionListVm { Employees = employees });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StockCodePermissionUpdateVm vm)
        {
            if (!await CanManageStockCodePermissionsAsync())
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var profile = await _context.EmployeeProfiles
                .FirstOrDefaultAsync(x => x.Id == vm.EmployeeProfileId && x.Status != Status.Deleted && x.CanAccessDesignArea);
            if (profile == null)
            {
                return NotFound();
            }

            profile.CanCreateStockCodes = vm.CanCreateStockCodes;
            profile.CanEditStockCodes = vm.CanEditStockCodes;
            profile.CanManageStockCodeDefinitions = vm.CanManageStockCodeDefinitions;
            profile.CanAccessMaterialGroups = vm.CanAccessMaterialGroups;
            profile.CanManageMaterials = vm.CanManageMaterials;
            profile.ModifiedBy = User?.Identity?.Name ?? "DesignManager";
            profile.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"{profile.FullName} için stok kodu yetkileri güncellendi.";

            return RedirectToAction(nameof(Index));
        }
    }
}
