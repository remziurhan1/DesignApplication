using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC
{
    public class SCStockSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var scPrefixes = new[]
            {
                "SCA0","SCA1","SCA2","SCA3","SCA4","SCA5",
                "SCA6","SCA7","SCA8","SCA9",
                "SCB0",
                "SCE1"
            };

            var sequences = new List<StockSequence>();
            foreach (var prefix in scPrefixes)
            {
                sequences.Add(new StockSequence
                {
                    Id = SeedId.From($"StockSequence:{prefix}"),
                    Prefix4 = prefix,
                    LastNumber = -1, // ✅ -1 → ilk üretilen kod 0000 olur
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            builder.HasData(sequences);
        }
    }
}