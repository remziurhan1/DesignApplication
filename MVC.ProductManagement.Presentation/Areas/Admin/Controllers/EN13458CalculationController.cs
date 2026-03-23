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

        public EN13458CalculationController(
            IEN13458CalculationServices service,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IStorageTypeService storageTypeService,
            IGeneratedStockCodeService generatedStockCodeService,
            IStockProductGroupService stockProductGroupService,
            AppDbContext context)
        {
            _service = service;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _storageTypeService = storageTypeService;
            _generatedStockCodeService = generatedStockCodeService;
            _stockProductGroupService = stockProductGroupService;
            _context = context;
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
        public async Task<IActionResult> Details(Guid id, Guid? costAnalysisId = null)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapDetailsVm(dto);
            await PopulateResultDisplayNamesAsync(vm);
            vm.CostAnalyses = await _service.GetCostAnalysesAsync(id);

            return View(vm);
        }

        [HttpGet]
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

            using var stream = new MemoryStream();
            using (var document = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
            {
                var mainPart = document.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());

                var body = mainPart.Document.Body;
                if (body == null)
                {
                    throw new InvalidOperationException("Word dokümanı oluşturulamadı.");
                }

                body.Append(
                    CreateParagraph(specification.DocumentTitle, true, 30, JustificationValues.Center),
                    CreateParagraph($"Doküman Tarihi: {specification.GeneratedAtUtc:dd.MM.yyyy HH:mm} UTC", false, 20, JustificationValues.Center),
                    CreateParagraph($"Revizyon: {specification.RevisionCode}", false, 20, JustificationValues.Center),
                    CreateParagraph(string.Empty));

                AppendWordTable(body, "Genel Bilgiler", specification.SummaryItems);
                AppendWordTable(body, "Malzeme ve Konstrüksiyon", specification.MaterialItems);
                AppendWordTable(body, "Performans ve Hesap Sonuçları", specification.PerformanceItems);
                AppendAccessoryTable(body, specification.AccessoryItems);
                AppendBulletList(body, "Kapsam", specification.ScopeItems);
                AppendBulletList(body, "Standart Notlar", specification.StandardNotes);

                mainPart.Document.Save();
            }

            var safeName = string.Concat((specification.Name ?? "EN13458_Sartname").Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)));
            var fileName = $"EN13458_Sartname_{safeName}_{DateTime.UtcNow:yyyyMMddHHmmss}.docx";

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

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return RedirectToAction(nameof(Cost), new { id, costAnalysisId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            vm.OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength;
            vm.OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength;
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
                OuterTankHeadWeldLength = vm.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = vm.OuterTankCircumferenceWeldLength,
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

            ViewBag.InnerBombeRateOptions = bombeRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} TL/kg", x.Id.ToString(), costTable.InnerHeadBombeLaborRateId == x.Id)).ToList();
            ViewBag.OuterBombeRateOptions = bombeRates.Select(x => new SelectListItem($"{x.MaterialType} - {x.RatePerKg:N2} TL/kg", x.Id.ToString(), costTable.OuterHeadBombeLaborRateId == x.Id)).ToList();
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
            var totalLengthMm = Math.Max(resultVm.InnerTankTotalLength, resultVm.OuterTankTotalLength);
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
                Name = resultVm.Name,
                DocumentTitle = $"{resultVm.StorageTypeName} Depolama Tankı Teknik Şartnamesi",
                RevisionCode = string.IsNullOrWhiteSpace(costTable.RevisionCode) ? "Ön İzleme" : costTable.RevisionCode,
                GeneratedAtUtc = DateTime.UtcNow,
                ProductDescription = $"{resultVm.StorageTypeName} servisinde kullanılmak üzere EN 13458 standardına göre tasarlanan, vakum-perlit izolasyonlu kriyojenik depolama tankı.",
                IntendedService = $"{resultVm.StorageTypeName} depolama ve sevk operasyonları",
                DesignCodeText = "TS EN 13458 / EN 13445 tasarım yaklaşımı",
                InsulationText = "Çift cidar, yüksek vakum ve perlit dolgu izolasyon",
                OrientationText = resultVm.TankOrientation == TankOrientation.Horizontal ? "Yatay" : "Dikey",
                ColdStretchText = resultVm.IsColdStretchApplied ? "Uygulanmıştır" : "Uygulanmamıştır",
                NetVolumeM3 = resultVm.InnerVolume / 1000d,
                GrossVolumeM3 = resultVm.OuterVolume / 1000d,
                WorkingPressureBar = resultVm.DesignPressure > 0 ? resultVm.DesignPressure : resultVm.Pressure,
                TestPressureBar = resultVm.TestPressure,
                StaticPressureBar = resultVm.StaticPressure,
                InnerDiameterMm = resultVm.OuterDiameter,
                OuterDiameterMm = resultVm.OuterTankDiameter,
                ShellLengthMm = resultVm.ShellLength,
                TotalLengthMm = totalLengthMm,
                LiquidDensity = resultVm.LiquidDensity,
                PerliteWeightKg = resultVm.PerliteWeight,
                InnerTankWeightKg = resultVm.InnerTankWeight,
                OuterTankWeightKg = resultVm.OuterTankWeight,
                TotalWeldLengthM = resultVm.TotalWeldLength,
                InnerShellMaterial = resultVm.InnerShellMaterialName,
                InnerHeadMaterial = resultVm.InnerHeadMaterialName,
                OuterShellMaterial = resultVm.OuterShellMaterialName,
                OuterHeadMaterial = resultVm.OuterHeadMaterialName,
                InnerShellForm = resultVm.InnerShellMaterialFormName,
                InnerHeadForm = resultVm.InnerHeadMaterialFormName,
                OuterShellForm = resultVm.OuterShellMaterialFormName,
                OuterHeadForm = resultVm.OuterHeadMaterialFormName,
                InnerShellThicknessMm = resultVm.RoundedInnerShellThickness,
                InnerHeadThicknessMm = resultVm.RoundedInnerHeadThickness,
                OuterShellThicknessMm = resultVm.RoundedOuterShellThickness,
                OuterHeadThicknessMm = resultVm.RoundedOuterHeadThickness,
                SummaryItems = BuildSpecificationSummaryItems(resultVm, costTable, totalLengthMm),
                MaterialItems = BuildSpecificationMaterialItems(resultVm),
                PerformanceItems = BuildSpecificationPerformanceItems(resultVm),
                AccessoryItems = accessoryItems,
                ScopeItems = BuildSpecificationScopeItems(resultVm),
                StandardNotes = BuildSpecificationStandardNotes(costTable)
            };
        }

        private static List<EN13458SpecificationItemVM> BuildSpecificationSummaryItems(EN13458ResultVM resultVm, EN13458MaterialCostTableDTO costTable, double totalLengthMm)
        {
            return new List<EN13458SpecificationItemVM>
            {
                CreateSpecItem("Tank adı", resultVm.Name),
                CreateSpecItem("Depolanan akışkan", resultVm.StorageTypeName),
                CreateSpecItem("Tasarım standardı", "TS EN 13458"),
                CreateSpecItem("Tank yönelimi", resultVm.TankOrientation.ToString()),
                CreateSpecItem("Net hacim", $"{resultVm.InnerVolume / 1000d:N2} m³"),
                CreateSpecItem("Brüt hacim", $"{resultVm.OuterVolume / 1000d:N2} m³"),
                CreateSpecItem("İç tank çapı", $"{resultVm.OuterDiameter:N2} mm"),
                CreateSpecItem("Dış tank çapı", $"{resultVm.OuterTankDiameter:N2} mm"),
                CreateSpecItem("Silindirik boy", $"{resultVm.ShellLength:N2} mm"),
                CreateSpecItem("Toplam boy", $"{totalLengthMm:N2} mm"),
                CreateSpecItem("Çalışma/tasarım basıncı", $"{(resultVm.DesignPressure > 0 ? resultVm.DesignPressure : resultVm.Pressure):N2} bar"),
                CreateSpecItem("Test basıncı", $"{resultVm.TestPressure:N2} bar"),
                CreateSpecItem("Sıvı yoğunluğu", $"{resultVm.LiquidDensity:N2} kg/m³"),
                CreateSpecItem("İzolasyon tipi", "Vakum + perlit"),
                CreateSpecItem("Revizyon", string.IsNullOrWhiteSpace(costTable.RevisionCode) ? "Ön İzleme" : costTable.RevisionCode)
            };
        }

        private static List<EN13458SpecificationItemVM> BuildSpecificationMaterialItems(EN13458ResultVM resultVm)
        {
            return new List<EN13458SpecificationItemVM>
            {
                CreateSpecItem("İç gövde malzemesi", $"{resultVm.InnerShellMaterialName} / {resultVm.InnerShellMaterialFormName}"),
                CreateSpecItem("İç bombe malzemesi", $"{resultVm.InnerHeadMaterialName} / {resultVm.InnerHeadMaterialFormName}"),
                CreateSpecItem("Dış gövde malzemesi", $"{resultVm.OuterShellMaterialName} / {resultVm.OuterShellMaterialFormName}"),
                CreateSpecItem("Dış bombe malzemesi", $"{resultVm.OuterHeadMaterialName} / {resultVm.OuterHeadMaterialFormName}"),
                CreateSpecItem("İç gövde kalınlığı", $"{resultVm.RoundedInnerShellThickness:N2} mm"),
                CreateSpecItem("İç bombe kalınlığı", $"{resultVm.RoundedInnerHeadThickness:N2} mm"),
                CreateSpecItem("Dış gövde kalınlığı", $"{resultVm.RoundedOuterShellThickness:N2} mm"),
                CreateSpecItem("Dış bombe kalınlığı", $"{resultVm.RoundedOuterHeadThickness:N2} mm"),
                CreateSpecItem("İç gövde akma dayanımı", $"{resultVm.InnerShellMaterialStrength:N2} MPa"),
                CreateSpecItem("İç bombe akma dayanımı", $"{resultVm.InnerHeadMaterialStrength:N2} MPa"),
                CreateSpecItem("Dış gövde akma dayanımı", $"{resultVm.OuterShellMaterialStrength:N2} MPa"),
                CreateSpecItem("Dış bombe akma dayanımı", $"{resultVm.OuterHeadMaterialStrength:N2} MPa")
            };
        }

        private static List<EN13458SpecificationItemVM> BuildSpecificationPerformanceItems(EN13458ResultVM resultVm)
        {
            var totalProfileLengthMm = resultVm.TotalProfileLength > 0 ? resultVm.TotalProfileLength : resultVm.RequiredProfileCount * resultVm.ProfileDevelopedLength;

            return new List<EN13458SpecificationItemVM>
            {
                CreateSpecItem("Toplam kaynak uzunluğu", $"{resultVm.TotalWeldLength:N2} m"),
                CreateSpecItem("Perlit hacmi", $"{resultVm.PerliteVolume:N2}"),
                CreateSpecItem("Perlit ağırlığı", $"{resultVm.PerliteWeight:N2} kg"),
                CreateSpecItem("Gaz azot hacmi", $"{resultVm.GasNitrogenVolume:N2}"),
                CreateSpecItem("Sıvı azot hacmi", $"{resultVm.LiquidNitrogenVolume:N2}"),
                CreateSpecItem("İç tank ağırlığı", $"{resultVm.InnerTankWeight:N2} kg"),
                CreateSpecItem("Dış tank ağırlığı", $"{resultVm.OuterTankWeight:N2} kg"),
                CreateSpecItem("Profil adedi", $"{resultVm.RequiredProfileCount}"),
                CreateSpecItem("Toplam profil boyu", $"{totalProfileLengthMm:N2} mm"),
                CreateSpecItem("Head collapse pressure", $"{resultVm.HeadCollapsePressure:N2} bar"),
                CreateSpecItem("Destek ring gereksinimi", resultVm.SupportRingRequired ? "Gerekli" : "Gerekli değil"),
                CreateSpecItem("Destek ring yeterlilik", resultVm.SupportRingAdequate ? "Yeterli" : "Yetersiz")
            };
        }

        private static List<string> BuildSpecificationScopeItems(EN13458ResultVM resultVm)
        {
            return new List<string>
            {
                $"{resultVm.StorageTypeName} servisinde kullanılacak kriyojenik depolama tankı tasarımı, üretimi ve fonksiyon testleri.",
                "İç ve dış tank, destek profilleri, perlit izolasyon ve ilgili kaynaklı imalat operasyonları.",
                "Malzeme sertifikaları, imalat izlenebilirliği ve sevk öncesi kalite kontrol dokümantasyonu.",
                "Müşteri tarafından sonradan eklenen ekipmanların aksesuar grubu altında stok kodları ile birlikte listelenmesi."
            };
        }

        private static List<string> BuildSpecificationStandardNotes(EN13458MaterialCostTableDTO costTable)
        {
            return new List<string>
            {
                "Bu şartname görünümünde yer alan hesap verileri sistemdeki kayıtlı EN13458 hesabından otomatik alınır; standart açıklama metinleri sabittir.",
                "İmalat öncesi nihai genel yerleşim, nozzle detayı ve kalite planı üretici tarafından onaya sunulmalıdır.",
                "Malzeme ve aksesuar listesi seçilen maliyet revizyonuna göre hazırlanır.",
                $"Bu doküman oluşturulurken kullanılan maliyet revizyonu: {(string.IsNullOrWhiteSpace(costTable.RevisionCode) ? "Ön İzleme" : costTable.RevisionCode)}."
            };
        }

        private static EN13458SpecificationItemVM CreateSpecItem(string label, string value)
            => new() { Label = label, Value = value };

        private static Paragraph CreateParagraph(string text, bool bold = false, int fontSize = 22, JustificationValues? justification = null)
        {
            var runProperties = new RunProperties(new DocumentFormat.OpenXml.Wordprocessing.FontSize { Val = fontSize.ToString() });
            if (bold)
            {
                runProperties.Append(new Bold());
            }

            var effectiveJustification = justification ?? JustificationValues.Left;

            return new Paragraph(
                new ParagraphProperties(new Justification { Val = effectiveJustification }),
                new Run(runProperties, new Text(text ?? string.Empty) { Space = SpaceProcessingModeValues.Preserve }));
        }

        private static void AppendWordTable(Body body, string title, IEnumerable<EN13458SpecificationItemVM> items)
        {
            body.Append(CreateParagraph(title, true, 24));

            var table = new Table(
                new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 8 },
                        new BottomBorder { Val = BorderValues.Single, Size = 8 },
                        new LeftBorder { Val = BorderValues.Single, Size = 8 },
                        new RightBorder { Val = BorderValues.Single, Size = 8 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 })));

            foreach (var item in items)
            {
                table.Append(new TableRow(
                    CreateTableCell(item.Label, true),
                    CreateTableCell(item.Value)));
            }

            body.Append(table);
            body.Append(CreateParagraph(string.Empty));
        }

        private static void AppendAccessoryTable(Body body, IReadOnlyCollection<EN13458AccessoryItemVM> accessoryItems)
        {
            body.Append(CreateParagraph("Aksesuar Grubu", true, 24));

            if (accessoryItems.Count == 0)
            {
                body.Append(CreateParagraph("Seçili revizyonda eklenmiş aksesuar bulunmuyor."));
                body.Append(CreateParagraph(string.Empty));
                return;
            }

            var table = new Table(
                new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 8 },
                        new BottomBorder { Val = BorderValues.Single, Size = 8 },
                        new LeftBorder { Val = BorderValues.Single, Size = 8 },
                        new RightBorder { Val = BorderValues.Single, Size = 8 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 })));

            table.Append(new TableRow(
                CreateTableCell("Grup", true),
                CreateTableCell("Ürün", true),
                CreateTableCell("Stok Kodu", true),
                CreateTableCell("Açıklama", true),
                CreateTableCell("Miktar", true),
                CreateTableCell("Birim", true)));

            foreach (var item in accessoryItems)
            {
                table.Append(new TableRow(
                    CreateTableCell(item.GroupName),
                    CreateTableCell(item.ItemName),
                    CreateTableCell(item.StockCode),
                    CreateTableCell(item.Description),
                    CreateTableCell(item.Quantity.ToString("N2")),
                    CreateTableCell(item.Unit)));
            }

            body.Append(table);
            body.Append(CreateParagraph(string.Empty));
        }

        private static void AppendBulletList(Body body, string title, IEnumerable<string> items)
        {
            body.Append(CreateParagraph(title, true, 24));
            foreach (var item in items)
            {
                body.Append(CreateParagraph($"• {item}"));
            }

            body.Append(CreateParagraph(string.Empty));
        }

        private static TableCell CreateTableCell(string text, bool bold = false)
        {
            var runProperties = new RunProperties(new DocumentFormat.OpenXml.Wordprocessing.FontSize { Val = "20" });
            if (bold)
            {
                runProperties.Append(new Bold());
            }

            return new TableCell(
                new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }),
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
