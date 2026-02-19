using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB
{
    public static class SBSeed
    {
        public class SBProductSeed : IEntityTypeConfiguration<SProduct>
        {
            public void Configure(EntityTypeBuilder<SProduct> builder)
            {
                var now = new DateTime(2026, 02, 05);
                var sbGroupId = SeedId.From("SProductGroup:B");

                var items = new (string Code, string Name)[]
                {
                    // A serisi
                    ("SBA0", "SOMUN AKB 8.8"),
                    ("SBA1", "SOMUN AKB 10.9"),
                    ("SBA2", "SOMUN AKB 12.9"),
                    ("SBA3", "SOMUN AKB SAPKALI 8.8"),
                    ("SBA4", "SOMUN AKB SAPKALI 10.9"),
                    ("SBA5", "SOMUN AKB SAPKALI 12.9"),
                    ("SBA6", "SOMUN AKB CROM"),
                    ("SBA7", "SOMUN AKB SAPKALI CROM"),
                    ("SBA8", "SOMUN AKB 8.8 FIBERLI"),
                    ("SBA9", "SOMUN AKB 10.9 FIBERLI"),
                    // B serisi
                    ("SBB0", "SOMUN AKB 12.9 FIBERLI"),
                    ("SBB1", "SOMUN AKB FIBERLI CROM"),
                    ("SBB2", "SOMUN AKB KONTRALI 8.8"),
                    ("SBB3", "SOMUN AKB KONTRALI 10.9"),
                    ("SBB4", "SOMUN AKB KONTRALI 12.9"),
                    ("SBB5", "SOMUN AKB KONTRALI CROM"),
                    ("SBB6", "SOMUN AKB KAYNAK 8.8"),
                    ("SBB7", "SOMUN AKB KAYNAK 10.9"),
                    ("SBB8", "SOMUN AKB KAYNAK CROM"),
                    ("SBB9", "SOMUN AKB TACLI 8.8"),
                    // C serisi
                    ("SBC0", "SOMUN AKB TACLI 10.9"),
                    ("SBC1", "SOMUN AKB TACLI CROM"),
                    ("SBC2", "SOMUN HALKALI"),
                    ("SBC3", "SOMUN KELEBEK"),
                    // D serisi
                    ("SBD0", "SOMUN AKB A194 2H"),
                    ("SBD1", "SOMUN AKB A194-7"),
                    // E serisi
                    ("SBE0", "SOMUN WHITWORTH / UNC / UNF"),
                    ("SBE1", "SOMUN ÖZEL GRUP (Ör: UZATMALI)")
                };

                foreach (var (code, name) in items)
                {
                    var lastChar = code[^1];
                    var digit = char.IsDigit(lastChar) ? int.Parse(lastChar.ToString()) : 0;

                    builder.HasData(new SProduct
                    {
                        Id = SeedId.From($"SProduct:SB:{code}"),
                        SProductGroupId = sbGroupId,
                        Code = code,
                        Name = name,
                        PrefixIndex = digit,
                        CreatedBy = "SEED",
                        CreatedDate = now,
                        Status = Domain.Enums.Status.Added
                    });
                }
            }
        }
    }
}