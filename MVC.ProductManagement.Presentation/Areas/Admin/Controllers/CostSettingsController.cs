using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.Costing;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.CostSettingsVMs;
using System.Globalization;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CostSettingsController : AdminBaseController
    {
        private readonly AppDbContext _context;

        public CostSettingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await BuildVmAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLaborRate([Bind(Prefix = "NewLaborRate")] LaborRateInputVM model)
        {
            ApplyLocalizedDouble("NewLaborRate.HourlyRate", nameof(model.HourlyRate), value => model.HourlyRate = value);

            if (!ModelState.IsValid)
            {
                return View("Index", await BuildVmAsync(model));
            }

            _context.LaborRates.Add(new LaborRate
            {
                Name = BuildLaborRateName(model),
                HourlyRate = model.HourlyRate,
                Notes = model.Notes?.Trim() ?? string.Empty
            });
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "İşçilik birim fiyatı kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLaborRate(LaborRateInputVM model)
        {
            ApplyLocalizedDouble(nameof(model.HourlyRate), nameof(model.HourlyRate), value => model.HourlyRate = value);

            var entity = await _context.LaborRates.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null) return RedirectToAction(nameof(Index));
            entity.Name = BuildLaborRateName(model);
            entity.HourlyRate = model.HourlyRate;
            entity.Notes = model.Notes?.Trim() ?? string.Empty;
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "İşçilik birim fiyatı güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLaborRate(Guid id)
        {
            var entity = await _context.LaborRates.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.LaborRates.Remove(entity);
                await _context.SaveChangesAsync();
                TempData["CostSettingsMessage"] = "İşçilik birim fiyatı silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGugHourlyRate([Bind(Prefix = "NewGugHourlyRate")] GugHourlyRateInputVM model)
        {
            ApplyLocalizedDouble("NewGugHourlyRate.HourlyRate", nameof(model.HourlyRate), value => model.HourlyRate = value);

            if (!ModelState.IsValid)
            {
                return View("Index", await BuildVmAsync(gug: model));
            }

            _context.GugHourlyRates.Add(new GugHourlyRate
            {
                Name = BuildGugRateName(model),
                HourlyRate = model.HourlyRate,
                Notes = model.Notes?.Trim() ?? string.Empty
            });
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "GÜG birim fiyatı kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateGugHourlyRate(GugHourlyRateInputVM model)
        {
            ApplyLocalizedDouble(nameof(model.HourlyRate), nameof(model.HourlyRate), value => model.HourlyRate = value);

            var entity = await _context.GugHourlyRates.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null) return RedirectToAction(nameof(Index));
            entity.Name = BuildGugRateName(model);
            entity.HourlyRate = model.HourlyRate;
            entity.Notes = model.Notes?.Trim() ?? string.Empty;
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "GÜG birim fiyatı güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGugHourlyRate(Guid id)
        {
            var entity = await _context.GugHourlyRates.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.GugHourlyRates.Remove(entity);
                await _context.SaveChangesAsync();
                TempData["CostSettingsMessage"] = "GÜG birim fiyatı silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBombeLaborRate([Bind(Prefix = "NewBombeLaborRate")] BombeLaborRateInputVM model)
        {
            ApplyLocalizedDouble("NewBombeLaborRate.RatePerKg", nameof(model.RatePerKg), value => model.RatePerKg = value);

            if (!ModelState.IsValid)
            {
                return View("Index", await BuildVmAsync(bombe: model));
            }

            _context.BombeLaborRates.Add(new BombeLaborRate
            {
                Name = BuildBombeRateName(model),
                MaterialType = model.MaterialType.Trim(),
                RatePerKg = model.RatePerKg,
                Notes = model.Notes?.Trim() ?? string.Empty
            });
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "Bombe birim fiyatı kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBombeLaborRate(BombeLaborRateInputVM model)
        {
            ApplyLocalizedDouble(nameof(model.RatePerKg), nameof(model.RatePerKg), value => model.RatePerKg = value);

            var entity = await _context.BombeLaborRates.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null) return RedirectToAction(nameof(Index));
            entity.Name = BuildBombeRateName(model);
            entity.MaterialType = model.MaterialType.Trim();
            entity.RatePerKg = model.RatePerKg;
            entity.Notes = model.Notes?.Trim() ?? string.Empty;
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "Bombe birim fiyatı güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBombeLaborRate(Guid id)
        {
            var entity = await _context.BombeLaborRates.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.BombeLaborRates.Remove(entity);
                await _context.SaveChangesAsync();
                TempData["CostSettingsMessage"] = "Bombe birim fiyatı silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOverheadRate([Bind(Prefix = "NewOverheadRate")] OverheadRateInputVM model)
        {
            ApplyLocalizedDouble("NewOverheadRate.Percentage", nameof(model.Percentage), value => model.Percentage = value);

            if (!ModelState.IsValid)
            {
                return View("Index", await BuildVmAsync(overhead: model));
            }

            _context.OverheadRates.Add(new OverheadRate
            {
                Name = BuildOverheadRateName(model),
                OverheadType = model.OverheadType.Trim(),
                Percentage = model.Percentage,
                Notes = model.Notes?.Trim() ?? string.Empty
            });
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "Gider oranı kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOverheadRate(OverheadRateInputVM model)
        {
            ApplyLocalizedDouble(nameof(model.Percentage), nameof(model.Percentage), value => model.Percentage = value);

            var entity = await _context.OverheadRates.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null) return RedirectToAction(nameof(Index));
            entity.Name = BuildOverheadRateName(model);
            entity.OverheadType = model.OverheadType.Trim();
            entity.Percentage = model.Percentage;
            entity.Notes = model.Notes?.Trim() ?? string.Empty;
            await _context.SaveChangesAsync();
            TempData["CostSettingsMessage"] = "Gider oranı güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOverheadRate(Guid id)
        {
            var entity = await _context.OverheadRates.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.OverheadRates.Remove(entity);
                await _context.SaveChangesAsync();
                TempData["CostSettingsMessage"] = "Gider oranı silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<CostSettingsIndexVM> BuildVmAsync(
            LaborRateInputVM? labor = null,
            GugHourlyRateInputVM? gug = null,
            BombeLaborRateInputVM? bombe = null,
            OverheadRateInputVM? overhead = null)
        {
            return new CostSettingsIndexVM
            {
                LaborRates = await _context.LaborRates.AsNoTracking().Where(x => x.Status != Domain.Enums.Status.Deleted).OrderBy(x => x.HourlyRate).ThenBy(x => x.Name).ToListAsync(),
                GugHourlyRates = await _context.GugHourlyRates.AsNoTracking().Where(x => x.Status != Domain.Enums.Status.Deleted).OrderBy(x => x.HourlyRate).ThenBy(x => x.Name).ToListAsync(),
                BombeLaborRates = await _context.BombeLaborRates.AsNoTracking().Where(x => x.Status != Domain.Enums.Status.Deleted).OrderBy(x => x.MaterialType).ThenBy(x => x.RatePerKg).ToListAsync(),
                OverheadRates = await _context.OverheadRates.AsNoTracking().Where(x => x.Status != Domain.Enums.Status.Deleted).OrderBy(x => x.OverheadType).ThenBy(x => x.Percentage).ToListAsync(),
                NewLaborRate = labor ?? new LaborRateInputVM(),
                NewGugHourlyRate = gug ?? new GugHourlyRateInputVM(),
                NewBombeLaborRate = bombe ?? new BombeLaborRateInputVM { MaterialType = "Paslanmaz" },
                NewOverheadRate = overhead ?? new OverheadRateInputVM { OverheadType = "Finance" }
            };
        }

        private static string BuildLaborRateName(LaborRateInputVM model)
            => !string.IsNullOrWhiteSpace(model.Name)
                ? model.Name.Trim()
                : $"İşçilik {FormatNumber(model.HourlyRate)} TL/Saat";

        private static string BuildGugRateName(GugHourlyRateInputVM model)
            => !string.IsNullOrWhiteSpace(model.Name)
                ? model.Name.Trim()
                : $"GÜG {FormatNumber(model.HourlyRate)} TL/Saat";

        private static string BuildBombeRateName(BombeLaborRateInputVM model)
            => !string.IsNullOrWhiteSpace(model.Name)
                ? model.Name.Trim()
                : $"{model.MaterialType.Trim()} Bombe {FormatNumber(model.RatePerKg)} TL/Kg";

        private static string BuildOverheadRateName(OverheadRateInputVM model)
        {
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                return model.Name.Trim();
            }

            var overheadLabel = string.Equals(model.OverheadType, "GeneralManagement", StringComparison.OrdinalIgnoreCase)
                ? "Genel Yönetim"
                : "Finans";

            return $"{overheadLabel} %{FormatNumber(model.Percentage)}";
        }

        private void ApplyLocalizedDouble(string formKey, string modelStateKey, Action<double> setter)
        {
            var value = ReadLocalizedDoubleFromForm(formKey);
            if (!value.HasValue)
            {
                return;
            }

            setter(value.Value);
            ModelState.Remove(modelStateKey);
        }

        private double? ReadLocalizedDoubleFromForm(string key)
        {
            if (!Request.HasFormContentType)
            {
                return null;
            }

            var rawValue = Request.Form[key].ToString();
            if (string.IsNullOrWhiteSpace(rawValue))
            {
                return null;
            }

            var normalized = rawValue.Trim().Replace(" ", string.Empty);
            var commaIndex = normalized.LastIndexOf(',');
            var dotIndex = normalized.LastIndexOf('.');

            if (commaIndex >= 0 && dotIndex >= 0)
            {
                normalized = commaIndex > dotIndex
                    ? normalized.Replace(".", string.Empty).Replace(',', '.')
                    : normalized.Replace(",", string.Empty);
            }
            else
            {
                normalized = normalized.Replace(',', '.');
            }

            return double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed)
                ? parsed
                : null;
        }

        private static string FormatNumber(double value) => value.ToString("N2", CultureInfo.GetCultureInfo("tr-TR"));
    }
}
