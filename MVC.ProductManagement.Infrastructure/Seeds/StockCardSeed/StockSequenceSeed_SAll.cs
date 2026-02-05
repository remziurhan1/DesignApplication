
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public class StockSequenceSeed_SAll : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 01, 01);
            var seqs = new List<StockSequence>();

            foreach (var prefix4 in SAllDefinitions.AllPrefixes())
            {
                seqs.Add(new StockSequence
                {
                    Id = SeedId.From($"StockSequence:{prefix4}"),
                    Prefix4 = prefix4,
                    StartNumber = 0,
                    LastNumber = -1,
                    CreatedBy = "SEED",
                    CreatedDate = now
                });
            }

            builder.HasData(seqs);
        }
    }
}
