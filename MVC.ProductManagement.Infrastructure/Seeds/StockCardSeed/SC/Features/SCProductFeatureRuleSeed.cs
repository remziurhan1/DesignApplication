using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SC.Features
{
    public class SCProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var washerTypeId = SeedId.From("SFeature:WASHER_TYPE");
            var materialId = SeedId.From("SFeature:SC_MATERIAL");
            var standardId = SeedId.From("SFeature:SC_STANDARD");
            var metricId = SeedId.From("SFeature:SC_METRIC");
            var coatingId = SeedId.From("SFeature:SC_COATING");

            var rules = new List<SProductFeatureRule>();

            // ===== SCA0: RONDELA DÜZ ÇELİK =====
            // Tip ve malzeme sabit, kaplama+standart+metrik dinamik
            AddRule(rules, "SCA0", washerTypeId, "WASHER_TYPE", true, "Düz Çelik", "WASHER_TYPE", now);
            AddRule(rules, "SCA0", materialId, "SC_MATERIAL", true, "Karbon Çelik", "SC_MATERIAL", now);
            AddRule(rules, "SCA0", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCA0", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA0", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA1: RONDELA DÜZ ALÜMİNYUM =====
            AddRule(rules, "SCA1", washerTypeId, "WASHER_TYPE", true, "Düz Alüminyum", "WASHER_TYPE", now);
            AddRule(rules, "SCA1", materialId, "SC_MATERIAL", true, "Alüminyum", "SC_MATERIAL", now);
            AddRule(rules, "SCA1", coatingId, "SC_COATING", true, "Doğal (Kaplamasız)", "SC_COATING", now);
            AddRule(rules, "SCA1", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA1", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA2: RONDELA DÜZ BAKIR =====
            AddRule(rules, "SCA2", washerTypeId, "WASHER_TYPE", true, "Düz Bakır", "WASHER_TYPE", now);
            AddRule(rules, "SCA2", materialId, "SC_MATERIAL", true, "Bakır", "SC_MATERIAL", now);
            AddRule(rules, "SCA2", coatingId, "SC_COATING", true, "Doğal (Kaplamasız)", "SC_COATING", now);
            AddRule(rules, "SCA2", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA2", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA3: RONDELA DÜZ CROM =====
            // Malzeme dinamik (304 veya 316)
            AddRule(rules, "SCA3", washerTypeId, "WASHER_TYPE", true, "Düz Crom", "WASHER_TYPE", now);
            AddRule(rules, "SCA3", materialId, "SC_MATERIAL", false, null, null, now);
            AddRule(rules, "SCA3", coatingId, "SC_COATING", true, "Paslanmaz", "SC_COATING", now);
            AddRule(rules, "SCA3", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA3", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA4: RONDELA YAYLI ÇELİK =====
            // Standart sabit DIN 127
            AddRule(rules, "SCA4", washerTypeId, "WASHER_TYPE", true, "Yaylı Çelik", "WASHER_TYPE", now);
            AddRule(rules, "SCA4", materialId, "SC_MATERIAL", true, "Karbon Çelik", "SC_MATERIAL", now);
            AddRule(rules, "SCA4", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCA4", standardId, "SC_STANDARD", true, "DIN 127", "SC_STANDARD", now);
            AddRule(rules, "SCA4", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA5: RONDELA YAYLI CROM =====
            AddRule(rules, "SCA5", washerTypeId, "WASHER_TYPE", true, "Yaylı Crom", "WASHER_TYPE", now);
            AddRule(rules, "SCA5", materialId, "SC_MATERIAL", false, null, null, now);
            AddRule(rules, "SCA5", coatingId, "SC_COATING", true, "Paslanmaz", "SC_COATING", now);
            AddRule(rules, "SCA5", standardId, "SC_STANDARD", true, "DIN 127", "SC_STANDARD", now);
            AddRule(rules, "SCA5", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA6: RONDELA TIRTIRLI ÇELİK =====
            AddRule(rules, "SCA6", washerTypeId, "WASHER_TYPE", true, "Tırtırlı Çelik", "WASHER_TYPE", now);
            AddRule(rules, "SCA6", materialId, "SC_MATERIAL", true, "Karbon Çelik", "SC_MATERIAL", now);
            AddRule(rules, "SCA6", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCA6", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA6", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA7: RONDELA ÇANAK ÇELİK =====
            AddRule(rules, "SCA7", washerTypeId, "WASHER_TYPE", true, "Çanak Çelik", "WASHER_TYPE", now);
            AddRule(rules, "SCA7", materialId, "SC_MATERIAL", true, "Karbon Çelik", "SC_MATERIAL", now);
            AddRule(rules, "SCA7", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCA7", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA7", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA8: RONDELA GENİŞ ÇELİK =====
            // Standart sabit DIN 9021
            AddRule(rules, "SCA8", washerTypeId, "WASHER_TYPE", true, "Geniş Çelik", "WASHER_TYPE", now);
            AddRule(rules, "SCA8", materialId, "SC_MATERIAL", true, "Karbon Çelik", "SC_MATERIAL", now);
            AddRule(rules, "SCA8", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCA8", standardId, "SC_STANDARD", true, "DIN 9021", "SC_STANDARD", now);
            AddRule(rules, "SCA8", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCA9: RONDELA SQUARE TAPERED =====
            AddRule(rules, "SCA9", washerTypeId, "WASHER_TYPE", true, "Square Tapered", "WASHER_TYPE", now);
            AddRule(rules, "SCA9", materialId, "SC_MATERIAL", true, "Karbon Çelik", "SC_MATERIAL", now);
            AddRule(rules, "SCA9", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCA9", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCA9", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCB0: RONDELA TIRTIRLI PASLANMAZ =====
            AddRule(rules, "SCB0", washerTypeId, "WASHER_TYPE", true, "Tırtırlı Paslanmaz", "WASHER_TYPE", now);
            AddRule(rules, "SCB0", materialId, "SC_MATERIAL", false, null, null, now);
            AddRule(rules, "SCB0", coatingId, "SC_COATING", true, "Paslanmaz", "SC_COATING", now);
            AddRule(rules, "SCB0", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCB0", metricId, "SC_METRIC", false, null, null, now);

            // ===== SCE1: RONDELA ÖZEL GRUP =====
            // Hepsi dinamik
            AddRule(rules, "SCE1", washerTypeId, "WASHER_TYPE", false, null, null, now);
            AddRule(rules, "SCE1", materialId, "SC_MATERIAL", false, null, null, now);
            AddRule(rules, "SCE1", coatingId, "SC_COATING", false, null, null, now);
            AddRule(rules, "SCE1", standardId, "SC_STANDARD", false, null, null, now);
            AddRule(rules, "SCE1", metricId, "SC_METRIC", false, null, null, now);

            builder.HasData(rules);
        }

        private void AddRule(
            List<SProductFeatureRule> rules,
            string productCode,
            Guid featureId,
            string featureName,
            bool isFixed,
            string? fixedValueCode,
            string? fixedFeatureName,
            DateTime now)
        {
            rules.Add(new SProductFeatureRule
            {
                Id = SeedId.From($"SProductFeatureRule:SC:{productCode}:{featureName}"),
                SProductId = SeedId.From($"SProduct:SC:{productCode}"),
                SFeatureId = featureId,
                IsFixed = isFixed,
                FixedValueId = isFixed && fixedValueCode != null
                    ? SeedId.From($"SFeatureValue:{fixedFeatureName}:{fixedValueCode}")
                    : null,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });
        }
    }
}