using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC.Features
{
    public class SCFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Rondela Tipi
                new SFeature
                {
                    Id = SeedId.From("SFeature:WASHER_TYPE"),
                    Code = "WASHER_TYPE",
                    Name = "Rondela Tipi",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Malzeme
                new SFeature
                {
                    Id = SeedId.From("SFeature:SC_MATERIAL"),
                    Code = "SC_MATERIAL",
                    Name = "Malzeme",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Standart
                new SFeature
                {
                    Id = SeedId.From("SFeature:SC_STANDARD"),
                    Code = "SC_STANDARD",
                    Name = "Standart",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Ölçü (Metrik)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SC_METRIC"),
                    Code = "SC_METRIC",
                    Name = "Ölçü (Metrik)",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Yüzey İşlemi
                new SFeature
                {
                    Id = SeedId.From("SFeature:SC_COATING"),
                    Code = "SC_COATING",
                    Name = "Yüzey İşlemi",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}
