using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.Features
{
    public class SBFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // ✅ SA ile AYNI feature ID'leri
            var materialId = SeedId.From("SFeature:MATERIAL");
            var standardId = SeedId.From("SFeature:STANDARD");
            var metricId = SeedId.From("SFeature:METRIC");
            var strengthId = SeedId.From("SFeature:STRENGTH");
            var coatingId = SeedId.From("SFeature:COATING");

            var rules = new List<SFeatureValueRule>();
            int sortOrder = 0;

            // ===== SBA0 =====
            AddValue(rules, "SBA0", materialId, "MATERIAL", "KARBON", ref sortOrder, now);
            AddValue(rules, "SBA0", materialId, "MATERIAL", "ALAŞIMLI", ref sortOrder, now);
            AddValue(rules, "SBA0", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddValue(rules, "SBA0", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA0", standardId, "STANDARD", "DIN 934", ref sortOrder, now);
            AddValue(rules, "SBA0", standardId, "STANDARD", "ISO 4032", ref sortOrder, now);
            AddMetrics(rules, "SBA0", metricId, ref sortOrder, now);

            // ===== SBA1 =====
            AddValue(rules, "SBA1", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddValue(rules, "SBA1", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA1", standardId, "STANDARD", "DIN 934", ref sortOrder, now);
            AddValue(rules, "SBA1", standardId, "STANDARD", "ISO 4032", ref sortOrder, now);
            AddMetrics(rules, "SBA1", metricId, ref sortOrder, now);

            // ===== SBA2 =====
            AddValue(rules, "SBA2", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddValue(rules, "SBA2", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA2", standardId, "STANDARD", "DIN 934", ref sortOrder, now);
            AddValue(rules, "SBA2", standardId, "STANDARD", "ISO 4032", ref sortOrder, now);
            AddMetrics(rules, "SBA2", metricId, ref sortOrder, now);

            // ===== SBA3 =====
            AddValue(rules, "SBA3", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddValue(rules, "SBA3", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA3", standardId, "STANDARD", "DIN 1587", ref sortOrder, now);
            AddMetrics(rules, "SBA3", metricId, ref sortOrder, now);

            // ===== SBA4 =====
            AddValue(rules, "SBA4", standardId, "STANDARD", "DIN 1587", ref sortOrder, now);
            AddMetrics(rules, "SBA4", metricId, ref sortOrder, now);

            // ===== SBA5 =====
            AddValue(rules, "SBA5", standardId, "STANDARD", "DIN 1587", ref sortOrder, now);
            AddMetrics(rules, "SBA5", metricId, ref sortOrder, now);

            // ===== SBA6 (CROM) =====
            AddValue(rules, "SBA6", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddValue(rules, "SBA6", materialId, "MATERIAL", "316", ref sortOrder, now);
            AddValue(rules, "SBA6", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddValue(rules, "SBA6", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);
            AddValue(rules, "SBA6", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA6", standardId, "STANDARD", "DIN 934", ref sortOrder, now);
            AddValue(rules, "SBA6", standardId, "STANDARD", "ISO 4032", ref sortOrder, now);
            AddMetrics(rules, "SBA6", metricId, ref sortOrder, now);

            // ===== SBA7 (SAPKALI CROM) =====
            AddValue(rules, "SBA7", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddValue(rules, "SBA7", materialId, "MATERIAL", "316", ref sortOrder, now);
            AddValue(rules, "SBA7", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddValue(rules, "SBA7", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);
            AddValue(rules, "SBA7", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA7", standardId, "STANDARD", "DIN 1587", ref sortOrder, now);
            AddMetrics(rules, "SBA7", metricId, ref sortOrder, now);

            // ===== SBA8 =====
            AddValue(rules, "SBA8", materialId, "MATERIAL", "KARBON", ref sortOrder, now);
            AddValue(rules, "SBA8", materialId, "MATERIAL", "ALAŞIMLI", ref sortOrder, now);
            AddValue(rules, "SBA8", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddValue(rules, "SBA8", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA8", standardId, "STANDARD", "DIN 985", ref sortOrder, now);
            AddMetrics(rules, "SBA8", metricId, ref sortOrder, now);

            // ===== SBA9 =====
            AddValue(rules, "SBA9", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddValue(rules, "SBA9", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBA9", standardId, "STANDARD", "DIN 985", ref sortOrder, now);
            AddMetrics(rules, "SBA9", metricId, ref sortOrder, now);

            // ===== SBB0 =====
            AddValue(rules, "SBB0", coatingId, "COATING", "SIYAH OKSIT", ref sortOrder, now);
            AddValue(rules, "SBB0", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBB0", standardId, "STANDARD", "DIN 985", ref sortOrder, now);
            AddMetrics(rules, "SBB0", metricId, ref sortOrder, now);

            // ===== SBB1 (FİBERLİ CROM) =====
            AddValue(rules, "SBB1", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddValue(rules, "SBB1", materialId, "MATERIAL", "316", ref sortOrder, now);
            AddValue(rules, "SBB1", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddValue(rules, "SBB1", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);
            AddValue(rules, "SBB1", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBB1", standardId, "STANDARD", "DIN 985", ref sortOrder, now);
            AddMetrics(rules, "SBB1", metricId, ref sortOrder, now);

            // ===== SBB2 =====
            AddValue(rules, "SBB2", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddValue(rules, "SBB2", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBB2", standardId, "STANDARD", "DIN 439", ref sortOrder, now);
            AddMetrics(rules, "SBB2", metricId, ref sortOrder, now);

            // ===== SBB3 =====
            AddValue(rules, "SBB3", standardId, "STANDARD", "DIN 439", ref sortOrder, now);
            AddMetrics(rules, "SBB3", metricId, ref sortOrder, now);

            // ===== SBB4 =====
            AddValue(rules, "SBB4", standardId, "STANDARD", "DIN 439", ref sortOrder, now);
            AddMetrics(rules, "SBB4", metricId, ref sortOrder, now);

            // ===== SBB5 (KONTRALI CROM) =====
            AddValue(rules, "SBB5", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddValue(rules, "SBB5", materialId, "MATERIAL", "316", ref sortOrder, now);
            AddValue(rules, "SBB5", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddValue(rules, "SBB5", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);
            AddValue(rules, "SBB5", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBB5", standardId, "STANDARD", "DIN 439", ref sortOrder, now);
            AddMetrics(rules, "SBB5", metricId, ref sortOrder, now);

            // ===== SBB6 =====
            AddValue(rules, "SBB6", standardId, "STANDARD", "DIN 929", ref sortOrder, now);
            AddMetrics(rules, "SBB6", metricId, ref sortOrder, now);

            // ===== SBB7 =====
            AddValue(rules, "SBB7", standardId, "STANDARD", "DIN 929", ref sortOrder, now);
            AddMetrics(rules, "SBB7", metricId, ref sortOrder, now);

            // ===== SBB8 (KAYNAK CROM) =====
            AddValue(rules, "SBB8", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddValue(rules, "SBB8", materialId, "MATERIAL", "316", ref sortOrder, now);
            AddValue(rules, "SBB8", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddValue(rules, "SBB8", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);
            AddValue(rules, "SBB8", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBB8", standardId, "STANDARD", "DIN 929", ref sortOrder, now);
            AddMetrics(rules, "SBB8", metricId, ref sortOrder, now);

            // ===== SBB9 =====
            AddValue(rules, "SBB9", coatingId, "COATING", "CINKO", ref sortOrder, now);
            AddValue(rules, "SBB9", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBB9", standardId, "STANDARD", "DIN 935", ref sortOrder, now);
            AddMetrics(rules, "SBB9", metricId, ref sortOrder, now);

            // ===== SBC0 =====
            AddValue(rules, "SBC0", standardId, "STANDARD", "DIN 935", ref sortOrder, now);
            AddMetrics(rules, "SBC0", metricId, ref sortOrder, now);

            // ===== SBC1 (TACLI CROM) =====
            AddValue(rules, "SBC1", materialId, "MATERIAL", "304", ref sortOrder, now);
            AddValue(rules, "SBC1", materialId, "MATERIAL", "316", ref sortOrder, now);
            AddValue(rules, "SBC1", strengthId, "STRENGTH", "A2-70", ref sortOrder, now);
            AddValue(rules, "SBC1", strengthId, "STRENGTH", "A4-80", ref sortOrder, now);
            AddValue(rules, "SBC1", coatingId, "COATING", "-", ref sortOrder, now);
            AddValue(rules, "SBC1", standardId, "STANDARD", "DIN 935", ref sortOrder, now);
            AddMetrics(rules, "SBC1", metricId, ref sortOrder, now);

            // ===== SBC2 (HALKALI) =====
            AddValue(rules, "SBC2", standardId, "STANDARD", "DIN 582", ref sortOrder, now);
            AddMetrics(rules, "SBC2", metricId, ref sortOrder, now);

            // ===== SBC3 (KELEBEK) =====
            AddValue(rules, "SBC3", standardId, "STANDARD", "DIN 315", ref sortOrder, now);
            AddMetrics(rules, "SBC3", metricId, ref sortOrder, now);

            builder.HasData(rules);
        }

        private void AddValue(
            List<SFeatureValueRule> rules,
            string productCode,
            Guid featureId,
            string featureName,
            string valueCode,
            ref int sortOrder,
            DateTime now)
        {
            rules.Add(new SFeatureValueRule
            {
                Id = SeedId.From($"SFeatureValueRule:SB:{productCode}:{featureName}:{valueCode}"),
                SProductId = SeedId.From($"SProduct:SB:{productCode}"),
                SFeatureId = featureId,
                SFeatureValueId = SeedId.From($"SFeatureValue:{featureName}:{valueCode}"), // ✅ SA value ID
                SortOrder = sortOrder++,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });
        }

        private void AddMetrics(
            List<SFeatureValueRule> rules,
            string productCode,
            Guid metricId,
            ref int sortOrder,
            DateTime now)
        {
            var metrics = new[] { "M3", "M4", "M5", "M6", "M8", "M10", "M12", "M14", "M16", "M18", "M20", "M22", "M24", "M27", "M30", "M33", "M36" };
            foreach (var m in metrics)
                AddValue(rules, productCode, metricId, "METRIC", m, ref sortOrder, now);
        }
    }
}