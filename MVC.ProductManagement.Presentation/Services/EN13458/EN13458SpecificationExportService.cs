using System.Globalization;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;

namespace MVC.ProductManagement.Presentation.Services.EN13458
{
    public class EN13458SpecificationExportService : IEN13458SpecificationExportService
    {
        public async Task<byte[]> BuildWordDocumentAsync(string templatePath, AdminEN13458SpecificationVM specification)
        {
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException("Şartname şablon dosyası bulunamadı.", templatePath);
            }

            var bytes = await File.ReadAllBytesAsync(templatePath);
            using var stream = new MemoryStream();
            await stream.WriteAsync(bytes, 0, bytes.Length);
            stream.Position = 0;

            using (var document = WordprocessingDocument.Open(stream, true))
            {
                ApplySpecificationTemplate(document, specification);
            }

            return stream.ToArray();
        }

        private static void ApplySpecificationTemplate(WordprocessingDocument document, AdminEN13458SpecificationVM specification)
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

        private static void InsertAccessoryTable(Body body, IReadOnlyCollection<AdminEN13458AccessoryItemVM> accessoryItems)
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
    }
}
