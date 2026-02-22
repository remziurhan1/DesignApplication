using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var sfGroupId = SeedId.From("SProductGroup:F");

            var products = new List<SProduct>();
            int index = 0;

            void Add(string code, string name) => products.Add(new SProduct
            {
                Id = SeedId.From($"SProduct:SF:{code}"),
                SProductGroupId = sfGroupId,
                Code = code,
                Name = name,
                PrefixIndex = index++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });

            // ===== LPG (SFA) =====
            Add("SFA0", "LPG VANALARI/VALFLERİ");
            Add("SFA1", "LPG EMNİYET/RELIEF VALFLERİ");
            Add("SFA2", "LPG REGÜLATÖRLERİ");
            Add("SFA3", "LPG SEVİYE/ÖLÇÜM GÖSTERGELERİ");
            Add("SFA4", "LPG AŞIRI AKIŞ/CHECK/DENGELEME/BP-PASS VALFLERİ");
            Add("SFA5", "LPG SAYAÇLARI VE PRINTER");
            Add("SFA6", "LPG FİLTRELERİ");
            Add("SFA7", "LPG POMPALARI VE KOMPRESÖRLERİ");
            Add("SFA8", "LPG ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI");
            Add("SFA9", "LPG AKSESUARLARI DİĞER");

            // ===== CRYOGENIC (SFC) =====
            Add("SFC0", "CRYOGENIC VANALARI/VALFLERİ");
            Add("SFC1", "CRYOGENIC EMNİYET/RELIEF VALFLERİ");
            Add("SFC2", "CRYOGENIC REGÜLATÖRLERİ");
            Add("SFC3", "CRYOGENIC SEVİYE/ÖLÇÜM GÖSTERGELERİ");
            Add("SFC4", "CRYOGENIC AŞIRI AKIŞ/CHECK/DENGELEME/BP-PASS VALFLERİ");
            Add("SFC5", "CRYOGENIC SAYAÇLARI VE PRINTER");
            Add("SFC6", "CRYOGENIC FİLTRELERİ");
            Add("SFC7", "CRYOGENIC POMPALARI VE KOMPRESÖRLERİ");
            Add("SFC8", "CRYOGENIC ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI");

            // ===== AKARYAKIT (SFF) =====
            Add("SFF0", "AKARYAKIT VANALARI/VALFLERİ");
            Add("SFF1", "AKARYAKIT EMNİYET/RELIEF VALFLERİ");
            Add("SFF2", "AKARYAKIT REGÜLATÖRLERİ");
            Add("SFF3", "AKARYAKIT SEVİYE/ÖLÇÜM GÖSTERGELERİ");
            Add("SFF4", "AKARYAKIT AŞIRI AKIŞ/CHECK/DENGELEME/BP-PASS VALFLERİ");
            Add("SFF5", "AKARYAKIT SAYAÇLARI VE PRINTER");
            Add("SFF6", "AKARYAKIT FİLTRELERİ");
            Add("SFF7", "AKARYAKIT POMPALARI VE KOMPRESÖRLERİ");
            Add("SFF8", "AKARYAKIT ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI");
            Add("SFF9", "AKARYAKIT MENHOL KAPAKLARI");

            // ===== SU / HİDROLİK / PNÖMATİK (SFG) =====
            Add("SFG0", "SU VANALARI");
            Add("SFG1", "HİDROLİK SİSTEM VANALAR/VALFLER");
            Add("SFG2", "TOPRAKLAMA VE MAKARALARI");
            Add("SFG3", "HORTUM MAKARALARI");
            Add("SFG4", "MANOMETRELER / BASINÇ ÖLÇÜM ALETLERİ");
            Add("SFG5", "TERMOMETRELER / SICAKLIK ÖLÇÜM ALETLERİ");
            Add("SFG6", "CONTALAR");
            Add("SFG7", "PNÖMATİK SİSTEM VANALAR/VALFLER");
            Add("SFG8", "SU HATTI POMPALARI");
            Add("SFG9", "SU HATTI SAYAÇLARI");

            // ===== ÖZEL (SFH) =====
            Add("SFH0", "LPG CYLINDER UNITS");
            Add("SFH1", "LPG GAS AND FIRE DETECTORS");
            Add("SFH2", "LPG REFILLING SCALES AND WEIGHING");
            Add("SFH3", "AIR COMPRESSORS");
            Add("SFH4", "FANLAR");
            Add("SFH5", "DİĞER POMPALAR VE KOMPRESÖRLER");
            Add("SFH6", "DİĞER SENSÖRLER");

            // ===== DOĞAL GAZ (SFJ) =====
            Add("SFJ0", "DOĞAL GAZ VANALARI/VALFLERİ");
            Add("SFJ1", "DOĞAL GAZ EMNİYET/RELIEF VALFLERİ");
            Add("SFJ2", "DOĞAL GAZ REGÜLATÖRLERİ");
            Add("SFJ3", "DOĞAL GAZ SEVİYE/ÖLÇÜM GÖSTERGELERİ");
            Add("SFJ4", "DOĞAL GAZ CHECK/DENGELEME/BP-PASS VALFLERİ");
            Add("SFJ5", "DOĞAL GAZ SAYAÇLARI VE PRINTER");
            Add("SFJ6", "DOĞAL GAZ FİLTRELERİ");
            Add("SFJ7", "DOĞAL GAZ POMPALARI VE KOMPRESÖRLERİ");
            Add("SFJ8", "DOĞAL GAZ ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI");

            // ===== KİMYASAL (SFK) =====
            Add("SFK0", "KİMYASAL VANALARI/VALFLERİ");
            Add("SFK1", "KİMYASAL EMNİYET/RELIEF VALFLERİ");
            Add("SFK2", "KİMYASAL REGÜLATÖRLERİ");
            Add("SFK3", "KİMYASAL SEVİYE/ÖLÇÜM GÖSTERGELERİ");
            Add("SFK4", "KİMYASAL AŞIRI AKIŞ/CHECK/DENGELEME/BP-PASS VALFLERİ");
            Add("SFK5", "KİMYASAL SAYAÇLARI VE PRINTER");
            Add("SFK6", "KİMYASAL FİLTRELERİ");
            Add("SFK7", "KİMYASAL POMPALARI VE KOMPRESÖRLERİ");
            Add("SFK8", "KİMYASAL ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI");
            Add("SFK9", "KİMYASAL AKSESUARLARI DİĞER");

            // ===== PROSES GAZ/DİĞER (SFL) =====
            Add("SFL0", "PROSES GAZ/DİĞER VANALARI/VALFLERİ");
            Add("SFL1", "PROSES GAZ/DİĞER EMNİYET/RELIEF VALFLERİ");
            Add("SFL2", "PROSES GAZ/DİĞER REGÜLATÖRLERİ");

            builder.HasData(products);
        }
    }
}