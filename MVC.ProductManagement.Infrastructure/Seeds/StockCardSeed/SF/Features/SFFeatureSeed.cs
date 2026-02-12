using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Ürün Kategorisi
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF:PRODUCT_CATEGORY"),
                    Code = "SF_PRODUCT_CATEGORY",
                    Name = "Ürün Kategorisi",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Malzeme
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF:MATERIAL"),
                    Code = "SF_MATERIAL",
                    Name = "Malzeme",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Bağlantı Tipi
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF:CONNECTION_TYPE"),
                    Code = "SF_CONNECTION_TYPE",
                    Name = "Bağlantı Tipi",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Çap/Boyut
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF:SIZE"),
                    Code = "SF_SIZE",
                    Name = "Çap/Boyut",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Basınç Sınıfı
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF:PRESSURE_CLASS"),
                    Code = "SF_PRESSURE_CLASS",
                    Name = "Basınç Sınıfı",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 6. Standart
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF:STANDARD"),
                    Code = "SF_STANDARD",
                    Name = "Standart",
                    SortOrder = 6,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}