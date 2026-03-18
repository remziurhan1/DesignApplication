using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypePropertiesRepository;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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

        public EN13458CalculationController(
            IEN13458CalculationServices service,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IStorageTypeService storageTypeService,
            IGeneratedStockCodeService generatedStockCodeService,
            IStockProductGroupService stockProductGroupService)
        {
            _service = service;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _storageTypeService = storageTypeService;
            _generatedStockCodeService = generatedStockCodeService;
            _stockProductGroupService = stockProductGroupService;
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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new EN13458DetailsVM
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
                WeldLength1500 = dto.WeldLength1500,
                WeldLength2000 = dto.WeldLength2000,
                WeldLength2500 = dto.WeldLength2500,
                WeldLength3000 = dto.WeldLength3000,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = dto.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = dto.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
                InnerShellThickness = dto.InnerShellThickness,
                InnerHeadThickness = dto.InnerHeadThickness,
                OuterShellThickness = dto.OuterShellThickness,
                OuterHeadThickness = dto.OuterHeadThickness,
                RoundedInnerShellThickness = dto.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = dto.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
                DesignPressure = dto.DesignPressure,
                TestPressure = dto.TestPressure,
                StaticPressure = dto.StaticPressure,
                InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = dto.InnerTankHeadWeight,
                OuterTankHeadWeight = dto.OuterTankHeadWeight,
                InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
                OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
                TotalWeldLength = dto.TotalWeldLength,
                TotalFilmCost = dto.TotalFilmCost,
                InnerTankTotalLength = dto.InnerTankTotalLength,
                OuterTankTotalLength = dto.OuterTankTotalLength,
                InnerVolume = dto.InnerVolume,
                OuterVolume = dto.OuterVolume,
                InnerSurfaceArea = dto.InnerSurfaceArea,
                OuterSurfaceArea = dto.OuterSurfaceArea,
                InnerTankWeight = dto.InnerTankWeight,
                OuterTankWeight = dto.OuterTankWeight,
                PerliteVolume = dto.PerliteVolume,
                PerliteWeight = dto.PerliteWeight,
                GasNitrogenVolume = dto.GasNitrogenVolume,
                LiquidNitrogenVolume = dto.LiquidNitrogenVolume,
                BucklingWaveNumber = dto.BucklingWaveNumber,
                ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1,
                PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2,
                DesignExternalPressurePv = dto.DesignExternalPressurePv,
                SupportRingRequired = dto.SupportRingRequired,
                SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe,
                SupportRingStressX = dto.SupportRingStressX,
                SupportRingAllowableStress = dto.SupportRingAllowableStress,
                SupportRingAdequate = dto.SupportRingAdequate,
                HeadCollapsePressure = dto.HeadCollapsePressure,
                RequiredProfileCount = dto.RequiredProfileCount,
                ProfileDevelopedLength = dto.ProfileDevelopedLength,
                TotalProfileLength = dto.TotalProfileLength,
                ProfileWeldLength = dto.ProfileWeldLength,

                InnerDevelopedLength = dto.InnerDevelopedLength,
                OuterDevelopedLength = dto.OuterDevelopedLength,
                InnerSectorPlan1500 = dto.InnerSectorPlan1500,
                InnerSectorPlan2000 = dto.InnerSectorPlan2000,
                InnerSectorPlan2500 = dto.InnerSectorPlan2500,
                InnerSectorPlan3000 = dto.InnerSectorPlan3000,
                OuterSectorPlan1500 = dto.OuterSectorPlan1500,
                OuterSectorPlan2000 = dto.OuterSectorPlan2000,
                OuterSectorPlan2500 = dto.OuterSectorPlan2500,
                OuterSectorPlan3000 = dto.OuterSectorPlan3000,
            };

            await PopulateResultDisplayNamesAsync(vm);
            await PopulateManualCostLookupsAsync(vm);
            var costTable = await GetSavedOrBuiltCostTableAsync(dto);
            ViewBag.CostTable = costTable;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ExportDetailExcel(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new EN13458DetailsVM
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
                WeldLength1500 = dto.WeldLength1500,
                WeldLength2000 = dto.WeldLength2000,
                WeldLength2500 = dto.WeldLength2500,
                WeldLength3000 = dto.WeldLength3000,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = dto.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = dto.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
                InnerShellThickness = dto.InnerShellThickness,
                InnerHeadThickness = dto.InnerHeadThickness,
                OuterShellThickness = dto.OuterShellThickness,
                OuterHeadThickness = dto.OuterHeadThickness,
                RoundedInnerShellThickness = dto.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = dto.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
                DesignPressure = dto.DesignPressure,
                TestPressure = dto.TestPressure,
                StaticPressure = dto.StaticPressure,
                InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = dto.InnerTankHeadWeight,
                OuterTankHeadWeight = dto.OuterTankHeadWeight,
                InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
                OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
                TotalWeldLength = dto.TotalWeldLength,
                TotalFilmCost = dto.TotalFilmCost,
                InnerTankTotalLength = dto.InnerTankTotalLength,
                OuterTankTotalLength = dto.OuterTankTotalLength,
                InnerVolume = dto.InnerVolume,
                OuterVolume = dto.OuterVolume,
                InnerSurfaceArea = dto.InnerSurfaceArea,
                OuterSurfaceArea = dto.OuterSurfaceArea,
                InnerTankWeight = dto.InnerTankWeight,
                OuterTankWeight = dto.OuterTankWeight,
                PerliteVolume = dto.PerliteVolume,
                PerliteWeight = dto.PerliteWeight,
                GasNitrogenVolume = dto.GasNitrogenVolume,
                LiquidNitrogenVolume = dto.LiquidNitrogenVolume,
                BucklingWaveNumber = dto.BucklingWaveNumber,
                ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1,
                PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2,
                DesignExternalPressurePv = dto.DesignExternalPressurePv,
                SupportRingRequired = dto.SupportRingRequired,
                SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe,
                SupportRingStressX = dto.SupportRingStressX,
                SupportRingAllowableStress = dto.SupportRingAllowableStress,
                SupportRingAdequate = dto.SupportRingAdequate,
                HeadCollapsePressure = dto.HeadCollapsePressure,
                RequiredProfileCount = dto.RequiredProfileCount,
                ProfileDevelopedLength = dto.ProfileDevelopedLength,
                TotalProfileLength = dto.TotalProfileLength,
                ProfileWeldLength = dto.ProfileWeldLength,
                InnerDevelopedLength = dto.InnerDevelopedLength,
                OuterDevelopedLength = dto.OuterDevelopedLength,
                InnerSectorPlan1500 = dto.InnerSectorPlan1500,
                InnerSectorPlan2000 = dto.InnerSectorPlan2000,
                InnerSectorPlan2500 = dto.InnerSectorPlan2500,
                InnerSectorPlan3000 = dto.InnerSectorPlan3000,
                OuterSectorPlan1500 = dto.OuterSectorPlan1500,
                OuterSectorPlan2000 = dto.OuterSectorPlan2000,
                OuterSectorPlan2500 = dto.OuterSectorPlan2500,
                OuterSectorPlan3000 = dto.OuterSectorPlan3000
            };

            await PopulateResultDisplayNamesAsync(vm);

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
                ("Bombe Malzeme Id", vm.InnerHeadMaterialId),
                ("Bombe Malzeme Formu", vm.InnerHeadMaterialFormName),
                ("Bombe Malzeme Formu Id", vm.InnerHeadMaterialFormId),
                ("Gövde Malzeme Id", vm.InnerShellMaterialId),
                ("Gövde Malzeme Formu Id", vm.InnerShellMaterialFormId),
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
                ("Bombe Malzeme Id", vm.OuterHeadMaterialId),
                ("Bombe Malzeme Formu", vm.OuterHeadMaterialFormName),
                ("Bombe Malzeme Formu Id", vm.OuterHeadMaterialFormId),
                ("Gövde Malzeme Id", vm.OuterShellMaterialId),
                ("Gövde Malzeme Formu Id", vm.OuterShellMaterialFormId),
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

            var costTable = await GetSavedOrBuiltCostTableAsync(dto);
            if (costTable != null)
            {
                var costWs = package.Workbook.Worksheets.Add("Maliyet Detay");
                var costRow = 1;

                WriteSectionHeader(costWs, costRow++, "Maliyet Grup Toplamları");
                costRow = WriteKeyValues(costWs, costRow,
                    costTable.GroupTotals
                        .OrderBy(x => x.CostGroupCode)
                        .Select(x => ($"{x.CostGroupCode} - {x.CostGroupName}", (object)x.TotalCost))
                        .ToList());

                costRow += 1;
                WriteSectionHeader(costWs, costRow++, "Maliyet Kalemleri");
                costWs.Cells[costRow, 1].Value = "Grup";
                costWs.Cells[costRow, 2].Value = "Kalem";
                costWs.Cells[costRow, 3].Value = "Stok Kodu";
                costWs.Cells[costRow, 4].Value = "Malzeme";
                costWs.Cells[costRow, 5].Value = "Miktar";
                costWs.Cells[costRow, 6].Value = "Birim";
                costWs.Cells[costRow, 7].Value = "Birim Fiyat";
                costWs.Cells[costRow, 8].Value = "Tutar";

                using (var header = costWs.Cells[costRow, 1, costRow, 8])
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
                    costWs.Cells[costRow, 7].Value = item.UnitPrice;
                    costWs.Cells[costRow, 8].Value = item.ItemCost;

                    using var dataRange = costWs.Cells[costRow, 1, costRow, 8];
                    dataRange.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                costWs.Cells[costWs.Dimension.Address].AutoFitColumns();
            }

            ws.Cells[ws.Dimension.Address].AutoFitColumns();
            var safeName = string.Concat((vm.Name ?? "EN13458").Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)));
            var fileName = $"EN13458_Detay_{safeName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            return File(
                package.GetAsByteArray(),
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
        public async Task<IActionResult> Calculate(EN13458CalculateVM vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View(vm);
            }

            if (vm.StorageTypeId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), "Lütfen bir depolama tipi seçin.");
                await LoadLookupsAsync();
                return View(vm);
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
                return View(vm);
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
                var resultVm = MapResultVm(result);
                await PopulateResultDisplayNamesAsync(resultVm);
                ViewBag.CostTable = await _service.BuildMaterialCostTableAsync(result);

                return View("Result", resultVm);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadLookupsAsync();
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EN13458ResultVM vm)
        {
            var dto = MapResultDto(vm);
            var saved = await _service.SaveAsync(dto, User?.Identity?.Name ?? "AdminUser");
            return RedirectToAction(nameof(Details), new { id = saved.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStockCode(Guid id, Guid generatedStockCodeId, double quantity = 1)
        {
            try
            {
                await _service.AddManualStockCodeCostAsync(id, generatedStockCodeId, quantity, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Stok kodu maliyete eklendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStockGroup(Guid id, Guid stockProductGroupId, double multiplier = 1)
        {
            try
            {
                await _service.AddManualStockGroupCostAsync(id, stockProductGroupId, multiplier, User?.Identity?.Name ?? "AdminUser");
                TempData["SuccessMessage"] = "Stok kod grubu maliyete eklendi.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCostItem(Guid id, Guid costDetailId)
        {
            try
            {
                await _service.RemoveCostDetailAsync(id, costDetailId);
                TempData["SuccessMessage"] = "Maliyet kalemi kaldırıldı.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        private EN13458ResultVM MapResultVm(EN13458ResultDTO dto)
        {
            var vm = new EN13458ResultVM
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
                WeldLength1500 = dto.WeldLength1500,
                WeldLength2000 = dto.WeldLength2000,
                WeldLength2500 = dto.WeldLength2500,
                WeldLength3000 = dto.WeldLength3000,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = dto.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = dto.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
                InnerShellThickness = dto.InnerShellThickness,
                InnerHeadThickness = dto.InnerHeadThickness,
                OuterShellThickness = dto.OuterShellThickness,
                OuterHeadThickness = dto.OuterHeadThickness,
                RoundedInnerShellThickness = dto.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = dto.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
                DesignPressure = dto.DesignPressure,
                TestPressure = dto.TestPressure,
                StaticPressure = dto.StaticPressure,
                InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = dto.InnerTankHeadWeight,
                OuterTankHeadWeight = dto.OuterTankHeadWeight,
                InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
                OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
                TotalWeldLength = dto.TotalWeldLength,
                TotalFilmCost = dto.TotalFilmCost,
                InnerTankTotalLength = dto.InnerTankTotalLength,
                OuterTankTotalLength = dto.OuterTankTotalLength,
                InnerVolume = dto.InnerVolume,
                OuterVolume = dto.OuterVolume,
                InnerSurfaceArea = dto.InnerSurfaceArea,
                OuterSurfaceArea = dto.OuterSurfaceArea,
                InnerTankWeight = dto.InnerTankWeight,
                OuterTankWeight = dto.OuterTankWeight,
                PerliteVolume = dto.PerliteVolume,
                PerliteWeight = dto.PerliteWeight,
                GasNitrogenVolume = dto.GasNitrogenVolume,
                LiquidNitrogenVolume = dto.LiquidNitrogenVolume,
                BucklingWaveNumber = dto.BucklingWaveNumber,
                ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1,
                PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2,
                DesignExternalPressurePv = dto.DesignExternalPressurePv,
                SupportRingRequired = dto.SupportRingRequired,
                SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe,
                SupportRingStressX = dto.SupportRingStressX,
                SupportRingAllowableStress = dto.SupportRingAllowableStress,
                SupportRingAdequate = dto.SupportRingAdequate,
                HeadCollapsePressure = dto.HeadCollapsePressure,
                RequiredProfileCount = dto.RequiredProfileCount,
                ProfileDevelopedLength = dto.ProfileDevelopedLength,
                TotalProfileLength = dto.TotalProfileLength,
                ProfileWeldLength = dto.ProfileWeldLength,
                InnerDevelopedLength = dto.InnerDevelopedLength,
                OuterDevelopedLength = dto.OuterDevelopedLength,
                InnerSectorPlan1500 = dto.InnerSectorPlan1500,
                InnerSectorPlan2000 = dto.InnerSectorPlan2000,
                InnerSectorPlan2500 = dto.InnerSectorPlan2500,
                InnerSectorPlan3000 = dto.InnerSectorPlan3000,
                OuterSectorPlan1500 = dto.OuterSectorPlan1500,
                OuterSectorPlan2000 = dto.OuterSectorPlan2000,
                OuterSectorPlan2500 = dto.OuterSectorPlan2500,
                OuterSectorPlan3000 = dto.OuterSectorPlan3000
            };

            return vm;
        }

        private static EN13458ResultDTO MapResultDto(EN13458ResultVM vm)
        {
            var dto = new EN13458ResultDTO
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

            return dto;
        }


        private async Task<EN13458MaterialCostTableDTO> GetSavedOrBuiltCostTableAsync(EN13458ResultDTO dto)
        {
            var saved = await _service.GetSavedMaterialCostTableAsync(dto.Id);
            return saved ?? await _service.BuildMaterialCostTableAsync(dto);
        }

        private async Task PopulateManualCostLookupsAsync(EN13458DetailsVM vm)
        {
            vm.AvailableStockGroups = (await _stockProductGroupService.GetAllAsync())
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem($"{x.Name} (Kalem: {x.ItemCount}, Tutar: {x.TotalCost:N2})", x.Id.ToString()))
                .ToList();

            vm.AvailableStockCodes = (await _generatedStockCodeService.GetAllAsync())
                .OrderBy(x => x.GeneratedCode)
                .Select(x => new SelectListItem($"{x.GeneratedCode} - {(!string.IsNullOrWhiteSpace(x.Description) ? x.Description : x.RuleName)}", x.Id.ToString()))
                .ToList();
        }

        private async Task PopulateResultDisplayNamesAsync(EN13458ResultVM vm)
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();
            var storageTypes = await _storageTypeService.GetAllAsync();

            var materialMap = materials.ToDictionary(x => x.Id, x => x.Name);
            var formMap = forms.ToDictionary(
                x => x.Id,
                x => $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]");
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

            ViewBag.Materials = materials
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

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
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new { value = x.Id.ToString(), text = x.Name }).ToList(),
                    StringComparer.OrdinalIgnoreCase);

            ViewBag.MaterialExternalProperties = materials
                .ToDictionary(
                    x => x.Id.ToString(),
                    x => new
                    {
                        elasticModulus = x.ElasticModulus,
                        yieldFactorK = x.YieldFactorK
                    });

            ViewBag.MaterialFormsByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new
                    {
                        value = x.Id.ToString(),
                        text = $"{x.FormType} [{x.ThicknessMin.ToString("0.###", CultureInfo.InvariantCulture)}-{x.ThicknessMax.ToString("0.###", CultureInfo.InvariantCulture)}]",
                        formType = x.FormType.ToString(),
                        momentOfInertia = x.MomentOfInertia,
                        sectionArea = x.SectionArea,
                        sectionModulus = x.SectionModulus
                    }).ToList());

            ViewBag.MaterialFormTypesByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => x.FormType.ToString()).Distinct().OrderBy(x => x).ToList());

            ViewBag.MaterialForms = forms
                .Select(x => new SelectListItem($"{x.FormType} [{x.ThicknessMin.ToString("0.###", CultureInfo.InvariantCulture)}-{x.ThicknessMax.ToString("0.###", CultureInfo.InvariantCulture)}]", x.Id.ToString()))
                .ToList();

            var storageTypeList = storageTypes.Data ?? new System.Collections.Generic.List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>();

            ViewBag.StorageTypes = storageTypeList
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.StorageTypeDensities = storageTypeList
                .ToDictionary(x => x.Id.ToString(), x => x.Density);
        }

        private static int WriteSection(ExcelWorksheet ws, int row, string title, IReadOnlyCollection<(string Label, object Value)> values)
        {
            WriteSectionHeader(ws, row++, title);
            row = WriteKeyValues(ws, row, values);
            return row;
        }

        private static void WriteSectionHeader(ExcelWorksheet ws, int row, string title)
        {
            ws.Cells[row, 1].Value = title;
            ws.Cells[row, 1, row, 2].Merge = true;
            ws.Cells[row, 1, row, 2].Style.Font.Bold = true;
            ws.Cells[row, 1, row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[row, 1, row, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(226, 239, 218));
        }

        private static int WriteKeyValues(ExcelWorksheet ws, int row, IReadOnlyCollection<(string Label, object Value)> values)
        {
            foreach (var (label, value) in values)
            {
                ws.Cells[row, 1].Value = label;
                ws.Cells[row, 1].Style.Font.Bold = true;
                ws.Cells[row, 2].Value = value?.ToString();
                row++;
            }

            row++;
            return row;
        }
    }
}
