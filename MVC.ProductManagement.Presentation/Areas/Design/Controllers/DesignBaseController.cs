using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Controllers;
using System.Security.Claims;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    [Area("Design")]
    [Authorize(Roles = "DesignEngineer,DesignManager,Admin")]
    public abstract class DesignBaseController : BaseController
    {

        protected async Task<bool> CanManageStockCodeDefinitionsAsync()
        {
            return await HasDesignPermissionAsync(x => x.CanManageStockCodeDefinitions);
        }

        protected async Task<bool> CanManageStockCodePermissionsAsync()
        {
            if (User.IsInRole("Admin") || User.IsInRole("DesignManager"))
            {
                return true;
            }

            var profile = await GetCurrentEmployeeProfileAsync();
            return profile != null
                   && profile.CanAccessDesignArea
                   && (profile.DepartmentRole.Contains("Müdür", StringComparison.OrdinalIgnoreCase)
                       || profile.DepartmentRole.Contains("Mudur", StringComparison.OrdinalIgnoreCase));
        }

        protected async Task<Domain.Entities.EmployeeProfile?> GetCurrentEmployeeProfileAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }

            var context = HttpContext.RequestServices.GetRequiredService<AppDbContext>();
            return await context.EmployeeProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        protected async Task<bool> HasDesignPermissionAsync(Func<Domain.Entities.EmployeeProfile, bool> permissionSelector)
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }

            var profile = await GetCurrentEmployeeProfileAsync();
            return profile != null && permissionSelector(profile);
        }
    }
}
