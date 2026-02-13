using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA.Features
{
    /// <summary>
    /// ✅ ESKİ SİSTEME UYGUN: PRODUCT_TYPE, HEAD_TYPE dahil, METRIC kullanılıyor
    /// </summary>
    public class SAFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var productTypeId = SeedId.From("SFeature:PRODUCT_TYPE");
            var materialId = SeedId.From("SFeature:MATERIAL");
            var headTypeId = SeedId.From("SFeature:HEAD_TYPE");
            var threadSystemId = SeedId.From("SFeature:THREAD_SYSTEM");
            var standardId = SeedId.From("SFeature:STANDARD");
            var metricId = SeedId.From("SFeature:METRIC");
            var lengthId = SeedId.From("SFeature:LENGTH");
            var strengthId = SeedId.From("SFeature:STRENGTH");
            var coatingId = SeedId.From("SFeature:COATING");

            var values = new List<SFeatureValue>();

            // ========== 1. ÜRÜN TİPİ ==========
            var productTypes = new[] { "CIVATA", "SOMUN", "PUL", "RONDELA", "PERCIN" };
            for (int i = 0; i < productTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:PRODUCT_TYPE:{productTypes[i]}"),
                    SFeatureId = productTypeId,
                    Code = productTypes[i],
                    Name = productTypes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. MALZEME ==========
            var materials = new[]
            {
                ("KARBON", "Karbon Çelik"),
                ("304", "Paslanmaz Çelik 304"),
                ("316", "Paslanmaz Çelik 316"),
                ("316L", "Paslanmaz Çelik 316L"),
                ("ALAŞIMLI", "Alaşımlı Çelik"),
                ("PIRINÇ", "Pirinç"),
                ("ALÜMINYUM", "Alüminyum")
            };
            for (int i = 0; i < materials.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:MATERIAL:{materials[i].Item1}"),
                    SFeatureId = materialId,
                    Code = materials[i].Item1,
                    Name = materials[i].Item2,
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 3. BAŞ TİPİ ==========
            var headTypes = new[]
            {
                ("AKB", "Altıgen Başlı"),
                ("SB", "Silindirik Başlı"),
                ("HB", "Havşa Başlı"),
                ("MB", "Mantar Başlı"),
                ("KB", "Kelebek Başlı"),
                ("YB", "Yuvarlak Başlı")
            };
            for (int i = 0; i < headTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:HEAD_TYPE:{headTypes[i].Item1}"),
                    SFeatureId = headTypeId,
                    Code = headTypes[i].Item1,
                    Name = headTypes[i].Item2,
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 4. DİŞ SİSTEMİ ==========
            var threadSystems = new[]
            {
                ("METRIK", "Metrik"),
                ("UNC", "UNC"),
                ("UNF", "UNF"),
                ("BSW", "BSW")
            };
            for (int i = 0; i < threadSystems.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:THREAD_SYSTEM:{threadSystems[i].Item1}"),
                    SFeatureId = threadSystemId,
                    Code = threadSystems[i].Item1,
                    Name = threadSystems[i].Item2,
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 5. STANDART ==========
            var standards = new[]
            {
                "DIN 931", "DIN 933", "ISO 4014", "ISO 4017",
                "DIN 912", "DIN 7991", "ASTM A193", "ASTM A320"
            };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:STANDARD:{standards[i]}"),
                    SFeatureId = standardId,
                    Code = standards[i],
                    Name = standards[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 6. METRİK (ÇAP) ==========
            var metrics = new[]
            {
                "M3", "M4", "M5", "M6", "M8", "M10", "M12", "M14", "M16", "M18", "M20",
                "M22", "M24", "M27", "M30", "M33", "M36",
                "1/4", "5/16", "3/8", "1/2", "5/8", "3/4", "7/8", "1"
            };
            for (int i = 0; i < metrics.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:METRIC:{metrics[i]}"),
                    SFeatureId = metricId,
                    Code = metrics[i],
                    Name = metrics[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 7. BOY ==========
            var lengths = new[]
            {
                10, 12, 16, 20, 25, 30, 35, 40, 45, 50, 60, 70, 80, 90, 100,
                120, 150, 200, 250, 300
            };
            for (int i = 0; i < lengths.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:LENGTH:{lengths[i]}"),
                    SFeatureId = lengthId,
                    Code = $"{lengths[i]}",
                    Name = $"{lengths[i]} mm",
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 8. MUKAVEMET SINIFI ==========
            var strengths = new[]
            {
                "4.6", "4.8", "5.6", "5.8", "8.8", "10.9", "12.9",
                "A2-70", "A4-80", "B7", "L7"
            };
            for (int i = 0; i < strengths.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:STRENGTH:{strengths[i]}"),
                    SFeatureId = strengthId,
                    Code = strengths[i],
                    Name = strengths[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 9. YÜZEY KAPLAMA ==========
            var coatings = new[]
            {
                ("SIYAH OKSIT", "Siyah Oksit"),
                ("CINKO", "Çinko Kaplama"),
                ("GEOMET", "Geomet"),
                ("HDG", "Sıcak Daldırma Galvaniz"),
                ("PTFE", "PTFE"),
                ("KADMIYUM", "Kadmiyum"),
                ("-", "Kaplamasız")
            };
            for (int i = 0; i < coatings.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:COATING:{coatings[i].Item1}"),
                    SFeatureId = coatingId,
                    Code = coatings[i].Item1,
                    Name = coatings[i].Item2,
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