using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace MVC.ProductManagement.Application.Services.Export
{
    /// <summary>
    /// Excel export service implementation (EPPlus)
    /// </summary>
    public class ExcelExportService : IExcelExportService
    {
        public ExcelExportService()
        {
            // EPPlus lisans ayarı
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        /// <summary>
        /// ✅ SA Stok kodlarını Excel'e export et
        /// </summary>
        public async Task<byte[]> ExportSAStockCardsAsync(List<SAStockCardListDto> stockCards)
        {
            return await Task.Run(() =>
            {
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("SA Stok Kodları");

                // ✅ BAŞLIK SATIRI
                var headers = new[]
                {
                    "Stok Kodu",
                    "Ürün Kodu",
                    "Ürün Adı",
                    "Açıklama",
                    "Oluşturulma Tarihi",
                    "Oluşturan"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cells[1, i + 1];
                    cell.Value = headers[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                    cell.Style.Font.Color.SetColor(Color.White);
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // ✅ VERİ SATIRLARI
                int row = 2;
                foreach (var item in stockCards)
                {
                    worksheet.Cells[row, 1].Value = item.StockCode8;
                    worksheet.Cells[row, 2].Value = item.ProductCode;
                    worksheet.Cells[row, 3].Value = item.ProductName;
                    worksheet.Cells[row, 4].Value = item.Description;
                    worksheet.Cells[row, 5].Value = item.CreatedDate.ToString("dd.MM.yyyy HH:mm");
                    worksheet.Cells[row, 6].Value = item.CreatedBy;

                    // Kenarlık
                    for (int col = 1; col <= headers.Length; col++)
                    {
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    row++;
                }

                // ✅ KOLON GENİŞLİKLERİ
                worksheet.Column(1).Width = 15; // Stok Kodu
                worksheet.Column(2).Width = 12; // Ürün Kodu
                worksheet.Column(3).Width = 25; // Ürün Adı
                worksheet.Column(4).Width = 60; // Açıklama
                worksheet.Column(5).Width = 18; // Tarih
                worksheet.Column(6).Width = 15; // Oluşturan

                // ✅ TABLO STILI
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // ✅ DONMUŞ BAŞLIK
                worksheet.View.FreezePanes(2, 1);

                return package.GetAsByteArray();
            });
        }

        /// <summary>
        /// ✅ SA Stok kodu detayını Excel'e export et
        /// </summary>
        public async Task<byte[]> ExportSAStockCardDetailAsync(SAStockCardDetailDto detail)
        {
            return await Task.Run(() =>
            {
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Stok Detay");

                int row = 1;

                // ✅ BAŞLIK
                AddDetailRow(worksheet, ref row, "STOK KODU DETAYI", "", isHeader: true);
                row++;

                // ✅ GENEL BİLGİLER
                AddDetailRow(worksheet, ref row, "Stok Kodu", detail.StockCode8, isBold: true);
                AddDetailRow(worksheet, ref row, "Prefix", detail.Prefix4);
                AddDetailRow(worksheet, ref row, "Seri No", detail.Serial4.ToString("0000"));
                AddDetailRow(worksheet, ref row, "Ürün", $"{detail.ProductCode} - {detail.ProductName}");
                AddDetailRow(worksheet, ref row, "Fluid", $"{detail.FluidCode} - {detail.FluidName}");
                AddDetailRow(worksheet, ref row, "Açıklama", detail.Description);
                AddDetailRow(worksheet, ref row, "Oluşturulma", detail.CreatedDate.ToString("dd.MM.yyyy HH:mm:ss"));
                AddDetailRow(worksheet, ref row, "Oluşturan", detail.CreatedBy);

                row++;

                // ✅ FEATURE'LAR
                AddDetailRow(worksheet, ref row, "ÖZELLİKLER", "", isHeader: true);
                row++;

                AddDetailRow(worksheet, ref row, "Özellik", "Değer", isBold: true, isSubHeader: true);

                foreach (var feature in detail.FeatureSelections.OrderBy(f => f.SortOrder))
                {
                    var valueText = string.IsNullOrEmpty(feature.ValueName) || feature.ValueCode == feature.ValueName
                        ? feature.ValueCode
                        : $"{feature.ValueCode} - {feature.ValueName}";

                    AddDetailRow(worksheet, ref row, feature.FeatureName, valueText);
                }

                // ✅ KOLON GENİŞLİKLERİ
                worksheet.Column(1).Width = 25;
                worksheet.Column(2).Width = 50;

                return package.GetAsByteArray();
            });
        }

        /// <summary>
        /// Helper: Detay satırı ekle
        /// </summary>
        private void AddDetailRow(ExcelWorksheet worksheet, ref int row, string label, string value,
            bool isHeader = false, bool isBold = false, bool isSubHeader = false)
        {
            var labelCell = worksheet.Cells[row, 1];
            var valueCell = worksheet.Cells[row, 2];

            labelCell.Value = label;
            valueCell.Value = value;

            if (isHeader)
            {
                worksheet.Cells[row, 1, row, 2].Merge = true;
                labelCell.Style.Font.Bold = true;
                labelCell.Style.Font.Size = 14;
                labelCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                labelCell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                labelCell.Style.Font.Color.SetColor(Color.White);
                labelCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
            else if (isSubHeader)
            {
                labelCell.Style.Font.Bold = true;
                valueCell.Style.Font.Bold = true;
                labelCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                labelCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                valueCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                valueCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }
            else if (isBold)
            {
                labelCell.Style.Font.Bold = true;
                valueCell.Style.Font.Bold = true;
            }

            labelCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            valueCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);

            row++;
        }
        public async Task<byte[]> ExportSBStockCardsAsync(List<SBStockCardListDto> stockCards)
        {
            return await Task.Run(() =>
            {
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("SB Stok Kodları");

                var headers = new[]
                {
            "Stok Kodu",
            "Ürün Kodu",
            "Ürün Adı",
            "Açıklama",
            "Oluşturulma Tarihi",
            "Oluşturan"
        };

                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cells[1, i + 1];
                    cell.Value = headers[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(70, 130, 90)); // SB için yeşil ton
                    cell.Style.Font.Color.SetColor(Color.White);
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                int row = 2;
                foreach (var item in stockCards)
                {
                    worksheet.Cells[row, 1].Value = item.StockCode8;
                    worksheet.Cells[row, 2].Value = item.ProductCode;
                    worksheet.Cells[row, 3].Value = item.ProductName;
                    worksheet.Cells[row, 4].Value = item.Description;
                    worksheet.Cells[row, 5].Value = item.CreatedDate.ToString("dd.MM.yyyy HH:mm");
                    worksheet.Cells[row, 6].Value = item.CreatedBy;

                    for (int col = 1; col <= headers.Length; col++)
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    row++;
                }

                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 12;
                worksheet.Column(3).Width = 25;
                worksheet.Column(4).Width = 60;
                worksheet.Column(5).Width = 18;
                worksheet.Column(6).Width = 15;

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                worksheet.View.FreezePanes(2, 1);

                return package.GetAsByteArray();
            });
        }

        public async Task<byte[]> ExportSBStockCardDetailAsync(SBStockCardDetailDto detail)
        {
            return await Task.Run(() =>
            {
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Stok Detay");

                int row = 1;

                AddDetailRow(worksheet, ref row, "STOK KODU DETAYI", "", isHeader: true);
                row++;

                AddDetailRow(worksheet, ref row, "Stok Kodu", detail.StockCode8, isBold: true);
                AddDetailRow(worksheet, ref row, "Prefix", detail.Prefix4);
                AddDetailRow(worksheet, ref row, "Seri No", detail.Serial4.ToString("0000"));
                AddDetailRow(worksheet, ref row, "Ürün", $"{detail.ProductCode} - {detail.ProductName}");
                AddDetailRow(worksheet, ref row, "Fluid", $"{detail.FluidCode} - {detail.FluidName}");
                AddDetailRow(worksheet, ref row, "Açıklama", detail.Description);
                AddDetailRow(worksheet, ref row, "Oluşturulma", detail.CreatedDate.ToString("dd.MM.yyyy HH:mm:ss"));
                AddDetailRow(worksheet, ref row, "Oluşturan", detail.CreatedBy);

                row++;

                AddDetailRow(worksheet, ref row, "ÖZELLİKLER", "", isHeader: true);
                row++;

                AddDetailRow(worksheet, ref row, "Özellik", "Değer", isBold: true, isSubHeader: true);

                foreach (var feature in detail.FeatureSelections.OrderBy(f => f.SortOrder))
                {
                    var valueText = string.IsNullOrEmpty(feature.ValueName) || feature.ValueCode == feature.ValueName
                        ? feature.ValueCode
                        : $"{feature.ValueCode} - {feature.ValueName}";

                    AddDetailRow(worksheet, ref row, feature.FeatureName, valueText);
                }

                worksheet.Column(1).Width = 25;
                worksheet.Column(2).Width = 50;

                return package.GetAsByteArray();
            });
        }

        public Task<byte[]> ExportSCStockCardsAsync(List<SCStockCardListDto> stockCards)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ExportSCStockCardDetailAsync(SCStockCardDetailDto detail)
        {
            throw new NotImplementedException();
        }
    }
}