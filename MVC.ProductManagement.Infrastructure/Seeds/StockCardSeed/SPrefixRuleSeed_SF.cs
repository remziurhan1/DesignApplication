using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public class SPrefixRuleSeed_SF : IEntityTypeConfiguration<SPrefixRule>
    {
        public void Configure(EntityTypeBuilder<SPrefixRule> builder)
        {
            var now = new DateTime(2026, 01, 01);

            var rules = new List<SPrefixRule>();

            // SF = Aksesuarlar => SProductGroup:F
            var sfGroupId = SeedId.From("SProductGroup:F");

            // 0..8 (LPG + Cryo ortak)
            int[] commonIdx = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            // 1) LPG (Fluid:A) -> SFA0..SFA8
            foreach (var idx in commonIdx)
            {
                rules.Add(NewRule(
                    idKey: $"SPrefixRule:SF:A:{idx}",
                    groupId: sfGroupId,
                    fluidId: SeedId.From("Fluid:A"),
                    productId: SProductId_SF(idx),
                    prefix: $"SFA{idx}",
                    now: now
                ));
            }

            // 2) Cryogenic ailesi: LNG(B), LOX(C), LIN(D), CO2(E) -> SFC0..SFC8
            var cryoFluids = new[] { "B", "C", "D", "E" };
            foreach (var f in cryoFluids)
            {
                foreach (var idx in commonIdx)
                {
                    rules.Add(NewRule(
                        idKey: $"SPrefixRule:SF:{f}:{idx}",
                        groupId: sfGroupId,
                        fluidId: SeedId.From($"Fluid:{f}"),
                        productId: SProductId_SF(idx),
                        prefix: $"SFC{idx}",
                        now: now
                    ));
                }
            }

            // 3) FUEL (Fluid:F) -> SFF0..SFF9
            for (int idx = 0; idx <= 9; idx++)
            {
                rules.Add(NewRule(
                    idKey: $"SPrefixRule:SF:F:{idx}",
                    groupId: sfGroupId,
                    fluidId: SeedId.From("Fluid:F"),
                    productId: SProductId_SF(idx),
                    prefix: $"SFF{idx}",
                    now: now
                ));
            }

            builder.HasData(rules);
        }

        // Senin SProductSeed_SAll formatına göre:
        // Id = SeedId.From($"SProduct:S{groupCode}:{code}")
        // SF için groupCode = F, code = F{digit} => "SProduct:SF:F0"
        private static Guid SProductId_SF(int digit)
            => SeedId.From($"SProduct:SF:F{digit}");

        private static SPrefixRule NewRule(string idKey, Guid groupId, Guid fluidId, Guid productId, string prefix, DateTime now)
        {
            return new SPrefixRule
            {
                Id = SeedId.From(idKey),
                SProductGroupId = groupId,
                FluidId = fluidId,
                SProductId = productId,
                Prefix = prefix,
                CreatedBy = "SEED",
                CreatedDate = now
            };
        }
    }
}
