using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    public class SFFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var productCategoryId = SeedId.From("SFeature:SF:PRODUCT_CATEGORY");
            var materialId = SeedId.From("SFeature:SF:MATERIAL");
            var connectionTypeId = SeedId.From("SFeature:SF:CONNECTION_TYPE");
            var sizeId = SeedId.From("SFeature:SF:SIZE");
            var pressureClassId = SeedId.From("SFeature:SF:PRESSURE_CLASS");
            var standardId = SeedId.From("SFeature:SF:STANDARD");

            var values = new List<SFeatureValue>();

            // ========== 1. ÜRÜN KATEGORİSİ ==========
            var productCategories = new[]
            {
                "Vana/Valf",
                "Emniyet/Relief Valf",
                "Regülatör",
                "Seviye/Ölçüm Göstergesi",
                "Aşırı Akış/Check/Dengeleme Valf",
                "Sayaç ve Printer",
                "Filtre",
                "Pompa",
                "Kompresör",
                "Adaptör/Konnektör/Bağlantı Parçası",
                "Menhol Kapak",
                "Su Vanası",
                "Hidrolik Sistem Vana/Valf",
                "Topraklama Makarası",
                "Hortum Makarası",
                "Manometre/Basınç Ölçer",
                "Termometre/Sıcaklık Ölçer",
                "Conta",
                "Pnömatik Sistem Vana/Valf",
                "Cylinder Unit",
                "Gaz/Yangın Dedektörü",
                "Tartı/Kantar",
                "Hava Kompresörü",
                "Fan",
                "Sensör"
            };
            for (int i = 0; i < productCategories.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SF:PRODUCT_CATEGORY:{productCategories[i]}"),
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
                "Paslanmaz Çelik AISI 304",
                "Paslanmaz Çelik AISI 316",
                "Pirinç",
                "Alüminyum",
                "Çelik",
                "Bronz",
                "Dökme Demir",
                "Karbon Çelik",
                "PVC",
                "Teflon (PTFE)",
                "Polipropilen (PP)"
            };
            for (int i = 0; i < materials.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SF:MATERIAL:{materials[i]}"),
                    SFeatureId = materialId,
                    Code = materials[i],
                    Name = materials[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 3. BAĞLANTI TİPİ ==========
            var connectionTypes = new[]
            {
                "NPT (İnç Konik Diş)",
                "BSP (İnç Paralel Diş)",
                "BSPT (İnç Konik Diş)",
                "Flanş PN10",
                "Flanş PN16",
                "Flanş PN25",
                "Flanş Class 150",
                "Flanş Class 300",
                "Civatalı",
                "Kaynaklı",
                "Hızlı Bağlantı (Quick Coupling)",
                "Klipsli",
                "Sıkmalı (Compression)",
                "Vidalı"
            };
            for (int i = 0; i < connectionTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SF:CONNECTION_TYPE:{connectionTypes[i]}"),
                    SFeatureId = connectionTypeId,
                    Code = connectionTypes[i],
                    Name = connectionTypes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 4. ÇAP/BOYUT ==========
            var sizes = new[]
            {
                "1/8\"", "1/4\"", "3/8\"", "1/2\"", "3/4\"", "1\"", "1 1/4\"", "1 1/2\"", "2\"", "2 1/2\"",
                "3\"", "4\"", "6\"", "8\"",
                "DN6", "DN10", "DN15", "DN20", "DN25", "DN32", "DN40", "DN50", "DN65", "DN80", "DN100", "DN150", "DN200"
            };
            for (int i = 0; i < sizes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SF:SIZE:{sizes[i]}"),
                    SFeatureId = sizeId,
                    Code = sizes[i],
                    Name = sizes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 5. BASINÇ SINIFI ==========
            var pressureClasses = new[]
            {
                "PN6", "PN10", "PN16", "PN25", "PN40", "PN63", "PN100",
                "Class 150", "Class 300", "Class 600", "Class 900", "Class 1500",
                "150 PSI", "300 PSI", "600 PSI",
                "Düşük Basınç", "Orta Basınç", "Yüksek Basınç"
            };
            for (int i = 0; i < pressureClasses.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SF:PRESSURE_CLASS:{pressureClasses[i]}"),
                    SFeatureId = pressureClassId,
                    Code = pressureClasses[i],
                    Name = pressureClasses[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 6. STANDART ==========
            var standards = new[]
            {
                "DIN", "ISO 5211", "ISO 10497", "ANSI B16.34", "API 6D", "API 594",
                "BS 5351", "EN 558", "TS EN 1092-1", "ASME B16.10", "MSS SP-61", "Özel"
            };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SF:STANDARD:{standards[i]}"),
                    SFeatureId = standardId,
                    Code = standards[i],
                    Name = standards[i],
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