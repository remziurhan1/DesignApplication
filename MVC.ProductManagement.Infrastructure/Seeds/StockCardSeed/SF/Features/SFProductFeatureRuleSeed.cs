using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    public class SFProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var akisMedyumuId = SeedId.From("SFeature:SF_AKIS_MEDYUMU");
            var markaId = SeedId.From("SFeature:SF_MARKA");
            var vanaTipiId = SeedId.From("SFeature:SF_VANA_TIPI");
            var aktuatorId = SeedId.From("SFeature:SF_AKTUATOR");
            var dnId = SeedId.From("SFeature:SF_DN");
            var basincSinifiId = SeedId.From("SFeature:SF_BASINC_SINIFI");
            var baglantiTipiId = SeedId.From("SFeature:SF_BAGLANTI_TIPI");
            var malzemeId = SeedId.From("SFeature:SF_MALZEME");
            var ayarBasinciId = SeedId.From("SFeature:SF_AYAR_BASINCI");
            var girisBasinciId = SeedId.From("SFeature:SF_GIRIS_BASINCI");
            var cikisBasinciId = SeedId.From("SFeature:SF_CIKIS_BASINCI");
            var baglantiCapiId = SeedId.From("SFeature:SF_BAGLANTI_CAPI");
            var olcumTipiId = SeedId.From("SFeature:SF_OLCUM_TIPI");
            var cikisSinyaliId = SeedId.From("SFeature:SF_CIKIS_SINYALI");
            var valfTipiId = SeedId.From("SFeature:SF_VALF_TIPI");
            var sayacTipiId = SeedId.From("SFeature:SF_SAYAC_TIPI");
            var goznekId = SeedId.From("SFeature:SF_GOZNEK");
            var pompaTipiId = SeedId.From("SFeature:SF_POMPA_TIPI");
            var gucKwId = SeedId.From("SFeature:SF_GUC_KW");
            var adaptorTipiId = SeedId.From("SFeature:SF_ADAPTOR_TIPI");
            var baglanti1Id = SeedId.From("SFeature:SF_BAGLANTI_1");
            var baglanti2Id = SeedId.From("SFeature:SF_BAGLANTI_2");
            var capiMmId = SeedId.From("SFeature:SF_CAPI_MM");
            var olcumAraligiId = SeedId.From("SFeature:SF_OLCUM_ARALIGI");
            var manomTipiId = SeedId.From("SFeature:SF_MANOMETRE_TIPI");
            var daldirmaId = SeedId.From("SFeature:SF_DALDIRMA_BOYU");
            var contaTipiId = SeedId.From("SFeature:SF_CONTA_TIPI");
            var tipId = SeedId.From("SFeature:SF_TIP");
            var kapasiteId = SeedId.From("SFeature:SF_KAPASITE");

            var rules = new List<SProductFeatureRule>();

            void Fixed(string productCode, Guid featureId, string featureCode, string fixedValueCode)
            {
                rules.Add(new SProductFeatureRule
                {
                    Id = SeedId.From($"SProductFeatureRule:SF:{productCode}:{featureCode}"),
                    SProductId = SeedId.From($"SProduct:SF:{productCode}"),
                    SFeatureId = featureId,
                    IsFixed = true,
                    FixedValueId = SeedId.From($"SFeatureValue:{featureCode}:{fixedValueCode}"),
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            void Dynamic(string productCode, Guid featureId, string featureCode)
            {
                rules.Add(new SProductFeatureRule
                {
                    Id = SeedId.From($"SProductFeatureRule:SF:{productCode}:{featureCode}"),
                    SProductId = SeedId.From($"SProduct:SF:{productCode}"),
                    SFeatureId = featureId,
                    IsFixed = false,
                    FixedValueId = null,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ============================================================
            // VANALAR: SFA0, SFC0, SFF0, SFG0, SFG1, SFG7, SFJ0, SFK0, SFL0
            // ============================================================
            var vanaGroups = new[]
            {
                ("SFA0","LPG"), ("SFC0","Cryogenic"), ("SFF0","Akaryakıt"),
                ("SFG0","Su"), ("SFG1","Hidrolik"), ("SFG7","Pnömatik"),
                ("SFJ0","Doğal Gaz"), ("SFK0","Kimyasal"), ("SFL0","Proses Gaz")
            };
            foreach (var (code, medyum) in vanaGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, vanaTipiId, "SF_VANA_TIPI");
                Dynamic(code, aktuatorId, "SF_AKTUATOR");
                Dynamic(code, dnId, "SF_DN");
                Dynamic(code, basincSinifiId, "SF_BASINC_SINIFI");
                Dynamic(code, baglantiTipiId, "SF_BAGLANTI_TIPI");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // EMNİYET/RELIEF: SFA1, SFC1, SFF1, SFJ1, SFK1, SFL1
            // ============================================================
            var emniyetGroups = new[]
            {
                ("SFA1","LPG"), ("SFC1","Cryogenic"), ("SFF1","Akaryakıt"),
                ("SFJ1","Doğal Gaz"), ("SFK1","Kimyasal"), ("SFL1","Proses Gaz")
            };
            foreach (var (code, medyum) in emniyetGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, dnId, "SF_DN");
                Dynamic(code, ayarBasinciId, "SF_AYAR_BASINCI");
                Dynamic(code, baglantiTipiId, "SF_BAGLANTI_TIPI");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // REGÜLATÖRLER: SFA2, SFC2, SFF2, SFJ2, SFK2, SFL2
            // ============================================================
            var regulatorGroups = new[]
            {
                ("SFA2","LPG"), ("SFC2","Cryogenic"), ("SFF2","Akaryakıt"),
                ("SFJ2","Doğal Gaz"), ("SFK2","Kimyasal"), ("SFL2","Proses Gaz")
            };
            foreach (var (code, medyum) in regulatorGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, girisBasinciId, "SF_GIRIS_BASINCI");
                Dynamic(code, cikisBasinciId, "SF_CIKIS_BASINCI");
                Dynamic(code, baglantiCapiId, "SF_BAGLANTI_CAPI");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // SEVİYE/ÖLÇÜM: SFA3, SFC3, SFF3, SFJ3, SFK3
            // ============================================================
            var seviyeGroups = new[]
            {
                ("SFA3","LPG"), ("SFC3","Cryogenic"), ("SFF3","Akaryakıt"),
                ("SFJ3","Doğal Gaz"), ("SFK3","Kimyasal")
            };
            foreach (var (code, medyum) in seviyeGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, olcumTipiId, "SF_OLCUM_TIPI");
                Dynamic(code, cikisSinyaliId, "SF_CIKIS_SINYALI");
                Dynamic(code, baglantiCapiId, "SF_BAGLANTI_CAPI");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // AŞIRI AKIŞ/CHECK/BP-PASS: SFA4, SFC4, SFF4, SFJ4, SFK4
            // ============================================================
            var asiriAkisGroups = new[]
            {
                ("SFA4","LPG"), ("SFC4","Cryogenic"), ("SFF4","Akaryakıt"),
                ("SFJ4","Doğal Gaz"), ("SFK4","Kimyasal")
            };
            foreach (var (code, medyum) in asiriAkisGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, valfTipiId, "SF_VALF_TIPI");
                Dynamic(code, dnId, "SF_DN");
                Dynamic(code, basincSinifiId, "SF_BASINC_SINIFI");
                Dynamic(code, baglantiTipiId, "SF_BAGLANTI_TIPI");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // SAYAÇLAR: SFA5, SFC5, SFF5, SFG9, SFJ5, SFK5
            // ============================================================
            var sayacGroups = new[]
            {
                ("SFA5","LPG"), ("SFC5","Cryogenic"), ("SFF5","Akaryakıt"),
                ("SFG9","Su"), ("SFJ5","Doğal Gaz"), ("SFK5","Kimyasal")
            };
            foreach (var (code, medyum) in sayacGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, sayacTipiId, "SF_SAYAC_TIPI");
                Dynamic(code, dnId, "SF_DN");
                Dynamic(code, basincSinifiId, "SF_BASINC_SINIFI");
                Dynamic(code, cikisSinyaliId, "SF_CIKIS_SINYALI");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // FİLTRELER: SFA6, SFC6, SFF6, SFJ6, SFK6
            // ============================================================
            var filtreGroups = new[]
            {
                ("SFA6","LPG"), ("SFC6","Cryogenic"), ("SFF6","Akaryakıt"),
                ("SFJ6","Doğal Gaz"), ("SFK6","Kimyasal")
            };
            foreach (var (code, medyum) in filtreGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, dnId, "SF_DN");
                Dynamic(code, basincSinifiId, "SF_BASINC_SINIFI");
                Dynamic(code, goznekId, "SF_GOZNEK");
                Dynamic(code, baglantiTipiId, "SF_BAGLANTI_TIPI");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // POMPALAR: SFA7, SFC7, SFF7, SFG8, SFH5, SFJ7, SFK7
            // ============================================================
            var pompaGroups = new[]
            {
                ("SFA7","LPG"), ("SFC7","Cryogenic"), ("SFF7","Akaryakıt"),
                ("SFG8","Su"), ("SFH5","Diğer"), ("SFJ7","Doğal Gaz"), ("SFK7","Kimyasal")
            };
            foreach (var (code, medyum) in pompaGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, pompaTipiId, "SF_POMPA_TIPI");
                Dynamic(code, gucKwId, "SF_GUC_KW");
                Dynamic(code, cikisBasinciId, "SF_CIKIS_BASINCI");
                Dynamic(code, dnId, "SF_DN");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // ADAPTÖRLER: SFA8, SFC8, SFF8, SFJ8, SFK8
            // ============================================================
            var adaptorGroups = new[]
            {
                ("SFA8","LPG"), ("SFC8","Cryogenic"), ("SFF8","Akaryakıt"),
                ("SFJ8","Doğal Gaz"), ("SFK8","Kimyasal")
            };
            foreach (var (code, medyum) in adaptorGroups)
            {
                Fixed(code, akisMedyumuId, "SF_AKIS_MEDYUMU", medyum);
                Dynamic(code, adaptorTipiId, "SF_ADAPTOR_TIPI");
                Dynamic(code, baglanti1Id, "SF_BAGLANTI_1");
                Dynamic(code, baglanti2Id, "SF_BAGLANTI_2");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // AKSESUARLAR: SFA9, SFK9
            // ============================================================
            foreach (var code in new[] { "SFA9", "SFK9" })
            {
                Dynamic(code, tipId, "SF_TIP");
                Dynamic(code, malzemeId, "SF_MALZEME");
                Dynamic(code, markaId, "SF_MARKA");
            }

            // ============================================================
            // MENHOL KAPAKLARI: SFF9
            // ============================================================
            Fixed("SFF9", akisMedyumuId, "SF_AKIS_MEDYUMU", "Akaryakıt");
            Dynamic("SFF9", tipId, "SF_TIP");
            Dynamic("SFF9", dnId, "SF_DN");
            Dynamic("SFF9", malzemeId, "SF_MALZEME");
            Dynamic("SFF9", markaId, "SF_MARKA");

            // ============================================================
            // MANOMETRE: SFG4
            // ============================================================
            Dynamic("SFG4", capiMmId, "SF_CAPI_MM");
            Dynamic("SFG4", olcumAraligiId, "SF_OLCUM_ARALIGI");
            Dynamic("SFG4", baglantiTipiId, "SF_BAGLANTI_TIPI");
            Dynamic("SFG4", manomTipiId, "SF_MANOMETRE_TIPI");
            Dynamic("SFG4", markaId, "SF_MARKA");

            // ============================================================
            // TERMOMETRE: SFG5
            // ============================================================
            Dynamic("SFG5", capiMmId, "SF_CAPI_MM");
            Dynamic("SFG5", olcumAraligiId, "SF_OLCUM_ARALIGI");
            Dynamic("SFG5", daldirmaId, "SF_DALDIRMA_BOYU");
            Dynamic("SFG5", baglantiTipiId, "SF_BAGLANTI_TIPI");
            Dynamic("SFG5", markaId, "SF_MARKA");

            // ============================================================
            // CONTALAR: SFG6
            // ============================================================
            Dynamic("SFG6", contaTipiId, "SF_CONTA_TIPI");
            Dynamic("SFG6", dnId, "SF_DN");
            Dynamic("SFG6", basincSinifiId, "SF_BASINC_SINIFI");
            Dynamic("SFG6", malzemeId, "SF_MALZEME");

            // ============================================================
            // TOPRAKLAMA: SFG2
            // ============================================================
            Dynamic("SFG2", tipId, "SF_TIP");
            Dynamic("SFG2", kapasiteId, "SF_KAPASITE");
            Dynamic("SFG2", malzemeId, "SF_MALZEME");

            // ============================================================
            // HORTUM MAKARASI: SFG3
            // ============================================================
            Dynamic("SFG3", tipId, "SF_TIP");
            Dynamic("SFG3", kapasiteId, "SF_KAPASITE");
            Dynamic("SFG3", baglantiCapiId, "SF_BAGLANTI_CAPI");

            // ============================================================
            // AIR COMPRESSORS: SFH3
            // ============================================================
            Dynamic("SFH3", pompaTipiId, "SF_POMPA_TIPI");
            Dynamic("SFH3", gucKwId, "SF_GUC_KW");
            Dynamic("SFH3", cikisBasinciId, "SF_CIKIS_BASINCI");
            Dynamic("SFH3", kapasiteId, "SF_KAPASITE");
            Dynamic("SFH3", markaId, "SF_MARKA");

            // ============================================================
            // FANLAR: SFH4
            // ============================================================
            Dynamic("SFH4", tipId, "SF_TIP");
            Dynamic("SFH4", gucKwId, "SF_GUC_KW");
            Dynamic("SFH4", kapasiteId, "SF_KAPASITE");
            Dynamic("SFH4", markaId, "SF_MARKA");

            // ============================================================
            // LPG CYLINDER UNITS: SFH0
            // ============================================================
            Fixed("SFH0", akisMedyumuId, "SF_AKIS_MEDYUMU", "LPG");
            Dynamic("SFH0", tipId, "SF_TIP");
            Dynamic("SFH0", kapasiteId, "SF_KAPASITE");
            Dynamic("SFH0", markaId, "SF_MARKA");

            // ============================================================
            // LPG DEDEKTÖR: SFH1
            // ============================================================
            Fixed("SFH1", akisMedyumuId, "SF_AKIS_MEDYUMU", "LPG");
            Dynamic("SFH1", tipId, "SF_TIP");
            Dynamic("SFH1", cikisSinyaliId, "SF_CIKIS_SINYALI");
            Dynamic("SFH1", markaId, "SF_MARKA");

            // ============================================================
            // LPG TARTISI: SFH2
            // ============================================================
            Fixed("SFH2", akisMedyumuId, "SF_AKIS_MEDYUMU", "LPG");
            Dynamic("SFH2", tipId, "SF_TIP");
            Dynamic("SFH2", kapasiteId, "SF_KAPASITE");
            Dynamic("SFH2", markaId, "SF_MARKA");

            // ============================================================
            // DİĞER SENSÖRLER: SFH6
            // ============================================================
            Dynamic("SFH6", tipId, "SF_TIP");
            Dynamic("SFH6", cikisSinyaliId, "SF_CIKIS_SINYALI");
            Dynamic("SFH6", markaId, "SF_MARKA");

            builder.HasData(rules);
        }
    }
}