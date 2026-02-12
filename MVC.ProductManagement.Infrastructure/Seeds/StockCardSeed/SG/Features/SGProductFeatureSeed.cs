using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG.Features
{
    public class SGProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // ✅ Güncellenmiş ID'ler
            var materialId = SeedId.From("SFeature:SG:MATERIAL");
            var standardId = SeedId.From("SFeature:SG:STANDARD");
            var diameterId = SeedId.From("SFeature:SG:DIAMETER");
            var lengthId = SeedId.From("SFeature:SG:LENGTH");
            var coatingId = SeedId.From("SFeature:SG:COATING");

            var sgProducts = new[]
            {
                "SGA0", "SGA1", "SGA2", "SGA3", "SGA4", "SGA5", "SGA6", "SGA7", "SGA8", "SGA9"
            };

            var productFeatures = new List<SProductFeature>();

            foreach (var productCode in sgProducts)
            {
                var productId = SeedId.From($"SProduct:SG:{productCode}");

                var features = new[]
                {
                    (materialId, "SG_MATERIAL", true),
                    (standardId, "SG_STANDARD", true),
                    (diameterId, "SG_DIAMETER", true),
                    (lengthId, "SG_LENGTH", true),
                    (coatingId, "SG_COATING", true)
                };

                foreach (var (featureId, featureCode, isRequired) in features)
                {
                    productFeatures.Add(new SProductFeature
                    {
                        Id = SeedId.From($"SProductFeature:SG:{productCode}:{featureCode}"), // ✅ SG: eklendi
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