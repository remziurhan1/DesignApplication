using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SH.Features
{
    public class SHProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var features = new[]
            {
                (SeedId.From("SFeature:NUT_TYPE"), "NUT_TYPE"),
                (SeedId.From("SFeature:MATERIAL"), "MATERIAL"),
                (SeedId.From("SFeature:THREAD_SYSTEM"), "THREAD_SYSTEM"),
                (SeedId.From("SFeature:STANDARD"), "STANDARD"),
                (SeedId.From("SFeature:METRIC"), "METRIC"),
                (SeedId.From("SFeature:STRENGTH"), "STRENGTH"),
                (SeedId.From("SFeature:COATING"), "COATING")
            };

            var shProducts = SAllDefinitions.AllPrefixes()
                .Where(p => p.StartsWith("SH"))
                .ToArray();

            var rules = new List<SProductFeatureRule>();

            foreach (var productCode in shProducts)
            {
                var productId = SeedId.From($"SProduct:SH:{productCode}");

                foreach (var (featureId, featureCode) in features)
                {
                    rules.Add(new SProductFeatureRule
                    {
                        Id = SeedId.From($"SProductFeatureRule:SH:{productCode}:{featureCode}"),
                        SProductId = productId,
                        SFeatureId = featureId,
                        IsFixed = false,
                        FixedValueId = null,
                        CreatedBy = "SEED",
                        CreatedDate = now,
                        Status = Domain.Enums.Status.Added
                    });
                }
            }

            builder.HasData(rules);
        }
    }
}
