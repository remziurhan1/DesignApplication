using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var sfGroupId = SeedId.From("SProductGroup:F");

            var items = new (string Code, string Name)[]
            {
                // ==================== SFA SERİSİ: LPG (10 adet) ====================
                ("SFA0", "LPG VANALARI/VALFLERİ"),
                ("SFA1", "LPG EMNİYET/RELIEF VALFLERİ"),
                ("SFA2", "LPG REGÜLATÖRLERİ"),
                ("SFA3", "LPG SEVİYE/ÖLÇÜM GÖSTERGELERİ"),
                ("SFA4", "LPG AŞIRI AKIŞ/CHECK/DENGELEME VALFLERİ"),
                ("SFA5", "LPG SAYAÇLARI VE PRINTER"),
                ("SFA6", "LPG FİLTRELERİ"),
                ("SFA7", "LPG POMPALARI VE KOMPRESÖRLERİ"),
                ("SFA8", "LPG ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI"),
                ("SFA9", "LPG AKSESUARLARI DİĞER"),

                // ==================== SFC SERİSİ: CRYOGENIC (9 adet) ====================
                ("SFC0", "CRYOGENIC VANALARI/VALFLERİ"),
                ("SFC1", "CRYOGENIC EMNİYET/RELIEF VALFLERİ"),
                ("SFC2", "CRYOGENIC REGÜLATÖRLERİ"),
                ("SFC3", "CRYOGENIC SEVİYE/ÖLÇÜM GÖSTERGELERİ"),
                ("SFC4", "CRYOGENIC CHECK/DENGELEME VALFLERİ"),
                ("SFC5", "CRYOGENIC SAYAÇLARI VE PRINTER"),
                ("SFC6", "CRYOGENIC FİLTRELERİ"),
                ("SFC7", "CRYOGENIC POMPALARI VE KOMPRESÖRLERİ"),
                ("SFC8", "CRYOGENIC ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI"),

                // ==================== SFF SERİSİ: AKARYAKIT (10 adet) ====================
                ("SFF0", "AKARYAKIT VANALARI/VALFLERİ"),
                ("SFF1", "AKARYAKIT EMNİYET/RELIEF VALFLERİ"),
                ("SFF2", "AKARYAKIT REGÜLATÖRLERİ"),
                ("SFF3", "AKARYAKIT SEVİYE/ÖLÇÜM GÖSTERGELERİ"),
                ("SFF4", "AKARYAKIT CHECK/DENGELEME VALFLERİ"),
                ("SFF5", "AKARYAKIT SAYAÇLARI VE PRINTER"),
                ("SFF6", "AKARYAKIT FİLTRELERİ"),
                ("SFF7", "AKARYAKIT POMPALARI VE KOMPRESÖRLERİ"),
                ("SFF8", "AKARYAKIT ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI"),
                ("SFF9", "AKARYAKIT MENHOL KAPAKLARI"),

                // ==================== SFG SERİSİ: SU, HİDROLİK, PNÖMATİK (10 adet) ====================
                ("SFG0", "SU VANALARI"),
                ("SFG1", "HİDROLİK SİSTEM VANALAR/VALFLER"),
                ("SFG2", "TOPRAKLAMA VE MAKARALARI"),
                ("SFG3", "HORTUM MAKARALARI"),
                ("SFG4", "MANOMETRELER / BASINÇ ÖLÇÜM ALETLERİ"),
                ("SFG5", "TERMOMETRELER / SICAKLIK ÖLÇÜM ALETLERİ"),
                ("SFG6", "CONTALAR"),
                ("SFG7", "PNÖMATİK SİSTEM VANALAR/VALFLER"),
                ("SFG8", "SU HATTI POMPALARI"),
                ("SFG9", "SU HATTI SAYAÇLARI"),

                // ==================== SFH SERİSİ: DİĞER EKİPMANLAR (7 adet) ====================
                ("SFH0", "CYLINDER UNITS"),
                ("SFH1", "GAZ VE YANGIN DEDEKTÖRLERI"),
                ("SFH2", "TARTI VE KANTARLAR"),
                ("SFH3", "HAVA KOMPRESÖRLERİ"),
                ("SFH4", "FANLAR"),
                ("SFH5", "DİĞER POMPALAR VE KOMPRESÖRLER"),
                ("SFH6", "DİĞER SENSÖRLER"),

                // ==================== SFJ SERİSİ: DOĞAL GAZ (9 adet) ====================
                ("SFJ0", "DOĞAL GAZ VANALARI/VALFLERİ"),
                ("SFJ1", "DOĞAL GAZ EMNİYET/RELIEF VALFLERİ"),
                ("SFJ2", "DOĞAL GAZ REGÜLATÖRLERİ"),
                ("SFJ3", "DOĞAL GAZ SEVİYE/ÖLÇÜM GÖSTERGELERİ"),
                ("SFJ4", "DOĞAL GAZ CHECK/DENGELEME VALFLERİ"),
                ("SFJ5", "DOĞAL GAZ SAYAÇLARI VE PRINTER"),
                ("SFJ6", "DOĞAL GAZ FİLTRELERİ"),
                ("SFJ7", "DOĞAL GAZ POMPALARI VE KOMPRESÖRLERİ"),
                ("SFJ8", "DOĞAL GAZ ADAPTÖR/KONNEKTÖR/BAĞLANTI PARÇALARI"),

                // ==================== SFK SERİSİ: KİMYASAL (5 adet) ====================
                ("SFK0", "KİMYASAL VANALARI/VALFLERİ"),
                ("SFK1", "KİMYASAL EMNİYET/RELIEF VALFLERİ"),
                ("SFK2", "KİMYASAL REGÜLATÖRLERİ"),
                ("SFK3", "KİMYASAL FİLTRELERİ"),
                ("SFK4", "KİMYASAL POMPALARI VE KOMPRESÖRLERİ"),

                // ==================== SFL SERİSİ: PROSES GAZ/DİĞER (3 adet) ====================
                ("SFL0", "PROSES GAZ VANALARI/VALFLERİ"),
                ("SFL1", "PROSES GAZ EMNİYET/RELIEF VALFLERİ"),
                ("SFL2", "PROSES GAZ REGÜLATÖRLERİ")
            };
            // Toplam: 10+9+10+10+7+9+5+3 = 63 ürün ✅

            int index = 0;
            foreach (var (code, name) in items)
            {
                builder.HasData(new SProduct
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
            }
        }
    }
}