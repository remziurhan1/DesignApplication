using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.AD2000CalculationServices;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.AD2000CalculationVMs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class AD2000CalculationController : AdminBaseController
    {
        private readonly IAD2000CalculationService _calculationService;
        private readonly IMaterialService _materialService;
        private readonly IMaterialFormService _materialFormService;
        private readonly IYieldStrengthService _yieldStrengthService;
        private readonly IStorageTypeService _storageTypeService;
        private readonly IGeneratedStockCodeService _generatedStockCodeService;
        private readonly IStockProductGroupService _stockProductGroupService;
        private readonly AppDbContext _context;

        public AD2000CalculationController(
            IAD2000CalculationService calculationService,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IYieldStrengthService yieldStrengthService,
            IStorageTypeService storageTypeService,
            IGeneratedStockCodeService generatedStockCodeService,
            IStockProductGroupService stockProductGroupService,
            AppDbContext context)
        {
            _calculationService = calculationService;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _yieldStrengthService = yieldStrengthService;
            _storageTypeService = storageTypeService;
            _generatedStockCodeService = generatedStockCodeService;
            _stockProductGroupService = stockProductGroupService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _calculationService.GetAllAsync() ?? new List<AD2000ResultDTO>();
            var vm = list.Select(x => new AD2000ListVM
            {
                Id = x.Id,
                Name = x.Name,
                DesignPressure = x.DesignPressure,
                RoundedShellThickness = x.RoundedShellThickness,
                RoundedHeadThickness = x.RoundedHeadThickness
            }).ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var calculation = await _context.AD2000Calculations
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);

            if (calculation == null)
            {
                return NotFound();
            }

            var costAnalyses = await _context.AD2000CostAnalyses
                .Where(x => x.AD2000CalculationId == id && x.Status != Status.Deleted)
                .ToListAsync();

            var costAnalysisIds = costAnalyses.Select(x => x.Id).ToList();

            var costItems = await _context.AD2000CostAnalysisItems
                .Where(x => costAnalysisIds.Contains(x.AD2000CostAnalysisId) && x.Status != Status.Deleted)
                .ToListAsync();

            var salesPrices = await _context.AD2000SalesPrices
                .Where(x => x.AD2000CalculationId == id && x.Status != Status.Deleted)
                .ToListAsync();

            _context.AD2000CostAnalysisItems.RemoveRange(costItems);
            _context.AD2000SalesPrices.RemoveRange(salesPrices);
            _context.AD2000CostAnalyses.RemoveRange(costAnalyses);
            _context.AD2000Calculations.Remove(calculation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, string mode = "manager")
        {
            var dto = await _calculationService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapResultVm(dto);
            await PopulateDisplayNamesAsync(vm);
            ViewBag.IsSalesView = string.Equals(mode, "sales", StringComparison.OrdinalIgnoreCase);
            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cost(Guid id, Guid? costAnalysisId = null)
        {
            var dto = await _calculationService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapResultVm(dto);
            vm.SelectedCostAnalysisId = costAnalysisId;
            await PopulateDisplayNamesAsync(vm);
            await PopulateManualCostLookupsAsync(vm);
            vm.CostAnalyses = await _calculationService.GetCostAnalysesAsync(id);

            var costTable = await _calculationService.GetCostAnalysisAsync(id, costAnalysisId) ?? await _calculationService.BuildMaterialCostTableAsync(dto);
            vm.SelectedCostAnalysisId = costTable.CostAnalysisId;
            await PopulateCostParameterLookupsAsync(costTable);
            ViewBag.CostTable = costTable;

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SalesPrice(Guid id, Guid costAnalysisId)
        {
            var dto = await _calculationService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapResultVm(dto);
            vm.SelectedCostAnalysisId = costAnalysisId;
            await PopulateDisplayNamesAsync(vm);
            vm.CostAnalyses = await _calculationService.GetCostAnalysesAsync(id);

            var costTable = await _calculationService.GetCostAnalysisAsync(id, costAnalysisId);
            if (costTable == null)
            {
                TempData["ErrorMessage"] = "Önce maliyet analizi oluşturup uygulayın.";
                return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
            }

            await PopulateCostParameterLookupsAsync(costTable);
            ViewBag.CostTable = costTable;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            await LoadLookupsAsync();
            return View(new AD2000CalculateVM { TankOrientation = TankOrientation.Horizontal, IsManualDensity = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(AD2000CalculateVM vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View(vm);
            }

            if (vm.IsManualDensity)
            {
                if (vm.LiquidDensity <= 0)
                {
                    ModelState.AddModelError(nameof(vm.LiquidDensity), "Yoğunluk değeri 0'dan büyük olmalıdır.");
                }
            }
            else if (!vm.StorageTypeId.HasValue || vm.StorageTypeId.Value == Guid.Empty)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), "Tanımlı sıvı seçiniz veya manuel yoğunluk seçeneğini işaretleyiniz.");
            }
            else
            {
                try { vm.LiquidDensity = await ResolveLiquidDensityAsync(vm.StorageTypeId.Value); }
                catch (InvalidOperationException ex) { ModelState.AddModelError(nameof(vm.StorageTypeId), ex.Message); }
            }

            var shellYield = await _yieldStrengthService.GetByConditionsAsync(vm.ShellMaterialFormId, vm.DesignTemperatureMax, vm.EstimatedShellThickness);
            var headYield = await _yieldStrengthService.GetByConditionsAsync(vm.HeadMaterialFormId, vm.DesignTemperatureMax, vm.EstimatedHeadThickness);
            if (shellYield == null) ModelState.AddModelError(nameof(vm.EstimatedShellThickness), "Gövde için girilen sıcaklık/kalınlıkta akma dayanımı bulunamadı.");
            if (headYield == null) ModelState.AddModelError(nameof(vm.EstimatedHeadThickness), "Bombe için girilen sıcaklık/kalınlıkta akma dayanımı bulunamadı.");

            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View(vm);
            }

            vm.ShellAllowableStress = shellYield!.Rp02;
            vm.HeadAllowableStress = headYield!.Rp02;
            vm.AllowableStress = vm.ShellAllowableStress;

            var result = await _calculationService.CalculateAsync(new AD2000CalculateDTO
            {
                Name = vm.Name,
                Diameter = vm.Diameter,
                ShellLength = vm.ShellLength,
                DesignPressure = vm.DesignPressure,
                DesignTemperatureMin = vm.DesignTemperatureMin,
                DesignTemperatureMax = vm.DesignTemperatureMax,
                CorrosionAllowance = vm.CorrosionAllowance,
                WeldJointFactor = vm.WeldJointFactor,
                AllowableStress = vm.AllowableStress,
                ShellAllowableStress = vm.ShellAllowableStress,
                HeadAllowableStress = vm.HeadAllowableStress,
                EstimatedShellThickness = vm.EstimatedShellThickness,
                EstimatedHeadThickness = vm.EstimatedHeadThickness,
                Beta = vm.Beta,
                TankOrientation = vm.TankOrientation,
                StorageTypeId = vm.StorageTypeId,
                IsManualDensity = vm.IsManualDensity,
                LiquidDensity = vm.LiquidDensity,
                StaticPressure = vm.StaticPressure,
                ShellMaterialId = vm.ShellMaterialId,
                ShellMaterialFormId = vm.ShellMaterialFormId,
                HeadMaterialId = vm.HeadMaterialId,
                HeadMaterialFormId = vm.HeadMaterialFormId,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength3000 = vm.WeldLength3000,
                WeldLength4000 = vm.WeldLength4000,
                ShellWeldLength = vm.ShellWeldLength,
                HeadWeldLength = vm.HeadWeldLength,
                CircumferenceWeldLength = vm.CircumferenceWeldLength,
                TotalWeldLength = vm.TotalWeldLength,
                StiffenerRingWeldLength = vm.StiffenerRingWeldLength,
                WeldConsumableCost = vm.WeldConsumableCost,
                SurfaceArea = vm.SurfaceArea
            });

            var resultVm = MapResultVm(result);
            await PopulateDisplayNamesAsync(resultVm);
            return View("Result", resultVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(AD2000ResultVM vm)
        {
            var dto = new AD2000ResultDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                Diameter = vm.Diameter,
                ShellLength = vm.ShellLength,
                DesignPressure = vm.DesignPressure,
                DesignTemperatureMin = vm.DesignTemperatureMin,
                DesignTemperatureMax = vm.DesignTemperatureMax,
                CorrosionAllowance = vm.CorrosionAllowance,
                WeldJointFactor = vm.WeldJointFactor,
                AllowableStress = vm.AllowableStress,
                ShellAllowableStress = vm.ShellAllowableStress,
                HeadAllowableStress = vm.HeadAllowableStress,
                EstimatedShellThickness = vm.EstimatedShellThickness,
                EstimatedHeadThickness = vm.EstimatedHeadThickness,
                Beta = vm.Beta,
                TankOrientation = vm.TankOrientation,
                StorageTypeId = vm.StorageTypeId,
                IsManualDensity = vm.IsManualDensity,
                LiquidDensity = vm.LiquidDensity,
                StaticPressure = vm.StaticPressure,
                ShellMaterialId = vm.ShellMaterialId,
                ShellMaterialFormId = vm.ShellMaterialFormId,
                HeadMaterialId = vm.HeadMaterialId,
                HeadMaterialFormId = vm.HeadMaterialFormId,
                ShellThickness = vm.ShellThickness,
                HeadThickness = vm.HeadThickness,
                RoundedShellThickness = vm.RoundedShellThickness,
                RoundedHeadThickness = vm.RoundedHeadThickness,
                TestPressure = vm.TestPressure,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength3000 = vm.WeldLength3000,
                WeldLength4000 = vm.WeldLength4000,
                ShellWeldLength = vm.ShellWeldLength,
                HeadWeldLength = vm.HeadWeldLength,
                CircumferenceWeldLength = vm.CircumferenceWeldLength,
                TotalWeldLength = vm.TotalWeldLength,
                StiffenerRingWeldLength = vm.StiffenerRingWeldLength,
                WeldConsumableCost = vm.WeldConsumableCost,
                SurfaceArea = vm.SurfaceArea
            };

            var saved = await _calculationService.SaveAsync(dto, User?.Identity?.Name ?? "AdminUser");
            return RedirectToAction(nameof(Details), new { id = saved.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCostAnalysis(Guid id, string analysisName, string notes = "")
        {
            try
            {
                var analysis = await _calculationService.CreateCostAnalysisAsync(id, analysisName, notes, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = $"{analysis.RevisionCode} maliyet analizi oluşturuldu.";
                return RedirectToAction(nameof(Cost), new { id, costAnalysisId = analysis.CostAnalysisId });
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Cost), new { id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCostAnalysisRevision(Guid id, Guid sourceCostAnalysisId, string analysisName, string notes = "")
        {
            try
            {
                var analysis = await _calculationService.CreateCostAnalysisRevisionAsync(id, sourceCostAnalysisId, analysisName, notes, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = $"{analysis.RevisionCode} revizyonu oluşturuldu.";
                return RedirectToAction(nameof(Cost), new { id, costAnalysisId = analysis.CostAnalysisId });
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Cost), new { id, costAnalysisId = sourceCostAnalysisId });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCostItem(Guid id, Guid costAnalysisId, Guid costAnalysisItemId, Guid? generatedStockCodeId, double? quantity = null, bool useManualUnitPrice = false, double? manualUnitPrice = null)
        {
            try
            {
                manualUnitPrice = ReadLocalizedDoubleFromForm(nameof(manualUnitPrice), manualUnitPrice);
                quantity = ReadLocalizedDoubleFromForm(nameof(quantity), quantity);
                await _calculationService.UpdateCostAnalysisItemAsync(id, costAnalysisId, costAnalysisItemId, generatedStockCodeId, quantity, useManualUnitPrice, manualUnitPrice, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Maliyet kalemi güncellendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(SalesPrice), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BulkUpdateCostItems(Guid id, Guid costAnalysisId, List<AD2000CostItemBulkUpdateVM> items)
        {
            try
            {
                for (var index = 0; index < items.Count; index++)
                {
                    items[index].Quantity = ReadLocalizedDoubleFromForm($"items[{index}].Quantity", items[index].Quantity);
                    items[index].ManualUnitPrice = ReadLocalizedDoubleFromForm($"items[{index}].ManualUnitPrice", items[index].ManualUnitPrice);
                    items[index].UseManualUnitPrice = ReadBooleanFromForm($"items[{index}].UseManualUnitPrice", items[index].UseManualUnitPrice);
                }

                await _calculationService.BulkUpdateCostAnalysisItemsAsync(id, costAnalysisId,
                    items.Where(x => x.CostAnalysisItemId != Guid.Empty)
                        .Select(x => (x.CostAnalysisItemId, x.GeneratedStockCodeId, x.Quantity, x.UseManualUnitPrice, x.ManualUnitPrice))
                        .ToList(),
                    User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Maliyet kalemleri güncellendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(SalesPrice), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBombeLabor(Guid id, Guid costAnalysisId, Guid? headBombeLaborRateId)
        {
            try
            {
                await _calculationService.UpdateBombeLaborAsync(id, costAnalysisId, headBombeLaborRateId, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Bombe işçilik seçimi güncellendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(SalesPrice), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveSalesPrice(Guid id, Guid costAnalysisId, Guid laborRateId, double laborHours, Guid gugHourlyRateId, Guid financeOverheadRateId, Guid generalManagementOverheadRateId, double profitPercentage)
        {
            try
            {
                laborHours = ReadLocalizedDoubleFromForm(nameof(laborHours), laborHours) ?? laborHours;
                profitPercentage = ReadLocalizedDoubleFromForm(nameof(profitPercentage), profitPercentage) ?? profitPercentage;
                await _calculationService.UpsertSalesPriceAsync(id, costAnalysisId, laborRateId, laborHours, gugHourlyRateId, financeOverheadRateId, generalManagementOverheadRateId, profitPercentage, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Satış fiyatı hesabı kaydedildi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(SalesPrice), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStockCode(Guid id, Guid costAnalysisId, Guid generatedStockCodeId, double quantity = 1, bool useManualUnitPrice = false, double? manualUnitPrice = null)
        {
            try
            {
                quantity = ReadLocalizedDoubleFromForm(nameof(quantity), quantity) ?? quantity;
                manualUnitPrice = ReadLocalizedDoubleFromForm(nameof(manualUnitPrice), manualUnitPrice);
                await _calculationService.AddManualStockCodeCostAsync(id, costAnalysisId, generatedStockCodeId, quantity, useManualUnitPrice, manualUnitPrice, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Stok kodu maliyete eklendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStockGroup(Guid id, Guid costAnalysisId, Guid stockProductGroupId, double multiplier = 1)
        {
            try
            {
                multiplier = ReadLocalizedDoubleFromForm(nameof(multiplier), multiplier) ?? multiplier;
                await _calculationService.AddManualStockGroupCostAsync(id, costAnalysisId, stockProductGroupId, multiplier, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Stok kod grubu maliyete eklendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveCostItem(Guid id, Guid costAnalysisId, Guid costAnalysisItemId)
        {
            try
            {
                await _calculationService.RemoveCostAnalysisItemAsync(id, costAnalysisId, costAnalysisItemId);
                TempData["SuccessMessage"] = "Maliyet kalemi kaldırıldı.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        private static AD2000ResultVM MapResultVm(AD2000ResultDTO result) => new AD2000ResultVM
        {
            Id = result.Id,
            Name = result.Name,
            Diameter = result.Diameter,
            ShellLength = result.ShellLength,
            DesignPressure = result.DesignPressure,
            DesignTemperatureMin = result.DesignTemperatureMin,
            DesignTemperatureMax = result.DesignTemperatureMax,
            CorrosionAllowance = result.CorrosionAllowance,
            WeldJointFactor = result.WeldJointFactor,
            AllowableStress = result.AllowableStress,
            ShellAllowableStress = result.ShellAllowableStress,
            HeadAllowableStress = result.HeadAllowableStress,
            EstimatedShellThickness = result.EstimatedShellThickness,
            EstimatedHeadThickness = result.EstimatedHeadThickness,
            Beta = result.Beta,
            TankOrientation = result.TankOrientation,
            StorageTypeId = result.StorageTypeId,
            IsManualDensity = result.IsManualDensity,
            LiquidDensity = result.LiquidDensity,
            StaticPressure = result.StaticPressure,
            ShellMaterialId = result.ShellMaterialId,
            ShellMaterialFormId = result.ShellMaterialFormId,
            HeadMaterialId = result.HeadMaterialId,
            HeadMaterialFormId = result.HeadMaterialFormId,
            ShellThickness = result.ShellThickness,
            HeadThickness = result.HeadThickness,
            RoundedShellThickness = result.RoundedShellThickness,
            RoundedHeadThickness = result.RoundedHeadThickness,
            TestPressure = result.TestPressure,
            WeldLength1500 = result.WeldLength1500,
            WeldLength2000 = result.WeldLength2000,
            WeldLength3000 = result.WeldLength3000,
            WeldLength4000 = result.WeldLength4000,
            ShellWeldLength = result.ShellWeldLength,
            HeadWeldLength = result.HeadWeldLength,
            CircumferenceWeldLength = result.CircumferenceWeldLength,
            TotalWeldLength = result.TotalWeldLength,
            StiffenerRingWeldLength = result.StiffenerRingWeldLength,
            WeldConsumableCost = result.WeldConsumableCost,
            SurfaceArea = result.SurfaceArea
        };

        private async Task PopulateDisplayNamesAsync(AD2000ResultVM vm)
        {
            var materials = await _materialService.GetAllAsync() ?? new List<MaterialListDto>();
            var materialForms = await _materialFormService.GetAllAsync() ?? new List<MaterialFormListDto>();
            var storageTypes = await _storageTypeService.GetAllAsync();
            var storageTypeList = storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>();

            vm.StorageTypeName = vm.StorageTypeId.HasValue ? storageTypeList.FirstOrDefault(x => x.Id == vm.StorageTypeId.Value)?.Name ?? string.Empty : string.Empty;
            vm.ShellMaterialName = materials.FirstOrDefault(x => x.Id == vm.ShellMaterialId)?.Name ?? string.Empty;
            vm.HeadMaterialName = materials.FirstOrDefault(x => x.Id == vm.HeadMaterialId)?.Name ?? string.Empty;
            vm.ShellMaterialFormName = materialForms.FirstOrDefault(x => x.Id == vm.ShellMaterialFormId)?.FormType.ToString() ?? string.Empty;
            vm.HeadMaterialFormName = materialForms.FirstOrDefault(x => x.Id == vm.HeadMaterialFormId)?.FormType.ToString() ?? string.Empty;
        }

        private async Task PopulateManualCostLookupsAsync(AD2000ResultVM vm)
        {
            vm.AvailableStockGroups = (await _stockProductGroupService.GetAllAsync())
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem($"{x.Name} (Kalem: {x.ItemCount}, Tutar: {x.TotalCost:N2})", x.Id.ToString()))
                .ToList();

            var stockCodes = (await _generatedStockCodeService.GetAllAsync()).OrderBy(x => x.GeneratedCode).ToList();
            vm.AvailableStockCodes = stockCodes.Select(x => new SelectListItem($"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}", x.Id.ToString())).ToList();
            ViewBag.StockCodeOptions = stockCodes.Select(x => new { id = x.Id, text = $"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}", unitPrice = Convert.ToDouble(x.UnitPrice ?? 0m) }).ToList();
        }

        private async Task PopulateCostParameterLookupsAsync(AD2000MaterialCostTableDTO costTable)
        {
            var laborRates = await _context.LaborRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.Name).ToListAsync();
            var gugHourlyRates = await _context.GugHourlyRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.Name).ToListAsync();
            var overheadRates = await _context.OverheadRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.OverheadType).ThenBy(x => x.Name).ToListAsync();
            var bombeRates = await _context.BombeLaborRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.MaterialType).ThenBy(x => x.Name).ToListAsync();

            ViewBag.LaborRateOptions = laborRates.Select(x => new SelectListItem($"{x.HourlyRate:N2} TL/saat", x.Id.ToString(), costTable.SalesPrice?.LaborRateId == x.Id)).ToList();
            ViewBag.GugRateOptions = gugHourlyRates.Select(x => new SelectListItem($"{x.HourlyRate:N2} TL/saat", x.Id.ToString(), costTable.SalesPrice?.GugHourlyRateId == x.Id)).ToList();
            ViewBag.FinanceRateOptions = overheadRates.Where(x => string.Equals(x.OverheadType, "Finance", StringComparison.OrdinalIgnoreCase)).Select(x => new SelectListItem($"%{x.Percentage:N2}", x.Id.ToString(), costTable.SalesPrice?.FinanceOverheadRateId == x.Id)).ToList();
            ViewBag.GeneralManagementRateOptions = overheadRates.Where(x => string.Equals(x.OverheadType, "GeneralManagement", StringComparison.OrdinalIgnoreCase)).Select(x => new SelectListItem($"%{x.Percentage:N2}", x.Id.ToString(), costTable.SalesPrice?.GeneralManagementOverheadRateId == x.Id)).ToList();
            ViewBag.HeadBombeRateOptions = bombeRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} €/kg", x.Id.ToString(), costTable.HeadBombeLaborRateId == x.Id)).ToList();
        }

        private double? ReadLocalizedDoubleFromForm(string key, double? fallback = null)
        {
            if (!Request.HasFormContentType) return fallback;
            var rawValue = Request.Form[key].ToString();
            if (string.IsNullOrWhiteSpace(rawValue)) return fallback;
            var normalized = rawValue.Trim().Replace(" ", string.Empty).Replace(',', '.');
            return double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed) ? parsed : fallback;
        }

        private bool ReadBooleanFromForm(string key, bool fallback = false)
        {
            if (!Request.HasFormContentType) return fallback;
            var value = Request.Form[key].ToString();
            if (string.IsNullOrWhiteSpace(value)) return fallback;
            if (string.Equals(value, "true", StringComparison.OrdinalIgnoreCase) || string.Equals(value, "on", StringComparison.OrdinalIgnoreCase) || value == "1") return true;
            if (string.Equals(value, "false", StringComparison.OrdinalIgnoreCase) || value == "0") return false;
            return fallback;
        }

        private async Task<double> ResolveLiquidDensityAsync(Guid storageTypeId)
        {
            var storageType = await _storageTypeService.GetByIdAsync(storageTypeId);
            if (storageType?.Data == null || storageType.Data.Density <= 0) throw new InvalidOperationException("Seçilen sıvı için geçerli yoğunluk değeri bulunamadı.");
            return storageType.Data.Density;
        }

        private async Task LoadLookupsAsync()
        {
            var materials = await _materialService.GetAllAsync() ?? new List<MaterialListDto>();
            var materialForms = await _materialFormService.GetAllAsync() ?? new List<MaterialFormListDto>();
            var storageTypes = await _storageTypeService.GetAllAsync();

            ViewBag.Materials = new SelectList(materials, "Id", "Name");
            ViewBag.MaterialGroups = materials.Select(x => (x.Group ?? string.Empty).Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).Select(x => new SelectListItem(x, x)).ToList();
            ViewBag.MaterialsByGroup = materials.Where(x => !string.IsNullOrWhiteSpace(x.Group)).GroupBy(x => x.Group.Trim(), StringComparer.OrdinalIgnoreCase).ToDictionary(g => g.Key, g => g.Select(x => new { value = x.Id.ToString(), text = x.Name }).ToList(), StringComparer.OrdinalIgnoreCase);
            ViewBag.MaterialForms = new SelectList(materialForms, "Id", "FormType");
            ViewBag.MaterialFormsByMaterial = materialForms.GroupBy(x => x.MaterialId).ToDictionary(g => g.Key.ToString(), g => g.Select(x => new { value = x.Id.ToString(), text = $"{x.FormType} [{x.ThicknessMin.ToString("0.###", CultureInfo.InvariantCulture)}-{x.ThicknessMax.ToString("0.###", CultureInfo.InvariantCulture)}]", formType = x.FormType.ToString() }).ToList());
            ViewBag.MaterialFormTypesByMaterial = materialForms.GroupBy(x => x.MaterialId).ToDictionary(g => g.Key.ToString(), g => g.Select(x => x.FormType.ToString()).Distinct().OrderBy(x => x).ToList());

            var storageTypeList = storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>();
            ViewBag.StorageTypes = storageTypeList.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            ViewBag.StorageTypeDensities = storageTypeList.ToDictionary(x => x.Id.ToString(), x => x.Density);
        }
    }
}
