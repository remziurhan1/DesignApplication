using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA.Features
{
    /// <summary>
    /// ✅ ESKİ SİSTEME UYGUN: Feature değerleri arası bağımlılık kuralları
    /// Örnek: MATERIAL=304 → COATING="-" (REQUIRED)
    /// Örnek: MATERIAL=304 → STRENGTH sadece A2-70, A4-80 (REQUIRED)
    /// </summary>
    public class SAFeatureValueDependencySeed : IEntityTypeConfiguration<SFeatureValueDependency>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueDependency> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var materialId = SeedId.From("SFeature:MATERIAL");
            var strengthId = SeedId.From("SFeature:STRENGTH");
            var coatingId = SeedId.From("SFeature:COATING");

            var rules = new List<SFeatureValueDependency>();

            // ========== GLOBAL KURALLAR (TÜM ÜRÜNLER İÇİN) ==========

            // 1. MATERIAL = 304 → COATING = "-" (ZORUNLU)
            AddDependency(rules, null, materialId, "MATERIAL", "304", coatingId, "COATING", "-", DependencyType.REQUIRED, now);

            // 2. MATERIAL = 316 → COATING = "-" (ZORUNLU)
            AddDependency(rules, null, materialId, "MATERIAL", "316", coatingId, "COATING", "-", DependencyType.REQUIRED, now);

            // 3. MATERIAL = 316L → COATING = "-" (ZORUNLU)
            AddDependency(rules, null, materialId, "MATERIAL", "316L", coatingId, "COATING", "-", DependencyType.REQUIRED, now);

            // 4. MATERIAL = 304 → STRENGTH = A2-70 (ZORUNLU)
            AddDependency(rules, null, materialId, "MATERIAL", "304", strengthId, "STRENGTH", "A2-70", DependencyType.REQUIRED, now);

            // 5. MATERIAL = 316 → STRENGTH = A4-80 (ZORUNLU)
            AddDependency(rules, null, materialId, "MATERIAL", "316", strengthId, "STRENGTH", "A4-80", DependencyType.REQUIRED, now);

            // 6. MATERIAL = 316L → STRENGTH = A4-80 (ZORUNLU)
            AddDependency(rules, null, materialId, "MATERIAL", "316L", strengthId, "STRENGTH", "A4-80", DependencyType.REQUIRED, now);

            // 7. STRENGTH = 12.9 → COATING = SIYAH OKSIT (ZORUNLU)
            AddDependency(rules, null, strengthId, "STRENGTH", "12.9", coatingId, "COATING", "SIYAH OKSIT", DependencyType.REQUIRED, now);

            // 8. MATERIAL = KARBON → COATING = CINKO (YASAK DEĞİL, ALLOWED)
            AddDependency(rules, null, materialId, "MATERIAL", "KARBON", coatingId, "COATING", "CINKO", DependencyType.ALLOWED, now);

            // 9. MATERIAL = KARBON → COATING = "-" (ALLOWED)
            AddDependency(rules, null, materialId, "MATERIAL", "KARBON", coatingId, "COATING", "-", DependencyType.ALLOWED, now);

            // 10. MATERIAL = ALAŞIMLI → COATING = SIYAH OKSIT (ALLOWED)
            AddDependency(rules, null, materialId, "MATERIAL", "ALAŞIMLI", coatingId, "COATING", "SIYAH OKSIT", DependencyType.ALLOWED, now);

            // 11. MATERIAL = ALAŞIMLI → COATING = "-" (ALLOWED)
            AddDependency(rules, null, materialId, "MATERIAL", "ALAŞIMLI", coatingId, "COATING", "-", DependencyType.ALLOWED, now);

            // ========== FORBIDDEN KURALLAR ==========

            // 12. MATERIAL = 304 → STRENGTH = 8.8 (YASAK - paslanmaz çelik mukavemet sınıfı kullanmaz)
            AddDependency(rules, null, materialId, "MATERIAL", "304", strengthId, "STRENGTH", "8.8", DependencyType.FORBIDDEN, now);

            // 13. MATERIAL = 304 → STRENGTH = 10.9 (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "304", strengthId, "STRENGTH", "10.9", DependencyType.FORBIDDEN, now);

            // 14. MATERIAL = 304 → STRENGTH = 12.9 (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "304", strengthId, "STRENGTH", "12.9", DependencyType.FORBIDDEN, now);

            // 15. MATERIAL = 316 → STRENGTH = 8.8 (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "316", strengthId, "STRENGTH", "8.8", DependencyType.FORBIDDEN, now);

            // 16. MATERIAL = 316 → STRENGTH = 10.9 (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "316", strengthId, "STRENGTH", "10.9", DependencyType.FORBIDDEN, now);

            // 17. MATERIAL = 316 → STRENGTH = 12.9 (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "316", strengthId, "STRENGTH", "12.9", DependencyType.FORBIDDEN, now);

            // 18. MATERIAL = 304 → COATING = CINKO (YASAK - paslanmaz çeliğe çinko kaplanmaz)
            AddDependency(rules, null, materialId, "MATERIAL", "304", coatingId, "COATING", "CINKO", DependencyType.FORBIDDEN, now);

            // 19. MATERIAL = 316 → COATING = CINKO (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "316", coatingId, "COATING", "CINKO", DependencyType.FORBIDDEN, now);

            // 20. MATERIAL = 304 → COATING = SIYAH OKSIT (YASAK)
            AddDependency(rules, null, materialId, "MATERIAL", "304", coatingId, "COATING", "SIYAH OKSIT", DependencyType.FORBIDDEN, now);

            builder.HasData(rules);
        }

        // ========== HELPER METHOD ==========

        private void AddDependency(
            List<SFeatureValueDependency> rules,
            string? productCode,
            Guid sourceFeatureId,
            string sourceFeatureName,
            string sourceValueCode,
            Guid targetFeatureId,
            string targetFeatureName,
            string targetValueCode,
            DependencyType type,
            DateTime now)
        {
            var productId = productCode != null ? (Guid?)SeedId.From($"SProduct:SA:{productCode}") : null;

            var idSuffix = productCode != null
                ? $"{productCode}:{sourceFeatureName}:{sourceValueCode}:{targetFeatureName}:{targetValueCode}"
                : $"GLOBAL:{sourceFeatureName}:{sourceValueCode}:{targetFeatureName}:{targetValueCode}";

            rules.Add(new SFeatureValueDependency
            {
                Id = SeedId.From($"SFeatureValueDependency:{idSuffix}"),
                SProductId = productId,
                SourceFeatureId = sourceFeatureId,
                SourceValueId = SeedId.From($"SFeatureValue:{sourceFeatureName}:{sourceValueCode}"),
                TargetFeatureId = targetFeatureId,
                TargetValueId = SeedId.From($"SFeatureValue:{targetFeatureName}:{targetValueCode}"),
                Type = type,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });
        }
    }
}