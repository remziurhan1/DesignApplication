using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.SBFeatureSeed
{
    public class SBFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                // 1. Somun Tipi
                new SFeature
                {
                    Id = SeedId.From("SFeature:NUT_TYPE"),
                    Code = "NUT_TYPE",
                    Name = "Somun Tipi",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 2. Mukavemet Sınıfı
                new SFeature
                {
                    Id = SeedId.From("SFeature:SB_STRENGTH"),
                    Code = "SB_STRENGTH",
                    Name = "Mukavemet Sınıfı",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 3. Standart
                new SFeature
                {
                    Id = SeedId.From("SFeature:SB_STANDARD"),
                    Code = "SB_STANDARD",
                    Name = "Standart",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 4. Ölçü (Metrik)
                new SFeature
                {
                    Id = SeedId.From("SFeature:SB_METRIC"),
                    Code = "SB_METRIC",
                    Name = "Ölçü (Metrik)",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // 5. Yüzey İşlemi
                new SFeature
                {
                    Id = SeedId.From("SFeature:SB_COATING"),
                    Code = "SB_COATING",
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
