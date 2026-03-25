using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Controllers;
using System.Security.Claims;

namespace MVC.ProductManagement.Presentation.Areas.Sales.Controllers
{
    [Area("Sales")]
    [Authorize(Roles = "Sales,Admin")]
    public abstract class SalesBaseController : BaseController
    {
        protected async Task<bool> CanAccessSalesManagerPanelAsync()
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }

            var profile = await GetCurrentSalesProfileAsync();
            if (profile == null || !profile.CanViewSalesPricing)
            {
                return false;
            }

            return HasManagerTitle(profile);
        }

        private static bool HasManagerTitle(Domain.Entities.EmployeeProfile profile)
        {
            return (!string.IsNullOrWhiteSpace(profile.DepartmentRole)
                    && (profile.DepartmentRole.Contains("müdür", StringComparison.OrdinalIgnoreCase)
                        || profile.DepartmentRole.Contains("manager", StringComparison.OrdinalIgnoreCase)))
                   || (!string.IsNullOrWhiteSpace(profile.Title)
                       && (profile.Title.Contains("müdür", StringComparison.OrdinalIgnoreCase)
                           || profile.Title.Contains("manager", StringComparison.OrdinalIgnoreCase)));
        }

        protected async Task<bool> HasSalesPermissionAsync(Func<Domain.Entities.EmployeeProfile, bool> permissionSelector)
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            var context = HttpContext.RequestServices.GetRequiredService<AppDbContext>();
            var profile = await context.EmployeeProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
            return profile != null && permissionSelector(profile);
        }

        protected async Task<Domain.Entities.EmployeeProfile?> GetCurrentSalesProfileAsync()
        {
            if (User.IsInRole("Admin"))
            {
                return null;
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }

            var context = HttpContext.RequestServices.GetRequiredService<AppDbContext>();
            return await context.EmployeeProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
