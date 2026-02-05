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
    public class SFeatureValueSeed_SAll : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var seedUser = "SEED";
            var seedDate = new DateTime(2026, 02, 04);

            var pnId = SeedId.From("SFeature:PN");
            var dnId = SeedId.From("SFeature:DN");

            builder.HasData(
                // PN values
                new SFeatureValue
                {
                    Id = SeedId.From("SFeatureValue:PN:PN16"),
                    SFeatureId = pnId,
                    Code = "PN16",
                    Name = "PN16",
                    SortOrder = 10,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                },
                new SFeatureValue
                {
                    Id = SeedId.From("SFeatureValue:PN:PN40"),
                    SFeatureId = pnId,
                    Code = "PN40",
                    Name = "PN40",
                    SortOrder = 20,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                },

                // DN values
                new SFeatureValue
                {
                    Id = SeedId.From("SFeatureValue:DN:DN25"),
                    SFeatureId = dnId,
                    Code = "DN25",
                    Name = "DN25",
                    SortOrder = 10,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                },
                new SFeatureValue
                {
                    Id = SeedId.From("SFeatureValue:DN:DN50"),
                    SFeatureId = dnId,
                    Code = "DN50",
                    Name = "DN50",
                    SortOrder = 20,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                }
            );
        }
    }
}
