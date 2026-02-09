using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG.Features
{
    public class SGFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Malzeme (SG için özel)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SG:MATERIAL"), // ✅ SG: eklendi
                    Code = "SG_MATERIAL",
                    Name = "Malzeme",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Standart (SG için özel)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SG:STANDARD"), // ✅ SG: eklendi
                    Code = "SG_STANDARD",
                    Name = "Standart",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Çap (SG için özel)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SG:DIAMETER"), // ✅ SG: eklendi
                    Code = "SG_DIAMETER",
                    Name = "Çap (mm)",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Boy (SG için özel)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SG:LENGTH"), // ✅ SG: eklendi
                    Code = "SG_LENGTH",
                    Name = "Boy (mm)",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Kaplama (SG için özel)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SG:COATING"), // ✅ SG: eklendi
                    Code = "SG_COATING",
                    Name = "Kaplama",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}