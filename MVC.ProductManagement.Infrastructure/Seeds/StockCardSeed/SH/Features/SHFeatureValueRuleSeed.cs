using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SH.Features
{
    public class SHFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var shProducts = SAllDefinitions.AllPrefixes()
                .Where(p => p.StartsWith("SH"))
                .ToArray();

            var featureValues = new Dictionary<string, string[]>
            {
                ["NUT_TYPE"] = new[] { "AKB", "SAPKALI", "FIBERLI", "KONTRALI" },
                ["MATERIAL"] = new[] { "KARBON", "304", "316", "ALAŞIMLI" },
                ["THREAD_SYSTEM"] = new[] { "METRIK", "UNC", "UNF" },
                ["STANDARD"] = new[] { "DIN 934", "DIN 985", "DIN 439", "ISO 4032" },
                ["METRIC"] = new[] { "M4", "M5", "M6", "M8", "M10", "M12", "M16" },
                ["STRENGTH"] = new[] { "8.8", "10.9", "12.9", "A2-70", "A4-80" },
                ["COATING"] = new[] { "SIYAH OKSIT", "CINKO", "GALVANIZ", "-" }
            };

            var rules = new List<SFeatureValueRule>();

            foreach (var productCode in shProducts)
            {
                var productId = SeedId.From($"SProduct:SH:{productCode}");

                foreach (var (featureCode, values) in featureValues)
                {
                    var featureId = SeedId.From($"SFeature:{featureCode}");
                    var sort = 0;

                    foreach (var valueCode in values)
                    {
                        rules.Add(new SFeatureValueRule
                        {
                            Id = SeedId.From($"SFeatureValueRule:SH:{productCode}:{featureCode}:{valueCode}"),
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
