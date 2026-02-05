using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA.Features
{
    /// <summary>
    /// SA ürünlerine Metrik ve Boy özelliklerini atar (tüm ürünler için zorunlu)
    /// </summary>
    public class SAProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var productTypeId = SeedId.From("SFeature:PRODUCT_TYPE");
            var materialId = SeedId.From("SFeature:MATERIAL");
            var headTypeId = SeedId.From("SFeature:HEAD_TYPE");
            var threadSystemId = SeedId.From("SFeature:THREAD_SYSTEM");
            var standardId = SeedId.From("SFeature:STANDARD");
            var metricId = SeedId.From("SFeature:METRIC");
            var lengthId = SeedId.From("SFeature:LENGTH");
            var strengthId = SeedId.From("SFeature:STRENGTH");
            var coatingId = SeedId.From("SFeature:COATING");

            var saProducts = new[]
            {
                "SAA0", "SAA1", "SAA2", "SAA3", "SAA4", "SAA5", "SAA6", "SAA7", "SAA8", "SAA9",
                "SAB0", "SAB1", "SAB2", "SAB3", "SAB4", "SAB5", "SAB6", "SAB7", "SAB8", "SAB9",
                "SAC0", "SAC1", "SAC2", "SAC3", "SAC4", "SAC5", "SAC6",
                "SAD0", "SAD1",
                "SAE0", "SAE1", "SAE2", "SAE3", "SAE4", "SAE5", "SAE6", "SAE7", "SAE8"
            };

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in saProducts)
            {
                var productId = SeedId.From($"SProduct:SA:{productCode}");

                // Tüm feature'lar zorunlu
                var features = new[]
                {
                    (productTypeId, "PRODUCT_TYPE"),
                    (materialId, "MATERIAL"),
                    (headTypeId, "HEAD_TYPE"),
                    (threadSystemId, "THREAD_SYSTEM"),
                    (standardId, "STANDARD"),
                    (metricId, "METRIC"),
                    (lengthId, "LENGTH"),
                    (strengthId, "STRENGTH"),
                    (coatingId, "COATING")
                };

                foreach (var (featureId, featureCode) in features)
                {
                    productFeatures.Add(new SProductFeature
                    {
                        Id = SeedId.From($"SProductFeature:{productCode}:{featureCode}"),
                        SProductId = productId,
                        SFeatureId = featureId,
                        IsRequired = true, // Hepsi zorunlu
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
