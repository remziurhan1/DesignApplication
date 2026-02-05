using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA
{
    public class SASequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var prefixes = new[]
            {
                // A serisi
                "SAA0", "SAA1", "SAA2", "SAA3", "SAA4", "SAA5", "SAA6", "SAA7", "SAA8", "SAA9",
                // B serisi
                "SAB0", "SAB1", "SAB2", "SAB3", "SAB4", "SAB5", "SAB6", "SAB7", "SAB8", "SAB9",
                // C serisi
                "SAC0", "SAC1", "SAC2", "SAC3", "SAC4", "SAC5", "SAC6",
                // D serisi
                "SAD0", "SAD1",
                // E serisi
                "SAE0", "SAE1", "SAE2", "SAE3", "SAE4", "SAE5", "SAE6", "SAE7", "SAE8"
            };

            foreach (var prefix in prefixes)
            {
                builder.HasData(new StockSequence
                {
                    Id = SeedId.From($"StockSequence:{prefix}"),
                    Prefix4 = prefix,
                    LastNumber = 999, // 1000'den başlasın
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }
        }
    }
}
