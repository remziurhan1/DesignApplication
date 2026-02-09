using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG
{
    public class SGProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // SG Grubu ID'si (G)
            var sgGroupId = SeedId.From("SProductGroup:G");

            var products = new List<SProduct>();
            int index = 0;

            // ==================== SGA SERİSİ: GRESORLAR VE PİMLER (10 adet) ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA0"),
                SProductGroupId = sgGroupId,
                Code = "SGA0",
                Name = "GRESORLUK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA1"),
                SProductGroupId = sgGroupId,
                Code = "SGA1",
                Name = "GUPİLYA / KOPİLYA",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA2"),
                SProductGroupId = sgGroupId,
                Code = "SGA2",
                Name = "PİM SİLİNDİRİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA3"),
                SProductGroupId = sgGroupId,
                Code = "SGA3",
                Name = "PİM KONİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA4"),
                SProductGroupId = sgGroupId,
                Code = "SGA4",
                Name = "PİM YAMA KOVANLI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA5"),
                SProductGroupId = sgGroupId,
                Code = "SGA5",
                Name = "PİM CENTİKLİ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA6"),
                SProductGroupId = sgGroupId,
                Code = "SGA6",
                Name = "PİM YAYLI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA7"),
                SProductGroupId = sgGroupId,
                Code = "SGA7",
                Name = "SEGMANLAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA8"),
                SProductGroupId = sgGroupId,
                Code = "SGA8",
                Name = "YARIKLI PİM",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SG:SGA9"),
                SProductGroupId = sgGroupId,
                Code = "SGA9",
                Name = "PERÇİN",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            builder.HasData(products);
        }
    }
}