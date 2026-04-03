using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Design.Models;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class CatalogController : DesignBaseController
    {
        private readonly AppDbContext _context;

        public CatalogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessDesignArea || x.CanAccessMaterialGroups))
            {
                return Forbid();
            }

            var vm = new DesignCatalogVm
            {
                Materials = await _context.Materials
                    .AsNoTracking()
                    .Where(x => x.Status != Status.Deleted)
                    .OrderBy(x => x.Name)
                    .Take(100)
                    .Select(x => new DesignSimpleLookupVm
                    {
                        Name = x.Name,
                        Description = $"{x.Standard} · {x.Group}"
                    }).ToListAsync(),

                MaterialForms = await _context.MaterialForms
                    .AsNoTracking()
                    .Include(x => x.Material)
                    .Where(x => x.Status != Status.Deleted)
                    .OrderBy(x => x.Material.Name)
                    .ThenBy(x => x.FormType)
                    .Take(100)
                    .Select(x => new DesignSimpleLookupVm
                    {
                        Name = $"{x.Material.Name} - {x.FormType}",
                        Description = $"{x.ThicknessMin:N1} - {x.ThicknessMax:N1} mm"
                    }).ToListAsync(),

                YieldStrengths = await _context.YieldStrengths
                    .AsNoTracking()
                    .Include(x => x.MaterialForm)
                        .ThenInclude(x => x.Material)
                    .Where(x => x.Status != Status.Deleted)
                    .OrderByDescending(x => x.Temperature)
                    .Take(100)
                    .Select(x => new DesignYieldStrengthVm
                    {
                        MaterialForm = x.MaterialForm.Material.Name + " - " + x.MaterialForm.FormType,
                        Temperature = x.Temperature,
                        Rp02 = x.Rp02,
                        Rm = x.Rm
                    }).ToListAsync(),

                StorageTypes = await _context.StorageTypes
                    .AsNoTracking()
                    .Where(x => x.Status != Status.Deleted)
                    .OrderBy(x => x.Name)
                    .Select(x => new DesignSimpleLookupVm
                    {
                        Name = x.Name,
                        Description = x.Description
                    }).ToListAsync(),

                Calculations = await BuildCalculationListAsync(),
                StockGroups = await BuildStockGroupsAsync()
            };

            return View(vm);
        }

        private async Task<List<DesignSimpleLookupVm>> BuildCalculationListAsync()
        {
            var en = await _context.EN13458Calculations
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                .Take(25)
                .Select(x => new DesignSimpleLookupVm
                {
                    Name = $"EN13458 - {x.Name}",
                    Description = $"P={x.DesignPressure:N2} bar / Test={x.TestPressure:N2} bar"
                })
                .ToListAsync();

            var ad = await _context.AD2000Calculations
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                .Take(25)
                .Select(x => new DesignSimpleLookupVm
                {
                    Name = $"AD2000 - {x.Name}",
                    Description = $"P={x.DesignPressure:N2} bar / Test={x.TestPressure:N2} bar"
                })
                .ToListAsync();

            return en.Concat(ad).OrderBy(x => x.Name).ToList();
        }

        private async Task<List<DesignStockGroupVm>> BuildStockGroupsAsync()
        {
            return await _context.StockProductGroups
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .Include(x => x.Items)
                    .ThenInclude(x => x.GeneratedStockCode)
                .OrderBy(x => x.Name)
                .Take(25)
                .Select(x => new DesignStockGroupVm
                {
                    GroupName = x.Name,
                    Codes = x.Items
                        .OrderBy(i => i.GeneratedStockCode.GeneratedCode)
                        .Select(i => i.GeneratedStockCode.GeneratedCode)
                        .Take(20)
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
