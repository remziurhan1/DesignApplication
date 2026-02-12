using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE
{
    public class SEProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // SE Grubu ID'si (E)
            var seGroupId = SeedId.From("SProductGroup:E");

            var products = new List<SProduct>();
            int index = 0;

            // ==================== SEA SERİSİ (11 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA0"),
                SProductGroupId = seGroupId,
                Code = "SEA0",
                Name = "KABLO TESİSAT",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA1"),
                SProductGroupId = seGroupId,
                Code = "SEA1",
                Name = "KABLO AKÜ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA2"),
                SProductGroupId = seGroupId,
                Code = "SEA2",
                Name = "KABLO TTR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA3"),
                SProductGroupId = seGroupId,
                Code = "SEA3",
                Name = "BAKIR KALAY KAPLI KABLO",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA4"),
                SProductGroupId = seGroupId,
                Code = "SEA4",
                Name = "AKÜ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA5"),
                SProductGroupId = seGroupId,
                Code = "SEA5",
                Name = "SİGORTA",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA6"),
                SProductGroupId = seGroupId,
                Code = "SEA6",
                Name = "ŞALTER",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA7"),
                SProductGroupId = seGroupId,
                Code = "SEA7",
                Name = "RÖLE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA8"),
                SProductGroupId = seGroupId,
                Code = "SEA8",
                Name = "KONNEKTÖR & SOKET",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEA9"),
                SProductGroupId = seGroupId,
                Code = "SEA9",
                Name = "DİYOT",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEAA"),
                SProductGroupId = seGroupId,
                Code = "SEAA",
                Name = "KABLO ENDÜSTRİYEL",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SEB SERİSİ (10 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB0"),
                SProductGroupId = seGroupId,
                Code = "SEB0",
                Name = "AMPUL & LAMBA",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB1"),
                SProductGroupId = seGroupId,
                Code = "SEB1",
                Name = "SWITCH & BUTTON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB2"),
                SProductGroupId = seGroupId,
                Code = "SEB2",
                Name = "PABUÇ TERMİNAL",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB3"),
                SProductGroupId = seGroupId,
                Code = "SEB3",
                Name = "NR TERMİNAL PİPE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB4"),
                SProductGroupId = seGroupId,
                Code = "SEB4",
                Name = "SPİRAL MAKARON/KABLO KILIFI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB5"),
                SProductGroupId = seGroupId,
                Code = "SEB5",
                Name = "ISI BÜZÜŞMELİ MAKARON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB6"),
                SProductGroupId = seGroupId,
                Code = "SEB6",
                Name = "KABLO KANALI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB7"),
                SProductGroupId = seGroupId,
                Code = "SEB7",
                Name = "KLEMENS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB8"),
                SProductGroupId = seGroupId,
                Code = "SEB8",
                Name = "ELEKTRİK TESİSAT REKORLARI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEB9"),
                SProductGroupId = seGroupId,
                Code = "SEB9",
                Name = "KABLO UÇ YÜKSÜĞÜ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SEC SERİSİ (10 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC0"),
                SProductGroupId = seGroupId,
                Code = "SEC0",
                Name = "KABLO VE KUMANDA SİSTEMLERİ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC1"),
                SProductGroupId = seGroupId,
                Code = "SEC1",
                Name = "ELEKTRİK MOTORU",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC2"),
                SProductGroupId = seGroupId,
                Code = "SEC2",
                Name = "LOAD CELL",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC3"),
                SProductGroupId = seGroupId,
                Code = "SEC3",
                Name = "DİĞER KABLOLAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC4"),
                SProductGroupId = seGroupId,
                Code = "SEC4",
                Name = "ELEKTRİKLİ ISITICILAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC5"),
                SProductGroupId = seGroupId,
                Code = "SEC5",
                Name = "KORNALAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC6"),
                SProductGroupId = seGroupId,
                Code = "SEC6",
                Name = "GÜÇ KAYNAKLARI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC7"),
                SProductGroupId = seGroupId,
                Code = "SEC7",
                Name = "KABLO TAMBUR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC8"),
                SProductGroupId = seGroupId,
                Code = "SEC8",
                Name = "VERİ OKUMA CİHAZLARI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEC9"),
                SProductGroupId = seGroupId,
                Code = "SEC9",
                Name = "SİGORTA RAYI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SED SERİSİ (3 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SED0"),
                SProductGroupId = seGroupId,
                Code = "SED0",
                Name = "ALGILAYICILAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SED1"),
                SProductGroupId = seGroupId,
                Code = "SED1",
                Name = "HABERLEŞME MODÜLLERİ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SED9"),
                SProductGroupId = seGroupId,
                Code = "SED9",
                Name = "TABELALR VE LEVHALAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SEE SERİSİ (1 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEE0"),
                SProductGroupId = seGroupId,
                Code = "SEE0",
                Name = "ELEKTRİK MALZEMELER",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SEF SERİSİ (2 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEF0"),
                SProductGroupId = seGroupId,
                Code = "SEF0",
                Name = "KABLO",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEF1"),
                SProductGroupId = seGroupId,
                Code = "SEF1",
                Name = "KABLO ENDÜSTRİYEL",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SEG SERİSİ (1 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SE:SEG0"),
                SProductGroupId = seGroupId,
                Code = "SEG0",
                Name = "BAĞLANTI KUTUSU",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            builder.HasData(products);
        }
    }
}