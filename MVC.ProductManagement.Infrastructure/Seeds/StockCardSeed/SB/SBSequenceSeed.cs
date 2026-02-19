using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB
{
    public class SBSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var prefixes = new[]
            {
                "SBA0","SBA1","SBA2","SBA3","SBA4","SBA5","SBA6","SBA7","SBA8","SBA9",
                "SBB0","SBB1","SBB2","SBB3","SBB4","SBB5","SBB6","SBB7","SBB8","SBB9",
                "SBC0","SBC1","SBC2","SBC3","SBD0", "SBD1", "SBE0", "SBE1"
            };

            foreach (var prefix in prefixes)
            {
                builder.HasData(new StockSequence
                {
                    Id = SeedId.From($"StockSequence:{prefix}"),
                    Prefix4 = prefix,
                    LastNumber = -1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }
        }
    }
}