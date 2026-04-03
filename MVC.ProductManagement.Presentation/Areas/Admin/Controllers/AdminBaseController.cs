using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Controllers;
using System.Security.Claims;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,DesignEngineer,DesignManager")]
    public class AdminBaseController : BaseController
    {
        protected async Task<bool> HasDesignPermissionAsync(Func<Domain.Entities.EmployeeProfile, bool> permissionSelector)
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
    }
}
