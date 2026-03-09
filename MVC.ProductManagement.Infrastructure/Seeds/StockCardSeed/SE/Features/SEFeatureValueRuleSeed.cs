using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE.Features
{
    public class SEFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var seProducts = new[]
            {
                "SEA0", "SEA1", "SEA2", "SEA3", "SEA4", "SEA5", "SEA6", "SEA7", "SEA8", "SEA9", "SEAA",
                "SEB0", "SEB1", "SEB2", "SEB3", "SEB4", "SEB5", "SEB6", "SEB7", "SEB8", "SEB9",
                "SEC0", "SEC1", "SEC2", "SEC3", "SEC4", "SEC5", "SEC6", "SEC7", "SEC8", "SEC9",
                "SED0", "SED1", "SED9", "SEE0", "SEF0", "SEF1", "SEG0"
            };

            var featureValues = new Dictionary<string, string[]>
            {
                ["PRODUCT_CATEGORY"] = new[] { "Kablo Tesisat", "Kablo Akü", "Kablo TTR", "Bakır Kalay Kaplı Kablo", "Akü", "Sigorta", "Şalter", "Röle", "Konnektör & Soket", "Diyot", "Ampul & Lamba", "Switch & Button", "Pabuç Terminal", "NR Terminal Pipe", "Spiral Makaron/Kablo Kılıfı", "Isı Büzüşmeli Makaron", "Kablo Kanalı", "Klemens", "Elektrik Tesisat Rekorları", "Kablo Uç Yüksüğü", "Kablo ve Kumanda Sistemleri", "Elektrik Motoru", "Load Cell", "Diğer Kablolar", "Elektrikli Isıtıcılar", "Kornalar", "Güç Kaynakları", "Kablo Tambur", "Veri Okuma Cihazları", "Sigorta Rayı", "Algılayıcılar", "Haberleşme Modülleri", "Tabela ve Levhalar", "Elektrik Malzemeler", "Kablo", "Kablo Endüstriyel", "Bağlantı Kutusu" },
                ["SE_MATERIAL"] = new[] { "Bakır", "Alüminyum", "Bakır Kalay Kaplı", "PVC", "Silikon", "Polietilen (PE)", "XLPE (Çapraz Bağlı Polietilen)", "Kauçuk", "Teflon (PTFE)", "Kurşun Asit (Akü)" },
                ["CROSS_SECTION"] = new[] { "0.22mm²", "0.35mm²", "0.5mm²", "0.75mm²", "1mm²", "1.5mm²", "2.5mm²", "4mm²", "6mm²", "10mm²", "16mm²", "25mm²", "35mm²", "50mm²", "70mm²", "95mm²", "120mm²", "150mm²", "185mm²", "240mm²", "300mm²", "5A", "10A", "16A", "20A", "32A", "40A", "50A", "63A", "80A", "100A" },
                ["VOLTAGE"] = new[] { "12V", "24V", "48V", "110V", "220V", "230V", "240V", "380V", "400V", "415V", "500V", "690V", "1000V" },
                ["SE_STANDARD"] = new[] { "IEC 60227", "IEC 60245", "DIN VDE 0250", "TSE", "UL", "CE", "ISO 6722", "SAE J1128", "EN 50525" },
                ["COLOR_TYPE"] = new[] { "Siyah", "Kırmızı", "Mavi", "Sarı/Yeşil", "Yeşil", "Sarı", "Beyaz", "Gri", "Kahverengi", "Turuncu", "Şeffaf", "Çok Damarlı (Renkli)" }
            };

            var rules = new List<SFeatureValueRule>();

            foreach (var productCode in seProducts)
            {
                var productId = SeedId.From($"SProduct:SE:{productCode}");

                foreach (var (featureCode, values) in featureValues)
                {
                    var featureId = SeedId.From($"SFeature:{featureCode}");
                    var sort = 0;

                    foreach (var valueCode in values)
                    {
                        rules.Add(new SFeatureValueRule
                        {
                            Id = SeedId.From($"SFeatureValueRule:SE:{productCode}:{featureCode}:{valueCode}"),
                            SProductId = productId,
                            SFeatureId = featureId,
                            SFeatureValueId = SeedId.From($"SFeatureValue:{featureCode}:{valueCode}"),
                            SortOrder = sort++,
                            CreatedBy = "SEED",
                            CreatedDate = now,
                            Status = Domain.Enums.Status.Added
                        });
                    }
                }
            }

            builder.HasData(rules);
        }
    }
}
