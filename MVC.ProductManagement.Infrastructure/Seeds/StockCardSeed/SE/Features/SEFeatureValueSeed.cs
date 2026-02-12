using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE.Features
{
    public class SEFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var productCategoryId = SeedId.From("SFeature:PRODUCT_CATEGORY");
            var materialId = SeedId.From("SFeature:SE_MATERIAL");
            var crossSectionId = SeedId.From("SFeature:CROSS_SECTION");
            var voltageId = SeedId.From("SFeature:VOLTAGE");
            var standardId = SeedId.From("SFeature:SE_STANDARD");
            var colorTypeId = SeedId.From("SFeature:COLOR_TYPE");

            var values = new List<SFeatureValue>();

            // ========== 1. ÜRÜN KATEGORİSİ ==========
            var productCategories = new[]
            {
                "Kablo Tesisat",
                "Kablo Akü",
                "Kablo TTR",
                "Bakır Kalay Kaplı Kablo",
                "Akü",
                "Sigorta",
                "Şalter",
                "Röle",
                "Konnektör & Soket",
                "Diyot",
                "Ampul & Lamba",
                "Switch & Button",
                "Pabuç Terminal",
                "NR Terminal Pipe",
                "Spiral Makaron/Kablo Kılıfı",
                "Isı Büzüşmeli Makaron",
                "Kablo Kanalı",
                "Klemens",
                "Elektrik Tesisat Rekorları",
                "Kablo Uç Yüksüğü",
                "Kablo ve Kumanda Sistemleri",
                "Elektrik Motoru",
                "Load Cell",
                "Diğer Kablolar",
                "Elektrikli Isıtıcılar",
                "Kornalar",
                "Güç Kaynakları",
                "Kablo Tambur",
                "Veri Okuma Cihazları",
                "Sigorta Rayı",
                "Algılayıcılar",
                "Haberleşme Modülleri",
                "Tabela ve Levhalar",
                "Elektrik Malzemeler",
                "Kablo",
                "Kablo Endüstriyel",
                "Bağlantı Kutusu"
            };
            for (int i = 0; i < productCategories.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:PRODUCT_CATEGORY:{productCategories[i]}"),
                    SFeatureId = productCategoryId,
                    Code = productCategories[i],
                    Name = productCategories[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. MALZEME ==========
            var materials = new[]
            {
                "Bakır",
                "Alüminyum",
                "Bakır Kalay Kaplı",
                "PVC",
                "Silikon",
                "Polietilen (PE)",
                "XLPE (Çapraz Bağlı Polietilen)",
                "Kauçuk",
                "Teflon (PTFE)",
                "Kurşun Asit (Akü)"
            };
            for (int i = 0; i < materials.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SE_MATERIAL:{materials[i]}"),
                    SFeatureId = materialId,
                    Code = materials[i],
                    Name = materials[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 3. KESİT/KAPASİTE ==========
            var crossSections = new[]
            {
                "0.22mm²",
                "0.35mm²",
                "0.5mm²",
                "0.75mm²",
                "1mm²",
                "1.5mm²",
                "2.5mm²",
                "4mm²",
                "6mm²",
                "10mm²",
                "16mm²",
                "25mm²",
                "35mm²",
                "50mm²",
                "70mm²",
                "95mm²",
                "120mm²",
                "150mm²",
                "185mm²",
                "240mm²",
                "300mm²",
                "5A",
                "10A",
                "16A",
                "20A",
                "32A",
                "40A",
                "50A",
                "63A",
                "80A",
                "100A"
            };
            for (int i = 0; i < crossSections.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:CROSS_SECTION:{crossSections[i]}"),
                    SFeatureId = crossSectionId,
                    Code = crossSections[i],
                    Name = crossSections[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 4. VOLTAJ ==========
            var voltages = new[]
            {
                "12V",
                "24V",
                "48V",
                "110V",
                "220V",
                "230V",
                "240V",
                "380V",
                "400V",
                "415V",
                "500V",
                "690V",
                "1000V"
            };
            for (int i = 0; i < voltages.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:VOLTAGE:{voltages[i]}"),
                    SFeatureId = voltageId,
                    Code = voltages[i],
                    Name = voltages[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 5. STANDART ==========
            var standards = new[]
            {
                "IEC 60227",
                "IEC 60245",
                "DIN VDE 0250",
                "TSE",
                "UL",
                "CE",
                "ISO 6722",
                "SAE J1128",
                "EN 50525"
            };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SE_STANDARD:{standards[i]}"),
                    SFeatureId = standardId,
                    Code = standards[i],
                    Name = standards[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 6. RENK/TİP ==========
            var colorTypes = new[]
            {
                "Siyah",
                "Kırmızı",
                "Mavi",
                "Sarı/Yeşil",
                "Yeşil",
                "Sarı",
                "Beyaz",
                "Gri",
                "Kahverengi",
                "Turuncu",
                "Şeffaf",
                "Çok Damarlı (Renkli)"
            };
            for (int i = 0; i < colorTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:COLOR_TYPE:{colorTypes[i]}"),
                    SFeatureId = colorTypeId,
                    Code = colorTypes[i],
                    Name = colorTypes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            builder.HasData(values);
        }
    }
}