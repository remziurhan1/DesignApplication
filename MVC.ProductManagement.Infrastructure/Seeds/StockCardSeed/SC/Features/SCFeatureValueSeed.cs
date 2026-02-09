using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC.Features
{
    public class SCFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var washerTypeId = SeedId.From("SFeature:WASHER_TYPE");
            var materialId = SeedId.From("SFeature:SC_MATERIAL");
            var standardId = SeedId.From("SFeature:SC_STANDARD");
            var metricId = SeedId.From("SFeature:SC_METRIC");
            var coatingId = SeedId.From("SFeature:SC_COATING");

            var values = new List<SFeatureValue>();

            // ========== 1. RONDELA TİPİ ==========
            var washerTypes = new[]
            {
                "Düz Çelik",
                "Düz Alüminyum",
                "Düz Bakır",
                "Düz Crom",
                "Yaylı Çelik",
                "Yaylı Crom",
                "Tırtırlı Çelik",
                "Çanak Çelik",
                "Geniş Çelik",
                "Özel Grup (Süper, EPDM/II)",
                "Square Tapered",
                "Tırtırlı Paslanmaz"
            };
            for (int i = 0; i < washerTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:WASHER_TYPE:{washerTypes[i]}"),
                    SFeatureId = washerTypeId,
                    Code = washerTypes[i],
                    Name = washerTypes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. MALZEME ==========
            var materials = new[]
            {
                "Karbon Çelik",
                "Alüminyum",
                "Bakır",
                "Paslanmaz Çelik AISI 304",
                "Paslanmaz Çelik AISI 316",
                "Pirinç"
            };
            for (int i = 0; i < materials.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SC_MATERIAL:{materials[i]}"),
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
                "DIN 125",
                "DIN 127",
                "DIN 9021",
                "ISO 7089",
                "ISO 7090",
                "ASTM F436"
            };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SC_STANDARD:{standards[i]}"),
                    SFeatureId = standardId,
                    Code = standards[i],
                    Name = standards[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 4. ÖLÇÜ (METRİK) ==========
            var metrics = new[] { "M6", "M8", "M10", "M12", "M16", "M20", "M24", "M27", "M30", "M36" };
            for (int i = 0; i < metrics.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SC_METRIC:{metrics[i]}"),
                    SFeatureId = metricId,
                    Code = metrics[i],
                    Name = metrics[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 5. YÜZEY İŞLEMİ ==========
            var coatings = new[]
            {
                "Doğal (Kaplamasız)",
                "Çinko Kaplama",
                "Krom Kaplama",
                "Paslanmaz",
                "Elektro Galvaniz"
            };
            for (int i = 0; i < coatings.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SC_COATING:{coatings[i]}"),
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
