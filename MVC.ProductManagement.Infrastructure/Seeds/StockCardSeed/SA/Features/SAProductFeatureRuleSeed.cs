using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SA.Features
{
    /// <summary>
    /// ✅ ESKİ SİSTEME UYGUN: PRODUCT_TYPE, HEAD_TYPE, METRIC kullanılıyor
    /// Prefix bazlı feature kuralları (sabit/dinamik ayrımı)
    /// </summary>
    public class SAProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
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

            var rules = new List<SProductFeatureRule>();

            // ========== SAA SERİSİ ==========

            // SAA0: CİVATA AKB 8.8
            AddRule(rules, "SAA0", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA0", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA0", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAA0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA0", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAA0", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAA0", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA0", lengthId, "LENGTH", false, null, now);

            // SAA1: CİVATA AKB 10.9
            AddRule(rules, "SAA1", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA1", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA1", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SAA1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA1", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAA1", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAA1", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA1", lengthId, "LENGTH", false, null, now);

            // SAA2: CİVATA AKB 12.9
            AddRule(rules, "SAA2", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA2", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA2", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SAA2", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA2", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAA2", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAA2", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA2", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA2", lengthId, "LENGTH", false, null, now);

            // SAA3: CİVATA AKB SAPKALI 8.8
            AddRule(rules, "SAA3", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA3", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA3", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAA3", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA3", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAA3", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA3", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAA3", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA3", lengthId, "LENGTH", false, null, now);

            // SAA4: CİVATA AKB SAPKALI 10.9
            AddRule(rules, "SAA4", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA4", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA4", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SAA4", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA4", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAA4", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAA4", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA4", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA4", lengthId, "LENGTH", false, null, now);

            // SAA5: CİVATA AKB SAPKALI 12.9
            AddRule(rules, "SAA5", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA5", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA5", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SAA5", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA5", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAA5", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAA5", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA5", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA5", lengthId, "LENGTH", false, null, now);

            // SAA6: CİVATA AKB CROM
            AddRule(rules, "SAA6", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA6", headTypeId, "HEAD_TYPE", true, "AKB", now);
            AddRule(rules, "SAA6", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA6", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA6", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAA6", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAA6", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAA6", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA6", lengthId, "LENGTH", false, null, now);

            // SAA7: CİVATA SB İNBUS 8.8
            AddRule(rules, "SAA7", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA7", headTypeId, "HEAD_TYPE", true, "SB", now);
            AddRule(rules, "SAA7", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAA7", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA7", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAA7", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA7", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAA7", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA7", lengthId, "LENGTH", false, null, now);

            // SAA8: CİVATA SB İNBUS 10.9
            AddRule(rules, "SAA8", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA8", headTypeId, "HEAD_TYPE", true, "SB", now);
            AddRule(rules, "SAA8", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SAA8", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA8", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAA8", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAA8", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA8", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA8", lengthId, "LENGTH", false, null, now);

            // SAA9: CİVATA SB İNBUS 12.9
            AddRule(rules, "SAA9", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAA9", headTypeId, "HEAD_TYPE", true, "SB", now);
            AddRule(rules, "SAA9", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SAA9", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAA9", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAA9", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAA9", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAA9", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAA9", lengthId, "LENGTH", false, null, now);

            // ========== SAB SERİSİ ==========

            // SAB0: CİVATA SB TORNAVİDA YARIKLI 8.8
            AddRule(rules, "SAB0", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB0", headTypeId, "HEAD_TYPE", true, "SB", now);
            AddRule(rules, "SAB0", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAB0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB0", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAB0", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAB0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB0", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB0", lengthId, "LENGTH", false, null, now);

            // SAB1: CİVATA SB YILDIZ KANALLI 8.8
            AddRule(rules, "SAB1", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB1", headTypeId, "HEAD_TYPE", true, "SB", now);
            AddRule(rules, "SAB1", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAB1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB1", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAB1", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAB1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB1", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB1", lengthId, "LENGTH", false, null, now);

            // SAB2: CİVATA SB İNBUS CROM
            AddRule(rules, "SAB2", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB2", headTypeId, "HEAD_TYPE", true, "SB", now);
            AddRule(rules, "SAB2", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB2", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB2", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAB2", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAB2", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAB2", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB2", lengthId, "LENGTH", false, null, now);

            // SAB3: CİVATA HB İNBUS 8.8
            AddRule(rules, "SAB3", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB3", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB3", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAB3", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB3", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAB3", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAB3", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB3", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB3", lengthId, "LENGTH", false, null, now);

            // SAB4: CİVATA HB İNBUS 10.9
            AddRule(rules, "SAB4", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB4", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB4", strengthId, "STRENGTH", true, "10.9", now);
            AddRule(rules, "SAB4", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB4", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAB4", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAB4", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB4", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB4", lengthId, "LENGTH", false, null, now);

            // SAB5: CİVATA HB İNBUS 12.9
            AddRule(rules, "SAB5", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB5", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB5", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SAB5", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB5", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAB5", coatingId, "COATING", true, "SIYAH OKSIT", now);
            AddRule(rules, "SAB5", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB5", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB5", lengthId, "LENGTH", false, null, now);

            // SAB6: CİVATA HB TORNAVİDA YARIKLI 8.8
            AddRule(rules, "SAB6", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB6", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB6", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAB6", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB6", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAB6", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB6", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAB6", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB6", lengthId, "LENGTH", false, null, now);

            // SAB7: CİVATA HB YILDIZ KANALLI 8.8
            AddRule(rules, "SAB7", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB7", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB7", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAB7", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB7", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAB7", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB7", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAB7", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB7", lengthId, "LENGTH", false, null, now);

            // SAB8: CİVATA HB İNBUS CROM
            AddRule(rules, "SAB8", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB8", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB8", strengthId, "STRENGTH", true, "12.9", now);
            AddRule(rules, "SAB8", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB8", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAB8", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB8", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAB8", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB8", lengthId, "LENGTH", false, null, now);

            // SAB9: CİVATA HB YILDIZ KANALLI CROM
            AddRule(rules, "SAB9", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAB9", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAB9", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAB9", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAB9", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAB9", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAB9", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAB9", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAB9", lengthId, "LENGTH", false, null, now);

            // ========== SAC SERİSİ ==========

            // SAC0: CİVATA HB SAC VİDASI/AKILLI VİDA CROM
            AddRule(rules, "SAC0", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC0", headTypeId, "HEAD_TYPE", true, "HB", now);
            AddRule(rules, "SAC0", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC0", materialId, "MATERIAL", true, "304", now);
            AddRule(rules, "SAC0", coatingId, "COATING", true, "-", now);
            AddRule(rules, "SAC0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC0", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAC0", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC0", lengthId, "LENGTH", false, null, now);

            // SAC1: CİVATA MB DUZ 8.8
            AddRule(rules, "SAC1", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC1", headTypeId, "HEAD_TYPE", true, "MB", now);
            AddRule(rules, "SAC1", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAC1", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC1", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAC1", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAC1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC1", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC1", lengthId, "LENGTH", false, null, now);

            // SAC2: CİVATA MB TORNAVİDA YARIKLI 8.8
            AddRule(rules, "SAC2", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC2", headTypeId, "HEAD_TYPE", true, "MB", now);
            AddRule(rules, "SAC2", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAC2", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC2", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAC2", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAC2", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC2", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC2", lengthId, "LENGTH", false, null, now);

            // SAC3: CİVATA MB YILDIZ KANALLI 8.8
            AddRule(rules, "SAC3", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC3", headTypeId, "HEAD_TYPE", true, "MB", now);
            AddRule(rules, "SAC3", strengthId, "STRENGTH", true, "8.8", now);
            AddRule(rules, "SAC3", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC3", materialId, "MATERIAL", true, "KARBON", now);
            AddRule(rules, "SAC3", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAC3", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC3", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC3", lengthId, "LENGTH", false, null, now);

            // SAC4: CİVATA MB İNBUS CROM
            AddRule(rules, "SAC4", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC4", headTypeId, "HEAD_TYPE", true, "MB", now);
            AddRule(rules, "SAC4", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC4", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC4", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAC4", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAC4", coatingId, "COATING", false, null, now);
            AddRule(rules, "SAC4", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC4", lengthId, "LENGTH", false, null, now);

            // SAC5: CİVATA MB SAC VİDASI/AKILLI VİDA CROM
            AddRule(rules, "SAC5", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC5", headTypeId, "HEAD_TYPE", true, "MB", now);
            AddRule(rules, "SAC5", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC5", materialId, "MATERIAL", true, "304", now);
            AddRule(rules, "SAC5", coatingId, "COATING", true, "-", now);
            AddRule(rules, "SAC5", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC5", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAC5", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC5", lengthId, "LENGTH", false, null, now);

            // SAC6: CİVATA KB (KELEBEK BASLI)
            AddRule(rules, "SAC6", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAC6", headTypeId, "HEAD_TYPE", true, "KB", now);
            AddRule(rules, "SAC6", threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
            AddRule(rules, "SAC6", coatingId, "COATING", true, "CINKO", now);
            AddRule(rules, "SAC6", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAC6", materialId, "MATERIAL", false, null, now);
            AddRule(rules, "SAC6", strengthId, "STRENGTH", false, null, now);
            AddRule(rules, "SAC6", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAC6", lengthId, "LENGTH", false, null, now);

            // ========== SAD SERİSİ (ASTM) ==========

            // SAD0: CİVATA ASTM A193 B7
            AddRule(rules, "SAD0", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAD0", strengthId, "STRENGTH", true, "B7", now);
            AddRule(rules, "SAD0", threadSystemId, "THREAD_SYSTEM", true, "UNC", now);
            AddRule(rules, "SAD0", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAD0", coatingId, "COATING", true, "-", now);
            AddRule(rules, "SAD0", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAD0", headTypeId, "HEAD_TYPE", false, null, now);
            AddRule(rules, "SAD0", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAD0", lengthId, "LENGTH", false, null, now);

            // SAD1: CİVATA ASTM A320 L7
            AddRule(rules, "SAD1", productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
            AddRule(rules, "SAD1", strengthId, "STRENGTH", true, "L7", now);
            AddRule(rules, "SAD1", threadSystemId, "THREAD_SYSTEM", true, "UNC", now);
            AddRule(rules, "SAD1", materialId, "MATERIAL", true, "ALAŞIMLI", now);
            AddRule(rules, "SAD1", coatingId, "COATING", true, "-", now);
            AddRule(rules, "SAD1", standardId, "STANDARD", false, null, now);
            AddRule(rules, "SAD1", headTypeId, "HEAD_TYPE", false, null, now);
            AddRule(rules, "SAD1", metricId, "METRIC", false, null, now);
            AddRule(rules, "SAD1", lengthId, "LENGTH", false, null, now);

            // ========== SAE SERİSİ ==========

            // SAE0-SAE8: Basitleştirilmiş kurallar
            for (int i = 0; i <= 8; i++)
            {
                var productCode = $"SAE{i}";
                AddRule(rules, productCode, productTypeId, "PRODUCT_TYPE", true, "CIVATA", now);
                AddRule(rules, productCode, threadSystemId, "THREAD_SYSTEM", true, "METRIK", now);
                AddRule(rules, productCode, coatingId, "COATING", true, "CINKO", now);
                AddRule(rules, productCode, standardId, "STANDARD", false, null, now);
                AddRule(rules, productCode, headTypeId, "HEAD_TYPE", false, null, now);
                AddRule(rules, productCode, materialId, "MATERIAL", false, null, now);
                AddRule(rules, productCode, strengthId, "STRENGTH", false, null, now);
                AddRule(rules, productCode, metricId, "METRIC", false, null, now);
                AddRule(rules, productCode, lengthId, "LENGTH", false, null, now);
            }

            builder.HasData(rules);
        }

        /// <summary>
        /// Helper: Tek bir kural ekle
        /// </summary>
        private void AddRule(
            List<SProductFeatureRule> rules,
            string productCode,
            Guid featureId,
            string featureName,
            bool isFixed,
            string? fixedValueCode,
            DateTime now)
        {
            var productId = SeedId.From($"SProduct:SA:{productCode}");

            rules.Add(new SProductFeatureRule
            {
                Id = SeedId.From($"SProductFeatureRule:{productCode}:{featureName}"),
                SProductId = productId,
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