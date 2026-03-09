using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE.Features
{
    public class SEProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var features = new[]
            {
                (SeedId.From("SFeature:PRODUCT_CATEGORY"), "PRODUCT_CATEGORY"),
                (SeedId.From("SFeature:SE_MATERIAL"), "SE_MATERIAL"),
                (SeedId.From("SFeature:CROSS_SECTION"), "CROSS_SECTION"),
                (SeedId.From("SFeature:VOLTAGE"), "VOLTAGE"),
                (SeedId.From("SFeature:SE_STANDARD"), "SE_STANDARD"),
                (SeedId.From("SFeature:COLOR_TYPE"), "COLOR_TYPE")
            };

            var seProducts = new[]
            {
                "SEA0", "SEA1", "SEA2", "SEA3", "SEA4", "SEA5", "SEA6", "SEA7", "SEA8", "SEA9", "SEAA",
                "SEB0", "SEB1", "SEB2", "SEB3", "SEB4", "SEB5", "SEB6", "SEB7", "SEB8", "SEB9",
                "SEC0", "SEC1", "SEC2", "SEC3", "SEC4", "SEC5", "SEC6", "SEC7", "SEC8", "SEC9",
                "SED0", "SED1", "SED9", "SEE0", "SEF0", "SEF1", "SEG0"
            };

            var rules = new List<SProductFeatureRule>();

            foreach (var productCode in seProducts)
            {
                var productId = SeedId.From($"SProduct:SE:{productCode}");

                foreach (var (featureId, featureCode) in features)
                {
                    rules.Add(new SProductFeatureRule
                    {
                        Id = SeedId.From($"SProductFeatureRule:SE:{productCode}:{featureCode}"),
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
