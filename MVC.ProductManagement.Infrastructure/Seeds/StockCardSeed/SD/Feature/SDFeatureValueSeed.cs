using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD.Features
{
    public class SDFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var connectionTypeId = SeedId.From("SFeature:CONNECTION_TYPE");
            var materialId = SeedId.From("SFeature:SD_MATERIAL");
            var standardId = SeedId.From("SFeature:SD_STANDARD");
            var connectionSizeId = SeedId.From("SFeature:CONNECTION_SIZE");
            var angleId = SeedId.From("SFeature:ANGLE");
            var coatingId = SeedId.From("SFeature:SD_COATING");

            var values = new List<SFeatureValue>();

            // ========== 1. BAĞLANTI TİPİ ==========
            var connectionTypes = new[]
            {
                "Rekor",
                "Tee",
                "Dirsek",
                "Redüksiyon",
                "Flans",
                "Boru Boğazı/Bağlayıcı",
                "Diğer Bağlantı Elemanları",
                "Fittings"
            };
            for (int i = 0; i < connectionTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:CONNECTION_TYPE:{connectionTypes[i]}"),
                    SFeatureId = connectionTypeId,
                    Code = connectionTypes[i],
                    Name = connectionTypes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. MALZEME ==========
            var materials = new[]
            {
                "Hidrolik Çelik",
                "Pnömatik Çelik",
                "Karbon Çelik",
                "Alüminyum",
                "Paslanmaz Çelik AISI 304",
                "Paslanmaz Çelik AISI 316",
                "Pirinç",
                "PPR",
                "PE (Polietilen)",
                "Polyemid",
                "Galvaniz Çelik",
                "Bronz"
            };
            for (int i = 0; i < materials.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SD_MATERIAL:{materials[i]}"),
                    SFeatureId = materialId,
                    Code = materials[i],
                    Name = materials[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 3. STANDART ==========
            var standards = new[]
            {
                "DIN 2353",
                "ISO 8434-1",
                "SAE J514",
                "DIN 3863",
                "DIN 2566",
                "ASTM A105",
                "EN 1092-1",
                "ASME B16.9",
                "DIN 2615",
                "ISO 4144"
            };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SD_STANDARD:{standards[i]}"),
                    SFeatureId = standardId,
                    Code = standards[i],
                    Name = standards[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 4. BAĞLANTI ÖLÇÜSÜ ==========
            var connectionSizes = new[]
            {
                "1/4\"",
                "3/8\"",
                "1/2\"",
                "3/4\"",
                "1\"",
                "1 1/4\"",
                "1 1/2\"",
                "2\"",
                "2 1/2\"",
                "3\"",
                "4\"",
                "DN6",
                "DN8",
                "DN10",
                "DN15",
                "DN20",
                "DN25",
                "DN32",
                "DN40",
                "DN50",
                "DN65",
                "DN80",
                "DN100"
            };
            for (int i = 0; i < connectionSizes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:CONNECTION_SIZE:{connectionSizes[i]}"),
                    SFeatureId = connectionSizeId,
                    Code = connectionSizes[i],
                    Name = connectionSizes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 5. AÇI ==========
            var angles = new[]
            {
                "45°",
                "90°",
                "180°",
                "T (Tee)",
                "Y (Y Bağlantı)"
            };
            for (int i = 0; i < angles.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:ANGLE:{angles[i]}"),
                    SFeatureId = angleId,
                    Code = angles[i],
                    Name = angles[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 6. YÜZEY İŞLEMİ ==========
            var coatings = new[]
            {
                "Doğal (Kaplamasız)",
                "Nikel Kaplama",
                "Krom Kaplama",
                "Çinko Kaplama",
                "Galvaniz",
                "Paslanmaz"
            };
            for (int i = 0; i < coatings.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SD_COATING:{coatings[i]}"),
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