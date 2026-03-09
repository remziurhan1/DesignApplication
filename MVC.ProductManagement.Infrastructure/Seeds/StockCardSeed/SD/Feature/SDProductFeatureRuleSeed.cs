using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD.Features
{
    public class SDProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var features = new[]
            {
                (SeedId.From("SFeature:CONNECTION_TYPE"), "CONNECTION_TYPE"),
                (SeedId.From("SFeature:SD_MATERIAL"), "SD_MATERIAL"),
                (SeedId.From("SFeature:SD_STANDARD"), "SD_STANDARD"),
                (SeedId.From("SFeature:CONNECTION_SIZE"), "CONNECTION_SIZE"),
                (SeedId.From("SFeature:ANGLE"), "ANGLE"),
                (SeedId.From("SFeature:SD_COATING"), "SD_COATING")
            };

            var sdProducts = new[]
            {
                "SDA0", "SDA1", "SDA2", "SDA3", "SDA4", "SDA5", "SDA6", "SDA7", "SDA8", "SDA9",
                "SDB0", "SDB1", "SDB2", "SDB3", "SDB4",
                "SDC0", "SDC1", "SDC2", "SDC3", "SDC4",
                "SDD0", "SDD1", "SDD2", "SDD3", "SDD4", "SDD5",
                "SDE0", "SDE1", "SDE2", "SDE3", "SDE4",
                "SDF0", "SDF1", "SDF2", "SDF3", "SDF4", "SDF9",
                "SDG1", "SDG3",
                "SDH0", "SDH1",
                "SDI1"
            };

            var rules = new List<SProductFeatureRule>();

            foreach (var productCode in sdProducts)
            {
                var productId = SeedId.From($"SProduct:SD:{productCode}");

                foreach (var (featureId, featureCode) in features)
                {
                    rules.Add(new SProductFeatureRule
                    {
                        Id = SeedId.From($"SProductFeatureRule:SD:{productCode}:{featureCode}"),
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
