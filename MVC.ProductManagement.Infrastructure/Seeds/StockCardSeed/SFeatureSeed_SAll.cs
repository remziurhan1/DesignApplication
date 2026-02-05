using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public class SFeatureSeed_SAll : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var seedUser = "SEED";
            var seedDate = new DateTime(2026, 02, 04);

            builder.HasData(
                new SFeature
                {
                    Id = SeedId.From("SFeature:PN"),
                    Code = "PN",
                    Name = "Basınç Sınıfı",
                    SortOrder = 10,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:DN"),
                    Code = "DN",
                    Name = "Anma Çapı",
                    SortOrder = 20,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                }
            );
        }
    }
}
