using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    public class SFFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
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

            var rules = new List<SFeatureValueRule>();
            int sortOrder = 0;

            void AddValue(string productCode, Guid featureId, string featureCode, string valueCode)
            {
                rules.Add(new SFeatureValueRule
                {
                    Id = SeedId.From($"SFeatureValueRule:SF:{productCode}:{featureCode}:{valueCode}"),
                    SProductId = SeedId.From($"SProduct:SF:{productCode}"),
                    SFeatureId = featureId,
                    SFeatureValueId = SeedId.From($"SFeatureValue:{featureCode}:{valueCode}"),
                    SortOrder = sortOrder++,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            void AddAll(string productCode, Guid featureId, string featureCode, params string[] values)
            {
                foreach (var v in values)
                    AddValue(productCode, featureId, featureCode, v);
            }

            var allDN = new[] {
                "DN10","DN15","DN20","DN25","DN32","DN40","DN50",
                "DN65","DN80","DN100","DN125","DN150","DN200",
                "DN250","DN300","DN350","DN400","DN500","DN600"
            };
            var allBasincSinifi = new[] {
                "PN6","PN10","PN16","PN25","PN40","PN63","PN100",
                "Class 150","Class 300","Class 600","Class 900","Class 1500"
            };
            var allBaglantiTipi = new[] {
                "Flanşlı","Dişli","Kaynaklı","Wafer","Lug",
                "Socket Weld","Butt Weld","Clamp"
            };
            var allMalzeme = new[] {
                "Dökme Demir (GG25)","Sfero Döküm (GGG40)","Karbon Çelik (A216 WCB)",
                "Paslanmaz Çelik AISI 304","Paslanmaz Çelik AISI 316",
                "Paslanmaz Çelik AISI 316L","Pirinç","Bronz","Alüminyum",
                "Duplex Paslanmaz","Hastelloy C276","Monel","PTFE Kaplı",
                "Grafit","NBR","EPDM","Viton"
            };
            var allMarka = new[] {
                "Emerson","Fisher","Spirax Sarco","Samson","Flowserve",
                "Velan","Metso","Crane","Kitz","Grundfos","Ebara",
                "Lowara","Pedrollo","Wilo","Sulzer","Xylem","Viking",
                "Blackmer","Elster","Actaris","Itron","Krohne",
                "Endress+Hauser","Yokogawa","ABB","Parker","Swagelok",
                "Festo","SMC","Wika","Wise","Bourdon","Ashcroft",
                "Tescom","Fairchild","Norgren","Cavagna",
                "Parker Hannifin","Pall","Donaldson","Winters","Diğer"
            };
            var allVanaTipi = new[] {
                "Küresel Vana","Kelebek Vana","Sürgülü Vana","İğne Vana",
                "Küresel Valf","Pistonlu Vana","Diyafram Vana","Plug Vana"
            };
            var allAktuator = new[] {
                "Manuel","Pnömatik","Elektrikli","Hidrolik",
                "Elektrohidrolik","Yaylı Diyafram"
            };
            var allAyarBasinci = new[] {
                "0.5 bar","1 bar","2 bar","3 bar","4 bar","5 bar",
                "6 bar","8 bar","10 bar","12 bar","16 bar","20 bar",
                "25 bar","32 bar","40 bar"
            };
            var allGirisBasinci = new[] {
                "0-10 bar","0-16 bar","0-25 bar","0-40 bar",
                "0-63 bar","0-100 bar","0-160 bar","0-250 bar"
            };
            var allCikisBasinci = new[] {
                "0-1 bar","0-2 bar","0-4 bar","0-6 bar",
                "0-10 bar","0-16 bar","0-25 bar","0-40 bar"
            };
            var allBaglantiCapi = new[] {
                "1/4\"","3/8\"","1/2\"","3/4\"","1\"",
                "1.1/4\"","1.1/2\"","2\"","2.1/2\"","3\"","4\""
            };
            var allOlcumTipi = new[] {
                "Manyetik","Ultrasonik","Radar","Şamandıralı",
                "Basınç Farkı","Kapasitif","Kondüktif","Guided Wave Radar"
            };
            var allCikisSinyali = new[] {
                "4-20mA","0-10V","HART","Profibus",
                "Foundation Fieldbus","Modbus","Puls","On/Off"
            };
            var allValfTipi = new[] {
                "Aşırı Akış Valfi","Check Valf","Geri Tepme Önleyici",
                "Dengeleme Valfi","By-Pass Valfi"
            };
            var allSayacTipi = new[] {
                "Hacimsel","Türbinli","Manyetik","Ultrasonik",
                "Coriolis","Oval Dişli","Rotary"
            };
            var allGoznek = new[] {
                "1 micron","5 micron","10 micron","25 micron",
                "50 micron","100 micron","150 micron","200 micron",
                "500 micron","1000 micron"
            };
            var allPompaTipi = new[] {
                "Santrifüj","Dalgıç","Dişli","Pistonlu","Vidalı",
                "Paletli","Peristaltik","Membran","Kompresör"
            };
            var allGucKw = new[] {
                "0.25 kW","0.37 kW","0.55 kW","0.75 kW","1.1 kW",
                "1.5 kW","2.2 kW","3 kW","4 kW","5.5 kW",
                "7.5 kW","11 kW","15 kW","18.5 kW","22 kW",
                "30 kW","37 kW","45 kW","55 kW","75 kW","90 kW","110 kW"
            };
            var allAdaptorTipi = new[] {
                "Dişli-Dişli","Flanş-Flanş","Dişli-Flanş",
                "Kampili","Storz","BSP-NPT","Quick Connect"
            };
            var allBaglanti = new[] {
                "1/4\" BSP","3/8\" BSP","1/2\" BSP","3/4\" BSP","1\" BSP",
                "1.1/4\" BSP","1.1/2\" BSP","2\" BSP",
                "1/4\" NPT","3/8\" NPT","1/2\" NPT","3/4\" NPT","1\" NPT",
                "DN25 Flanş","DN32 Flanş","DN40 Flanş","DN50 Flanş",
                "DN65 Flanş","DN80 Flanş","DN100 Flanş"
            };
            var allCapiMm = new[] {
                "40 mm","50 mm","63 mm","80 mm","100 mm",
                "115 mm","150 mm","160 mm","200 mm","250 mm"
            };
            var allOlcumAraligi = new[] {
                "-30...+50 °C","-20...+60 °C","0...+100 °C","0...+120 °C",
                "0...+160 °C","0...+200 °C","0...+300 °C","0...+400 °C",
                "-1...+0 bar","0...+1 bar","0...+2.5 bar","0...+4 bar",
                "0...+6 bar","0...+10 bar","0...+16 bar","0...+25 bar",
                "0...+40 bar","0...+60 bar","0...+100 bar","0...+160 bar",
                "0...+250 bar","0...+400 bar","0...+600 bar"
            };
            var allManomTipi = new[] {
                "Bourdon Tüplü","Diyafram","Kapsül","Dijital","Differential","Gliserinli"
            };
            var allDaldirma = new[] {
                "100 mm","150 mm","200 mm","250 mm","300 mm",
                "400 mm","500 mm","600 mm","750 mm","1000 mm"
            };
            var allContaTipi = new[] {
                "Spiral Wound","Ring Joint","Düz Conta","Kammprofile",
                "Full Face","Raised Face","PTFE Sarmalı","Grafit Sarmalı"
            };
            var allTip = new[] { "Tip A", "Tip B", "Tip C", "Standart", "Özel", "Diğer" };
            var allKapasite = new[] {
                "5 kg","10 kg","15 kg","20 kg","25 kg","33 kg","45 kg",
                "100 L","200 L","300 L","500 L","1000 L",
                "1 m³/h","2 m³/h","5 m³/h","10 m³/h","20 m³/h",
                "50 m³/h","100 m³/h","200 m³/h","500 m³/h"
            };

            // ============================================================
            // VANALAR: SFA0, SFC0, SFF0, SFG0, SFG1, SFG7, SFJ0, SFK0, SFL0
            // ============================================================
            var vanaGroups = new[] {
                "SFA0","SFC0","SFF0","SFG0","SFG1","SFG7","SFJ0","SFK0","SFL0"
            };
            foreach (var code in vanaGroups)
            {
                AddAll(code, vanaTipiId, "SF_VANA_TIPI", allVanaTipi);
                AddAll(code, aktuatorId, "SF_AKTUATOR", allAktuator);
                AddAll(code, dnId, "SF_DN", allDN);
                AddAll(code, basincSinifiId, "SF_BASINC_SINIFI", allBasincSinifi);
                AddAll(code, baglantiTipiId, "SF_BAGLANTI_TIPI", allBaglantiTipi);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // EMNİYET/RELIEF: SFA1, SFC1, SFF1, SFJ1, SFK1, SFL1
            // ============================================================
            var emniyetGroups = new[] { "SFA1", "SFC1", "SFF1", "SFJ1", "SFK1", "SFL1" };
            foreach (var code in emniyetGroups)
            {
                AddAll(code, dnId, "SF_DN", allDN);
                AddAll(code, ayarBasinciId, "SF_AYAR_BASINCI", allAyarBasinci);
                AddAll(code, baglantiTipiId, "SF_BAGLANTI_TIPI", allBaglantiTipi);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // REGÜLATÖRLER: SFA2, SFC2, SFF2, SFJ2, SFK2, SFL2
            // ============================================================
            var regulatorGroups = new[] { "SFA2", "SFC2", "SFF2", "SFJ2", "SFK2", "SFL2" };
            foreach (var code in regulatorGroups)
            {
                AddAll(code, girisBasinciId, "SF_GIRIS_BASINCI", allGirisBasinci);
                AddAll(code, cikisBasinciId, "SF_CIKIS_BASINCI", allCikisBasinci);
                AddAll(code, baglantiCapiId, "SF_BAGLANTI_CAPI", allBaglantiCapi);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // SEVİYE/ÖLÇÜM: SFA3, SFC3, SFF3, SFJ3, SFK3
            // ============================================================
            var seviyeGroups = new[] { "SFA3", "SFC3", "SFF3", "SFJ3", "SFK3" };
            foreach (var code in seviyeGroups)
            {
                AddAll(code, olcumTipiId, "SF_OLCUM_TIPI", allOlcumTipi);
                AddAll(code, cikisSinyaliId, "SF_CIKIS_SINYALI", allCikisSinyali);
                AddAll(code, baglantiCapiId, "SF_BAGLANTI_CAPI", allBaglantiCapi);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // AŞIRI AKIŞ/CHECK/BP-PASS: SFA4, SFC4, SFF4, SFJ4, SFK4
            // ============================================================
            var asiriAkisGroups = new[] { "SFA4", "SFC4", "SFF4", "SFJ4", "SFK4" };
            foreach (var code in asiriAkisGroups)
            {
                AddAll(code, valfTipiId, "SF_VALF_TIPI", allValfTipi);
                AddAll(code, dnId, "SF_DN", allDN);
                AddAll(code, basincSinifiId, "SF_BASINC_SINIFI", allBasincSinifi);
                AddAll(code, baglantiTipiId, "SF_BAGLANTI_TIPI", allBaglantiTipi);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // SAYAÇLAR: SFA5, SFC5, SFF5, SFG9, SFJ5, SFK5
            // ============================================================
            var sayacGroups = new[] { "SFA5", "SFC5", "SFF5", "SFG9", "SFJ5", "SFK5" };
            foreach (var code in sayacGroups)
            {
                AddAll(code, sayacTipiId, "SF_SAYAC_TIPI", allSayacTipi);
                AddAll(code, dnId, "SF_DN", allDN);
                AddAll(code, basincSinifiId, "SF_BASINC_SINIFI", allBasincSinifi);
                AddAll(code, cikisSinyaliId, "SF_CIKIS_SINYALI", allCikisSinyali);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // FİLTRELER: SFA6, SFC6, SFF6, SFJ6, SFK6
            // ============================================================
            var filtreGroups = new[] { "SFA6", "SFC6", "SFF6", "SFJ6", "SFK6" };
            foreach (var code in filtreGroups)
            {
                AddAll(code, dnId, "SF_DN", allDN);
                AddAll(code, basincSinifiId, "SF_BASINC_SINIFI", allBasincSinifi);
                AddAll(code, goznekId, "SF_GOZNEK", allGoznek);
                AddAll(code, baglantiTipiId, "SF_BAGLANTI_TIPI", allBaglantiTipi);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // POMPALAR: SFA7, SFC7, SFF7, SFG8, SFH5, SFJ7, SFK7
            // ============================================================
            var pompaGroups = new[] { "SFA7", "SFC7", "SFF7", "SFG8", "SFH5", "SFJ7", "SFK7" };
            foreach (var code in pompaGroups)
            {
                AddAll(code, pompaTipiId, "SF_POMPA_TIPI", allPompaTipi);
                AddAll(code, gucKwId, "SF_GUC_KW", allGucKw);
                AddAll(code, cikisBasinciId, "SF_CIKIS_BASINCI", allCikisBasinci);
                AddAll(code, dnId, "SF_DN", allDN);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // ADAPTÖRLER: SFA8, SFC8, SFF8, SFJ8, SFK8
            // ============================================================
            var adaptorGroups = new[] { "SFA8", "SFC8", "SFF8", "SFJ8", "SFK8" };
            foreach (var code in adaptorGroups)
            {
                AddAll(code, adaptorTipiId, "SF_ADAPTOR_TIPI", allAdaptorTipi);
                AddAll(code, baglanti1Id, "SF_BAGLANTI_1", allBaglanti);
                AddAll(code, baglanti2Id, "SF_BAGLANTI_2", allBaglanti);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // AKSESUARLAR: SFA9, SFK9
            // ============================================================
            foreach (var code in new[] { "SFA9", "SFK9" })
            {
                AddAll(code, tipId, "SF_TIP", allTip);
                AddAll(code, malzemeId, "SF_MALZEME", allMalzeme);
                AddAll(code, markaId, "SF_MARKA", allMarka);
            }

            // ============================================================
            // MENHOL KAPAKLARI: SFF9
            // ============================================================
            AddAll("SFF9", tipId, "SF_TIP", allTip);
            AddAll("SFF9", dnId, "SF_DN", allDN);
            AddAll("SFF9", malzemeId, "SF_MALZEME", allMalzeme);
            AddAll("SFF9", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // MANOMETRE: SFG4
            // ============================================================
            AddAll("SFG4", capiMmId, "SF_CAPI_MM", allCapiMm);
            AddAll("SFG4", olcumAraligiId, "SF_OLCUM_ARALIGI", allOlcumAraligi);
            AddAll("SFG4", baglantiTipiId, "SF_BAGLANTI_TIPI", allBaglantiTipi);
            AddAll("SFG4", manomTipiId, "SF_MANOMETRE_TIPI", allManomTipi);
            AddAll("SFG4", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // TERMOMETRE: SFG5
            // ============================================================
            AddAll("SFG5", capiMmId, "SF_CAPI_MM", allCapiMm);
            AddAll("SFG5", olcumAraligiId, "SF_OLCUM_ARALIGI", allOlcumAraligi);
            AddAll("SFG5", daldirmaId, "SF_DALDIRMA_BOYU", allDaldirma);
            AddAll("SFG5", baglantiTipiId, "SF_BAGLANTI_TIPI", allBaglantiTipi);
            AddAll("SFG5", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // CONTALAR: SFG6
            // ============================================================
            AddAll("SFG6", contaTipiId, "SF_CONTA_TIPI", allContaTipi);
            AddAll("SFG6", dnId, "SF_DN", allDN);
            AddAll("SFG6", basincSinifiId, "SF_BASINC_SINIFI", allBasincSinifi);
            AddAll("SFG6", malzemeId, "SF_MALZEME", allMalzeme);

            // ============================================================
            // TOPRAKLAMA: SFG2
            // ============================================================
            AddAll("SFG2", tipId, "SF_TIP", allTip);
            AddAll("SFG2", kapasiteId, "SF_KAPASITE", allKapasite);
            AddAll("SFG2", malzemeId, "SF_MALZEME", allMalzeme);

            // ============================================================
            // HORTUM MAKARASI: SFG3
            // ============================================================
            AddAll("SFG3", tipId, "SF_TIP", allTip);
            AddAll("SFG3", kapasiteId, "SF_KAPASITE", allKapasite);
            AddAll("SFG3", baglantiCapiId, "SF_BAGLANTI_CAPI", allBaglantiCapi);

            // ============================================================
            // AIR COMPRESSORS: SFH3
            // ============================================================
            AddAll("SFH3", pompaTipiId, "SF_POMPA_TIPI", allPompaTipi);
            AddAll("SFH3", gucKwId, "SF_GUC_KW", allGucKw);
            AddAll("SFH3", cikisBasinciId, "SF_CIKIS_BASINCI", allCikisBasinci);
            AddAll("SFH3", kapasiteId, "SF_KAPASITE", allKapasite);
            AddAll("SFH3", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // FANLAR: SFH4
            // ============================================================
            AddAll("SFH4", tipId, "SF_TIP", allTip);
            AddAll("SFH4", gucKwId, "SF_GUC_KW", allGucKw);
            AddAll("SFH4", kapasiteId, "SF_KAPASITE", allKapasite);
            AddAll("SFH4", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // LPG CYLINDER UNITS: SFH0
            // ============================================================
            AddAll("SFH0", tipId, "SF_TIP", allTip);
            AddAll("SFH0", kapasiteId, "SF_KAPASITE", allKapasite);
            AddAll("SFH0", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // LPG DEDEKTÖR: SFH1
            // ============================================================
            AddAll("SFH1", tipId, "SF_TIP", allTip);
            AddAll("SFH1", cikisSinyaliId, "SF_CIKIS_SINYALI", allCikisSinyali);
            AddAll("SFH1", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // LPG TARTISI: SFH2
            // ============================================================
            AddAll("SFH2", tipId, "SF_TIP", allTip);
            AddAll("SFH2", kapasiteId, "SF_KAPASITE", allKapasite);
            AddAll("SFH2", markaId, "SF_MARKA", allMarka);

            // ============================================================
            // DİĞER SENSÖRLER: SFH6
            // ============================================================
            AddAll("SFH6", tipId, "SF_TIP", allTip);
            AddAll("SFH6", cikisSinyaliId, "SF_CIKIS_SINYALI", allCikisSinyali);
            AddAll("SFH6", markaId, "SF_MARKA", allMarka);

            builder.HasData(rules);
        }
    }
}