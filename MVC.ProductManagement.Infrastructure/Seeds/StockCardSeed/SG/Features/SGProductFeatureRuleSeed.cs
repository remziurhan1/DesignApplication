using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG.Features
{
    public class SGProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var features = new[]
            {
                (SeedId.From("SFeature:SG:MATERIAL"), "SG:MATERIAL"),
                (SeedId.From("SFeature:SG:STANDARD"), "SG:STANDARD"),
                (SeedId.From("SFeature:SG:DIAMETER"), "SG:DIAMETER"),
                (SeedId.From("SFeature:SG:LENGTH"), "SG:LENGTH"),
                (SeedId.From("SFeature:SG:COATING"), "SG:COATING")
            };

            var sgProducts = new[]
            {
                "SGA0", "SGA1", "SGA2", "SGA3", "SGA4", "SGA5", "SGA6", "SGA7", "SGA8", "SGA9"
            };

            var rules = new List<SProductFeatureRule>();

            foreach (var productCode in sgProducts)
            {
                var productId = SeedId.From($"SProduct:SG:{productCode}");

                foreach (var (featureId, featureCode) in features)
                {
                    rules.Add(new SProductFeatureRule
                    {
                        Id = SeedId.From($"SProductFeatureRule:SG:{productCode}:{featureCode}"),
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
