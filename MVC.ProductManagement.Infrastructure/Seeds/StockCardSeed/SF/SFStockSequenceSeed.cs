using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFStockSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var prefixes = new[]
            {
                // LPG
                "SFA0","SFA1","SFA2","SFA3","SFA4","SFA5","SFA6","SFA7","SFA8","SFA9",
                // Cryogenic
                "SFC0","SFC1","SFC2","SFC3","SFC4","SFC5","SFC6","SFC7","SFC8",
                // Akaryakıt
                "SFF0","SFF1","SFF2","SFF3","SFF4","SFF5","SFF6","SFF7","SFF8","SFF9",
                // Su/Hidrolik/Pnömatik + Ölçüm
                "SFG0","SFG1","SFG2","SFG3","SFG4","SFG5","SFG6","SFG7","SFG8","SFG9",
                // Özel
                "SFH0","SFH1","SFH2","SFH3","SFH4","SFH5","SFH6",
                // Doğal Gaz
                "SFJ0","SFJ1","SFJ2","SFJ3","SFJ4","SFJ5","SFJ6","SFJ7","SFJ8",
                // Kimyasal
                "SFK0","SFK1","SFK2","SFK3","SFK4","SFK5","SFK6","SFK7","SFK8","SFK9",
                // Proses Gaz
                "SFL0","SFL1","SFL2"
            };

            var sequences = new List<StockSequence>();
            foreach (var prefix in prefixes)
            {
                sequences.Add(new StockSequence
                {
                    Id = SeedId.From($"StockSequence:{prefix}"),
                    Prefix4 = prefix,
                    LastNumber = -1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            builder.HasData(sequences);
        }
    }
}