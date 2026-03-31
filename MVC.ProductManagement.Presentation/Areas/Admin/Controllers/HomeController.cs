using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.Home;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : AdminBaseController
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new TechnicalDashboardVm
            {
                En13458CalculationCount = await _context.EN13458Calculations
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                Ad2000CalculationCount = await _context.AD2000Calculations
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                MaterialCount = await _context.Materials
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                CustomerCount = await _context.Customers
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                ActiveSalesRequestCount = await _context.SalesRequests
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted)
            };

            vm.RecentActivities = await BuildRecentActivitiesAsync();

            return View(vm);
        }

        private async Task<List<TechnicalActivityVm>> BuildRecentActivitiesAsync()
        {
            var activities = new List<TechnicalActivityVm>();

            var recentEn = await _context.EN13458Calculations
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                .Take(5)
                .Select(x => new TechnicalActivityVm
                {
                    Title = $"EN13458 hesap güncellendi: {x.Name}",
                    Date = x.ModifiedDate ?? x.CreatedDate
                })
                .ToListAsync();

            var recentAd = await _context.AD2000Calculations
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                .Take(5)
                .Select(x => new TechnicalActivityVm
                {
                    Title = $"AD2000 hesap güncellendi: {x.Name}",
                    Date = x.ModifiedDate ?? x.CreatedDate
                })
                .ToListAsync();

            var recentRequests = await _context.SalesRequests
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                .Take(5)
                .Select(x => new TechnicalActivityVm
                {
                    Title = $"Talep güncellendi: {x.RequestNo}",
                    Date = x.ModifiedDate ?? x.CreatedDate
                })
                .ToListAsync();

            activities.AddRange(recentEn);
            activities.AddRange(recentAd);
            activities.AddRange(recentRequests);

            return activities
                .OrderByDescending(x => x.Date)
                .Take(10)
                .ToList();
        }
    }
}
