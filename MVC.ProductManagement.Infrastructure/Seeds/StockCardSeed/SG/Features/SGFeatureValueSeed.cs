using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG.Features
{
    public class SGFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // ✅ Güncellenmiş ID'ler
            var materialId = SeedId.From("SFeature:SG:MATERIAL");
            var standardId = SeedId.From("SFeature:SG:STANDARD");
            var diameterId = SeedId.From("SFeature:SG:DIAMETER");
            var lengthId = SeedId.From("SFeature:SG:LENGTH");
            var coatingId = SeedId.From("SFeature:SG:COATING");

            var values = new List<SFeatureValue>();

            // ========== 1. MALZEME ==========
            var materials = new[]
            {
                "Çelik",
                "Paslanmaz Çelik AISI 304",
                "Paslanmaz Çelik AISI 316",
                "Alüminyum",
                "Bakır",
                "Pirinç",
                "Plastik (PA)",
                "Bronz",
                "Sertleştirilmiş Çelik"
            };
            for (int i = 0; i < materials.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SG:MATERIAL:{materials[i]}"), // ✅ SG: eklendi
                    SFeatureId = materialId,
                    Code = materials[i],
                    Name = materials[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. STANDART ==========
            var standards = new[]
            {
                "DIN 1",
                "DIN 6",
                "DIN 7",
                "DIN 1481",
                "ISO 2338",
                "ISO 8734",
                "ISO 8735",
                "ANSI B18.8.2",
                "JIS B 1354",
                "DIN 71412",
                "Özel"
            };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SG:STANDARD:{standards[i]}"), // ✅ SG: eklendi
                    SFeatureId = standardId,
                    Code = standards[i],
                    Name = standards[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 3. ÇAP (mm) ==========
            var diameters = new[]
            {
                "1mm", "1.5mm", "2mm", "2.5mm", "3mm", "4mm", "5mm", "6mm", "7mm", "8mm",
                "10mm", "12mm", "13mm", "14mm", "16mm", "18mm", "20mm", "22mm", "25mm", "30mm",
                "M6", "M8", "M10", "M12", "M14", "M16", "M18", "M20", "M22", "M24", "M27", "M30"
            };
            for (int i = 0; i < diameters.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SG:DIAMETER:{diameters[i]}"), // ✅ SG: eklendi
                    SFeatureId = diameterId,
                    Code = diameters[i],
                    Name = diameters[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 4. BOY (mm) ==========
            var lengths = new[]
            {
                "6mm", "8mm", "10mm", "12mm", "14mm", "16mm", "18mm", "20mm", "22mm", "25mm",
                "28mm", "30mm", "32mm", "35mm", "40mm", "45mm", "50mm", "55mm", "60mm", "65mm",
                "70mm", "75mm", "80mm", "90mm", "100mm", "110mm", "120mm", "140mm", "150mm", "160mm",
                "180mm", "200mm"
            };
            for (int i = 0; i < lengths.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SG:LENGTH:{lengths[i]}"), // ✅ SG: eklendi
                    SFeatureId = lengthId,
                    Code = lengths[i],
                    Name = lengths[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 5. KAPLAMA ==========
            var coatings = new[]
            {
                "Kaplamasız",
                "Çinko Kaplama",
                "Nikel Kaplama",
                "Krom Kaplama",
                "Galvaniz",
                "Siyah Oksit",
                "Fosfor Kaplama",
                "Teflon Kaplama"
            };
            for (int i = 0; i < coatings.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SG:COATING:{coatings[i]}"), // ✅ SG: eklendi
                    SFeatureId = coatingId,
                    Code = coatings[i],
                    Name = coatings[i],
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