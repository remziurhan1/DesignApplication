
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Threading.Tasks;
//using LicenseContext = OfficeOpenXml.LicenseContext;

//namespace MVC.ProductManagement.Application.Services.Export
//{
//    public class ExcelExportService : IExcelExportService
//    {
//        // Grup renkleri
//        private static readonly Color ColorSA = Color.FromArgb(79, 129, 189);  // Mavi
//        private static readonly Color ColorSB = Color.FromArgb(70, 130, 90);   // Yeşil
//        private static readonly Color ColorSC = Color.FromArgb(150, 100, 180); // Mor
//        private static readonly Color ColorSF = Color.FromArgb(190, 100, 50);  // Turuncu
//        private static readonly Color ColorSD = Color.FromArgb(52, 152, 219);
//        private static readonly Color ColorSE = Color.FromArgb(46, 204, 113);
//        private static readonly Color ColorSG = Color.FromArgb(155, 89, 182);
//        private static readonly Color ColorSH = Color.FromArgb(241, 196, 15);

//        public ExcelExportService()
//        {
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//        }

//        #region SA

//        public async Task<byte[]> ExportSAStockCardsAsync(List<SAStockCardListDto> stockCards)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("SA Stok Kodları");

//                WriteListHeaders(ws, ColorSA);
//                int row = 2;
//                foreach (var item in stockCards)
//                    WriteListRow(ws, row++, item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy);

//                FormatListSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        public async Task<byte[]> ExportSAStockCardDetailAsync(SAStockCardDetailDto detail)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("Stok Detay");
//                int row = 1;

//                WriteDetailHeader(ws, ref row, ColorSA);
//                WriteDetailInfo(ws, ref row, detail.StockCode8, detail.Prefix4, detail.Serial4,
//                    detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName,
//                    detail.Description, detail.CreatedDate, detail.CreatedBy);

//                WriteFeatures(ws, ref row, detail.FeatureSelections
//                    .OrderBy(f => f.SortOrder)
//                    .Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//                FormatDetailSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        #endregion

//        #region SB

//        public async Task<byte[]> ExportSBStockCardsAsync(List<SBStockCardListDto> stockCards)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("SB Stok Kodları");

//                WriteListHeaders(ws, ColorSB);
//                int row = 2;
//                foreach (var item in stockCards)
//                    WriteListRow(ws, row++, item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy);

//                FormatListSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        public async Task<byte[]> ExportSBStockCardDetailAsync(SBStockCardDetailDto detail)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("Stok Detay");
//                int row = 1;

//                WriteDetailHeader(ws, ref row, ColorSB);
//                WriteDetailInfo(ws, ref row, detail.StockCode8, detail.Prefix4, detail.Serial4,
//                    detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName,
//                    detail.Description, detail.CreatedDate, detail.CreatedBy);

//                WriteFeatures(ws, ref row, detail.FeatureSelections
//                    .OrderBy(f => f.SortOrder)
//                    .Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//                FormatDetailSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        #endregion

//        #region SC

//        public async Task<byte[]> ExportSCStockCardsAsync(List<SCStockCardListDto> stockCards)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("SC Stok Kodları");

//                WriteListHeaders(ws, ColorSC);
//                int row = 2;
//                foreach (var item in stockCards)
//                    WriteListRow(ws, row++, item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy);

//                FormatListSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        public async Task<byte[]> ExportSCStockCardDetailAsync(SCStockCardDetailDto detail)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("Stok Detay");
//                int row = 1;

//                WriteDetailHeader(ws, ref row, ColorSC);
//                WriteDetailInfo(ws, ref row, detail.StockCode8, detail.Prefix4, detail.Serial4,
//                    detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName,
//                    detail.Description, detail.CreatedDate, detail.CreatedBy);

//                WriteFeatures(ws, ref row, detail.FeatureSelections
//                    .OrderBy(f => f.SortOrder)
//                    .Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//                FormatDetailSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        #endregion


//        #region SD

//        public async Task<byte[]> ExportSDStockCardsAsync(List<SDStockCardListDto> stockCards) => await ExportListAsync("SD Stok Kodları", ColorSD, stockCards.Select(item => (item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy)));

//        public async Task<byte[]> ExportSDStockCardDetailAsync(SDStockCardDetailDto detail) => await ExportDetailAsync(ColorSD, detail.StockCode8, detail.Prefix4, detail.Serial4, detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName, detail.Description, detail.CreatedDate, detail.CreatedBy, detail.FeatureSelections.OrderBy(f => f.SortOrder).Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//        #endregion

//        #region SE

//        public async Task<byte[]> ExportSEStockCardsAsync(List<SEStockCardListDto> stockCards) => await ExportListAsync("SE Stok Kodları", ColorSE, stockCards.Select(item => (item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy)));

//        public async Task<byte[]> ExportSEStockCardDetailAsync(SEStockCardDetailDto detail) => await ExportDetailAsync(ColorSE, detail.StockCode8, detail.Prefix4, detail.Serial4, detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName, detail.Description, detail.CreatedDate, detail.CreatedBy, detail.FeatureSelections.OrderBy(f => f.SortOrder).Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//        #endregion

//        #region SG

//        public async Task<byte[]> ExportSGStockCardsAsync(List<SGStockCardListDto> stockCards) => await ExportListAsync("SG Stok Kodları", ColorSG, stockCards.Select(item => (item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy)));

//        public async Task<byte[]> ExportSGStockCardDetailAsync(SGStockCardDetailDto detail) => await ExportDetailAsync(ColorSG, detail.StockCode8, detail.Prefix4, detail.Serial4, detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName, detail.Description, detail.CreatedDate, detail.CreatedBy, detail.FeatureSelections.OrderBy(f => f.SortOrder).Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//        #endregion

//        #region SH

//        public async Task<byte[]> ExportSHStockCardsAsync(List<SHStockCardListDto> stockCards) => await ExportListAsync("SH Stok Kodları", ColorSH, stockCards.Select(item => (item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy)));

//        public async Task<byte[]> ExportSHStockCardDetailAsync(SHStockCardDetailDto detail) => await ExportDetailAsync(ColorSH, detail.StockCode8, detail.Prefix4, detail.Serial4, detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName, detail.Description, detail.CreatedDate, detail.CreatedBy, detail.FeatureSelections.OrderBy(f => f.SortOrder).Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//        #endregion

//        #region SF

//        public async Task<byte[]> ExportSFStockCardsAsync(List<SFStockCardListDto> stockCards)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("SF Stok Kodları");

//                WriteListHeaders(ws, ColorSF);
//                int row = 2;
//                foreach (var item in stockCards)
//                    WriteListRow(ws, row++, item.StockCode8, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy);

//                FormatListSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        public async Task<byte[]> ExportSFStockCardDetailAsync(SFStockCardDetailDto detail)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("Stok Detay");
//                int row = 1;

//                WriteDetailHeader(ws, ref row, ColorSF);
//                WriteDetailInfo(ws, ref row, detail.StockCode8, detail.Prefix4, detail.Serial4,
//                    detail.ProductCode, detail.ProductName, detail.FluidCode, detail.FluidName,
//                    detail.Description, detail.CreatedDate, detail.CreatedBy);

//                WriteFeatures(ws, ref row, detail.FeatureSelections
//                    .OrderBy(f => f.SortOrder)
//                    .Select(f => (f.FeatureName, f.ValueCode, f.ValueName)));

//                FormatDetailSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        #endregion

//        #region ORTAK YARDIMCI METODLAR

//        // Bazı gruplarda expression-bodied export metotları bu helper'ları kullanıyor.
//        // Helper'ları merkezde tutmak, kopya kodu ve isim-hata riskini azaltır.
//        private async Task<byte[]> ExportListAsync(
//            string sheetName,
//            Color headerColor,
//            IEnumerable<(string StockCode, string ProductCode, string ProductName, string Description, DateTime CreatedDate, string CreatedBy)> rows)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add(sheetName);

//                WriteListHeaders(ws, headerColor);
//                int row = 2;
//                foreach (var item in rows)
//                    WriteListRow(ws, row++, item.StockCode, item.ProductCode, item.ProductName, item.Description, item.CreatedDate, item.CreatedBy);

//                FormatListSheet(ws);
//                return package.GetAsByteArray();
//            });
//        }

//        private async Task<byte[]> ExportDetailAsync(
//            Color headerColor,
//            string stockCode,
//            string prefix,
//            int serial,
//            string productCode,
//            string productName,
//            string? fluidCode,
//            string? fluidName,
//            string description,
//            DateTime createdDate,
//            string createdBy,
//            IEnumerable<(string FeatureName, string ValueCode, string ValueName)> features)
//        {
//            return await Task.Run(() =>
//            {
//                using var package = new ExcelPackage();
//                var ws = package.Workbook.Worksheets.Add("Stok Detay");
//                int row = 1;

//                WriteDetailHeader(ws, ref row, headerColor);
//                WriteDetailInfo(ws, ref row, stockCode, prefix, serial, productCode, productName, fluidCode, fluidName, description, createdDate, createdBy);
//                WriteFeatures(ws, ref row, features);
//                FormatDetailSheet(ws);

//                return package.GetAsByteArray();
//            });
//        }

//        private void WriteListHeaders(ExcelWorksheet ws, Color headerColor)
//        {
//            var headers = new[] { "Stok Kodu", "Ürün Kodu", "Ürün Adı", "Açıklama", "Oluşturulma Tarihi", "Oluşturan" };
//            for (int i = 0; i < headers.Length; i++)
//            {
//                var cell = ws.Cells[1, i + 1];
//                cell.Value = headers[i];
//                cell.Style.Font.Bold = true;
//                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
//                cell.Style.Fill.BackgroundColor.SetColor(headerColor);
//                cell.Style.Font.Color.SetColor(Color.White);
//                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
//                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
//            }
//        }

//        private void WriteListRow(ExcelWorksheet ws, int row,
//            string stockCode, string productCode, string productName,
//            string description, DateTime createdDate, string createdBy)
//        {
//            ws.Cells[row, 1].Value = stockCode;
//            ws.Cells[row, 2].Value = productCode;
//            ws.Cells[row, 3].Value = productName;
//            ws.Cells[row, 4].Value = description;
//            ws.Cells[row, 5].Value = createdDate.ToString("dd.MM.yyyy HH:mm");
//            ws.Cells[row, 6].Value = createdBy;

//            for (int col = 1; col <= 6; col++)
//                ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
//        }

//        private void FormatListSheet(ExcelWorksheet ws)
//        {
//            ws.Column(1).Width = 15;
//            ws.Column(2).Width = 12;
//            ws.Column(3).Width = 30;
//            ws.Column(4).Width = 60;
//            ws.Column(5).Width = 18;
//            ws.Column(6).Width = 15;
//            ws.View.FreezePanes(2, 1);
//        }

//        private void WriteDetailHeader(ExcelWorksheet ws, ref int row, Color headerColor)
//        {
//            var merged = ws.Cells[row, 1, row, 2];
//            merged.Merge = true;
//            merged.Value = "STOK KODU DETAYI";
//            merged.Style.Font.Bold = true;
//            merged.Style.Font.Size = 14;
//            merged.Style.Fill.PatternType = ExcelFillStyle.Solid;
//            merged.Style.Fill.BackgroundColor.SetColor(headerColor);
//            merged.Style.Font.Color.SetColor(Color.White);
//            merged.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
//            merged.Style.Border.BorderAround(ExcelBorderStyle.Thin);
//            row += 2;
//        }

//        private void WriteDetailInfo(ExcelWorksheet ws, ref int row,
//            string stockCode, string prefix, int serial,
//            string productCode, string productName,
//            string? fluidCode, string? fluidName,
//            string description, DateTime createdDate, string createdBy)
//        {
//            AddRow(ws, ref row, "Stok Kodu", stockCode, isBold: true);
//            AddRow(ws, ref row, "Prefix", prefix);
//            AddRow(ws, ref row, "Seri No", serial.ToString("0000"));
//            AddRow(ws, ref row, "Ürün", $"{productCode} - {productName}");

//            if (!string.IsNullOrWhiteSpace(fluidCode))
//                AddRow(ws, ref row, "Fluid", $"{fluidCode} - {fluidName}");

//            AddRow(ws, ref row, "Açıklama", description);
//            AddRow(ws, ref row, "Oluşturulma", createdDate.ToString("dd.MM.yyyy HH:mm:ss"));
//            AddRow(ws, ref row, "Oluşturan", createdBy);
//            row++;
//        }

//        private void WriteFeatures(ExcelWorksheet ws, ref int row,
//            IEnumerable<(string FeatureName, string ValueCode, string ValueName)> features)
//        {
//            // Alt başlık
//            var subHeader = ws.Cells[row, 1, row, 2];
//            subHeader.Value = "ÖZELLİKLER";
//            subHeader.Merge = true;
//            subHeader.Style.Font.Bold = true;
//            subHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
//            subHeader.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
//            subHeader.Style.Border.BorderAround(ExcelBorderStyle.Thin);
//            row += 2;

//            AddRow(ws, ref row, "Özellik", "Değer", isBold: true, isSubHeader: true);

//            foreach (var (featureName, valueCode, valueName) in features)
//            {
//                var valueText = string.IsNullOrEmpty(valueName) || valueCode == valueName
//                    ? valueCode
//                    : $"{valueCode} - {valueName}";

//                AddRow(ws, ref row, featureName, valueText);
//            }
//        }

//        private void FormatDetailSheet(ExcelWorksheet ws)
//        {
//            ws.Column(1).Width = 30;
//            ws.Column(2).Width = 60;
//        }

//        private void AddRow(ExcelWorksheet ws, ref int row, string label, string value,
//            bool isBold = false, bool isSubHeader = false)
//        {
//            var labelCell = ws.Cells[row, 1];
//            var valueCell = ws.Cells[row, 2];

//            labelCell.Value = label;
//            valueCell.Value = value;

//            if (isSubHeader)
//            {
//                labelCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
//                labelCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
//                valueCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
//                valueCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
//            }

//            if (isBold || isSubHeader)
//            {
//                labelCell.Style.Font.Bold = true;
//                valueCell.Style.Font.Bold = true;
//            }

//            labelCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
//            valueCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);

//            row++;
//        }

//        #endregion
//    }
//}
