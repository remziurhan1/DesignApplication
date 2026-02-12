using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var productCategoryId = SeedId.From("SFeature:SF:PRODUCT_CATEGORY");
            var materialId = SeedId.From("SFeature:SF:MATERIAL");
            var connectionTypeId = SeedId.From("SFeature:SF:CONNECTION_TYPE");
            var sizeId = SeedId.From("SFeature:SF:SIZE");
            var pressureClassId = SeedId.From("SFeature:SF:PRESSURE_CLASS");
            var standardId = SeedId.From("SFeature:SF:STANDARD");

            var sfProducts = new[]
            {
                // ==================== SFA SERİSİ: LPG (10 adet) ====================
                "SFA0", "SFA1", "SFA2", "SFA3", "SFA4", "SFA5", "SFA6", "SFA7", "SFA8", "SFA9",
                
                // ==================== SFC SERİSİ: CRYOGENIC (9 adet) ====================
                "SFC0", "SFC1", "SFC2", "SFC3", "SFC4", "SFC5", "SFC6", "SFC7", "SFC8",
                
                // ==================== SFF SERİSİ: AKARYAKIT (10 adet) ====================
                "SFF0", "SFF1", "SFF2", "SFF3", "SFF4", "SFF5", "SFF6", "SFF7", "SFF8", "SFF9",
                
                // ==================== SFG SERİSİ: SU, HİDROLİK, PNÖMATİK (10 adet) ====================
                "SFG0", "SFG1", "SFG2", "SFG3", "SFG4", "SFG5", "SFG6", "SFG7", "SFG8", "SFG9",
                
                // ==================== SFH SERİSİ: DİĞER EKİPMANLAR (7 adet) ====================
                "SFH0", "SFH1", "SFH2", "SFH3", "SFH4", "SFH5", "SFH6",
                
                // ==================== SFJ SERİSİ: DOĞAL GAZ (9 adet) ====================
                "SFJ0", "SFJ1", "SFJ2", "SFJ3", "SFJ4", "SFJ5", "SFJ6", "SFJ7", "SFJ8",
                
                // ==================== SFK SERİSİ: KİMYASAL (5 adet) ====================
                "SFK0", "SFK1", "SFK2", "SFK3", "SFK4",
                
                // ==================== SFL SERİSİ: PROSES GAZ/DİĞER (3 adet) ====================
                "SFL0", "SFL1", "SFL2"
            };
            // Toplam: 10+9+10+10+7+9+5+3 = 63 ürün ✅

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in sfProducts)
            {
                var productId = SeedId.From($"SProduct:SF:{productCode}");

                var features = new[]
                {
                    (productCategoryId, "SF_PRODUCT_CATEGORY", true),
                    (materialId, "SF_MATERIAL", true),
                    (connectionTypeId, "SF_CONNECTION_TYPE", true),
                    (sizeId, "SF_SIZE", true),
                    (pressureClassId, "SF_PRESSURE_CLASS", true),
                    (standardId, "SF_STANDARD", true)
                };

                foreach (var (featureId, featureCode, isRequired) in features)
                {
                    productFeatures.Add(new SProductFeature
                    {
                        Id = SeedId.From($"SProductFeature:SF:{productCode}:{featureCode}"),
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