using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA.Features
{
    /// <summary>
    /// ✅ ESKİ SİSTEME UYGUN: Prefix bazında izinli feature değerleri
    /// Örnek: SAA0 için MATERIAL → KARBON, ALAŞIMLI (sadece bunlar gösterilir)
    /// </summary>
    public class SAFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // ✅ TÜM FEATURE ID'LERİ TANIMLA
            var productTypeId = SeedId.From("SFeature:PRODUCT_TYPE");
            var materialId = SeedId.From("SFeature:MATERIAL");
            var headTypeId = SeedId.From("SFeature:HEAD_TYPE");  // ✅ EKLE
            var threadSystemId = SeedId.From("SFeature:THREAD_SYSTEM");
            var standardId = SeedId.From("SFeature:STANDARD");
            var metricId = SeedId.From("SFeature:METRIC");
            var lengthId = SeedId.From("SFeature:LENGTH");
            var strengthId = SeedId.From("SFeature:STRENGTH");
            var coatingId = SeedId.From("SFeature:COATING");

            var rules = new List<SFeatureValueRule>();
            int sortOrder = 0;

            // ... (geri kalan kod aynı)

            // ========== SAA0: MATERIAL + COATING + STANDARD ==========
            AddAllowedValue(rules, "SAA0", materialId, "MATERIAL", "KARBON", ref sortOrder, now);
            AddAllowedValue(rules, "SAA0", materialId, "MATERIAL", "ALAŞIMLI", ref sortOrder, now);

            AddAllowedValue(rules, "SAA0", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddAllowedValue(rules, "SAA0", coatingId, "COATING", "GALVANIZ", ref sortOrder, now);
            AddAllowedValue(rules, "SAA0", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddAllowedValue(rules, "SAA0", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAA0", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllowedValue(rules, "SAA0", standardId, "STANDARD", "ISO 4017", ref sortOrder, now);

            AddAllMetrics(rules, "SAA0", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA0", lengthId, ref sortOrder, now);

            // ========== SAA1: MATERIAL + COATING + STANDARD ==========
            AddAllowedValue(rules, "SAA1", materialId, "MATERIAL", "ALAŞIMLI", ref sortOrder, now);

            AddAllowedValue(rules, "SAA1", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddAllowedValue(rules, "SAA1", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAA1", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllowedValue(rules, "SAA1", standardId, "STANDARD", "ISO 4017", ref sortOrder, now);

            AddAllMetrics(rules, "SAA1", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA1", lengthId, ref sortOrder, now);

            // ========== SAA2: STANDARD (sabit değerler zaten ProductFeatureRule'da) ==========
            AddAllowedValue(rules, "SAA2", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllowedValue(rules, "SAA2", standardId, "STANDARD", "ISO 4017", ref sortOrder, now);

            AddAllMetrics(rules, "SAA2", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA2", lengthId, ref sortOrder, now);

            // ========== SAA3: COATING + STANDARD ==========
            AddAllowedValue(rules, "SAA3", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddAllowedValue(rules, "SAA3", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAA3", standardId, "STANDARD", "DIN 931", ref sortOrder, now);
            AddAllowedValue(rules, "SAA3", standardId, "STANDARD", "ISO 4014", ref sortOrder, now);

            AddAllMetrics(rules, "SAA3", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA3", lengthId, ref sortOrder, now);

            // ========== SAA4: STANDARD ==========
            AddAllowedValue(rules, "SAA4", standardId, "STANDARD", "DIN 931", ref sortOrder, now);
            AddAllowedValue(rules, "SAA4", standardId, "STANDARD", "ISO 4014", ref sortOrder, now);

            AddAllMetrics(rules, "SAA4", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA4", lengthId, ref sortOrder, now);

            // ========== SAA5: STANDARD ==========
            AddAllowedValue(rules, "SAA5", standardId, "STANDARD", "DIN 931", ref sortOrder, now);
            AddAllowedValue(rules, "SAA5", standardId, "STANDARD", "ISO 4014", ref sortOrder, now);

            AddAllMetrics(rules, "SAA5", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA5", lengthId, ref sortOrder, now);

            // ========== SAA6: MATERIAL + STRENGTH + COATING + STANDARD ==========
            AddAllowedValue(rules, "SAA6", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddAllowedValue(rules, "SAA6", materialId, "MATERIAL", "316", ref sortOrder, now);

            AddAllowedValue(rules, "SAA6", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddAllowedValue(rules, "SAA6", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);

            AddAllowedValue(rules, "SAA6", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAA6", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllowedValue(rules, "SAA6", standardId, "STANDARD", "ISO 4017", ref sortOrder, now);

            AddAllMetrics(rules, "SAA6", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA6", lengthId, ref sortOrder, now);

            // ========== SAA7: COATING + STANDARD ==========
            AddAllowedValue(rules, "SAA7", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddAllowedValue(rules, "SAA7", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAA7", standardId, "STANDARD", "DIN 912", ref sortOrder, now);

            AddAllMetrics(rules, "SAA7", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA7", lengthId, ref sortOrder, now);

            // ========== SAA8: STANDARD ==========
            AddAllowedValue(rules, "SAA8", standardId, "STANDARD", "DIN 912", ref sortOrder, now);

            AddAllMetrics(rules, "SAA8", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA8", lengthId, ref sortOrder, now);

            // ========== SAA9: STANDARD ==========
            AddAllowedValue(rules, "SAA9", standardId, "STANDARD", "DIN 912", ref sortOrder, now);

            AddAllMetrics(rules, "SAA9", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAA9", lengthId, ref sortOrder, now);

            // ========== SAB SERİSİ ==========

            // SAB0: STANDARD
            AddAllowedValue(rules, "SAB0", standardId, "STANDARD", "DIN 912", ref sortOrder, now);
            AddAllMetrics(rules, "SAB0", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB0", lengthId, ref sortOrder, now);

            // SAB1: STANDARD
            AddAllowedValue(rules, "SAB1", standardId, "STANDARD", "DIN 912", ref sortOrder, now);
            AddAllMetrics(rules, "SAB1", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB1", lengthId, ref sortOrder, now);

            // SAB2: MATERIAL + STRENGTH + COATING + STANDARD
            AddAllowedValue(rules, "SAB2", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddAllowedValue(rules, "SAB2", materialId, "MATERIAL", "316", ref sortOrder, now);

            AddAllowedValue(rules, "SAB2", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddAllowedValue(rules, "SAB2", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);

            AddAllowedValue(rules, "SAB2", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAB2", standardId, "STANDARD", "DIN 912", ref sortOrder, now);
            AddAllMetrics(rules, "SAB2", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB2", lengthId, ref sortOrder, now);

            // SAB3: STANDARD
            AddAllowedValue(rules, "SAB3", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB3", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB3", lengthId, ref sortOrder, now);

            // SAB4: STANDARD
            AddAllowedValue(rules, "SAB4", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB4", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB4", lengthId, ref sortOrder, now);

            // SAB5: STANDARD
            AddAllowedValue(rules, "SAB5", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB5", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB5", lengthId, ref sortOrder, now);

            // SAB6: COATING + STANDARD
            AddAllowedValue(rules, "SAB6", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddAllowedValue(rules, "SAB6", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAB6", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB6", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB6", lengthId, ref sortOrder, now);

            // SAB7: COATING + STANDARD
            AddAllowedValue(rules, "SAB7", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddAllowedValue(rules, "SAB7", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAB7", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB7", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB7", lengthId, ref sortOrder, now);

            // SAB8: COATING + STANDARD
            AddAllowedValue(rules, "SAB8", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAB8", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB8", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB8", lengthId, ref sortOrder, now);

            // SAB9: MATERIAL + STRENGTH + COATING + STANDARD
            AddAllowedValue(rules, "SAB9", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddAllowedValue(rules, "SAB9", materialId, "MATERIAL", "316", ref sortOrder, now);

            AddAllowedValue(rules, "SAB9", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddAllowedValue(rules, "SAB9", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);

            AddAllowedValue(rules, "SAB9", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAB9", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAB9", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAB9", lengthId, ref sortOrder, now);

            // ========== SAC SERİSİ ==========

            // SAC0: STRENGTH + STANDARD
            AddAllowedValue(rules, "SAC0", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddAllowedValue(rules, "SAC0", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);

            AddAllowedValue(rules, "SAC0", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAC0", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC0", lengthId, ref sortOrder, now);

            // SAC1: STANDARD
            AddAllowedValue(rules, "SAC1", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllMetrics(rules, "SAC1", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC1", lengthId, ref sortOrder, now);

            // SAC2: STANDARD
            AddAllowedValue(rules, "SAC2", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllMetrics(rules, "SAC2", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC2", lengthId, ref sortOrder, now);

            // SAC3: STANDARD
            AddAllowedValue(rules, "SAC3", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllMetrics(rules, "SAC3", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC3", lengthId, ref sortOrder, now);

            // SAC4: MATERIAL + STRENGTH + COATING + STANDARD
            AddAllowedValue(rules, "SAC4", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddAllowedValue(rules, "SAC4", materialId, "MATERIAL", "316", ref sortOrder, now);

            AddAllowedValue(rules, "SAC4", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddAllowedValue(rules, "SAC4", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);

            AddAllowedValue(rules, "SAC4", coatingId, "COATING", "-", ref sortOrder, now);

            AddAllowedValue(rules, "SAC4", standardId, "STANDARD", "DIN 912", ref sortOrder, now);
            AddAllMetrics(rules, "SAC4", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC4", lengthId, ref sortOrder, now);

            // SAC5: STRENGTH + STANDARD
            AddAllowedValue(rules, "SAC5", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddAllowedValue(rules, "SAC5", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);

            AddAllowedValue(rules, "SAC5", standardId, "STANDARD", "DIN 7991", ref sortOrder, now);
            AddAllMetrics(rules, "SAC5", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC5", lengthId, ref sortOrder, now);

            // SAC6: MATERIAL + STRENGTH + STANDARD
            AddAllowedValue(rules, "SAC6", materialId, "MATERIAL", "KARBON", ref sortOrder, now);
            AddAllowedValue(rules, "SAC6", materialId, "MATERIAL", "304", ref sortOrder, now);

            AddAllowedValue(rules, "SAC6", strengthId, "STRENGTH", "4.6", ref sortOrder, now);
            AddAllowedValue(rules, "SAC6", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);

            AddAllowedValue(rules, "SAC6", standardId, "STANDARD", "DIN 933", ref sortOrder, now);
            AddAllMetrics(rules, "SAC6", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAC6", lengthId, ref sortOrder, now);
            // ========== SAD SERİSİ ==========

            // SAD0: HEAD_TYPE + STANDARD + METRIC + LENGTH
            AddAllowedValue(rules, "SAD0", headTypeId, "HEAD_TYPE", "AKB", ref sortOrder, now);
            AddAllowedValue(rules, "SAD0", headTypeId, "HEAD_TYPE", "SB", ref sortOrder, now);
            AddAllowedValue(rules, "SAD0", headTypeId, "HEAD_TYPE", "HB", ref sortOrder, now);

            AddAllowedValue(rules, "SAD0", standardId, "STANDARD", "ASTM A193", ref sortOrder, now);
            AddAllowedUNCMetrics(rules, "SAD0", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAD0", lengthId, ref sortOrder, now);

            // SAD1: HEAD_TYPE + STANDARD + METRIC + LENGTH
            AddAllowedValue(rules, "SAD1", headTypeId, "HEAD_TYPE", "AKB", ref sortOrder, now);
            AddAllowedValue(rules, "SAD1", headTypeId, "HEAD_TYPE", "SB", ref sortOrder, now);
            AddAllowedValue(rules, "SAD1", headTypeId, "HEAD_TYPE", "HB", ref sortOrder, now);

            AddAllowedValue(rules, "SAD1", standardId, "STANDARD", "ASTM A320", ref sortOrder, now);
            AddAllowedUNCMetrics(rules, "SAD1", metricId, ref sortOrder, now);
            AddAllLengths(rules, "SAD1", lengthId, ref sortOrder, now);

            // ========== SAE SERİSİ ==========
            for (int i = 0; i <= 8; i++)
            {
                var productCode = $"SAE{i}";

                AddAllowedValue(rules, productCode, materialId, "MATERIAL", "KARBON", ref sortOrder, now);
                AddAllowedValue(rules, productCode, materialId, "MATERIAL", "304", ref sortOrder, now);

                AddAllowedValue(rules, productCode, strengthId, "STRENGTH", "4.6", ref sortOrder, now);
                AddAllowedValue(rules, productCode, strengthId, "STRENGTH", "8.8", ref sortOrder, now);
                AddAllowedValue(rules, productCode, strengthId, "STRENGTH", "A2-70", ref sortOrder, now);

                AddAllowedValue(rules, productCode, standardId, "STANDARD", "DIN 933", ref sortOrder, now);
                AddAllowedValue(rules, productCode, standardId, "STANDARD", "ISO 4017", ref sortOrder, now);

                AddAllowedValue(rules, productCode, headTypeId, "HEAD_TYPE", "AKB", ref sortOrder, now);
                AddAllowedValue(rules, productCode, headTypeId, "HEAD_TYPE", "SB", ref sortOrder, now);
                AddAllowedValue(rules, productCode, headTypeId, "HEAD_TYPE", "HB", ref sortOrder, now);

                AddAllMetrics(rules, productCode, metricId, ref sortOrder, now);
                AddAllLengths(rules, productCode, lengthId, ref sortOrder, now);
            }

            builder.HasData(rules);
        }

        // ========== HELPER METHODS ==========

        private void AddAllowedValue(
            List<SFeatureValueRule> rules,
            string productCode,
            Guid featureId,
            string featureName,
            string valueCode,
            ref int sortOrder,
            DateTime now)
        {
            var productId = SeedId.From($"SProduct:SA:{productCode}");
            var valueId = SeedId.From($"SFeatureValue:{featureName}:{valueCode}");

            rules.Add(new SFeatureValueRule
            {
                Id = SeedId.From($"SFeatureValueRule:{productCode}:{featureName}:{valueCode}"),
                SProductId = productId,
                SFeatureId = featureId,
                SFeatureValueId = valueId,
                SortOrder = sortOrder++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });
        }

        private void AddAllMetrics(
            List<SFeatureValueRule> rules,
            string productCode,
            Guid metricId,
            ref int sortOrder,
            DateTime now)
        {
            // Not: Geniş metrik listesi runtime sync servisinde rule tablosuna yazılır.
            var metrics = new[] { "M3", "M4", "M5", "M6", "M8", "M10", "M12", "M14", "M16", "M18", "M20", "M22", "M24", "M27", "M30", "M33", "M36" };
            foreach (var metric in metrics)
            {
                AddAllowedValue(rules, productCode, metricId, "METRIC", metric, ref sortOrder, now);
            }
        }

        private void AddAllowedUNCMetrics(
            List<SFeatureValueRule> rules,
            string productCode,
            Guid metricId,
            ref int sortOrder,
            DateTime now)
        {
            var metrics = new[] { "1/4", "5/16", "3/8", "1/2", "5/8", "3/4", "7/8", "1" };
            foreach (var metric in metrics)
            {
                AddAllowedValue(rules, productCode, metricId, "METRIC", metric, ref sortOrder, now);
            }
        }

        private void AddAllLengths(
            List<SFeatureValueRule> rules,
            string productCode,
            Guid lengthId,
            ref int sortOrder,
            DateTime now)
        {
            // Not: Geniş length listesi runtime sync servisinde rule tablosuna yazılır.
            var lengths = new[] { 10, 12, 16, 20, 25, 30, 35, 40, 45, 50, 60, 70, 80, 90, 100, 120, 150, 200, 250, 300 };
            foreach (var length in lengths)
            {
                AddAllowedValue(rules, productCode, lengthId, "LENGTH", $"{length}", ref sortOrder, now);
            }
        }
    }
}
