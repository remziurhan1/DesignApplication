using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA.Features
{
    public class SAFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Ürün Tipi
                new SFeature
                {
                    Id = SeedId.From("SFeature:PRODUCT_TYPE"),
                    Code = "PRODUCT_TYPE",
                    Name = "Ürün Tipi",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Malzeme
                new SFeature
                {
                    Id = SeedId.From("SFeature:MATERIAL"),
                    Code = "MATERIAL",
                    Name = "Malzeme",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Baş Tipi
                new SFeature
                {
                    Id = SeedId.From("SFeature:HEAD_TYPE"),
                    Code = "HEAD_TYPE",
                    Name = "Baş Tipi",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Diş Sistemi
                new SFeature
                {
                    Id = SeedId.From("SFeature:THREAD_SYSTEM"),
                    Code = "THREAD_SYSTEM",
                    Name = "Diş Sistemi",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Standart
                new SFeature
                {
                    Id = SeedId.From("SFeature:STANDARD"),
                    Code = "STANDARD",
                    Name = "Standart",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 6. Metrik
                new SFeature
                {
                    Id = SeedId.From("SFeature:METRIC"),
                    Code = "METRIC",
                    Name = "Metrik Ölçü",
                    SortOrder = 6,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 7. Boy
                new SFeature
                {
                    Id = SeedId.From("SFeature:LENGTH"),
                    Code = "LENGTH",
                    Name = "Boy (mm)",
                    SortOrder = 7,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 8. Mukavemet Sınıfı
                new SFeature
                {
                    Id = SeedId.From("SFeature:STRENGTH"),
                    Code = "STRENGTH",
                    Name = "Mukavemet Sınıfı",
                    SortOrder = 8,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 9. Yüzey Kaplama
                new SFeature
                {
                    Id = SeedId.From("SFeature:COATING"),
                    Code = "COATING",
                    Name = "Yüzey Kaplama",
                    SortOrder = 9,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}