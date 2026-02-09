using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD
{
    public class SDProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // SD Grubu ID'si (D)
            var sdGroupId = SeedId.From("SProductGroup:D");

            var products = new List<SProduct>();
            int index = 0;

            // ==================== SDA: HİDROLİK ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA0"),
                SProductGroupId = sdGroupId,
                Code = "SDA0",
                Name = "HİDROLİK REKOR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA1"),
                SProductGroupId = sdGroupId,
                Code = "SDA1",
                Name = "HİDROLİK TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA2"),
                SProductGroupId = sdGroupId,
                Code = "SDA2",
                Name = "HİDROLİK DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA3"),
                SProductGroupId = sdGroupId,
                Code = "SDA3",
                Name = "HİDROLİK REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA4"),
                SProductGroupId = sdGroupId,
                Code = "SDA4",
                Name = "HİDROLİK DİĞER BAĞLANTI ELEMANLARI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA5"),
                SProductGroupId = sdGroupId,
                Code = "SDA5",
                Name = "ÇELİK FİTTİNGS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA6"),
                SProductGroupId = sdGroupId,
                Code = "SDA6",
                Name = "PASLANMAZ FİTTİNGS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA7"),
                SProductGroupId = sdGroupId,
                Code = "SDA7",
                Name = "PİRİNÇ FİTTİNGS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA8"),
                SProductGroupId = sdGroupId,
                Code = "SDA8",
                Name = "PPR - PE FİTTİNGS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDA9"),
                SProductGroupId = sdGroupId,
                Code = "SDA9",
                Name = "ALÜMİNYUM FİTTİNGS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDB: PNÖMATİK ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDB0"),
                SProductGroupId = sdGroupId,
                Code = "SDB0",
                Name = "PNÖMATİK REKOR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDB1"),
                SProductGroupId = sdGroupId,
                Code = "SDB1",
                Name = "PNÖMATİK TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDB2"),
                SProductGroupId = sdGroupId,
                Code = "SDB2",
                Name = "PNÖMATİK DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDB3"),
                SProductGroupId = sdGroupId,
                Code = "SDB3",
                Name = "PNÖMATİK REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDB4"),
                SProductGroupId = sdGroupId,
                Code = "SDB4",
                Name = "PNÖMATİK DİĞER BAĞLANTI ELEMANLARI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDC: ÇELİK ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDC0"),
                SProductGroupId = sdGroupId,
                Code = "SDC0",
                Name = "ÇELİK DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDC1"),
                SProductGroupId = sdGroupId,
                Code = "SDC1",
                Name = "ÇELİK FLANS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDC2"),
                SProductGroupId = sdGroupId,
                Code = "SDC2",
                Name = "ÇELİK REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDC3"),
                SProductGroupId = sdGroupId,
                Code = "SDC3",
                Name = "ÇELİK BORU BOĞAZI/BAĞLAYICI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDC4"),
                SProductGroupId = sdGroupId,
                Code = "SDC4",
                Name = "ÇELİK TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDD: ALÜMİNYUM ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDD0"),
                SProductGroupId = sdGroupId,
                Code = "SDD0",
                Name = "ALÜ. DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDD1"),
                SProductGroupId = sdGroupId,
                Code = "SDD1",
                Name = "ALÜ. FLANS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDD2"),
                SProductGroupId = sdGroupId,
                Code = "SDD2",
                Name = "ALÜ. REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDD3"),
                SProductGroupId = sdGroupId,
                Code = "SDD3",
                Name = "ALÜ. BORU BOĞAZI/BAĞLAYICI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDD4"),
                SProductGroupId = sdGroupId,
                Code = "SDD4",
                Name = "ALÜ. TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDD5"),
                SProductGroupId = sdGroupId,
                Code = "SDD5",
                Name = "ALÜ. REKOR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDE: PASLANMAZ ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDE0"),
                SProductGroupId = sdGroupId,
                Code = "SDE0",
                Name = "PASLANMAZ DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDE1"),
                SProductGroupId = sdGroupId,
                Code = "SDE1",
                Name = "PASLANMAZ FLANS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDE2"),
                SProductGroupId = sdGroupId,
                Code = "SDE2",
                Name = "PASLANMAZ REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDE3"),
                SProductGroupId = sdGroupId,
                Code = "SDE3",
                Name = "PASLANMAZ BORU BOĞAZI/BAĞLAYICI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDE4"),
                SProductGroupId = sdGroupId,
                Code = "SDE4",
                Name = "PASLANMAZ TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDF: PİRİNÇ ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDF0"),
                SProductGroupId = sdGroupId,
                Code = "SDF0",
                Name = "PİRİNÇ DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDF1"),
                SProductGroupId = sdGroupId,
                Code = "SDF1",
                Name = "PİRİNÇ FLANS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDF2"),
                SProductGroupId = sdGroupId,
                Code = "SDF2",
                Name = "PİRİNÇ REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDF3"),
                SProductGroupId = sdGroupId,
                Code = "SDF3",
                Name = "PİRİNÇ BORU BOĞAZI/BAĞLAYICI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDF4"),
                SProductGroupId = sdGroupId,
                Code = "SDF4",
                Name = "PİRİNÇ TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDF9"),
                SProductGroupId = sdGroupId,
                Code = "SDF9",
                Name = "POLYEMİD/POLİETİLEN DİRSEK",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDG: POLYEMİD/POLİETİLEN ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDG1"),
                SProductGroupId = sdGroupId,
                Code = "SDG1",
                Name = "POLYEMİD/POLİETİLEN REDÜKSİYON",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDG3"),
                SProductGroupId = sdGroupId,
                Code = "SDG3",
                Name = "POLYEMİD/POLİETİLEN TEE",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDH: GALVANİZ ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDH0"),
                SProductGroupId = sdGroupId,
                Code = "SDH0",
                Name = "GALVANİZ FLANSLAR",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDH1"),
                SProductGroupId = sdGroupId,
                Code = "SDH1",
                Name = "GALVANİZ FİTTİNGS ELEMANLARI",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ==================== SDI: BRONZ ====================
            products.Add(new SProduct
            {
                Id = SeedId.From("SProduct:SD:SDI1"),
                SProductGroupId = sdGroupId,
                Code = "SDI1",
                Name = "BRONZ FLANS",
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            builder.HasData(products);
        }
    }
}