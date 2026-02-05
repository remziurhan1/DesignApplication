using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.S;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    /// <summary>
    /// SF grubu için prefix kuralları:
    /// - LPG (A) -> SFA0, SFA1...
    /// - Cryogenic (B,C,D,E) -> SFC0, SFC1...
    /// - FUEL (F) -> SFF0, SFF1...
    /// </summary>
    public class SFPrefixRuleSeed : IEntityTypeConfiguration<SPrefixRule>
    {
        public void Configure(EntityTypeBuilder<SPrefixRule> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var rules = new List<SPrefixRule>();

            var sfGroupId = SeedId.From("SProductGroup:F");
            int[] commonIdx = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            // 1) LPG (Fluid:A) -> SFA0..SFA8
            foreach (var idx in commonIdx)
            {
                rules.Add(CreateRule(
                    idKey: $"SPrefixRule:SF:A:{idx}",
                    groupId: sfGroupId,
                    fluidId: SeedId.From("Fluid:A"),
                    productId: SeedId.From($"SProduct:SF:F{idx}"),
                    prefix: $"SFA{idx}",
                    now: now
                ));
            }

            // 2) Cryogenic (LNG=B, LOX=C, LIN=D, CO2=E) -> SFC0..SFC8
            var cryoFluids = new[] { "B", "C", "D", "E" };
            foreach (var fluidCode in cryoFluids)
            {
                foreach (var idx in commonIdx)
                {
                    rules.Add(CreateRule(
                        idKey: $"SPrefixRule:SF:{fluidCode}:{idx}",
                        groupId: sfGroupId,
                        fluidId: SeedId.From($"Fluid:{fluidCode}"),
                        productId: SeedId.From($"SProduct:SF:F{idx}"),
                        prefix: $"SFC{idx}",
                        now: now
                    ));
                }
            }

            // 3) FUEL (Fluid:F) -> SFF0..SFF9
            for (int idx = 0; idx <= 9; idx++)
            {
                rules.Add(CreateRule(
                    idKey: $"SPrefixRule:SF:F:{idx}",
                    groupId: sfGroupId,
                    fluidId: SeedId.From("Fluid:F"),
                    productId: SeedId.From($"SProduct:SF:F{idx}"),
                    prefix: $"SFF{idx}",
                    now: now
                ));
            }

            builder.HasData(rules);
        }

        private static SPrefixRule CreateRule(
            string idKey,
            Guid groupId,
            Guid fluidId,
            Guid productId,
            string prefix,
            DateTime now)
        {
            return new SPrefixRule
            {
                Id = SeedId.From(idKey),
                SProductGroupId = groupId,
                FluidId = fluidId,
                SProductId = productId,
                Prefix = prefix,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            };
        }
    }
}
