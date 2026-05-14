using OfficeOpenXml;
using OfficeOpenXml.Style;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using AdminEN13458DetailsVM = MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs.EN13458DetailsVM;

namespace MVC.ProductManagement.Presentation.Services.EN13458
{
    public class EN13458AdminExportService : IEN13458AdminExportService
    {
        public byte[] BuildDetailExcel(AdminEN13458DetailsVM vm, EN13458MaterialCostTableDTO costTable)
        {
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

            return package.GetAsByteArray();
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
