using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Mappers;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;
using MVC.ProductManagement.Presentation.Services.EN13458;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class EN13458CalculationController : AdminBaseController
    {
        private readonly IEN13458CalculationServices _service;
        private readonly IMaterialService _materialService;
        private readonly IMaterialFormService _materialFormService;
        private readonly IStorageTypeService _storageTypeService;
        private readonly IGeneratedStockCodeService _generatedStockCodeService;
        private readonly IStockProductGroupService _stockProductGroupService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEN13458AdminExportService _exportService;
        private readonly IEN13458SpecificationExportService _specificationExportService;

        public EN13458CalculationController(
            IEN13458CalculationServices service,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IStorageTypeService storageTypeService,
            IGeneratedStockCodeService generatedStockCodeService,
            IStockProductGroupService stockProductGroupService,
            IWebHostEnvironment webHostEnvironment,
            IEN13458AdminExportService exportService,
            IEN13458SpecificationExportService specificationExportService)
        {
            _service = service;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _storageTypeService = storageTypeService;
            _generatedStockCodeService = generatedStockCodeService;
            _stockProductGroupService = stockProductGroupService;
            _webHostEnvironment = webHostEnvironment;
            _exportService = exportService;
            _specificationExportService = specificationExportService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            var vm = list.Select(x => new EN13458ListVM
            {
                Id = x.Id,
                Name = x.Name,
                OuterDiameter = x.OuterDiameter,
                OuterTankDiameter = x.OuterTankDiameter,
                ShellLength = x.ShellLength,
                Pressure = x.Pressure,
                RoundedInnerShellThickness = x.RoundedInnerShellThickness,
                RoundedOuterShellThickness = x.RoundedOuterShellThickness
            }).ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, Guid? costAnalysisId = null, string mode = "manager")
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = EN13458CalculationVmMapper.MapDetailsVm(dto);
            await PopulateResultDisplayNamesAsync(vm);
            vm.CostAnalyses = await _service.GetCostAnalysesAsync(id);
            ViewBag.IsSalesView = string.Equals(mode, "sales", StringComparison.OrdinalIgnoreCase);

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cost(Guid id, Guid? costAnalysisId = null)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = EN13458CalculationVmMapper.MapDetailsVm(dto);
            vm.SelectedCostAnalysisId = costAnalysisId;

            await PopulateResultDisplayNamesAsync(vm);
            await PopulateManualCostLookupsAsync(vm);
            vm.CostAnalyses = await _service.GetCostAnalysesAsync(id);

            var costTable = await _service.GetCostAnalysisAsync(id, costAnalysisId) ?? await _service.BuildMaterialCostTableAsync(dto);
            await PopulateCostParameterLookupsAsync(costTable);
            vm.SelectedCostAnalysisId = costTable.CostAnalysisId;
            ViewBag.CostTable = costTable;

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SalesPrice(Guid id, Guid costAnalysisId)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = EN13458CalculationVmMapper.MapDetailsVm(dto);
            vm.SelectedCostAnalysisId = costAnalysisId;
            await PopulateResultDisplayNamesAsync(vm);
            vm.CostAnalyses = await _service.GetCostAnalysesAsync(id);

            var costTable = await _service.GetCostAnalysisAsync(id, costAnalysisId);
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
        public async Task<IActionResult> Specification(Guid id, Guid? costAnalysisId = null)
        {
            var specification = await BuildSpecificationVmAsync(id, costAnalysisId);
            if (specification == null)
            {
                return NotFound();
            }

            return View(specification);
        }

        [HttpGet]
        public async Task<IActionResult> ExportSpecificationWord(Guid id, Guid? costAnalysisId = null)
        {
            var specification = await BuildSpecificationVmAsync(id, costAnalysisId);
            if (specification == null)
            {
                return NotFound();
            }

            var fileName = $"LLL_Storage_Tank_Quotation_{DateTime.UtcNow:yyyyMMddHHmmss}.docx";

            return File(
                await _specificationExportService.BuildWordDocumentAsync(GetSpecificationTemplatePath(), specification),
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileName);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            await LoadLookupsAsync();
            return View("Calculate", EN13458CalculationVmMapper.MapCalculateVm(dto));
        }

        [HttpGet]
        public async Task<IActionResult> ExportDetailExcel(Guid id, Guid? costAnalysisId = null)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = EN13458CalculationVmMapper.MapDetailsVm(dto);
            await PopulateResultDisplayNamesAsync(vm);

            var costTable = await _service.GetCostAnalysisAsync(id, costAnalysisId) ?? await _service.BuildMaterialCostTableAsync(dto);
            var safeName = string.Concat((vm.Name ?? "EN13458").Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)));
            var fileName = $"EN13458_Detay_{safeName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            return File(
                _exportService.BuildDetailExcel(vm, costTable),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            await LoadLookupsAsync();

            return View(new EN13458CalculateVM
            {
                Name = "EN13458 Hesabı",
                OuterDiameter = 2000,
                OuterTankDiameter = 2500,
                ShellLength = 6000,
                Pressure = 16,
                StorageTypeId = Guid.Empty,
                LiquidDensity = 808,
                TankOrientation = TankOrientation.Horizontal,
                IsColdStretchApplied = false,
                StiffenerSpacing = 750
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Calculate(EN13458CalculateVM vm) => ProcessCalculationAsync(vm, isEditMode: false);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Update(EN13458CalculateVM vm) => ProcessCalculationAsync(vm, isEditMode: true);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EN13458ResultVM vm)
        {
            var dto = EN13458CalculationVmMapper.MapResultDto(vm);
            var saved = await _service.SaveAsync(dto, User?.Identity?.Name ?? "AdminUser");
            TempData["SuccessMessage"] = vm.IsEditMode ? "Tank hesabı güncellendi." : "Tank hesabı kaydedildi.";
            return RedirectToAction(nameof(Details), new { id = saved.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCostAnalysis(Guid id, string analysisName, string notes = "")
        {
            try
            {
                var analysis = await _service.CreateCostAnalysisAsync(id, analysisName, notes, User?.Identity?.Name ?? "AdminUser");
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
                var analysis = await _service.CreateCostAnalysisRevisionAsync(id, sourceCostAnalysisId, analysisName, notes, User?.Identity?.Name ?? "AdminUser");
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

                await _service.UpdateCostAnalysisItemAsync(id, costAnalysisId, costAnalysisItemId, generatedStockCodeId, quantity, useManualUnitPrice, manualUnitPrice, User?.Identity?.Name ?? "AdminUser");
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
        public async Task<IActionResult> BulkUpdateCostItems(Guid id, Guid costAnalysisId, List<EN13458CostItemBulkUpdateVM> items)
        {
            try
            {
                for (var index = 0; index < items.Count; index++)
                {
                    items[index].Quantity = ReadLocalizedDoubleFromForm($"items[{index}].Quantity", items[index].Quantity);
                    items[index].ManualUnitPrice = ReadLocalizedDoubleFromForm($"items[{index}].ManualUnitPrice", items[index].ManualUnitPrice);
                    items[index].UseManualUnitPrice = ReadBooleanFromForm($"items[{index}].UseManualUnitPrice", items[index].UseManualUnitPrice);
                }

                await _service.BulkUpdateCostAnalysisItemsAsync(
                    id,
                    costAnalysisId,
                    items
                        .Where(x => x.CostAnalysisItemId != Guid.Empty)
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
        public async Task<IActionResult> UpdateBombeLabor(Guid id, Guid costAnalysisId, Guid? innerHeadBombeLaborRateId, Guid? outerHeadBombeLaborRateId)
        {
            try
            {
                await _service.UpdateBombeLaborAsync(id, costAnalysisId, innerHeadBombeLaborRateId, outerHeadBombeLaborRateId, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Bombe işçilik seçimleri güncellendi.";
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

                await _service.UpsertSalesPriceAsync(id, costAnalysisId, laborRateId, laborHours, gugHourlyRateId, financeOverheadRateId, generalManagementOverheadRateId, profitPercentage, User?.Identity?.Name ?? "AdminUser");
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

                await _service.AddManualStockCodeCostAsync(id, costAnalysisId, generatedStockCodeId, quantity, useManualUnitPrice, manualUnitPrice, User?.Identity?.Name ?? "AdminUser");
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
                await _service.AddManualStockGroupCostAsync(id, costAnalysisId, stockProductGroupId, multiplier, User?.Identity?.Name ?? "AdminUser");
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
                await _service.RemoveCostAnalysisItemAsync(id, costAnalysisId, costAnalysisItemId);
                TempData["SuccessMessage"] = "Maliyet kalemi kaldırıldı.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        private async Task<IActionResult> ProcessCalculationAsync(EN13458CalculateVM vm, bool isEditMode)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }

            if (vm.StorageTypeId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), "Lütfen bir depolama tipi seçin.");
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }

            double liquidDensity;
            try
            {
                liquidDensity = await ResolveLiquidDensityAsync(vm.StorageTypeId);
                vm.LiquidDensity = liquidDensity;
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), ex.Message);
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }

            var dto = new EN13458CalculateDTO
            {
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
                OuterTankDiameter = vm.OuterTankDiameter,
                ShellLength = vm.ShellLength,
                Pressure = vm.Pressure,
                StorageTypeId = vm.StorageTypeId,
                LiquidDensity = liquidDensity,
                TankOrientation = vm.TankOrientation,
                IsColdStretchApplied = vm.IsColdStretchApplied,
                InnerShellMaterialId = vm.InnerShellMaterialId,
                InnerShellMaterialFormId = vm.InnerShellMaterialFormId,
                InnerHeadMaterialId = vm.InnerHeadMaterialId,
                InnerHeadMaterialFormId = vm.InnerHeadMaterialFormId,
                OuterShellMaterialId = vm.OuterShellMaterialId,
                OuterShellMaterialFormId = vm.OuterShellMaterialFormId,
                OuterHeadMaterialId = vm.OuterHeadMaterialId,
                OuterHeadMaterialFormId = vm.OuterHeadMaterialFormId,
                StiffenerSpacing = vm.StiffenerSpacing,
                StiffenerArea = vm.StiffenerArea,
                StiffenerInertia = vm.StiffenerInertia,
                StiffenerSectionModulus = vm.StiffenerSectionModulus
            };

            try
            {
                var result = await _service.CalculateAsync(dto);
                result.Id = vm.Id;
                var resultVm = EN13458CalculationVmMapper.MapResultVm(result);
                resultVm.IsEditMode = isEditMode;
                await PopulateResultDisplayNamesAsync(resultVm);
                return View("Result", resultVm);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }
        }

        private async Task PopulateManualCostLookupsAsync(EN13458DetailsVM vm)
        {
            vm.AvailableStockGroups = (await _stockProductGroupService.GetAllAsync())
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem($"{x.Name} (Kalem: {x.ItemCount}, Tutar: {x.TotalCost:N2})", x.Id.ToString()))
                .ToList();

            var stockCodes = await _generatedStockCodeService.GetFilteredAsync(new GeneratedStockCodeFilterDto
            {
                Take = 1000
            });

            vm.AvailableStockCodes = stockCodes
                .OrderBy(x => x.GeneratedCode)
                .Select(x => new SelectListItem($"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}", x.Id.ToString()))
                .ToList();

            ViewBag.StockCodeOptions = stockCodes.Select(x => new
            {
                id = x.Id,
                text = $"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}",
                unitPrice = Convert.ToDouble(x.UnitPrice ?? 0m),
                mainGroupCode = x.MainGroupCode,
                subGroupCode = x.SubGroupCode,
                searchText = $"{x.GeneratedCode} {x.Description} {x.RuleName} {x.MainGroupCode} {x.SubGroupCode} {x.SubGroupName}"
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> SearchStockCodes(string? term, string? mainGroupCode, string? subGroupCode, bool onlyWithPrice = false, int take = 50)
        {
            var stockCodes = await _generatedStockCodeService.GetFilteredAsync(new GeneratedStockCodeFilterDto
            {
                SearchTerm = term,
                MainGroupCode = mainGroupCode,
                SubGroupCode = subGroupCode,
                OnlyWithPrice = onlyWithPrice,
                Take = take
            });

            return Json(stockCodes.Select(x => new
            {
                id = x.Id,
                text = $"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}",
                unitPrice = Convert.ToDouble(x.UnitPrice ?? 0m),
                mainGroupCode = x.MainGroupCode,
                subGroupCode = x.SubGroupCode
            }));
        }

        private async Task PopulateCostParameterLookupsAsync(EN13458MaterialCostTableDTO costTable)
        {
            var lookups = await _service.GetCostParameterLookupsAsync();

            ViewBag.LaborRateOptions = lookups.LaborRates.Select(x => new SelectListItem($"{x.HourlyRate:N2} TL/saat", x.Id.ToString(), costTable.SalesPrice?.LaborRateId == x.Id)).ToList();
            ViewBag.GugRateOptions = lookups.GugHourlyRates.Select(x => new SelectListItem($"{x.HourlyRate:N2} TL/saat", x.Id.ToString(), costTable.SalesPrice?.GugHourlyRateId == x.Id)).ToList();
            ViewBag.FinanceRateOptions = lookups.OverheadRates.Where(x => string.Equals(x.OverheadType, "Finance", StringComparison.OrdinalIgnoreCase)).Select(x => new SelectListItem($"%{x.Percentage:N2}", x.Id.ToString(), costTable.SalesPrice?.FinanceOverheadRateId == x.Id)).ToList();
            ViewBag.GeneralManagementRateOptions = lookups.OverheadRates.Where(x => string.Equals(x.OverheadType, "GeneralManagement", StringComparison.OrdinalIgnoreCase)).Select(x => new SelectListItem($"%{x.Percentage:N2}", x.Id.ToString(), costTable.SalesPrice?.GeneralManagementOverheadRateId == x.Id)).ToList();

            ViewBag.InnerBombeRateOptions = lookups.BombeLaborRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} €/kg", x.Id.ToString(), costTable.InnerHeadBombeLaborRateId == x.Id)).ToList();
            ViewBag.OuterBombeRateOptions = lookups.BombeLaborRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} €/kg", x.Id.ToString(), costTable.OuterHeadBombeLaborRateId == x.Id)).ToList();
        }

        private async Task<EN13458SpecificationVM?> BuildSpecificationVmAsync(Guid id, Guid? costAnalysisId)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return null;
            }

            var resultVm = EN13458CalculationVmMapper.MapResultVm(dto);
            await PopulateResultDisplayNamesAsync(resultVm);

            var costTable = await _service.GetCostAnalysisAsync(id, costAnalysisId) ?? await _service.BuildMaterialCostTableAsync(dto);
            var accessoryItems = costTable.Items
                .Where(x => x.IsManual && !x.IsBombeLabor)
                .OrderBy(x => x.CostGroupCode)
                .ThenBy(x => x.ItemName)
                .Select(x => new EN13458AccessoryItemVM
                {
                    GroupName = string.IsNullOrWhiteSpace(x.CostGroupName) ? "Aksesuar" : x.CostGroupName,
                    ItemName = string.IsNullOrWhiteSpace(x.ItemName) ? x.StockCodeName : x.ItemName,
                    StockCode = x.StockCode,
                    Description = string.IsNullOrWhiteSpace(x.StockCodeName) ? x.MaterialName : x.StockCodeName,
                    Quantity = x.Quantity,
                    Unit = string.IsNullOrWhiteSpace(x.Unit) ? "adet" : x.Unit
                })
                .ToList();

            return new EN13458SpecificationVM
            {
                Id = resultVm.Id,
                SelectedCostAnalysisId = costTable.CostAnalysisId,
                GeneratedAtUtc = DateTime.UtcNow,
                DocumentTitle = "Quotation for Cryogenic storage tank",
                FluidDisplay = resultVm.StorageTypeName,
                PressureDisplay = $"{(resultVm.DesignPressure > 0 ? resultVm.DesignPressure : resultVm.Pressure):N0} Bar",
                HeaderItems = BuildSpecificationHeaderItems(),
                IntroParagraphs = BuildSpecificationIntroParagraphs(),
                GeneralItems = new List<EN13458SpecificationLineVM>
                {
                    CreateSpecItem("Type", "Vacuum Insulated Storage Tank"),
                    CreateSpecItem("Design Code", "EN 13458"),
                    CreateSpecItem("Approval", "2014/68/EU CE Marked"),
                    CreateSpecItem("Fluid", resultVm.StorageTypeName),
                    CreateSpecItem("Inner Vessel", "Stainless Steel (Acc. To EN 10028-7)"),
                    CreateSpecItem("Outer Vessel", "Carbon Steel    (Acc. To EN 10025/10028)"),
                    CreateSpecItem("Earthquake", "Seismic Zone 1 in accordance with UBC1997"),
                    CreateSpecItem("Wind Load", "45 m/s Acc. To EN 1991-2-4")
                },
                InnerVesselItems = new List<EN13458SpecificationLineVM>
                {
                    CreateSpecItem("Gross Capacity", "20.810 Liters"),
                    CreateSpecItem("Net Capacity(95% ratio)", "19.770 Liters"),
                    CreateSpecItem("MAWP", $"{(resultVm.DesignPressure > 0 ? resultVm.DesignPressure : resultVm.Pressure):N0} Bar"),
                    CreateSpecItem("Design Code", "EN 13458 ANNEX C"),
                    CreateSpecItem("Design Temperature", "-196 °C / +50 °C"),
                    CreateSpecItem("Material", "SS 1,4306 & 1,4307 or equivalent (Acc. To EN 10028-7)"),
                    CreateSpecItem("Radiographic Control", "%100"),
                    CreateSpecItem("Cleaning", "will be cleaned suitable to oxygen use.")
                },
                OuterVesselItems = new List<EN13458SpecificationLineVM>
                {
                    CreateSpecItem("Design Pressure", "1 barg"),
                    CreateSpecItem("Design Code", "EN 13458 / EN 13445"),
                    CreateSpecItem("Design Temperature", "-20 °C / +50 °C"),
                    CreateSpecItem("Material", "Carbon Steel S355 or equivalent  (Acc. To EN 10025/10028)")
                },
                InsulationItems = new List<EN13458SpecificationLineVM>
                {
                    CreateSpecItem("Type", "Perlite + Vacuum Insulation"),
                    CreateSpecItem("Perlite Density", "90-100 kg/m3"),
                    CreateSpecItem("Vacuum Value", "5 x 10-2")
                },
                PipeworkItems = new List<EN13458SpecificationLineVM>
                {
                    CreateSpecItem("Pipe Material", "Seamless pipe AISI 304/304L min. sch10"),
                    CreateSpecItem("Pipework testing", "Welds and pressure test"),
                    CreateSpecItem("Valves", "See Accessories List below"),
                    CreateSpecItem("Safety Valves", "See Accessories List below"),
                    CreateSpecItem("Level Gauges", "See Accessories List below"),
                    CreateSpecItem("Pressure Gauges", "See Accessories List below"),
                    CreateSpecItem("PBUC", "Aluminum finned type"),
                    CreateSpecItem(string.Empty, "(Acc. to Max. 300 Nm3/h LIN discharge capacity with standard pressure building coil at 0,7 x MAWP and 8 hours operating time)"),
                    CreateSpecItem("Flow schematic", "See P&ID below")
                },
                AccessoryItems = accessoryItems,
                SurfaceApplicationItems = new List<EN13458SpecificationLineVM>
                {
                    CreateSpecItem("Sandblasting", "Outer tank will be shot blasted with sa 2,5 screen quality"),
                    CreateSpecItem("Painting", "Primer epoxy grey (120 µ)"),
                    CreateSpecItem(string.Empty, "Topcoat polyurethane white (80 µ)"),
                    CreateSpecItem("Logo", "Logo application price will be given optionally.")
                },
                VesselDocumentationItems = new List<string>
                {
                    "Inspection Test Plan (ITP)",
                    "Hydrostatic test certificate",
                    "Final inspection report",
                    "Manufacturer’s name plate",
                    "Tank approval certificate",
                    "Third party inspection reports",
                    "Welding procedures and applications",
                    "Radiographic reports",
                    "Dye-penetrant reports",
                    "Material certification"
                },
                InspectionItems = new List<string>
                {
                    "Inspection and certification to be carried out by BV or TUV etc."
                },
                CommercialParagraphs = new List<string>
                {
                    "Our prices are net in EURO (€), for delivery Exw. GEBZE/KOCAELİ/TURKEY.",
                    "Standard packing for open transport and export customs clearance are included.",
                    "Seaworthy packing, transport, customs duties and any other charges are excluded."
                },
                QuotationRows = new List<EN13458QuotationRowVM>
                {
                    new EN13458QuotationRowVM
                    {
                        No = "1",
                        Product = "20 m³ LLL Storage Tank",
                        UnitPrice = "€",
                        Quantity = "1",
                        TotalPrice = "€"
                    }
                },
                Notes = new List<string>
                {
                    "Local certificates are not included in our offer.",
                    "Template, anchor and bolts are not included in our offer.",
                    "All connection (FC,C etc.) will be PN40 DN40 standard flange according to EN."
                },
                PaymentTerms = new List<string>
                {
                    "%50 Advance payment",
                    "%50 Before shipment"
                },
                DeliveryTerms = new List<string>
                {
                    "14-16 weeks after receiving down payment",
                    "Exact delivery date to be agreed at time of order"
                },
                WarrantyTerms = new List<string>
                {
                    "12 months after final inspection report prepared by Quality Department",
                    "All resale products and components only carry the warranty offered by their original manufacturer."
                },
                StorageTerms = new List<string>
                {
                    "Cryocan provide 2 weeks free storage after completion excluding handling cost if any",
                    "storage fee will be 150$/day after."
                },
                ValidityTerms = new List<string>
                {
                    "Our quotation is valid for 30 days",
                    "This quotation letter is valid with Cryocan General Terms & Conditions of Sales"
                },
                FooterTechnicalNotes = new List<string>
                {
                    $"SV: Inner vessel safety valves set pressure will be {(resultVm.DesignPressure > 0 ? resultVm.DesignPressure : resultVm.Pressure):N0} bar.",
                    "PCV : Pressure regulator set point range will be 8-25 bar."
                }
            };
        }

        private static List<EN13458SpecificationLineVM> BuildSpecificationHeaderItems()
        {
            return new List<EN13458SpecificationLineVM>
            {
                CreateSpecItem("Company Name", "Representative :"),
                CreateSpecItem("Attention", "Tel :"),
                CreateSpecItem("Tel", "E-mail  :"),
                CreateSpecItem("E-mail", "Date:"),
                CreateSpecItem("Country", "Offer Ref. No:"),
                CreateSpecItem("Project ID (end user)", ":")
            };
        }

        private static List<string> BuildSpecificationIntroParagraphs()
        {
            return new List<string>
            {
                "You may find our proposal along with technical specification as below for Cryogenic Storage tank.",
                "We hope you will find everything satisfactory and please do not hesitate to contact us should you or any of your team members have any questions and/or comments regarding our proposal.",
                "Sincerely yours,"
            };
        }

        private static EN13458SpecificationLineVM CreateSpecItem(string label, string value)
            => new() { Label = label, Value = value };

        private string GetSpecificationTemplatePath()
        {
            var contentTemplatePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Templates", "LLL_17 Bar Storage Tank Quotation_(20m3).docx");
            if (System.IO.File.Exists(contentTemplatePath))
            {
                return contentTemplatePath;
            }

            var repoRootTemplatePath = Path.GetFullPath(Path.Combine(_webHostEnvironment.ContentRootPath, "..", "LLL_17 Bar Storage Tank Quotation_(20m3).docx"));
            if (System.IO.File.Exists(repoRootTemplatePath))
            {
                return repoRootTemplatePath;
            }

            return Path.Combine(AppContext.BaseDirectory, "Templates", "LLL_17 Bar Storage Tank Quotation_(20m3).docx");
        }

        private double? ReadLocalizedDoubleFromForm(string key, double? fallback = null)
        {
            if (!Request.HasFormContentType)
            {
                return fallback;
            }

            var rawValue = Request.Form[key].ToString();
            if (string.IsNullOrWhiteSpace(rawValue))
            {
                return fallback;
            }

            var normalized = rawValue.Trim().Replace(" ", string.Empty).Replace(',', '.');
            if (double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed))
            {
                return parsed;
            }

            return fallback;
        }

        private bool ReadBooleanFromForm(string key, bool fallback = false)
        {
            if (!Request.HasFormContentType)
            {
                return fallback;
            }

            var values = Request.Form[key];
            if (values.Count == 0)
            {
                return fallback;
            }

            foreach (var value in values)
            {
                if (bool.TryParse(value, out var parsed) && parsed)
                {
                    return true;
                }
            }

            return false;
        }

        private async Task PopulateResultDisplayNamesAsync(EN13458ResultVM vm)
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();
            var storageTypes = await _storageTypeService.GetAllAsync();

            var materialMap = materials.ToDictionary(x => x.Id, x => x.Name);
            var formMap = forms.ToDictionary(x => x.Id, x => $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]");
            var storageTypeMap = (storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>())
                .ToDictionary(x => x.Id, x => x.Name);

            vm.StorageTypeName = storageTypeMap.GetValueOrDefault(vm.StorageTypeId, "-");
            vm.InnerShellMaterialName = materialMap.GetValueOrDefault(vm.InnerShellMaterialId, "-");
            vm.InnerShellMaterialFormName = formMap.GetValueOrDefault(vm.InnerShellMaterialFormId, "-");
            vm.InnerHeadMaterialName = materialMap.GetValueOrDefault(vm.InnerHeadMaterialId, "-");
            vm.InnerHeadMaterialFormName = formMap.GetValueOrDefault(vm.InnerHeadMaterialFormId, "-");
            vm.OuterShellMaterialName = materialMap.GetValueOrDefault(vm.OuterShellMaterialId, "-");
            vm.OuterShellMaterialFormName = formMap.GetValueOrDefault(vm.OuterShellMaterialFormId, "-");
            vm.OuterHeadMaterialName = materialMap.GetValueOrDefault(vm.OuterHeadMaterialId, "-");
            vm.OuterHeadMaterialFormName = formMap.GetValueOrDefault(vm.OuterHeadMaterialFormId, "-");
        }

        private async Task<double> ResolveLiquidDensityAsync(Guid storageTypeId)
        {
            var storageType = await _storageTypeService.GetByIdAsync(storageTypeId);
            if (storageType?.Data == null || storageType.Data.Density <= 0)
            {
                throw new InvalidOperationException("Seçilen depolama tipi için geçerli yoğunluk verisi bulunamadı.");
            }

            return storageType.Data.Density;
        }

        private async Task LoadLookupsAsync()
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();
            var storageTypes = await _storageTypeService.GetAllAsync();

            static string BuildMaterialDisplay(MaterialListDto material, IEnumerable<MaterialFormListDto> materialForms, string? materialClass = null)
            {
                var scopedForms = materialForms
                    .Where(x => string.IsNullOrWhiteSpace(materialClass)
                        || string.Equals((x.MaterialClass ?? string.Empty).Trim(), materialClass.Trim(), StringComparison.OrdinalIgnoreCase));

                var details = scopedForms
                    .Select(x => string.Join(" / ", new[] { x.SymbolicName, x.Norm, x.FormType.ToString() }
                        .Where(v => !string.IsNullOrWhiteSpace(v))
                        .Select(v => v!.Trim())))
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(2)
                    .ToList();

                return details.Count == 0 ? material.Name : $"{material.Name} ({string.Join(" | ", details)})";
            }

            var formsByMaterialId = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(g => g.Key, g => g.ToList());

            ViewBag.Materials = materials
                .Select(x => new SelectListItem(
                    BuildMaterialDisplay(x, formsByMaterialId.GetValueOrDefault(x.Id) ?? new List<MaterialFormListDto>()),
                    x.Id.ToString()))
                .ToList();
            var materialClasses = forms
                .Select(x => (x.MaterialClass ?? string.Empty).Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            ViewBag.MaterialGroups = materialClasses
                .Select(x => new SelectListItem(x, x))
                .ToList();

            ViewBag.MaterialsByGroup = materialClasses.ToDictionary(
                group => group,
                group => materials
                    .Where(m => (formsByMaterialId.GetValueOrDefault(m.Id) ?? new List<MaterialFormListDto>())
                        .Any(f => string.Equals((f.MaterialClass ?? string.Empty).Trim(), group, StringComparison.OrdinalIgnoreCase)))
                    .Select(m => new
                    {
                        value = m.Id.ToString(),
                        text = BuildMaterialDisplay(m, formsByMaterialId.GetValueOrDefault(m.Id) ?? new List<MaterialFormListDto>(), group)
                    })
                    .ToList(),
                StringComparer.OrdinalIgnoreCase);

            ViewBag.MaterialForms = forms
                .Select(x => new SelectListItem($"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]", x.Id.ToString()))
                .ToList();

            ViewBag.MaterialFormsByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new
                    {
                        value = x.Id.ToString(),
                        text = $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]",
                        formType = x.FormType.ToString(),
                        materialClass = x.MaterialClass,
                        norm = x.Norm,
                        symbolicName = x.SymbolicName,
                        momentOfInertia = x.MomentOfInertia,
                        sectionArea = x.SectionArea,
                        sectionModulus = x.SectionModulus
                    }).ToList());

            ViewBag.MaterialFormTypesByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(g => g.Key.ToString(), g => g.Select(x => x.FormType.ToString()).Distinct().OrderBy(x => x).ToList());

            ViewBag.StorageTypes = (storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>())
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.StorageTypeDensities = (storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>())
                .ToDictionary(x => x.Id.ToString(), x => x.Density);

            ViewBag.MaterialExternalProperties = forms.ToDictionary(x => x.Id.ToString(), x => new { elasticModulus = x.ElasticModulus, yieldFactorK = x.YieldFactorK });
        }

    }
}
