using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public class PrefixRuleSeed_SAll : IEntityTypeConfiguration<PrefixRule>
    {
        public void Configure(EntityTypeBuilder<PrefixRule> builder)
        {
            var now = new DateTime(2026, 01, 01);
            var rules = new List<PrefixRule>();

            foreach (var prefix4 in SAllDefinitions.AllPrefixes())
            {
                var groupCode = prefix4[1].ToString();    // F
                var step3Code = prefix4[2].ToString();    // A
                var digit = prefix4[3].ToString();        // 0

                var sProductGroupId = SeedId.From($"SProductGroup:{groupCode}");
                var sProductId = SeedId.From($"SProduct:S{groupCode}:{step3Code}{digit}");

                // Fluid: Code = A/B/C/... (senin Fluid tablon)
                var fluidId = SeedId.From($"Fluid:{step3Code}");

                rules.Add(new PrefixRule
                {
                    Id = SeedId.From($"PrefixRule:{prefix4}"),
                    FluidId = fluidId,
                    SProductGroupId = sProductGroupId,
                    SProductId = sProductId,
                    Prefix4 = prefix4,
                    CreatedBy = "SEED",
                    CreatedDate = now
                });
            }

            builder.HasData(rules);
        }
    }
}
