using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC.Features
{
    public class SCProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var washerTypeId = SeedId.From("SFeature:WASHER_TYPE");
            var materialId = SeedId.From("SFeature:SC_MATERIAL");
            var standardId = SeedId.From("SFeature:SC_STANDARD");
            var metricId = SeedId.From("SFeature:SC_METRIC");
            var coatingId = SeedId.From("SFeature:SC_COATING");

            var scProducts = new[]
            {
                "SCA0", "SCA1", "SCA2", "SCA3", "SCA4", "SCA5", "SCA6", "SCA7", "SCA8",
                "SCE1",
                "SCA9",
                "SCB0"
            };

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in scProducts)
            {
                var productId = SeedId.From($"SProduct:SC:{productCode}");

                var features = new[]
                {
                    (washerTypeId, "WASHER_TYPE"),
                    (materialId, "SC_MATERIAL"),
                    (standardId, "SC_STANDARD"),
                    (metricId, "SC_METRIC"),
                    (coatingId, "SC_COATING")
                };

                foreach (var (featureId, featureCode) in features)
                {
                    productFeatures.Add(new SProductFeature
                    {
                        Id = SeedId.From($"SProductFeature:{productCode}:{featureCode}"),
                        SProductId = productId,
                        SFeatureId = featureId,
                        IsRequired = true,
                        CreatedBy = "SEED",
                        CreatedDate = now,
                        Status = Domain.Enums.Status.Added
                    });
                }
            }

            builder.HasData(productFeatures);
        }
    }
}
