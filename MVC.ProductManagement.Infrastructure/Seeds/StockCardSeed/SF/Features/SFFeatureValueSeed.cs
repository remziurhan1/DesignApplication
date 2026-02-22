using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    public class SFFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
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

            var values = new List<SFeatureValue>();

            void Add(string featureCode, Guid featureId, params string[] codes)
            {
                for (int i = 0; i < codes.Length; i++)
                {
                    values.Add(new SFeatureValue
                    {
                        Id = SeedId.From($"SFeatureValue:{featureCode}:{codes[i]}"),
                        SFeatureId = featureId,
                        Code = codes[i],
                        Name = codes[i],
                        SortOrder = i,
                        CreatedBy = "SEED",
                        CreatedDate = now,
                        Status = Domain.Enums.Status.Added
                    });
                }
            }

            // ===== AKIŞ MEDYUMU =====
            Add("SF_AKIS_MEDYUMU", akisMedyumuId,
                "LPG", "Cryogenic", "Akaryakıt", "Su", "Hidrolik",
                "Pnömatik", "Doğal Gaz", "Kimyasal", "Proses Gaz", "Diğer");

            // ===== MARKA =====
            Add("SF_MARKA", markaId,
                "Emerson", "Fisher", "Spirax Sarco", "Samson", "Flowserve",
                "Velan", "Metso", "Crane", "Kitz", "Grundfos", "Ebara",
                "Lowara", "Pedrollo", "Wilo", "Sulzer", "Xylem", "Viking",
                "Blackmer", "Elster", "Actaris", "Itron", "Krohne",
                "Endress+Hauser", "Yokogawa", "ABB", "Parker", "Swagelok",
                "Festo", "SMC", "Wika", "Wise", "Bourdon", "Ashcroft",
                "Tescom", "Fairchild", "Norgren", "Cavagna",
                "Parker Hannifin", "Pall", "Donaldson", "Winters", "Diğer");

            // ===== VANA TİPİ =====
            Add("SF_VANA_TIPI", vanaTipiId,
                "Küresel Vana", "Kelebek Vana", "Sürgülü Vana", "İğne Vana",
                "Küresel Valf", "Pistonlu Vana", "Diyafram Vana", "Plug Vana");

            // ===== AKTÜATÖR TİPİ =====
            Add("SF_AKTUATOR", aktuatorId,
                "Manuel", "Pnömatik", "Elektrikli", "Hidrolik",
                "Elektrohidrolik", "Yaylı Diyafram");

            // ===== DN =====
            Add("SF_DN", dnId,
                "DN10", "DN15", "DN20", "DN25", "DN32", "DN40", "DN50",
                "DN65", "DN80", "DN100", "DN125", "DN150", "DN200",
                "DN250", "DN300", "DN350", "DN400", "DN500", "DN600");

            // ===== BASINÇ SINIFI =====
            Add("SF_BASINC_SINIFI", basincSinifiId,
                "PN6", "PN10", "PN16", "PN25", "PN40", "PN63", "PN100",
                "Class 150", "Class 300", "Class 600", "Class 900", "Class 1500");

            // ===== BAĞLANTI TİPİ =====
            Add("SF_BAGLANTI_TIPI", baglantiTipiId,
                "Flanşlı", "Dişli", "Kaynaklı", "Wafer", "Lug",
                "Socket Weld", "Butt Weld", "Clamp");

            // ===== MALZEME =====
            Add("SF_MALZEME", malzemeId,
                "Dökme Demir (GG25)", "Sfero Döküm (GGG40)", "Karbon Çelik (A216 WCB)",
                "Paslanmaz Çelik AISI 304", "Paslanmaz Çelik AISI 316",
                "Paslanmaz Çelik AISI 316L", "Pirinç", "Bronz", "Alüminyum",
                "Duplex Paslanmaz", "Hastelloy C276", "Monel", "PTFE Kaplı",
                "Grafit", "NBR", "EPDM", "Viton");

            // ===== AYAR BASINCI =====
            Add("SF_AYAR_BASINCI", ayarBasinciId,
                "0.5 bar", "1 bar", "2 bar", "3 bar", "4 bar", "5 bar",
                "6 bar", "8 bar", "10 bar", "12 bar", "16 bar", "20 bar",
                "25 bar", "32 bar", "40 bar");

            // ===== GİRİŞ BASINCI =====
            Add("SF_GIRIS_BASINCI", girisBasinciId,
                "0-10 bar", "0-16 bar", "0-25 bar", "0-40 bar",
                "0-63 bar", "0-100 bar", "0-160 bar", "0-250 bar");

            // ===== ÇIKIŞ BASINCI =====
            Add("SF_CIKIS_BASINCI", cikisBasinciId,
                "0-1 bar", "0-2 bar", "0-4 bar", "0-6 bar",
                "0-10 bar", "0-16 bar", "0-25 bar", "0-40 bar");

            // ===== BAĞLANTI ÇAPI =====
            Add("SF_BAGLANTI_CAPI", baglantiCapiId,
                "1/4\"", "3/8\"", "1/2\"", "3/4\"", "1\"",
                "1.1/4\"", "1.1/2\"", "2\"", "2.1/2\"", "3\"", "4\"");

            // ===== ÖLÇÜM TİPİ =====
            Add("SF_OLCUM_TIPI", olcumTipiId,
                "Manyetik", "Ultrasonik", "Radar", "Şamandıralı",
                "Basınç Farkı", "Kapasitif", "Kondüktif", "Guided Wave Radar");

            // ===== ÇIKIŞ SİNYALİ =====
            Add("SF_CIKIS_SINYALI", cikisSinyaliId,
                "4-20mA", "0-10V", "HART", "Profibus",
                "Foundation Fieldbus", "Modbus", "Puls", "On/Off");

            // ===== VALF TİPİ =====
            Add("SF_VALF_TIPI", valfTipiId,
                "Aşırı Akış Valfi", "Check Valf", "Geri Tepme Önleyici",
                "Dengeleme Valfi", "By-Pass Valfi");

            // ===== SAYAÇ TİPİ =====
            Add("SF_SAYAC_TIPI", sayacTipiId,
                "Hacimsel", "Türbinli", "Manyetik", "Ultrasonik",
                "Coriolis", "Oval Dişli", "Rotary");

            // ===== GÖZENEK BOYUTU =====
            Add("SF_GOZNEK", goznekId,
                "1 micron", "5 micron", "10 micron", "25 micron",
                "50 micron", "100 micron", "150 micron", "200 micron",
                "500 micron", "1000 micron");

            // ===== POMPA TİPİ =====
            Add("SF_POMPA_TIPI", pompaTipiId,
                "Santrifüj", "Dalgıç", "Dişli", "Pistonlu", "Vidalı",
                "Paletli", "Peristaltik", "Membran", "Kompresör");

            // ===== GÜÇ (kW) =====
            Add("SF_GUC_KW", gucKwId,
                "0.25 kW", "0.37 kW", "0.55 kW", "0.75 kW", "1.1 kW",
                "1.5 kW", "2.2 kW", "3 kW", "4 kW", "5.5 kW",
                "7.5 kW", "11 kW", "15 kW", "18.5 kW", "22 kW",
                "30 kW", "37 kW", "45 kW", "55 kW", "75 kW", "90 kW", "110 kW");

            // ===== ADAPTÖR TİPİ =====
            Add("SF_ADAPTOR_TIPI", adaptorTipiId,
                "Dişli-Dişli", "Flanş-Flanş", "Dişli-Flanş",
                "Kampili", "Storz", "BSP-NPT", "Quick Connect");

            // ===== BAĞLANTI 1 =====
            Add("SF_BAGLANTI_1", baglanti1Id,
                "1/4\" BSP", "3/8\" BSP", "1/2\" BSP", "3/4\" BSP", "1\" BSP",
                "1.1/4\" BSP", "1.1/2\" BSP", "2\" BSP",
                "1/4\" NPT", "3/8\" NPT", "1/2\" NPT", "3/4\" NPT", "1\" NPT",
                "DN25 Flanş", "DN32 Flanş", "DN40 Flanş", "DN50 Flanş",
                "DN65 Flanş", "DN80 Flanş", "DN100 Flanş");

            // ===== BAĞLANTI 2 =====
            Add("SF_BAGLANTI_2", baglanti2Id,
                "1/4\" BSP", "3/8\" BSP", "1/2\" BSP", "3/4\" BSP", "1\" BSP",
                "1.1/4\" BSP", "1.1/2\" BSP", "2\" BSP",
                "1/4\" NPT", "3/8\" NPT", "1/2\" NPT", "3/4\" NPT", "1\" NPT",
                "DN25 Flanş", "DN32 Flanş", "DN40 Flanş", "DN50 Flanş",
                "DN65 Flanş", "DN80 Flanş", "DN100 Flanş");

            // ===== ÇAP (mm) =====
            Add("SF_CAPI_MM", capiMmId,
                "40 mm", "50 mm", "63 mm", "80 mm", "100 mm",
                "115 mm", "150 mm", "160 mm", "200 mm", "250 mm");

            // ===== ÖLÇÜM ARALIĞI =====
            Add("SF_OLCUM_ARALIGI", olcumAraligiId,
                "-30...+50 °C", "-20...+60 °C", "0...+100 °C", "0...+120 °C",
                "0...+160 °C", "0...+200 °C", "0...+300 °C", "0...+400 °C",
                "-1...+0 bar", "0...+1 bar", "0...+2.5 bar", "0...+4 bar",
                "0...+6 bar", "0...+10 bar", "0...+16 bar", "0...+25 bar",
                "0...+40 bar", "0...+60 bar", "0...+100 bar", "0...+160 bar",
                "0...+250 bar", "0...+400 bar", "0...+600 bar");

            // ===== MANOMETRETİPİ =====
            Add("SF_MANOMETRE_TIPI", manomTipiId,
                "Bourdon Tüplü", "Diyafram", "Kapsül", "Dijital",
                "Differential", "Gliserinli");

            // ===== DALDIRMA BOYU =====
            Add("SF_DALDIRMA_BOYU", daldirmaId,
                "100 mm", "150 mm", "200 mm", "250 mm", "300 mm",
                "400 mm", "500 mm", "600 mm", "750 mm", "1000 mm");

            // ===== CONTA TİPİ =====
            Add("SF_CONTA_TIPI", contaTipiId,
                "Spiral Wound", "Ring Joint", "Düz Conta", "Kammprofile",
                "Full Face", "Raised Face", "PTFE Sarmalı", "Grafit Sarmalı");

            // ===== TİP =====
            Add("SF_TIP", tipId,
                "Tip A", "Tip B", "Tip C", "Standart", "Özel", "Diğer");

            // ===== KAPASİTE =====
            Add("SF_KAPASITE", kapasiteId,
                "5 kg", "10 kg", "15 kg", "20 kg", "25 kg", "33 kg", "45 kg",
                "100 L", "200 L", "300 L", "500 L", "1000 L",
                "1 m³/h", "2 m³/h", "5 m³/h", "10 m³/h", "20 m³/h",
                "50 m³/h", "100 m³/h", "200 m³/h", "500 m³/h");

            builder.HasData(values);
        }
    }
}