using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EN13458CalculationController(
            IEN13458CalculationServices service,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IStorageTypeService storageTypeService,
            IGeneratedStockCodeService generatedStockCodeService,
            IStockProductGroupService stockProductGroupService,
            AppDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _storageTypeService = storageTypeService;
            _generatedStockCodeService = generatedStockCodeService;
            _stockProductGroupService = stockProductGroupService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            var calculation = await _context.EN13458Calculations
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);

            if (calculation == null)
            {
                return NotFound();
            }

            var costAnalyses = await _context.EN13458CostAnalyses
                .Where(x => x.EN13458CalculationId == id && x.Status != Status.Deleted)
                .ToListAsync();

            var costAnalysisIds = costAnalyses.Select(x => x.Id).ToList();

            var costItems = await _context.EN13458CostAnalysisItems
                .Where(x => costAnalysisIds.Contains(x.EN13458CostAnalysisId) && x.Status != Status.Deleted)
                .ToListAsync();

            var salesPrices = await _context.EN13458SalesPrices
                .Where(x => x.EN13458CalculationId == id && x.Status != Status.Deleted)
                .ToListAsync();

            var costDetails = await _context.EN13458CostDetails
                .Where(x => x.EN13458CalculationId == id && x.Status != Status.Deleted)
                .ToListAsync();

            _context.EN13458CostAnalysisItems.RemoveRange(costItems);
            _context.EN13458SalesPrices.RemoveRange(salesPrices);
            _context.EN13458CostDetails.RemoveRange(costDetails);
            _context.EN13458CostAnalyses.RemoveRange(costAnalyses);
            _context.EN13458Calculations.Remove(calculation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, Guid? costAnalysisId = null, string mode = "manager")
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapDetailsVm(dto);
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

            var vm = MapDetailsVm(dto);
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

            var vm = MapDetailsVm(dto);
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

            var templatePath = GetSpecificationTemplatePath();
            if (!System.IO.File.Exists(templatePath))
            {
                throw new FileNotFoundException("Şartname şablon dosyası bulunamadı.", templatePath);
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(templatePath);
            using var stream = new MemoryStream();
            await stream.WriteAsync(bytes, 0, bytes.Length);
            stream.Position = 0;

            using (var document = WordprocessingDocument.Open(stream, true))
            {
                ApplySpecificationTemplate(document, specification);
            }

            var fileName = $"LLL_Storage_Tank_Quotation_{DateTime.UtcNow:yyyyMMddHHmmss}.docx";

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            await LoadLookupsAsync();
            return View("Calculate", MapCalculateVm(dto));
        }

        [HttpGet]
        public async Task<IActionResult> ExportDetailExcel(Guid id, Guid? costAnalysisId = null)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapDetailsVm(dto);
            await PopulateResultDisplayNamesAsync(vm);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("EN13458 Detay");
            var row = 1;

            WriteSectionHeader(ws, row++, "EN13458 Hesap Özeti");
            row = WriteKeyValues(ws, row, new List<(string Label, object Value)>
            {
                ("Ad", vm.Name),
                ("Kayıt Id", vm.Id),
                ("İç Tank Çapı", vm.OuterDiameter),
                ("Dış Tank Çapı", vm.OuterTankDiameter),
                ("Silindirik Boy", vm.ShellLength),
                ("Basınç", vm.Pressure),
                ("Depolama Tipi", vm.StorageTypeName),
                ("Depolama Tipi Id", vm.StorageTypeId),
                ("Sıvı Yoğunluğu", vm.LiquidDensity),
                ("Tank Yönelimi", vm.TankOrientation),
                ("Cold Stretch", vm.IsColdStretchApplied ? "Evet" : "Hayır"),
                ("Kaynak Metrajı 1500", vm.WeldLength1500),
                ("Kaynak Metrajı 2000", vm.WeldLength2000),
                ("Kaynak Metrajı 2500", vm.WeldLength2500),
                ("Kaynak Metrajı 3000", vm.WeldLength3000)
            });

            row = WriteSection(ws, row, "İç Tank", new List<(string Label, object Value)>
            {
                ("Gövde Malzemesi", vm.InnerShellMaterialName),
                ("Gövde Malzeme Formu", vm.InnerShellMaterialFormName),
                ("Bombe Malzemesi", vm.InnerHeadMaterialName),
                ("Bombe Malzeme Formu", vm.InnerHeadMaterialFormName),
                ("Gövde Akma Dayanımı", vm.InnerShellMaterialStrength),
                ("Bombe Akma Dayanımı", vm.InnerHeadMaterialStrength),
                ("Gövde Kalınlığı", vm.InnerShellThickness),
                ("Bombe Kalınlığı", vm.InnerHeadThickness),
                ("Yuvarlanmış Gövde Kalınlığı", vm.RoundedInnerShellThickness),
                ("Yuvarlanmış Bombe Kalınlığı", vm.RoundedInnerHeadThickness),
                ("Bombe Pulu Çapı", vm.InnerTankHeadPulDiameter),
                ("Bombe Ağırlığı", vm.InnerTankHeadWeight),
                ("Bombe Kaynak Uzunluğu", vm.InnerTankHeadWeldLength),
                ("Çevre Kaynak Uzunluğu", vm.InnerTankCircumferenceWeldLength),
                ("Toplam Uzunluk", vm.InnerTankTotalLength),
                ("İç Hacim", vm.InnerVolume),
                ("İç Yüzey Alanı", vm.InnerSurfaceArea),
                ("Tank Ağırlığı", vm.InnerTankWeight)
            });

            row = WriteSection(ws, row, "Dış Tank", new List<(string Label, object Value)>
            {
                ("Gövde Malzemesi", vm.OuterShellMaterialName),
                ("Gövde Malzeme Formu", vm.OuterShellMaterialFormName),
                ("Bombe Malzemesi", vm.OuterHeadMaterialName),
                ("Bombe Malzeme Formu", vm.OuterHeadMaterialFormName),
                ("Gövde Akma Dayanımı", vm.OuterShellMaterialStrength),
                ("Bombe Akma Dayanımı", vm.OuterHeadMaterialStrength),
                ("Gövde Kalınlığı", vm.OuterShellThickness),
                ("Bombe Kalınlığı", vm.OuterHeadThickness),
                ("Yuvarlanmış Gövde Kalınlığı", vm.RoundedOuterShellThickness),
                ("Yuvarlanmış Bombe Kalınlığı", vm.RoundedOuterHeadThickness),
                ("Bombe Pulu Çapı", vm.OuterTankHeadPulDiameter),
                ("Bombe Ağırlığı", vm.OuterTankHeadWeight),
                ("Bombe Kaynak Uzunluğu", vm.OuterTankHeadWeldLength),
                ("Çevre Kaynak Uzunluğu", vm.OuterTankCircumferenceWeldLength),
                ("Toplam Uzunluk", vm.OuterTankTotalLength),
                ("Dış Hacim", vm.OuterVolume),
                ("Dış Yüzey Alanı", vm.OuterSurfaceArea),
                ("Tank Ağırlığı", vm.OuterTankWeight)
            });

            row = WriteSection(ws, row, "Ortak Sonuçlar", new List<(string Label, object Value)>
            {
                ("Design Pressure", vm.DesignPressure),
                ("Test Pressure", vm.TestPressure),
                ("Static Pressure", vm.StaticPressure),
                ("Toplam Kaynak Uzunluğu", vm.TotalWeldLength),
                ("Toplam Film Maliyeti", vm.TotalFilmCost),
                ("Perlit Hacmi", vm.PerliteVolume),
                ("Perlit Ağırlığı", vm.PerliteWeight),
                ("Gaz Azot Hacmi", vm.GasNitrogenVolume),
                ("Sıvı Azot Hacmi", vm.LiquidNitrogenVolume),
                ("Burkulma Dalga Sayısı", vm.BucklingWaveNumber),
                ("Elastik Burkulma Basıncı (P1)", vm.ElasticBucklingPressureP1),
                ("Plastik Çökme Basıncı (P2)", vm.PlasticCollapsePressureP2),
                ("Dış Tasarım Basıncı (Pv)", vm.DesignExternalPressurePv),
                ("Takviye Halkası Gerekli", vm.SupportRingRequired ? "Evet" : "Hayır"),
                ("Takviye Halkası Kritik Basınç (Pe)", vm.SupportRingCriticalPressurePe),
                ("Takviye Halkası Gerilme (X)", vm.SupportRingStressX),
                ("Takviye Halkası İzin Verilen Gerilme", vm.SupportRingAllowableStress),
                ("Takviye Halkası Yeterli", vm.SupportRingAdequate ? "Evet" : "Hayır"),
                ("Head Collapse Pressure", vm.HeadCollapsePressure),
                ("Gerekli Profil Sayısı", vm.RequiredProfileCount),
                ("Profil Açınım Boyu (mm)", vm.ProfileDevelopedLength),
                ("Toplam Profil Boyu (mm)", vm.TotalProfileLength),
                ("Profil Kaynak Metrajı (mm)", vm.ProfileWeldLength)
            });

            WriteSection(ws, row, "Sac Oryantasyonu", new List<(string Label, object Value)>
            {
                ("İç Tank Açınım", vm.InnerDevelopedLength),
                ("Dış Tank Açınım", vm.OuterDevelopedLength),
                ("İç 1500", vm.InnerSectorPlan1500),
                ("İç 2000", vm.InnerSectorPlan2000),
                ("İç 2500", vm.InnerSectorPlan2500),
                ("İç 3000", vm.InnerSectorPlan3000),
                ("Dış 1500", vm.OuterSectorPlan1500),
                ("Dış 2000", vm.OuterSectorPlan2000),
                ("Dış 2500", vm.OuterSectorPlan2500),
                ("Dış 3000", vm.OuterSectorPlan3000)
            });

            var costTable = await _service.GetCostAnalysisAsync(id, costAnalysisId) ?? await _service.BuildMaterialCostTableAsync(dto);
            var costWs = package.Workbook.Worksheets.Add("Maliyet Detay");
            var costRow = 1;

            WriteSectionHeader(costWs, costRow++, $"Maliyet Özeti - {costTable.RevisionCode}");
            costRow = WriteKeyValues(costWs, costRow, new List<(string Label, object Value)>
            {
                ("Analiz", costTable.AnalysisName),
                ("Revizyon", costTable.RevisionCode),
                ("Toplam", costTable.GrandTotalCost)
            });

            costRow += 1;
            WriteSectionHeader(costWs, costRow++, "Maliyet Kalemleri");
            costWs.Cells[costRow, 1].Value = "Grup";
            costWs.Cells[costRow, 2].Value = "Kalem";
            costWs.Cells[costRow, 3].Value = "Stok Kodu";
            costWs.Cells[costRow, 4].Value = "Malzeme";
            costWs.Cells[costRow, 5].Value = "Miktar";
            costWs.Cells[costRow, 6].Value = "Birim";
            costWs.Cells[costRow, 7].Value = "Stok Fiyatı";
            costWs.Cells[costRow, 8].Value = "Hesaba Giren Fiyat";
            costWs.Cells[costRow, 9].Value = "Hesaplanan Birim Fiyat";
            costWs.Cells[costRow, 10].Value = "Tutar";

            using (var header = costWs.Cells[costRow, 1, costRow, 10])
            {
                header.Style.Font.Bold = true;
                header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                header.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                header.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }

            foreach (var item in costTable.Items)
            {
                costRow++;
                costWs.Cells[costRow, 1].Value = $"{item.CostGroupCode} - {item.CostGroupName}";
                costWs.Cells[costRow, 2].Value = item.ItemName;
                costWs.Cells[costRow, 3].Value = item.StockCode;
                costWs.Cells[costRow, 4].Value = item.MaterialName;
                costWs.Cells[costRow, 5].Value = item.Quantity;
                costWs.Cells[costRow, 6].Value = item.Unit;
                costWs.Cells[costRow, 7].Value = item.StockUnitPrice;
                costWs.Cells[costRow, 8].Value = item.UseManualUnitPrice ? item.ManualUnitPrice ?? 0 : item.StockUnitPrice;
                costWs.Cells[costRow, 9].Value = item.UnitPrice;
                costWs.Cells[costRow, 10].Value = item.ItemCost;
            }

            costWs.Cells[costWs.Dimension.Address].AutoFitColumns();
            ws.Cells[ws.Dimension.Address].AutoFitColumns();
            var safeName = string.Concat((vm.Name ?? "EN13458").Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)));
            var fileName = $"EN13458_Detay_{safeName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
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
            var dto = MapResultDto(vm);
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
                var resultVm = MapResultVm(result);
                resultVm.IsEditMode = isEditMode;
                await PopulateResultDisplayNamesAsync(resultVm);
                ViewBag.CostTable = await _service.BuildMaterialCostTableAsync(result);
                return View("Result", resultVm);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }
        }

        private static EN13458DetailsVM MapDetailsVm(EN13458ResultDTO dto)
        {
            var vm = new EN13458DetailsVM();
            CopyResult(dto, vm);
            return vm;
        }

        private static EN13458CalculateVM MapCalculateVm(EN13458ResultDTO dto)
        {
            return new EN13458CalculateVM
            {
                Id = dto.Id,
                Name = dto.Name,
                OuterDiameter = dto.OuterDiameter,
                OuterTankDiameter = dto.OuterTankDiameter,
                ShellLength = dto.ShellLength,
                Pressure = dto.Pressure,
                StorageTypeId = dto.StorageTypeId,
                LiquidDensity = dto.LiquidDensity,
                TankOrientation = dto.TankOrientation,
                IsColdStretchApplied = dto.IsColdStretchApplied,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                StiffenerSpacing = 750
            };
        }

        private EN13458ResultVM MapResultVm(EN13458ResultDTO dto)
        {
            var vm = new EN13458ResultVM();
            CopyResult(dto, vm);
            return vm;
        }

        private static void CopyResult(EN13458ResultDTO dto, EN13458ResultVM vm)
        {
            vm.Id = dto.Id;
            vm.Name = dto.Name;
            vm.OuterDiameter = dto.OuterDiameter;
            vm.OuterTankDiameter = dto.OuterTankDiameter;
            vm.ShellLength = dto.ShellLength;
            vm.Pressure = dto.Pressure;
            vm.StorageTypeId = dto.StorageTypeId;
            vm.LiquidDensity = dto.LiquidDensity;
            vm.TankOrientation = dto.TankOrientation;
            vm.IsColdStretchApplied = dto.IsColdStretchApplied;
            vm.WeldLength1500 = dto.WeldLength1500;
            vm.WeldLength2000 = dto.WeldLength2000;
            vm.WeldLength2500 = dto.WeldLength2500;
            vm.WeldLength3000 = dto.WeldLength3000;
            vm.InnerShellMaterialId = dto.InnerShellMaterialId;
            vm.InnerShellMaterialFormId = dto.InnerShellMaterialFormId;
            vm.InnerHeadMaterialId = dto.InnerHeadMaterialId;
            vm.InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId;
            vm.OuterShellMaterialId = dto.OuterShellMaterialId;
            vm.OuterShellMaterialFormId = dto.OuterShellMaterialFormId;
            vm.OuterHeadMaterialId = dto.OuterHeadMaterialId;
            vm.OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId;
            vm.InnerShellMaterialStrength = dto.InnerShellMaterialStrength;
            vm.InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength;
            vm.OuterShellMaterialStrength = dto.OuterShellMaterialStrength;
            vm.OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength;
            vm.InnerShellThickness = dto.InnerShellThickness;
            vm.InnerHeadThickness = dto.InnerHeadThickness;
            vm.OuterShellThickness = dto.OuterShellThickness;
            vm.OuterHeadThickness = dto.OuterHeadThickness;
            vm.RoundedInnerShellThickness = dto.RoundedInnerShellThickness;
            vm.RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness;
            vm.RoundedOuterShellThickness = dto.RoundedOuterShellThickness;
            vm.RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness;
            vm.DesignPressure = dto.DesignPressure;
            vm.TestPressure = dto.TestPressure;
            vm.StaticPressure = dto.StaticPressure;
            vm.InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter;
            vm.OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter;
            vm.InnerTankHeadWeight = dto.InnerTankHeadWeight;
            vm.OuterTankHeadWeight = dto.OuterTankHeadWeight;
            vm.InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength;
            vm.InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength;
            vm.InnerTankShellWeldLength = dto.InnerTankShellWeldLength;
            vm.InnerTankBombeWeldLength = dto.InnerTankBombeWeldLength;
            vm.InnerTankTotalWeldLength = dto.InnerTankTotalWeldLength;
            vm.OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength;
            vm.OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength;
            vm.OuterTankShellWeldLength = dto.OuterTankShellWeldLength;
            vm.OuterTankBombeWeldLength = dto.OuterTankBombeWeldLength;
            vm.OuterTankTotalWeldLength = dto.OuterTankTotalWeldLength;
            vm.StiffenerRingWeldLength = dto.StiffenerRingWeldLength;
            vm.TotalWeldLength = dto.TotalWeldLength;
            vm.TotalFilmCost = dto.TotalFilmCost;
            vm.InnerTankTotalLength = dto.InnerTankTotalLength;
            vm.OuterTankTotalLength = dto.OuterTankTotalLength;
            vm.InnerVolume = dto.InnerVolume;
            vm.OuterVolume = dto.OuterVolume;
            vm.InnerSurfaceArea = dto.InnerSurfaceArea;
            vm.OuterSurfaceArea = dto.OuterSurfaceArea;
            vm.InnerTankWeight = dto.InnerTankWeight;
            vm.OuterTankWeight = dto.OuterTankWeight;
            vm.PerliteVolume = dto.PerliteVolume;
            vm.PerliteWeight = dto.PerliteWeight;
            vm.GasNitrogenVolume = dto.GasNitrogenVolume;
            vm.LiquidNitrogenVolume = dto.LiquidNitrogenVolume;
            vm.BucklingWaveNumber = dto.BucklingWaveNumber;
            vm.ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1;
            vm.PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2;
            vm.DesignExternalPressurePv = dto.DesignExternalPressurePv;
            vm.SupportRingRequired = dto.SupportRingRequired;
            vm.SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe;
            vm.SupportRingStressX = dto.SupportRingStressX;
            vm.SupportRingAllowableStress = dto.SupportRingAllowableStress;
            vm.SupportRingAdequate = dto.SupportRingAdequate;
            vm.HeadCollapsePressure = dto.HeadCollapsePressure;
            vm.RequiredProfileCount = dto.RequiredProfileCount;
            vm.ProfileDevelopedLength = dto.ProfileDevelopedLength;
            vm.TotalProfileLength = dto.TotalProfileLength;
            vm.ProfileWeldLength = dto.ProfileWeldLength;
            vm.InnerDevelopedLength = dto.InnerDevelopedLength;
            vm.OuterDevelopedLength = dto.OuterDevelopedLength;
            vm.InnerSectorPlan1500 = dto.InnerSectorPlan1500;
            vm.InnerSectorPlan2000 = dto.InnerSectorPlan2000;
            vm.InnerSectorPlan2500 = dto.InnerSectorPlan2500;
            vm.InnerSectorPlan3000 = dto.InnerSectorPlan3000;
            vm.OuterSectorPlan1500 = dto.OuterSectorPlan1500;
            vm.OuterSectorPlan2000 = dto.OuterSectorPlan2000;
            vm.OuterSectorPlan2500 = dto.OuterSectorPlan2500;
            vm.OuterSectorPlan3000 = dto.OuterSectorPlan3000;
        }

        private static EN13458ResultDTO MapResultDto(EN13458ResultVM vm)
        {
            return new EN13458ResultDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
                OuterTankDiameter = vm.OuterTankDiameter,
                ShellLength = vm.ShellLength,
                Pressure = vm.Pressure,
                StorageTypeId = vm.StorageTypeId,
                LiquidDensity = vm.LiquidDensity,
                TankOrientation = vm.TankOrientation,
                IsColdStretchApplied = vm.IsColdStretchApplied,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength2500 = vm.WeldLength2500,
                WeldLength3000 = vm.WeldLength3000,
                InnerShellMaterialId = vm.InnerShellMaterialId,
                InnerShellMaterialFormId = vm.InnerShellMaterialFormId,
                InnerHeadMaterialId = vm.InnerHeadMaterialId,
                InnerHeadMaterialFormId = vm.InnerHeadMaterialFormId,
                OuterShellMaterialId = vm.OuterShellMaterialId,
                OuterShellMaterialFormId = vm.OuterShellMaterialFormId,
                OuterHeadMaterialId = vm.OuterHeadMaterialId,
                OuterHeadMaterialFormId = vm.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = vm.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = vm.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = vm.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = vm.OuterHeadMaterialStrength,
                InnerShellThickness = vm.InnerShellThickness,
                InnerHeadThickness = vm.InnerHeadThickness,
                OuterShellThickness = vm.OuterShellThickness,
                OuterHeadThickness = vm.OuterHeadThickness,
                RoundedInnerShellThickness = vm.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = vm.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = vm.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = vm.RoundedOuterHeadThickness,
                DesignPressure = vm.DesignPressure,
                TestPressure = vm.TestPressure,
                StaticPressure = vm.StaticPressure,
                InnerTankHeadPulDiameter = vm.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = vm.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = vm.InnerTankHeadWeight,
                OuterTankHeadWeight = vm.OuterTankHeadWeight,
                InnerTankHeadWeldLength = vm.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = vm.InnerTankCircumferenceWeldLength,
                InnerTankShellWeldLength = vm.InnerTankShellWeldLength,
                InnerTankBombeWeldLength = vm.InnerTankBombeWeldLength,
                InnerTankTotalWeldLength = vm.InnerTankTotalWeldLength,
                OuterTankHeadWeldLength = vm.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = vm.OuterTankCircumferenceWeldLength,
                OuterTankShellWeldLength = vm.OuterTankShellWeldLength,
                OuterTankBombeWeldLength = vm.OuterTankBombeWeldLength,
                OuterTankTotalWeldLength = vm.OuterTankTotalWeldLength,
                StiffenerRingWeldLength = vm.StiffenerRingWeldLength,
                TotalWeldLength = vm.TotalWeldLength,
                TotalFilmCost = vm.TotalFilmCost,
                InnerTankTotalLength = vm.InnerTankTotalLength,
                OuterTankTotalLength = vm.OuterTankTotalLength,
                InnerVolume = vm.InnerVolume,
                OuterVolume = vm.OuterVolume,
                InnerSurfaceArea = vm.InnerSurfaceArea,
                OuterSurfaceArea = vm.OuterSurfaceArea,
                InnerTankWeight = vm.InnerTankWeight,
                OuterTankWeight = vm.OuterTankWeight,
                PerliteVolume = vm.PerliteVolume,
                PerliteWeight = vm.PerliteWeight,
                GasNitrogenVolume = vm.GasNitrogenVolume,
                LiquidNitrogenVolume = vm.LiquidNitrogenVolume,
                BucklingWaveNumber = vm.BucklingWaveNumber,
                ElasticBucklingPressureP1 = vm.ElasticBucklingPressureP1,
                PlasticCollapsePressureP2 = vm.PlasticCollapsePressureP2,
                DesignExternalPressurePv = vm.DesignExternalPressurePv,
                SupportRingRequired = vm.SupportRingRequired,
                SupportRingCriticalPressurePe = vm.SupportRingCriticalPressurePe,
                SupportRingStressX = vm.SupportRingStressX,
                SupportRingAllowableStress = vm.SupportRingAllowableStress,
                SupportRingAdequate = vm.SupportRingAdequate,
                HeadCollapsePressure = vm.HeadCollapsePressure,
                RequiredProfileCount = vm.RequiredProfileCount,
                ProfileDevelopedLength = vm.ProfileDevelopedLength,
                TotalProfileLength = vm.TotalProfileLength,
                ProfileWeldLength = vm.ProfileWeldLength,
                InnerDevelopedLength = vm.InnerDevelopedLength,
                OuterDevelopedLength = vm.OuterDevelopedLength,
                InnerSectorPlan1500 = vm.InnerSectorPlan1500,
                InnerSectorPlan2000 = vm.InnerSectorPlan2000,
                InnerSectorPlan2500 = vm.InnerSectorPlan2500,
                InnerSectorPlan3000 = vm.InnerSectorPlan3000,
                OuterSectorPlan1500 = vm.OuterSectorPlan1500,
                OuterSectorPlan2000 = vm.OuterSectorPlan2000,
                OuterSectorPlan2500 = vm.OuterSectorPlan2500,
                OuterSectorPlan3000 = vm.OuterSectorPlan3000
            };
        }

        private async Task PopulateManualCostLookupsAsync(EN13458DetailsVM vm)
        {
            vm.AvailableStockGroups = (await _stockProductGroupService.GetAllAsync())
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem($"{x.Name} (Kalem: {x.ItemCount}, Tutar: {x.TotalCost:N2})", x.Id.ToString()))
                .ToList();

            var stockCodes = (await _generatedStockCodeService.GetAllAsync())
                .OrderBy(x => x.GeneratedCode)
                .ToList();

            vm.AvailableStockCodes = stockCodes
                .OrderBy(x => x.GeneratedCode)
                .Select(x => new SelectListItem($"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}", x.Id.ToString()))
                .ToList();

            ViewBag.StockCodeOptions = stockCodes.Select(x => new
            {
                id = x.Id,
                text = $"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}",
                unitPrice = Convert.ToDouble(x.UnitPrice ?? 0m)
            }).ToList();
        }

        private async Task PopulateCostParameterLookupsAsync(EN13458MaterialCostTableDTO costTable)
        {
            var laborRates = await _context.LaborRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.Name).ToListAsync();
            var gugHourlyRates = await _context.GugHourlyRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.Name).ToListAsync();
            var overheadRates = await _context.OverheadRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.OverheadType).ThenBy(x => x.Name).ToListAsync();
            var bombeRates = await _context.BombeLaborRates.AsNoTracking().Where(x => x.Status != Status.Deleted).OrderBy(x => x.MaterialType).ThenBy(x => x.Name).ToListAsync();

            ViewBag.LaborRateOptions = laborRates.Select(x => new SelectListItem($"{x.HourlyRate:N2} TL/saat", x.Id.ToString(), costTable.SalesPrice?.LaborRateId == x.Id)).ToList();
            ViewBag.GugRateOptions = gugHourlyRates.Select(x => new SelectListItem($"{x.HourlyRate:N2} TL/saat", x.Id.ToString(), costTable.SalesPrice?.GugHourlyRateId == x.Id)).ToList();
            ViewBag.FinanceRateOptions = overheadRates.Where(x => string.Equals(x.OverheadType, "Finance", StringComparison.OrdinalIgnoreCase)).Select(x => new SelectListItem($"%{x.Percentage:N2}", x.Id.ToString(), costTable.SalesPrice?.FinanceOverheadRateId == x.Id)).ToList();
            ViewBag.GeneralManagementRateOptions = overheadRates.Where(x => string.Equals(x.OverheadType, "GeneralManagement", StringComparison.OrdinalIgnoreCase)).Select(x => new SelectListItem($"%{x.Percentage:N2}", x.Id.ToString(), costTable.SalesPrice?.GeneralManagementOverheadRateId == x.Id)).ToList();

            ViewBag.InnerBombeRateOptions = bombeRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} €/kg", x.Id.ToString(), costTable.InnerHeadBombeLaborRateId == x.Id)).ToList();
            ViewBag.OuterBombeRateOptions = bombeRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} €/kg", x.Id.ToString(), costTable.OuterHeadBombeLaborRateId == x.Id)).ToList();
        }

        private async Task<EN13458SpecificationVM?> BuildSpecificationVmAsync(Guid id, Guid? costAnalysisId)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return null;
            }

            var resultVm = MapResultVm(dto);
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

        private static void ApplySpecificationTemplate(WordprocessingDocument document, EN13458SpecificationVM specification)
        {
            var body = document.MainDocumentPart?.Document?.Body;
            if (body == null)
            {
                throw new InvalidOperationException("Şablon Word doküman gövdesi okunamadı.");
            }

            foreach (var paragraph in body.Descendants<Paragraph>().ToList())
            {
                var paragraphText = paragraph.InnerText?.Trim();
                if (string.IsNullOrWhiteSpace(paragraphText))
                {
                    continue;
                }

                if (paragraphText.StartsWith("Fluid:", StringComparison.OrdinalIgnoreCase))
                {
                    ReplaceParagraphText(paragraph, $"Fluid: {specification.FluidDisplay}");
                }
                else if (paragraphText.StartsWith("MAWP:", StringComparison.OrdinalIgnoreCase))
                {
                    ReplaceParagraphText(paragraph, $"MAWP: {specification.PressureDisplay}");
                }
                else if (paragraphText.StartsWith("SV:", StringComparison.OrdinalIgnoreCase))
                {
                    ReplaceParagraphText(paragraph, $"SV: Inner vessel safety valves set pressure will be {specification.PressureDisplay.ToLowerInvariant()}.");
                }
            }

            InsertAccessoryTable(body, specification.AccessoryItems);
            document.MainDocumentPart?.Document?.Save();
        }

        private static void ReplaceParagraphText(Paragraph paragraph, string newText)
        {
            paragraph.RemoveAllChildren<Run>();
            paragraph.Append(new Run(new Text(newText) { Space = SpaceProcessingModeValues.Preserve }));
        }

        private static void InsertAccessoryTable(Body body, IReadOnlyCollection<EN13458AccessoryItemVM> accessoryItems)
        {
            var anchorParagraph = body.Descendants<Paragraph>()
                .FirstOrDefault(x => string.Equals(x.InnerText?.Trim(), "Flow schematic: See P&ID below", StringComparison.OrdinalIgnoreCase));

            if (anchorParagraph == null)
            {
                return;
            }

            OpenXmlElement insertAfter = anchorParagraph;
            var heading = new Paragraph(new Run(new RunProperties(new Bold()), new Text("Accessories List")));
            insertAfter.InsertAfterSelf(heading);
            insertAfter = heading;

            if (accessoryItems.Count == 0)
            {
                var emptyParagraph = new Paragraph(new Run(new Text("No accessory added.")));
                insertAfter.InsertAfterSelf(emptyParagraph);
                return;
            }

            var table = new Table(
                new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 6 },
                        new BottomBorder { Val = BorderValues.Single, Size = 6 },
                        new LeftBorder { Val = BorderValues.Single, Size = 6 },
                        new RightBorder { Val = BorderValues.Single, Size = 6 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 })));

            table.Append(
                CreateAccessoryRow("Group", "Item", "Stock Code", "Description", "Qty", "Unit", true));

            foreach (var item in accessoryItems)
            {
                table.Append(CreateAccessoryRow(
                    item.GroupName,
                    item.ItemName,
                    item.StockCode,
                    item.Description,
                    item.Quantity.ToString("N2", CultureInfo.InvariantCulture),
                    item.Unit,
                    false));
            }

            insertAfter.InsertAfterSelf(table);
        }

        private static TableRow CreateAccessoryRow(string group, string item, string stockCode, string description, string quantity, string unit, bool isHeader)
        {
            return new TableRow(
                CreateAccessoryCell(group, isHeader),
                CreateAccessoryCell(item, isHeader),
                CreateAccessoryCell(stockCode, isHeader),
                CreateAccessoryCell(description, isHeader),
                CreateAccessoryCell(quantity, isHeader),
                CreateAccessoryCell(unit, isHeader));
        }

        private static TableCell CreateAccessoryCell(string text, bool bold)
        {
            var runProperties = new RunProperties();
            if (bold)
            {
                runProperties.Append(new Bold());
            }

            return new TableCell(
                new Paragraph(new Run(runProperties, new Text(text ?? string.Empty) { Space = SpaceProcessingModeValues.Preserve })));
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

            ViewBag.Materials = materials.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            ViewBag.MaterialGroups = materials
                .Select(x => (x.Group ?? string.Empty).Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .Select(x => new SelectListItem(x, x))
                .ToList();

            ViewBag.MaterialsByGroup = materials
                .Where(x => !string.IsNullOrWhiteSpace(x.Group))
                .GroupBy(x => x.Group.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.Select(x => new { value = x.Id.ToString(), text = x.Name }).ToList(), StringComparer.OrdinalIgnoreCase);

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

            ViewBag.MaterialExternalProperties = materials.ToDictionary(x => x.Id.ToString(), x => new { elasticModulus = x.ElasticModulus, yieldFactorK = x.YieldFactorK });
        }

        private static void WriteSectionHeader(ExcelWorksheet ws, int row, string title)
        {
            ws.Cells[row, 1].Value = title;
            ws.Cells[row, 1, row, 2].Merge = true;
            ws.Cells[row, 1, row, 2].Style.Font.Bold = true;
            ws.Cells[row, 1, row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[row, 1, row, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);
            ws.Cells[row, 1, row, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
        }

        private static int WriteKeyValues(ExcelWorksheet ws, int startRow, List<(string Label, object Value)> items)
        {
            var row = startRow;
            foreach (var item in items)
            {
                ws.Cells[row, 1].Value = item.Label;
                ws.Cells[row, 2].Value = item.Value;
                ws.Cells[row, 1, row, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                row++;
            }

            return row + 1;
        }

        private static int WriteSection(ExcelWorksheet ws, int startRow, string title, List<(string Label, object Value)> items)
        {
            WriteSectionHeader(ws, startRow, title);
            return WriteKeyValues(ws, startRow + 1, items);
        }
    }
}
