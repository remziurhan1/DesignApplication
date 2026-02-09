using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.SBFeatureSeed
{
    public class SBProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var nutTypeId = SeedId.From("SFeature:NUT_TYPE");
            var strengthId = SeedId.From("SFeature:SB_STRENGTH");
            var standardId = SeedId.From("SFeature:SB_STANDARD");
            var metricId = SeedId.From("SFeature:SB_METRIC");
            var coatingId = SeedId.From("SFeature:SB_COATING");

            var sbProducts = new[]
            {
                "SBA0", "SBA1", "SBA2", "SBA3", "SBA4", "SBA5", "SBA6", "SBA7", "SBA8", "SBA9",
                "SBB0", "SBB1", "SBB2", "SBB3", "SBB4", "SBB5", "SBB6", "SBB7", "SBB8", "SBB9",
                "SBC0", "SBC1", "SBC2", "SBC3",
                "SBE0", "SBE1",
                "SBD0", "SBD1"
            };

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in sbProducts)
            {
                var productId = SeedId.From($"SProduct:SB:{productCode}");

                var features = new[]
                {
                    (nutTypeId, "NUT_TYPE"),
                    (strengthId, "SB_STRENGTH"),
                    (standardId, "SB_STANDARD"),
                    (metricId, "SB_METRIC"),
                    (coatingId, "SB_COATING")
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
