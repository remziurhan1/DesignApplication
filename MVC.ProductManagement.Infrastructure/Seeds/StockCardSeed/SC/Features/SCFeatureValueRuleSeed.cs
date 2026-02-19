using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC.Features
{
    public class SCFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var washerTypeId = SeedId.From("SFeature:WASHER_TYPE");
            var materialId = SeedId.From("SFeature:SC_MATERIAL");
            var standardId = SeedId.From("SFeature:SC_STANDARD");
            var metricId = SeedId.From("SFeature:SC_METRIC");
            var coatingId = SeedId.From("SFeature:SC_COATING");

            var rules = new List<SFeatureValueRule>();
            int sortOrder = 0;

            var allMetrics = new[] { "M6", "M8", "M10", "M12", "M16", "M20", "M24", "M27", "M30", "M36" };

            // ===== SCA0: DÜZ ÇELİK =====
            // Kaplama dinamik
            AddValue(rules, "SCA0", coatingId, "SC_COATING", "Doğal (Kaplamasız)", ref sortOrder, now);
            AddValue(rules, "SCA0", coatingId, "SC_COATING", "Çinko Kaplama", ref sortOrder, now);
            AddValue(rules, "SCA0", coatingId, "SC_COATING", "Elektro Galvaniz", ref sortOrder, now);
            // Standart dinamik
            AddValue(rules, "SCA0", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA0", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddValue(rules, "SCA0", standardId, "SC_STANDARD", "ISO 7090", ref sortOrder, now);
            // Metrik
            AddMetrics(rules, "SCA0", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA1: DÜZ ALÜMİNYUM =====
            AddValue(rules, "SCA1", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA1", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddMetrics(rules, "SCA1", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA2: DÜZ BAKIR =====
            AddValue(rules, "SCA2", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA2", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddMetrics(rules, "SCA2", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA3: DÜZ CROM =====
            // Malzeme dinamik
            AddValue(rules, "SCA3", materialId, "SC_MATERIAL", "Paslanmaz Çelik AISI 304", ref sortOrder, now);
            AddValue(rules, "SCA3", materialId, "SC_MATERIAL", "Paslanmaz Çelik AISI 316", ref sortOrder, now);
            AddValue(rules, "SCA3", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA3", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddValue(rules, "SCA3", standardId, "SC_STANDARD", "ISO 7090", ref sortOrder, now);
            AddMetrics(rules, "SCA3", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA4: YAYLI ÇELİK =====
            AddValue(rules, "SCA4", coatingId, "SC_COATING", "Doğal (Kaplamasız)", ref sortOrder, now);
            AddValue(rules, "SCA4", coatingId, "SC_COATING", "Çinko Kaplama", ref sortOrder, now);
            AddValue(rules, "SCA4", coatingId, "SC_COATING", "Elektro Galvaniz", ref sortOrder, now);
            AddMetrics(rules, "SCA4", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA5: YAYLI CROM =====
            AddValue(rules, "SCA5", materialId, "SC_MATERIAL", "Paslanmaz Çelik AISI 304", ref sortOrder, now);
            AddValue(rules, "SCA5", materialId, "SC_MATERIAL", "Paslanmaz Çelik AISI 316", ref sortOrder, now);
            AddMetrics(rules, "SCA5", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA6: TIRTIRLI ÇELİK =====
            AddValue(rules, "SCA6", coatingId, "SC_COATING", "Doğal (Kaplamasız)", ref sortOrder, now);
            AddValue(rules, "SCA6", coatingId, "SC_COATING", "Çinko Kaplama", ref sortOrder, now);
            AddValue(rules, "SCA6", coatingId, "SC_COATING", "Elektro Galvaniz", ref sortOrder, now);
            AddValue(rules, "SCA6", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA6", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddMetrics(rules, "SCA6", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA7: ÇANAK ÇELİK =====
            AddValue(rules, "SCA7", coatingId, "SC_COATING", "Doğal (Kaplamasız)", ref sortOrder, now);
            AddValue(rules, "SCA7", coatingId, "SC_COATING", "Çinko Kaplama", ref sortOrder, now);
            AddValue(rules, "SCA7", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA7", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddMetrics(rules, "SCA7", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA8: GENİŞ ÇELİK =====
            AddValue(rules, "SCA8", coatingId, "SC_COATING", "Doğal (Kaplamasız)", ref sortOrder, now);
            AddValue(rules, "SCA8", coatingId, "SC_COATING", "Çinko Kaplama", ref sortOrder, now);
            AddValue(rules, "SCA8", coatingId, "SC_COATING", "Elektro Galvaniz", ref sortOrder, now);
            AddMetrics(rules, "SCA8", metricId, allMetrics, ref sortOrder, now);

            // ===== SCA9: SQUARE TAPERED =====
            AddValue(rules, "SCA9", coatingId, "SC_COATING", "Doğal (Kaplamasız)", ref sortOrder, now);
            AddValue(rules, "SCA9", coatingId, "SC_COATING", "Çinko Kaplama", ref sortOrder, now);
            AddValue(rules, "SCA9", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCA9", standardId, "SC_STANDARD", "ASTM F436", ref sortOrder, now);
            AddMetrics(rules, "SCA9", metricId, allMetrics, ref sortOrder, now);

            // ===== SCB0: TIRTIRLI PASLANMAZ =====
            AddValue(rules, "SCB0", materialId, "SC_MATERIAL", "Paslanmaz Çelik AISI 304", ref sortOrder, now);
            AddValue(rules, "SCB0", materialId, "SC_MATERIAL", "Paslanmaz Çelik AISI 316", ref sortOrder, now);
            AddValue(rules, "SCB0", standardId, "SC_STANDARD", "DIN 125", ref sortOrder, now);
            AddValue(rules, "SCB0", standardId, "SC_STANDARD", "ISO 7089", ref sortOrder, now);
            AddMetrics(rules, "SCB0", metricId, allMetrics, ref sortOrder, now);

            // ===== SCE1: ÖZEL GRUP =====
            // Tüm değerler mevcut
            var allWasherTypes = new[]
            {
                "Düz Çelik","Düz Alüminyum","Düz Bakır","Düz Crom","Yaylı Çelik",
                "Yaylı Crom","Tırtırlı Çelik","Çanak Çelik","Geniş Çelik",
                "Özel Grup (Süper, EPDM/II)","Square Tapered","Tırtırlı Paslanmaz"
            };
            foreach (var wt in allWasherTypes)
                AddValue(rules, "SCE1", washerTypeId, "WASHER_TYPE", wt, ref sortOrder, now);

            var allMaterials = new[]
            {
                "Karbon Çelik","Alüminyum","Bakır",
                "Paslanmaz Çelik AISI 304","Paslanmaz Çelik AISI 316","Pirinç"
            };
            foreach (var m in allMaterials)
                AddValue(rules, "SCE1", materialId, "SC_MATERIAL", m, ref sortOrder, now);

            var allCoatings = new[]
            {
                "Doğal (Kaplamasız)","Çinko Kaplama","Krom Kaplama","Paslanmaz","Elektro Galvaniz"
            };
            foreach (var c in allCoatings)
                AddValue(rules, "SCE1", coatingId, "SC_COATING", c, ref sortOrder, now);

            var allStandards = new[]
            {
                "DIN 125","DIN 127","DIN 9021","ISO 7089","ISO 7090","ASTM F436"
            };
            foreach (var s in allStandards)
                AddValue(rules, "SCE1", standardId, "SC_STANDARD", s, ref sortOrder, now);

            AddMetrics(rules, "SCE1", metricId, allMetrics, ref sortOrder, now);

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
                Id = SeedId.From($"SFeatureValueRule:SC:{productCode}:{featureName}:{valueCode}"),
                SProductId = SeedId.From($"SProduct:SC:{productCode}"),
                SFeatureId = featureId,
                SFeatureValueId = SeedId.From($"SFeatureValue:{featureName}:{valueCode}"),
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
            string[] metrics,
            ref int sortOrder,
            DateTime now)
        {
            foreach (var m in metrics)
                AddValue(rules, productCode, metricId, "SC_METRIC", m, ref sortOrder, now);
        }
    }
}