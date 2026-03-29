using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.Home;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
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
                MaterialFormCount = await _context.MaterialForms
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                YieldStrengthCount = await _context.YieldStrengths
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                AllowableStressCount = await _context.AllowableStresses
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                StorageTypeCount = await _context.StorageTypes
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted),
                ThermodynamicPropertyCount = await _context.ThermodynamicProperties
                    .AsNoTracking()
                    .CountAsync(x => x.Status != Status.Deleted)
            };

            return View(vm);
        }
    }
}
