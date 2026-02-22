using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    public class SFFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_AKIS_MEDYUMU"),
                    Code = "SF_AKIS_MEDYUMU",
                    Name = "Akış Medyumu",
                    SortOrder = 1,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_MARKA"),
                    Code = "SF_MARKA",
                    Name = "Marka",
                    SortOrder = 2,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_VANA_TIPI"),
                    Code = "SF_VANA_TIPI",
                    Name = "Vana Tipi",
                    SortOrder = 3,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_AKTUATOR"),
                    Code = "SF_AKTUATOR",
                    Name = "Aktüatör Tipi",
                    SortOrder = 4,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_DN"),
                    Code = "SF_DN",
                    Name = "DN / Nominal Çap",
                    SortOrder = 5,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_BASINC_SINIFI"),
                    Code = "SF_BASINC_SINIFI",
                    Name = "Basınç Sınıfı",
                    SortOrder = 6,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_BAGLANTI_TIPI"),
                    Code = "SF_BAGLANTI_TIPI",
                    Name = "Bağlantı Tipi",
                    SortOrder = 7,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_MALZEME"),
                    Code = "SF_MALZEME",
                    Name = "Malzeme",
                    SortOrder = 8,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_AYAR_BASINCI"),
                    Code = "SF_AYAR_BASINCI",
                    Name = "Ayar Basıncı",
                    SortOrder = 9,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_GIRIS_BASINCI"),
                    Code = "SF_GIRIS_BASINCI",
                    Name = "Giriş Basıncı",
                    SortOrder = 10,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_CIKIS_BASINCI"),
                    Code = "SF_CIKIS_BASINCI",
                    Name = "Çıkış Basıncı",
                    SortOrder = 11,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_BAGLANTI_CAPI"),
                    Code = "SF_BAGLANTI_CAPI",
                    Name = "Bağlantı Çapı",
                    SortOrder = 12,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_OLCUM_TIPI"),
                    Code = "SF_OLCUM_TIPI",
                    Name = "Ölçüm Tipi",
                    SortOrder = 13,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_CIKIS_SINYALI"),
                    Code = "SF_CIKIS_SINYALI",
                    Name = "Çıkış Sinyali",
                    SortOrder = 14,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_VALF_TIPI"),
                    Code = "SF_VALF_TIPI",
                    Name = "Valf Tipi",
                    SortOrder = 15,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_SAYAC_TIPI"),
                    Code = "SF_SAYAC_TIPI",
                    Name = "Sayaç Tipi",
                    SortOrder = 16,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_GOZNEK"),
                    Code = "SF_GOZNEK",
                    Name = "Gözenek Boyutu",
                    SortOrder = 17,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_POMPA_TIPI"),
                    Code = "SF_POMPA_TIPI",
                    Name = "Pompa Tipi",
                    SortOrder = 18,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_GUC_KW"),
                    Code = "SF_GUC_KW",
                    Name = "Güç (kW)",
                    SortOrder = 19,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_ADAPTOR_TIPI"),
                    Code = "SF_ADAPTOR_TIPI",
                    Name = "Adaptör Tipi",
                    SortOrder = 20,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_BAGLANTI_1"),
                    Code = "SF_BAGLANTI_1",
                    Name = "Bağlantı 1",
                    SortOrder = 21,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_BAGLANTI_2"),
                    Code = "SF_BAGLANTI_2",
                    Name = "Bağlantı 2",
                    SortOrder = 22,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_CAPI_MM"),
                    Code = "SF_CAPI_MM",
                    Name = "Çap (mm)",
                    SortOrder = 23,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_OLCUM_ARALIGI"),
                    Code = "SF_OLCUM_ARALIGI",
                    Name = "Ölçüm Aralığı",
                    SortOrder = 24,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_MANOMETRE_TIPI"),
                    Code = "SF_MANOMETRE_TIPI",
                    Name = "Manometre Tipi",
                    SortOrder = 25,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_DALDIRMA_BOYU"),
                    Code = "SF_DALDIRMA_BOYU",
                    Name = "Daldırma Boyu",
                    SortOrder = 26,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_CONTA_TIPI"),
                    Code = "SF_CONTA_TIPI",
                    Name = "Conta Tipi",
                    SortOrder = 27,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_TIP"),
                    Code = "SF_TIP",
                    Name = "Tip",
                    SortOrder = 28,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                },
                new SFeature
                {
                    Id = SeedId.From("SFeature:SF_KAPASITE"),
                    Code = "SF_KAPASITE",
                    Name = "Kapasite",
                    SortOrder = 29,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                }
            );
        }
    }
}