using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC
{

    public class SCProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // SC Grubu ID'si (C)
            var scGroupId = SeedId.From("SProductGroup:C");

            var products = new List<SProduct>();
            int index = 0;

            // SCA0: RONDELA DÜZ ÇELİK
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA0"),
                SProductGroupId = scGroupId,
                Code = "SCA0",
                Name = "RONDELA DÜZ ÇELİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA1: RONDELA DÜZ ALÜMİNYUM
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA1"),
                SProductGroupId = scGroupId,
                Code = "SCA1",
                Name = "RONDELA DÜZ ALÜMİNYUM",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA2: RONDELA DÜZ BAKIR
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA2"),
                SProductGroupId = scGroupId,
                Code = "SCA2",
                Name = "RONDELA DÜZ BAKIR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA3: RONDELA DÜZ CROM
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA3"),
                SProductGroupId = scGroupId,
                Code = "SCA3",
                Name = "RONDELA DÜZ CROM",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA4: RONDELA YAYLI ÇELİK
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA4"),
                SProductGroupId = scGroupId,
                Code = "SCA4",
                Name = "RONDELA YAYLI ÇELİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA5: RONDELA YAYLI CROM
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA5"),
                SProductGroupId = scGroupId,
                Code = "SCA5",
                Name = "RONDELA YAYLI CROM",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA6: RONDELA TIRTIRLI ÇELİK
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA6"),
                SProductGroupId = scGroupId,
                Code = "SCA6",
                Name = "RONDELA TIRTIRLI ÇELİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA7: RONDELA ÇANAK ÇELİK
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA7"),
                SProductGroupId = scGroupId,
                Code = "SCA7",
                Name = "RONDELA ÇANAK ÇELİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA8: RONDELA GENİŞ ÇELİK
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA8"),
                SProductGroupId = scGroupId,
                Code = "SCA8",
                Name = "RONDELA GENİŞ ÇELİK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCE1: RONDELA ÖZEL GRUP
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCE1"),
                SProductGroupId = scGroupId,
                Code = "SCE1",
                Name = "RONDELA ÖZEL GRUP (Ör:Süper,EPDM/II)",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCA9: RONDELA SQUARE TAPERED
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCA9"),
                SProductGroupId = scGroupId,
                Code = "SCA9",
                Name = "RONDELA SQUARE TAPERED",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // SCB0: RONDELA TIRTIRLI PASLANMAZ
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SC:SCB0"),
                SProductGroupId = scGroupId,
                Code = "SCB0",
                Name = "RONDELA TIRTIRLI PASLANMAZ",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            builder.HasData(products);
        }
    }
}
