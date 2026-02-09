using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE.Features
{
    public class SEFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Ürün Kategorisi
                new SFeature
                {
                    Id = SeedId.From("SFeature:PRODUCT_CATEGORY"),
                    Code = "PRODUCT_CATEGORY",
                    Name = "Ürün Kategorisi",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Malzeme
                new SFeature
                {
                    Id = SeedId.From("SFeature:SE_MATERIAL"),
                    Code = "SE_MATERIAL",
                    Name = "Malzeme",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Kesit/Kapasite
                new SFeature
                {
                    Id = SeedId.From("SFeature:CROSS_SECTION"),
                    Code = "CROSS_SECTION",
                    Name = "Kesit/Kapasite",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Voltaj
                new SFeature
                {
                    Id = SeedId.From("SFeature:VOLTAGE"),
                    Code = "VOLTAGE",
                    Name = "Voltaj",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Standart
                new SFeature
                {
                    Id = SeedId.From("SFeature:SE_STANDARD"),
                    Code = "SE_STANDARD",
                    Name = "Standart",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 6. Renk/Tip
                new SFeature
                {
                    Id = SeedId.From("SFeature:COLOR_TYPE"),
                    Code = "COLOR_TYPE",
                    Name = "Renk/Tip",
                    SortOrder = 6,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}