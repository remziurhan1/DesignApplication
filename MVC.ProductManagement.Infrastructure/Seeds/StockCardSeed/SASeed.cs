using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using System;
using System.Linq;

// TODO: SeedId hangi namespace'te ise onu ekle
using MVC.ProductManagement.Infrastructure.Seeds;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public static class SASeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var seedUser = "SEED";
            var seedDate = new DateTime(2026, 02, 04);

            // ✅ SProductGroupSeed_SAll ile birebir uyumlu
            var saGroupId = SeedId.From("SProductGroup:A");

            var items = new (string Prefix4, string Name)[]
            {
                ("SAA0","CİVATA AKB 8.8"),
                ("SAA1","CİVATA AKB 10.9"),
                ("SAA2","CİVATA AKB 12.9"),
                ("SAA3","CİVATA AKB SAPKALI 8.8"),
                ("SAA4","CİVATA AKB SAPKALI 10.9"),
                ("SAA5","CİVATA AKB SAPKALI 12.9"),
                ("SAA6","CİVATA AKB CROM"),
                ("SAA7","CİVATA SB İNBUS 8.8"),
                ("SAA8","CİVATA SB İNBUS 10.9"),
                ("SAA9","CİVATA SB İNBUS 12.9"),

                ("SAB0","CİVATA SB TORNAVİDA YARIKLI 8.8"),
                ("SAB1","CİVATA SB YILDIZ KANALLI 8.8"),
                ("SAB2","CİVATA SB İNBUS CROM"),
                ("SAB3","CİVATA HB İNBUS 8.8"),
                ("SAB4","CİVATA HB İNBUS 10.9"),
                ("SAB5","CİVATA HB İNBUS 12.9"),
                ("SAB6","CİVATA HB TORNAVİDA YARIKLI 8.8"),
                ("SAB7","CİVATA HB YILDIZ KANALLI 8.8"),
                ("SAB8","CİVATA HB İNBUS CROM"),
                ("SAB9","CİVATA HB YILDIZ KANALLI CROM"),

                ("SAC0","CİVATA HB SAC VİDASI/AKILLI VİDA CROM"),
                ("SAC1","CİVATA MB DUZ 8.8"),
                ("SAC2","CİVATA MB TORNAVİDA YARIKLI 8.8"),
                ("SAC3","CİVATA MB YILDIZ KANALLI 8.8"),
                ("SAC4","CİVATA MB İNBUS CROM"),
                ("SAC5","CİVATA MB SAC VİDASI/AKILLI VİDA CROM"),
                ("SAC6","CİVATA KB (KELEBEK BASLI)"),

                ("SAD0","CİVATA AKB A193 B7"),
                ("SAD1","CİVATA AKB A320 L7"),

                ("SAE0","CİVATA WHITWORTH / UNC / UNF"),
                ("SAE1","CİVATA ÖZEL GRUP"),
                ("SAE2","PERCIN CELIK"),
                ("SAE3","PERCIN ALUMINYUM"),
                ("SAE4","PERCIN KROM"),
                ("SAE5","PERCIN SOMUN"),
                ("SAE6","SAPLAMALAR"),
                ("SAE7","CİVATA SETŞKUR"),
                ("SAE8","U-BOLT"),
            };

            var products = items.Select(x => new SProduct
            {
                Id = SeedId.From($"SProduct:{x.Prefix4}"),
                SProductGroupId = saGroupId,
                Code = x.Prefix4,
                Name = x.Name,
                PrefixIndex = int.Parse(x.Prefix4[^1].ToString()),
                CreatedBy = seedUser,
                CreatedDate = seedDate,
                Status = Domain.Enums.Status.Added
            }).ToArray();

            builder.Entity<SProduct>().HasData(products);

            // StockSequence seed'i zaten StockSequenceSeed_SAll içinde.
        }
    }
}
