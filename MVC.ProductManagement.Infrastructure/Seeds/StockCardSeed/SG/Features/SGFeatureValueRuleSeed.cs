using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG.Features
{
    public class SGFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var sgProducts = new[]
            {
                "SGA0", "SGA1", "SGA2", "SGA3", "SGA4", "SGA5", "SGA6", "SGA7", "SGA8", "SGA9"
            };

            var featureValues = new Dictionary<string, string[]>
            {
                ["SG:MATERIAL"] = new[] { "Çelik", "Paslanmaz Çelik AISI 304", "Paslanmaz Çelik AISI 316", "Alüminyum", "Bakır", "Pirinç", "Plastik (PA)", "Bronz", "Sertleştirilmiş Çelik" },
                ["SG:STANDARD"] = new[] { "DIN 1", "DIN 6", "DIN 7", "DIN 1481", "ISO 2338", "ISO 8734", "ISO 8735", "ANSI B18.8.2", "JIS B 1354", "DIN 71412", "Özel" },
                ["SG:DIAMETER"] = new[] { "1mm", "1.5mm", "2mm", "2.5mm", "3mm", "4mm", "5mm", "6mm", "7mm", "8mm", "10mm", "12mm", "13mm", "14mm", "16mm", "18mm", "20mm", "22mm", "25mm", "30mm", "M6", "M8", "M10", "M12", "M14", "M16", "M18", "M20", "M22", "M24", "M27", "M30" },
                ["SG:LENGTH"] = new[] { "6mm", "8mm", "10mm", "12mm", "14mm", "16mm", "18mm", "20mm", "22mm", "25mm", "28mm", "30mm", "32mm", "35mm", "40mm", "45mm", "50mm", "55mm", "60mm", "65mm", "70mm", "75mm", "80mm", "90mm", "100mm", "110mm", "120mm", "140mm", "150mm", "160mm", "180mm", "200mm" },
                ["SG:COATING"] = new[] { "Kaplamasız", "Çinko Kaplama", "Nikel Kaplama", "Krom Kaplama", "Galvaniz", "Siyah Oksit", "Fosfor Kaplama", "Teflon Kaplama" }
            };

            var rules = new List<SFeatureValueRule>();

            foreach (var productCode in sgProducts)
            {
                var productId = SeedId.From($"SProduct:SG:{productCode}");

                foreach (var (featureCode, values) in featureValues)
                {
                    var featureId = SeedId.From($"SFeature:{featureCode}");
                    var sort = 0;

                    foreach (var valueCode in values)
                    {
                        rules.Add(new SFeatureValueRule
                        {
                            Id = SeedId.From($"SFeatureValueRule:SG:{productCode}:{featureCode}:{valueCode}"),
                            SProductId = productId,
                            SFeatureId = featureId,
                            SFeatureValueId = SeedId.From($"SFeatureValue:{featureCode}:{valueCode}"),
                            SortOrder = sort++,
                            CreatedBy = "SEED",
                            CreatedDate = now,
                            Status = Domain.Enums.Status.Added
                        });
                    }
                }
            }

            builder.HasData(rules);
        }
    }
}
