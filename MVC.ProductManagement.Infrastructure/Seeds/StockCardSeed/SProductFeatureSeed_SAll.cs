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
    public class SProductFeatureSeed_SAll : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var seedUser = "SEED";
            var seedDate = new DateTime(2026, 02, 04);

            // ✅ Senin SProductSeed formatına göre:
            // groupCode = F, digit = 0 -> code = F0 -> key = "SProduct:SF:F0"
            var f0ProductId = SeedId.From("SProduct:SF:F0");

            var pnId = SeedId.From("SFeature:PN");
            var dnId = SeedId.From("SFeature:DN");

            builder.HasData(
                new SProductFeature
                {
                    Id = SeedId.From("SProductFeature:SF:F0:PN"),
                    SProductId = f0ProductId,
                    SFeatureId = pnId,
                    IsRequired = true,
                    SortOrder = 10,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                },
                new SProductFeature
                {
                    Id = SeedId.From("SProductFeature:SF:F0:DN"),
                    SProductId = f0ProductId,
                    SFeatureId = dnId,
                    IsRequired = true,
                    SortOrder = 20,
                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                }
            );
        }
    }
}
