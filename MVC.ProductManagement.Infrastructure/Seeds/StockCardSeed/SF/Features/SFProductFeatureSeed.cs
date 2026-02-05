using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    /// <summary>
    /// SF ürünlerine hangi feature'ların atanacağını tanımlar
    /// F0 (Vana) -> PN, DN, SURFACE zorunlu
    /// F1, F2... için de eklenebilir
    /// </summary>
    public class SFProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var f0Id = SeedId.From("SProduct:SF:F0");
            var pnId = SeedId.From("SFeature:PN");
            var dnId = SeedId.From("SFeature:DN");
            var surfaceId = SeedId.From("SFeature:SURFACE");

            builder.HasData(
                // F0 (Vana) için PN zorunlu
                new SProductFeature
                {
                    Id = SeedId.From("SProductFeature:F0:PN"),
                    SProductId = f0Id,
                    SFeatureId = pnId,
                    IsRequired = true,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // F0 (Vana) için DN zorunlu
                new SProductFeature
                {
                    Id = SeedId.From("SProductFeature:F0:DN"),
                    SProductId = f0Id,
                    SFeatureId = dnId,
                    IsRequired = true,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                // F0 (Vana) için SURFACE opsiyonel
                new SProductFeature
                {
                    Id = SeedId.From("SProductFeature:F0:SURFACE"),
                    SProductId = f0Id,
                    SFeatureId = surfaceId,
                    IsRequired = false,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );

            // ✅ İleride F1, F2... için de ekleyebilirsiniz
            // Örnek:
            // var f1Id = SeedId.From("SProduct:SF:F1");
            // builder.HasData(
            //     new SProductFeature
            //     {
            //         Id = SeedId.From("SProductFeature:F1:PN"),
            //         SProductId = f1Id,
            //         SFeatureId = pnId,
            //         IsRequired = true,
            //         CreatedBy = "SEED",
            //         CreatedDate = now,
            //         Status = Domain.Enums.Status.Added
            //     }
            // );
        }
    }
}
