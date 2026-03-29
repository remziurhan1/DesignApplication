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
            var en13458CountTask = _context.EN13458Calculations.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var ad2000CountTask = _context.AD2000Calculations.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var materialCountTask = _context.Materials.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var materialFormCountTask = _context.MaterialForms.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var yieldStrengthCountTask = _context.YieldStrengths.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var allowableStressCountTask = _context.AllowableStresses.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var storageTypeCountTask = _context.StorageTypes.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);
            var thermodynamicPropertyCountTask = _context.ThermodynamicProperties.AsNoTracking().CountAsync(x => x.Status != Status.Deleted);

            await Task.WhenAll(
                en13458CountTask,
                ad2000CountTask,
                materialCountTask,
                materialFormCountTask,
                yieldStrengthCountTask,
                allowableStressCountTask,
                storageTypeCountTask,
                thermodynamicPropertyCountTask);

            var vm = new TechnicalDashboardVm
            {
                En13458CalculationCount = en13458CountTask.Result,
                Ad2000CalculationCount = ad2000CountTask.Result,
                MaterialCount = materialCountTask.Result,
                MaterialFormCount = materialFormCountTask.Result,
                YieldStrengthCount = yieldStrengthCountTask.Result,
                AllowableStressCount = allowableStressCountTask.Result,
                StorageTypeCount = storageTypeCountTask.Result,
                ThermodynamicPropertyCount = thermodynamicPropertyCountTask.Result
            };

            return View(vm);
        }
    }
}
