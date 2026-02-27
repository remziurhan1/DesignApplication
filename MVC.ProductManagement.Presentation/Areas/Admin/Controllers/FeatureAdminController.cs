using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.FeatureAdmin;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureAdminController : Controller
    {
        private readonly AppDbContext _db;

        public FeatureAdminController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string groupCode = "SA")
        {
            groupCode = groupCode.ToUpperInvariant();
            var featurePrefix = GetFeaturePrefix(groupCode);

            var features = await _db.Set<SFeature>()
                .AsNoTracking()
                .Include(f => f.Values)
                .Where(f => f.Code.StartsWith(featurePrefix) || (groupCode is "SA" or "SB" && BasicStandardCodes.Contains(f.Code)))
                .OrderBy(f => f.SortOrder)
                .Select(f => new FeatureItemVm
                {
                    Id = f.Id,
                    Code = f.Code,
                    Name = f.Name,
                    SortOrder = f.SortOrder,
                    Values = f.Values.OrderBy(v => v.SortOrder).Select(v => new FeatureValueItemVm
                    {
                        Id = v.Id,
                        Code = v.Code,
                        Name = v.Name,
                        SortOrder = v.SortOrder
                    }).ToList()
                })
                .ToListAsync();

            return View(new FeatureAdminVm { GroupCode = groupCode, Features = features });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeature(FeatureCreateVm vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Code) || string.IsNullOrWhiteSpace(vm.Name))
            {
                TempData["ErrorMessage"] = "Feature kodu ve adı zorunludur.";
                return RedirectToAction(nameof(Index), new { groupCode = vm.GroupCode });
            }

            var code = vm.Code.Trim().ToUpperInvariant();
            var exists = await _db.Set<SFeature>().AnyAsync(f => f.Code == code);
            if (exists)
            {
                TempData["ErrorMessage"] = "Bu feature kodu zaten var.";
                return RedirectToAction(nameof(Index), new { groupCode = vm.GroupCode });
            }

            _db.Set<SFeature>().Add(new SFeature
            {
                Id = SeedId.From($"SFeature:{code}"),
                Code = code,
                Name = vm.Name.Trim(),
                SortOrder = vm.SortOrder,
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.UtcNow,
                Status = Domain.Enums.Status.Added
            });

            await _db.SaveChangesAsync();
            TempData["SuccessMessage"] = "Feature eklendi.";
            return RedirectToAction(nameof(Index), new { groupCode = vm.GroupCode });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFeature(Guid featureId, string groupCode, string name, int sortOrder)
        {
            var feature = await _db.Set<SFeature>().FirstOrDefaultAsync(f => f.Id == featureId);
            if (feature == null)
            {
                TempData["ErrorMessage"] = "Feature bulunamadı.";
                return RedirectToAction(nameof(Index), new { groupCode });
            }

            feature.Name = name.Trim();
            feature.SortOrder = sortOrder;
            feature.ModifiedBy = "ADMIN";
            feature.ModifiedDate = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            TempData["SuccessMessage"] = "Feature güncellendi.";
            return RedirectToAction(nameof(Index), new { groupCode });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateValue(FeatureValueCreateVm vm)
        {
            var feature = await _db.Set<SFeature>().FirstOrDefaultAsync(f => f.Id == vm.FeatureId);
            if (feature == null)
            {
                TempData["ErrorMessage"] = "Feature bulunamadı.";
                return RedirectToAction(nameof(Index), new { groupCode = vm.GroupCode });
            }

            var code = vm.Code.Trim();
            var exists = await _db.Set<SFeatureValue>().AnyAsync(v => v.SFeatureId == vm.FeatureId && v.Code == code);
            if (exists)
            {
                TempData["ErrorMessage"] = "Bu değer zaten var.";
                return RedirectToAction(nameof(Index), new { groupCode = vm.GroupCode });
            }

            _db.Set<SFeatureValue>().Add(new SFeatureValue
            {
                Id = SeedId.From($"SFeatureValue:{feature.Code}:{code}"),
                SFeatureId = vm.FeatureId,
                Code = code,
                Name = vm.Name.Trim(),
                SortOrder = vm.SortOrder,
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.UtcNow,
                Status = Domain.Enums.Status.Added
            });

            await _db.SaveChangesAsync();
            TempData["SuccessMessage"] = "Feature değeri eklendi.";
            return RedirectToAction(nameof(Index), new { groupCode = vm.GroupCode });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateValue(Guid valueId, string groupCode, string name, int sortOrder)
        {
            var value = await _db.Set<SFeatureValue>().FirstOrDefaultAsync(v => v.Id == valueId);
            if (value == null)
            {
                TempData["ErrorMessage"] = "Feature değeri bulunamadı.";
                return RedirectToAction(nameof(Index), new { groupCode });
            }

            value.Name = name.Trim();
            value.SortOrder = sortOrder;
            value.ModifiedBy = "ADMIN";
            value.ModifiedDate = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            TempData["SuccessMessage"] = "Feature değeri güncellendi.";
            return RedirectToAction(nameof(Index), new { groupCode });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteValue(Guid valueId, string groupCode)
        {
            var value = await _db.Set<SFeatureValue>().FirstOrDefaultAsync(v => v.Id == valueId);
            if (value != null)
            {
                _db.Set<SFeatureValue>().Remove(value);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Feature değeri silindi.";
            }

            return RedirectToAction(nameof(Index), new { groupCode });
        }

        private static readonly HashSet<string> BasicStandardCodes = new()
        {
            "MATERIAL","THREAD_SYSTEM","STANDARD","METRIC","LENGTH","STRENGTH","COATING","HEAD_TYPE","PRODUCT_TYPE","WASHER_TYPE"
        };

        private static string GetFeaturePrefix(string groupCode) => groupCode switch
        {
            "SF" => "SF_",
            "SC" => "SC_",
            _ => string.Empty
        };
    }
}
