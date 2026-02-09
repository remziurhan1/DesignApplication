using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD.Features
{
    public class SDProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var connectionTypeId = SeedId.From("SFeature:CONNECTION_TYPE");
            var materialId = SeedId.From("SFeature:SD_MATERIAL");
            var standardId = SeedId.From("SFeature:SD_STANDARD");
            var connectionSizeId = SeedId.From("SFeature:CONNECTION_SIZE");
            var angleId = SeedId.From("SFeature:ANGLE");
            var coatingId = SeedId.From("SFeature:SD_COATING");

            var sdProducts = new[]
            {
                // SDA Serisi
                "SDA0", "SDA1", "SDA2", "SDA3", "SDA4", "SDA5", "SDA6", "SDA7", "SDA8", "SDA9",
                // SDB Serisi
                "SDB0", "SDB1", "SDB2", "SDB3", "SDB4",
                // SDC Serisi
                "SDC0", "SDC1", "SDC2", "SDC3", "SDC4",
                // SDD Serisi
                "SDD0", "SDD1", "SDD2", "SDD3", "SDD4", "SDD5",
                // SDE Serisi
                "SDE0", "SDE1", "SDE2", "SDE3", "SDE4",
                // SDF Serisi
                "SDF0", "SDF1", "SDF2", "SDF3", "SDF4", "SDF9",
                // SDG Serisi
                "SDG1", "SDG3",
                // SDH Serisi
                "SDH0", "SDH1",
                // SDI Serisi
                "SDI1"
            };

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in sdProducts)
            {
                var productId = SeedId.From($"SProduct:SD:{productCode}");

                // Her ürün için tüm feature'lar
                var features = new[]
                {
                    (connectionTypeId, "CONNECTION_TYPE", true),
                    (materialId, "SD_MATERIAL", true),
                    (standardId, "SD_STANDARD", true),
                    (connectionSizeId, "CONNECTION_SIZE", true),
                    (angleId, "ANGLE", false), // Opsiyonel (sadece Dirsek/Tee için gerekli)
                    (coatingId, "SD_COATING", true)
                };

                foreach (var (featureId, featureCode, isRequired) in features)
                {
                    productFeatures.Add(new SProductFeature
                    {
                        Id = SeedId.From($"SProductFeature:{productCode}:{featureCode}"),
                        SProductId = productId,
                        SFeatureId = featureId,
                        IsRequired = isRequired,
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