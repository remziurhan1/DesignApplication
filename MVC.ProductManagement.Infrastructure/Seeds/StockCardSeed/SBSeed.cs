using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    /// <summary>
    /// SB (Somunlar) ürünlerini seed eder.
    ///
    /// Neden bu seed var?
    /// - UI'daki "Product" dropdown'u SProduct tablosundan doluyor.
    /// - Kod üretiminde prefix kaynağı: SProduct.Code (örn: SBA0, SBB3...)
    /// - SProductGroupId = "B" (Somunlar) olduğu için ürünler doğru grupta listelenir.
    ///
    /// Neden SProductSeed_SAll içine koymuyoruz?
    /// - SProductSeed_SAll sadece SF (F grubu) için bırakıldı.
    /// - SA/SB gibi grupları ayrı seed etmek, geçmişte yaşadığımız seed çakışmasını engeller.
    /// </summary>
    public static class SBSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var seedUser = "SEED";
            var seedDate = new DateTime(2026, 02, 04);

            // Bu ID, SProductGroupSeed_SAll içindeki "B" (Somunlar) kaydının ID'si olmalı.
            // Diğer seed'ler/ürünler buradan grup ID alacağı için bu satır kritik.
            var sbGroupId = SeedId.From("SProductGroup:B");

            // Görseldeki tabloya %100 birebir:
            // SB + (A/B/C/D/E alt harfi) + (0-9 index)
            // Code alanı prefix görevinde: SBA0, SBB1, ...
            var items = new (string Code, string Name)[]
            {
                // A serisi
                ("SBA0","SOMUN AKB 8.8"),
                ("SBA1","SOMUN AKB 10.9"),
                ("SBA2","SOMUN AKB 12.9"),
                ("SBA3","SOMUN AKB SAPKALI 8.8"),
                ("SBA4","SOMUN AKB SAPKALI 10.9"),
                ("SBA5","SOMUN AKB SAPKALI 12.9"),
                ("SBA6","SOMUN AKB CROM"),
                ("SBA7","SOMUN AKB SAPKALI CROM"),
                ("SBA8","SOMUN AKB 8.8 FIBERLI"),
                ("SBA9","SOMUN AKB 10.9 FIBERLI"),

                // B serisi
                ("SBB0","SOMUN AKB 12.9 FIBERLI"),
                ("SBB1","SOMUN AKB FIBERLI CROM"),
                ("SBB2","SOMUN AKB KONTRALI 8.8"),
                ("SBB3","SOMUN AKB KONTRALI 10.9"),
                ("SBB4","SOMUN AKB KONTRALI 12.9"),
                ("SBB5","SOMUN AKB KONTRALI CROM"),
                ("SBB6","SOMUN AKB KAYNAK 8.8"),
                ("SBB7","SOMUN AKB KAYNAK 10.9"),
                ("SBB8","SOMUN AKB KAYNAK CROM"),
                ("SBB9","SOMUN AKB TACLI 8.8"),

                // C serisi (tabloda 0-3 var)
                ("SBC0","SOMUN AKB TACLI 10.9"),
                ("SBC1","SOMUN AKB TACLI CROM"),
                ("SBC2","SOMUN HALKALI"),
                ("SBC3","SOMUN KELEBEK"),

                // E serisi
                ("SBE0","SOMUN WHITWORTH / UNC / UNF"),
                ("SBE1","SOMUN ÖZEL GRUP (Ör: UZATMALI)"),

                // D serisi
                ("SBD0","SOMUN AKB A194 2H"),
                ("SBD1","SOMUN AKB A194-7"),
            };

            foreach (var (code, name) in items)
            {
                builder.Entity<SProduct>().HasData(new SProduct
                {
                    // Id'yi deterministik üretmek için code'u anahtar yapıyoruz.
                    // Böylece migration/seed her çalıştığında aynı ID gelir.
                    Id = SeedId.From($"SProduct:{code}"),

                    SProductGroupId = sbGroupId,
                    Code = code,
                    Name = name,

                    CreatedBy = seedUser,
                    CreatedDate = seedDate,
                    Status = Status.Added
                });
            }
        }
    }
}
