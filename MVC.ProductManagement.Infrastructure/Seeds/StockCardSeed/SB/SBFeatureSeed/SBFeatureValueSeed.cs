using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.SBFeatureSeed
{
    public class SBFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var nutTypeId = SeedId.From("SFeature:NUT_TYPE");
            var strengthId = SeedId.From("SFeature:SB_STRENGTH");
            var standardId = SeedId.From("SFeature:SB_STANDARD");
            var metricId = SeedId.From("SFeature:SB_METRIC");
            var coatingId = SeedId.From("SFeature:SB_COATING");

            var values = new List<SFeatureValue>();

            // ========== 1. SOMUN TİPİ ==========
            var nutTypes = new[]
            {
                "AKB",
                "AKB Şapkalı",
                "Kontra",
                "Kaynak",
                "Taçlı",
                "Halkalı",
                "Whitworth/UNC/UNF",
                "Özel Grup (Uzatmalı)"
            };
            for (int i = 0; i < nutTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:NUT_TYPE:{nutTypes[i]}"),
                    SFeatureId = nutTypeId,
                    Code = nutTypes[i],
                    Name = nutTypes[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. MUKAVEMET SINIFI ==========
            var strengths = new[] { "8.8", "10.9", "12.9" };
            for (int i = 0; i < strengths.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SB_STRENGTH:{strengths[i]}"),
                    SFeatureId = strengthId,
                    Code = strengths[i],
                    Name = strengths[i],
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 3. STANDART ==========
            var standards = new[] { "DIN 934", "DIN 985", "ISO 4032", "ASTM A194-2H", "ASTM A194-7" };
            for (int i = 0; i < standards.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SB_STANDARD:{standards[i]}"),
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
                    Id = SeedId.From($"SFeatureValue:SB_METRIC:{metrics[i]}"),
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
            var coatings = new[] { "Doğal", "Krom", "Fiberli", "Elektro Galvaniz", "Sıcak Galvaniz" };
            for (int i = 0; i < coatings.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:SB_COATING:{coatings[i]}"),
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
