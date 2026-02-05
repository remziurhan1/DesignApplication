using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var sequences = new List<StockSequence>();

            // SFA serisi (LPG için: 0-8)
            for (int i = 0; i <= 8; i++)
            {
                sequences.Add(CreateSequence($"SFA{i}", now));
            }

            // SFC serisi (Cryogenic için: 0-8)
            for (int i = 0; i <= 8; i++)
            {
                sequences.Add(CreateSequence($"SFC{i}", now));
            }

            // SFF serisi (FUEL için: 0-9)
            for (int i = 0; i <= 9; i++)
            {
                sequences.Add(CreateSequence($"SFF{i}", now));
            }

            builder.HasData(sequences);
        }

        private static StockSequence CreateSequence(string prefix, DateTime now) => new StockSequence
        {
            Id = SeedId.From($"StockSequence:{prefix}"),
            Prefix4 = prefix,
            LastNumber = 999, // 1000'den başlasın
            CreatedBy = "SEED",
            CreatedDate = now,
            Status = Domain.Enums.Status.Added
        };
    }
}
