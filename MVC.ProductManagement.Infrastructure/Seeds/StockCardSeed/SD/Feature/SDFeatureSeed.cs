using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD.Features
{
    public class SDFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Bağlantı Tipi
                new SFeature
                {
                    Id = SeedId.From("SFeature:CONNECTION_TYPE"),
                    Code = "CONNECTION_TYPE",
                    Name = "Bağlantı Tipi",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Malzeme
                new SFeature
                {
                    Id = SeedId.From("SFeature:SD_MATERIAL"),
                    Code = "SD_MATERIAL",
                    Name = "Malzeme",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Standart
                new SFeature
                {
                    Id = SeedId.From("SFeature:SD_STANDARD"),
                    Code = "SD_STANDARD",
                    Name = "Standart",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Bağlantı Ölçüsü
                new SFeature
                {
                    Id = SeedId.From("SFeature:CONNECTION_SIZE"),
                    Code = "CONNECTION_SIZE",
                    Name = "Bağlantı Ölçüsü",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Açı (Dirsek/Tee için)
                new SFeature
                {
                    Id = SeedId.From("SFeature:ANGLE"),
                    Code = "ANGLE",
                    Name = "Açı",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 6. Yüzey İşlemi
                new SFeature
                {
                    Id = SeedId.From("SFeature:SD_COATING"),
                    Code = "SD_COATING",
                    Name = "Yüzey İşlemi",
                    SortOrder = 6,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}