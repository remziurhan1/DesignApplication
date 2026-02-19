using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.Features
{
    public class SBProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            // ✅ SA ile AYNI feature ID'leri kullan (paylaşımlı)
            var nutTypeId = SeedId.From("SFeature:NUT_TYPE");
            var materialId = SeedId.From("SFeature:MATERIAL");
            var threadSystemId = SeedId.From("SFeature:THREAD_SYSTEM");
            var standardId = SeedId.From("SFeature:STANDARD");
            var metricId = SeedId.From("SFeature:METRIC");
            var strengthId = SeedId.From("SFeature:STRENGTH");
            var coatingId = SeedId.From("SFeature:COATING");

            var rules = new List<SProductFeatureRule>();

            // ===== SBA SERİSİ =====
            // SBA0: SOMUN AKB 8.8
            AddRule(rules, "SBA0", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBA0", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SBA0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA0", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBA0", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBA0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA0", metricId, "METRIC", false, null, now);

            // SBA1: SOMUN AKB 10.9
            AddRule(rules, "SBA1", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBA1", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SBA1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA1", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBA1", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBA1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA1", metricId, "METRIC", false, null, now);

            // SBA2: SOMUN AKB 12.9
            AddRule(rules, "SBA2", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBA2", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SBA2", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA2", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBA2", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBA2", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA2", metricId, "METRIC", false, null, now);

            // SBA3: SOMUN AKB SAPKALI 8.8
            AddRule(rules, "SBA3", nutTypeId, "NUT_TYPE", true, "SAPKALI", now);
            AddRule(rules, "SBA3", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SBA3", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA3", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SBA3", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBA3", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA3", metricId, "METRIC", false, null, now);

            // SBA4: SOMUN AKB SAPKALI 10.9
            AddRule(rules, "SBA4", nutTypeId, "NUT_TYPE", true, "SAPKALI", now);
            AddRule(rules, "SBA4", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SBA4", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA4", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBA4", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBA4", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA4", metricId, "METRIC", false, null, now);

            // SBA5: SOMUN AKB SAPKALI 12.9
            AddRule(rules, "SBA5", nutTypeId, "NUT_TYPE", true, "SAPKALI", now);
            AddRule(rules, "SBA5", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SBA5", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA5", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBA5", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBA5", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA5", metricId, "METRIC", false, null, now);

            // SBA6: SOMUN AKB CROM
            AddRule(rules, "SBA6", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBA6", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA6", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBA6", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBA6", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBA6", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA6", metricId, "METRIC", false, null, now);

            // SBA7: SOMUN AKB SAPKALI CROM
            AddRule(rules, "SBA7", nutTypeId, "NUT_TYPE", true, "SAPKALI", now);
            AddRule(rules, "SBA7", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA7", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBA7", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBA7", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBA7", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA7", metricId, "METRIC", false, null, now);

            // SBA8: SOMUN AKB 8.8 FİBERLİ
            AddRule(rules, "SBA8", nutTypeId, "NUT_TYPE", true, "FIBERLI", now);
            AddRule(rules, "SBA8", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SBA8", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA8", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBA8", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBA8", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA8", metricId, "METRIC", false, null, now);

            // SBA9: SOMUN AKB 10.9 FİBERLİ
            AddRule(rules, "SBA9", nutTypeId, "NUT_TYPE", true, "FIBERLI", now);
            AddRule(rules, "SBA9", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SBA9", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBA9", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBA9", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBA9", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBA9", metricId, "METRIC", false, null, now);

            // ===== SBB SERİSİ =====
            // SBB0: SOMUN AKB 12.9 FİBERLİ
            AddRule(rules, "SBB0", nutTypeId, "NUT_TYPE", true, "FIBERLI", now);
            AddRule(rules, "SBB0", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SBB0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB0", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBB0", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBB0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB0", metricId, "METRIC", false, null, now);

            // SBB1: SOMUN AKB FİBERLİ CROM
            AddRule(rules, "SBB1", nutTypeId, "NUT_TYPE", true, "FIBERLI", now);
            AddRule(rules, "SBB1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB1", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBB1", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBB1", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBB1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB1", metricId, "METRIC", false, null, now);

            // SBB2: SOMUN AKB KONTRALI 8.8
            AddRule(rules, "SBB2", nutTypeId, "NUT_TYPE", true, "KONTRALI", now);
            AddRule(rules, "SBB2", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SBB2", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB2", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SBB2", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBB2", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB2", metricId, "METRIC", false, null, now);

            // SBB3: SOMUN AKB KONTRALI 10.9
            AddRule(rules, "SBB3", nutTypeId, "NUT_TYPE", true, "KONTRALI", now);
            AddRule(rules, "SBB3", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SBB3", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB3", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBB3", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBB3", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB3", metricId, "METRIC", false, null, now);

            // SBB4: SOMUN AKB KONTRALI 12.9
            AddRule(rules, "SBB4", nutTypeId, "NUT_TYPE", true, "KONTRALI", now);
            AddRule(rules, "SBB4", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SBB4", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB4", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBB4", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBB4", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB4", metricId, "METRIC", false, null, now);

            // SBB5: SOMUN AKB KONTRALI CROM
            AddRule(rules, "SBB5", nutTypeId, "NUT_TYPE", true, "KONTRALI", now);
            AddRule(rules, "SBB5", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB5", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBB5", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBB5", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBB5", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB5", metricId, "METRIC", false, null, now);

            // SBB6: SOMUN AKB KAYNAK 8.8
            AddRule(rules, "SBB6", nutTypeId, "NUT_TYPE", true, "KAYNAK", now);
            AddRule(rules, "SBB6", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SBB6", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB6", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SBB6", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SBB6", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB6", metricId, "METRIC", false, null, now);

            // SBB7: SOMUN AKB KAYNAK 10.9
            AddRule(rules, "SBB7", nutTypeId, "NUT_TYPE", true, "KAYNAK", now);
            AddRule(rules, "SBB7", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SBB7", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB7", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBB7", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBB7", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB7", metricId, "METRIC", false, null, now);

            // SBB8: SOMUN AKB KAYNAK CROM
            AddRule(rules, "SBB8", nutTypeId, "NUT_TYPE", true, "KAYNAK", now);
            AddRule(rules, "SBB8", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB8", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBB8", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBB8", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBB8", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB8", metricId, "METRIC", false, null, now);

            // SBB9: SOMUN AKB TACLI 8.8
            AddRule(rules, "SBB9", nutTypeId, "NUT_TYPE", true, "TACLI", now);
            AddRule(rules, "SBB9", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SBB9", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBB9", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SBB9", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBB9", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBB9", metricId, "METRIC", false, null, now);

            // ===== SBC SERİSİ =====
            // SBC0: SOMUN AKB TACLI 10.9
            AddRule(rules, "SBC0", nutTypeId, "NUT_TYPE", true, "TACLI", now);
            AddRule(rules, "SBC0", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SBC0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBC0", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SBC0", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SBC0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBC0", metricId, "METRIC", false, null, now);

            // SBC1: SOMUN AKB TACLI CROM
            AddRule(rules, "SBC1", nutTypeId, "NUT_TYPE", true, "TACLI", now);
            AddRule(rules, "SBC1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBC1", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBC1", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBC1", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBC1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBC1", metricId, "METRIC", false, null, now);

            // SBC2: SOMUN HALKALI
            AddRule(rules, "SBC2", nutTypeId, "NUT_TYPE", true, "HALKALI", now);
            AddRule(rules, "SBC2", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBC2", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBC2", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBC2", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBC2", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBC2", metricId, "METRIC", false, null, now);

            // SBC3: SOMUN KELEBEK
            AddRule(rules, "SBC3", nutTypeId, "NUT_TYPE", true, "KELEBEK", now);
            AddRule(rules, "SBC3", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBC3", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBC3", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBC3", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBC3", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBC3", metricId, "METRIC", false, null, now);

            // ===== SBD SERİSİ (ASTM) =====
            // SBD0: SOMUN AKB A194 2H
            AddRule(rules, "SBD0", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBD0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBD0", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBD0", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBD0", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBD0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBD0", metricId, "METRIC", false, null, now);

            // SBD1: SOMUN AKB A194-7
            AddRule(rules, "SBD1", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBD1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SBD1", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBD1", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBD1", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBD1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBD1", metricId, "METRIC", false, null, now);

            // ===== SBE SERİSİ (ÖZEL) =====
            // SBE0: SOMUN WHITWORTH / UNC / UNF
            AddRule(rules, "SBE0", nutTypeId, "NUT_TYPE", true, "AKB", now);
            AddRule(rules, "SBE0", threadSystemId, "THREAD_SYSTEM", false, null, now);
            AddRule(rules, "SBE0", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBE0", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBE0", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBE0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBE0", metricId, "METRIC", false, null, now);

            // SBE1: SOMUN ÖZEL GRUP
            AddRule(rules, "SBE1", nutTypeId, "NUT_TYPE", false, null, now);
            AddRule(rules, "SBE1", threadSystemId, "THREAD_SYSTEM", false, null, now);
            AddRule(rules, "SBE1", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SBE1", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SBE1", coatingId, "COATING", false, null, now);
            AddRule(rules, "SBE1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SBE1", metricId, "METRIC", false, null, now);

            builder.HasData(rules);
        }

        private void AddRule(
            List<SProductFeatureRule> rules,
            string productCode,
            Guid featureId,
            string featureName,
            bool isFixed,
            string? fixedValueCode,
            DateTime now)
        {
            rules.Add(new SProductFeatureRule
            {
                Id = SeedId.From($"SProductFeatureRule:SB:{productCode}:{featureName}"),
                SProductId = SeedId.From($"SProduct:SB:{productCode}"),
                SFeatureId = featureId,
                IsFixed = isFixed,
                FixedValueId = isFixed && fixedValueCode != null
                    ? SeedId.From($"SFeatureValue:{featureName}:{fixedValueCode}")
                    : null,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });
        }
    }
}