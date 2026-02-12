using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE.Features
{
    public class SEProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var productCategoryId = SeedId.From("SFeature:PRODUCT_CATEGORY");
            var materialId = SeedId.From("SFeature:SE_MATERIAL");
            var crossSectionId = SeedId.From("SFeature:CROSS_SECTION");
            var voltageId = SeedId.From("SFeature:VOLTAGE");
            var standardId = SeedId.From("SFeature:SE_STANDARD");
            var colorTypeId = SeedId.From("SFeature:COLOR_TYPE");

            var seProducts = new[]
            {
                // SEA Serisi
                "SEA0", "SEA1", "SEA2", "SEA3", "SEA4", "SEA5", "SEA6", "SEA7", "SEA8", "SEA9", "SEAA",
                // SEB Serisi
                "SEB0", "SEB1", "SEB2", "SEB3", "SEB4", "SEB5", "SEB6", "SEB7", "SEB8", "SEB9",
                // SEC Serisi
                "SEC0", "SEC1", "SEC2", "SEC3", "SEC4", "SEC5", "SEC6", "SEC7", "SEC8", "SEC9",
                // SED, SEE, SEF, SEG Serisi
                "SED0", "SED1", "SED9", "SEE0", "SEF0", "SEF1", "SEG0"
            };

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in seProducts)
            {
                var productId = SeedId.From($"SProduct:SE:{productCode}");

                // Her ürün için tüm feature'lar
                var features = new[]
                {
                    (productCategoryId, "PRODUCT_CATEGORY", true),
                    (materialId, "SE_MATERIAL", true),
                    (crossSectionId, "CROSS_SECTION", true),
                    (voltageId, "VOLTAGE", true),
                    (standardId, "SE_STANDARD", true),
                    (colorTypeId, "COLOR_TYPE", true)
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