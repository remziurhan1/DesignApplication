using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Rules
{
    /// <summary>
    /// Tüm stok grupları (SA..SH) için yüksek değişkenlik gösteren katalog verilerini
    /// runtime'da senkronize eder. HasData migration şişmesini azaltmak için kullanılır.
    /// </summary>
    public class RuleCatalogSyncService : IRuleCatalogSyncService
    {
        private readonly AppDbContext _db;

        public RuleCatalogSyncService(AppDbContext db)
        {
            _db = db;
        }

        public async Task SyncAsync(CancellationToken cancellationToken = default)
        {
            await SyncSaAsync(cancellationToken);
            await SyncSdAsync(cancellationToken);
            await SyncSeAsync(cancellationToken);
            await SyncSfAsync(cancellationToken);
            await SyncSgAsync(cancellationToken);
            await SyncShAsync(cancellationToken);
        }

        /// <summary>
        /// SA/SB/SC: METRIC, SC_METRIC ve LENGTH feature value'larını ve eksik rule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncSaAsync(CancellationToken cancellationToken)
        {
            var saMetricFeatureId = SeedId.From("SFeature:METRIC");
            var sbMetricFeatureId = SeedId.From("SFeature:METRIC");
            var scMetricFeatureId = SeedId.From("SFeature:SC_METRIC");
            var saLengthFeatureId = SeedId.From("SFeature:LENGTH");

            var metricCodes = new List<string> { "M1.6", "M2", "M2.5" };
            metricCodes.AddRange(Enumerable.Range(3, 62).Select(x => $"M{x}")); // M3..M64

            var lengths = Enumerable.Range(1, 42).Select(x => x * 5).ToList(); // 5..210

            await EnsureFeatureValuesAsync(saMetricFeatureId, "METRIC", metricCodes, cancellationToken);
            await EnsureFeatureValuesAsync(scMetricFeatureId, "SC_METRIC", metricCodes, cancellationToken);
            await EnsureFeatureValuesAsync(saLengthFeatureId, "LENGTH", lengths.Select(x => x.ToString()).ToList(), cancellationToken);

            var headTypeFeatureId = SeedId.From("SFeature:HEAD_TYPE");
            var strengthFeatureId = SeedId.From("SFeature:STRENGTH");
            var materialFeatureId = SeedId.From("SFeature:MATERIAL");
            var coatingFeatureId = SeedId.From("SFeature:COATING");
            var threadSystemFeatureId = SeedId.From("SFeature:THREAD_SYSTEM");
            var standardFeatureId = SeedId.From("SFeature:STANDARD");

            await EnsureFeatureValuesAsync(headTypeFeatureId, "HEAD_TYPE", new List<string>
            {
                "AKB", "SAPKALI", "SB_INBUS", "SB_YARIKLI", "SB_YILDIZ",
                "HB_INBUS", "HB_YARIKLI", "HB_YILDIZ", "HB_SAC",
                "MB_DUZ", "MB_YARIKLI", "MB_YILDIZ", "MB_INBUS", "MB_SAC", "KB"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(strengthFeatureId, "STRENGTH", new List<string> { "8.8", "10.9", "12.9" }, cancellationToken);
            await EnsureFeatureValuesAsync(materialFeatureId, "MATERIAL", new List<string> { "KARBON", "ALAŞIMLI" }, cancellationToken);
            await EnsureFeatureValuesAsync(coatingFeatureId, "COATING", new List<string> { "SIYAH OKSIT", "CINKO", "GALVANIZ", "-" }, cancellationToken);
            await EnsureFeatureValuesAsync(threadSystemFeatureId, "THREAD_SYSTEM", new List<string> { "METRIK", "UNC", "UNF", "BSW" }, cancellationToken);

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var saProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // SAA0 → CİVATA AKB 8.8
                ("SAA0", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAA0", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAA0", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA0", materialFeatureId,     false, null),
                ("SAA0", coatingFeatureId,      false, null),
                ("SAA0", standardFeatureId,     false, null),
                ("SAA0", saMetricFeatureId,     false, null),
                ("SAA0", saLengthFeatureId,     false, null),
                // SAA1 → CİVATA AKB 10.9
                ("SAA1", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAA1", strengthFeatureId,     true,  FV("STRENGTH",      "10.9")),
                ("SAA1", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA1", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAA1", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAA1", standardFeatureId,     false, null),
                ("SAA1", saMetricFeatureId,     false, null),
                ("SAA1", saLengthFeatureId,     false, null),
                // SAA2 → CİVATA AKB 12.9
                ("SAA2", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAA2", strengthFeatureId,     true,  FV("STRENGTH",      "12.9")),
                ("SAA2", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA2", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAA2", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAA2", standardFeatureId,     false, null),
                ("SAA2", saMetricFeatureId,     false, null),
                ("SAA2", saLengthFeatureId,     false, null),
                // SAA3 → CİVATA AKB SAPKALI 8.8
                ("SAA3", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SAPKALI")),
                ("SAA3", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAA3", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA3", materialFeatureId,     true,  FV("MATERIAL",      "KARBON")),
                ("SAA3", coatingFeatureId,      false, null),
                ("SAA3", standardFeatureId,     false, null),
                ("SAA3", saMetricFeatureId,     false, null),
                ("SAA3", saLengthFeatureId,     false, null),
                // SAA4 → CİVATA AKB SAPKALI 10.9
                ("SAA4", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SAPKALI")),
                ("SAA4", strengthFeatureId,     true,  FV("STRENGTH",      "10.9")),
                ("SAA4", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA4", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAA4", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAA4", standardFeatureId,     false, null),
                ("SAA4", saMetricFeatureId,     false, null),
                ("SAA4", saLengthFeatureId,     false, null),
                // SAA5 → CİVATA AKB SAPKALI 12.9
                ("SAA5", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SAPKALI")),
                ("SAA5", strengthFeatureId,     true,  FV("STRENGTH",      "12.9")),
                ("SAA5", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA5", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAA5", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAA5", standardFeatureId,     false, null),
                ("SAA5", saMetricFeatureId,     false, null),
                ("SAA5", saLengthFeatureId,     false, null),
                // SAA6 → CİVATA AKB CROM
                ("SAA6", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAA6", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA6", materialFeatureId,     false, null),
                ("SAA6", strengthFeatureId,     false, null),
                ("SAA6", coatingFeatureId,      false, null),
                ("SAA6", standardFeatureId,     false, null),
                ("SAA6", saMetricFeatureId,     false, null),
                ("SAA6", saLengthFeatureId,     false, null),
                // SAA7 → CİVATA SB İNBUS 8.8
                ("SAA7", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SB_INBUS")),
                ("SAA7", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAA7", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA7", materialFeatureId,     false, null),
                ("SAA7", coatingFeatureId,      false, null),
                ("SAA7", standardFeatureId,     false, null),
                ("SAA7", saMetricFeatureId,     false, null),
                ("SAA7", saLengthFeatureId,     false, null),
                // SAA8 → CİVATA SB İNBUS 10.9
                ("SAA8", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SB_INBUS")),
                ("SAA8", strengthFeatureId,     true,  FV("STRENGTH",      "10.9")),
                ("SAA8", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA8", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAA8", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAA8", standardFeatureId,     false, null),
                ("SAA8", saMetricFeatureId,     false, null),
                ("SAA8", saLengthFeatureId,     false, null),
                // SAA9 → CİVATA SB İNBUS 12.9
                ("SAA9", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SB_INBUS")),
                ("SAA9", strengthFeatureId,     true,  FV("STRENGTH",      "12.9")),
                ("SAA9", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAA9", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAA9", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAA9", standardFeatureId,     false, null),
                ("SAA9", saMetricFeatureId,     false, null),
                ("SAA9", saLengthFeatureId,     false, null),
                // SAB0 → CİVATA SB TORNAVİDA YARIKLI 8.8
                ("SAB0", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SB_YARIKLI")),
                ("SAB0", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAB0", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB0", materialFeatureId,     false, null),
                ("SAB0", coatingFeatureId,      false, null),
                ("SAB0", standardFeatureId,     false, null),
                ("SAB0", saMetricFeatureId,     false, null),
                ("SAB0", saLengthFeatureId,     false, null),
                // SAB1 → CİVATA SB YILDIZ KANALLI 8.8
                ("SAB1", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SB_YILDIZ")),
                ("SAB1", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAB1", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB1", materialFeatureId,     false, null),
                ("SAB1", coatingFeatureId,      false, null),
                ("SAB1", standardFeatureId,     false, null),
                ("SAB1", saMetricFeatureId,     false, null),
                ("SAB1", saLengthFeatureId,     false, null),
                // SAB2 → CİVATA SB İNBUS CROM
                ("SAB2", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "SB_INBUS")),
                ("SAB2", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB2", materialFeatureId,     false, null),
                ("SAB2", strengthFeatureId,     false, null),
                ("SAB2", coatingFeatureId,      false, null),
                ("SAB2", standardFeatureId,     false, null),
                ("SAB2", saMetricFeatureId,     false, null),
                ("SAB2", saLengthFeatureId,     false, null),
                // SAB3 → CİVATA HB İNBUS 8.8
                ("SAB3", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_INBUS")),
                ("SAB3", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAB3", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB3", materialFeatureId,     false, null),
                ("SAB3", coatingFeatureId,      false, null),
                ("SAB3", standardFeatureId,     false, null),
                ("SAB3", saMetricFeatureId,     false, null),
                ("SAB3", saLengthFeatureId,     false, null),
                // SAB4 → CİVATA HB İNBUS 10.9
                ("SAB4", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_INBUS")),
                ("SAB4", strengthFeatureId,     true,  FV("STRENGTH",      "10.9")),
                ("SAB4", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB4", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAB4", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAB4", standardFeatureId,     false, null),
                ("SAB4", saMetricFeatureId,     false, null),
                ("SAB4", saLengthFeatureId,     false, null),
                // SAB5 → CİVATA HB İNBUS 12.9
                ("SAB5", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_INBUS")),
                ("SAB5", strengthFeatureId,     true,  FV("STRENGTH",      "12.9")),
                ("SAB5", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB5", materialFeatureId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SAB5", coatingFeatureId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SAB5", standardFeatureId,     false, null),
                ("SAB5", saMetricFeatureId,     false, null),
                ("SAB5", saLengthFeatureId,     false, null),
                // SAB6 → CİVATA HB TORNAVİDA YARIKLI 8.8
                ("SAB6", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_YARIKLI")),
                ("SAB6", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAB6", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB6", materialFeatureId,     false, null),
                ("SAB6", coatingFeatureId,      false, null),
                ("SAB6", standardFeatureId,     false, null),
                ("SAB6", saMetricFeatureId,     false, null),
                ("SAB6", saLengthFeatureId,     false, null),
                // SAB7 → CİVATA HB YILDIZ KANALLI 8.8
                ("SAB7", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_YILDIZ")),
                ("SAB7", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAB7", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB7", materialFeatureId,     false, null),
                ("SAB7", coatingFeatureId,      false, null),
                ("SAB7", standardFeatureId,     false, null),
                ("SAB7", saMetricFeatureId,     false, null),
                ("SAB7", saLengthFeatureId,     false, null),
                // SAB8 → CİVATA HB İNBUS CROM
                ("SAB8", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_INBUS")),
                ("SAB8", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB8", materialFeatureId,     false, null),
                ("SAB8", strengthFeatureId,     false, null),
                ("SAB8", coatingFeatureId,      false, null),
                ("SAB8", standardFeatureId,     false, null),
                ("SAB8", saMetricFeatureId,     false, null),
                ("SAB8", saLengthFeatureId,     false, null),
                // SAB9 → CİVATA HB YILDIZ KANALLI CROM
                ("SAB9", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_YILDIZ")),
                ("SAB9", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAB9", materialFeatureId,     false, null),
                ("SAB9", strengthFeatureId,     false, null),
                ("SAB9", coatingFeatureId,      false, null),
                ("SAB9", standardFeatureId,     false, null),
                ("SAB9", saMetricFeatureId,     false, null),
                ("SAB9", saLengthFeatureId,     false, null),
                // SAC0 → CİVATA HB SAC VİDASI/AKILLI VİDA CROM
                ("SAC0", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "HB_SAC")),
                ("SAC0", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC0", materialFeatureId,     false, null),
                ("SAC0", strengthFeatureId,     false, null),
                ("SAC0", coatingFeatureId,      false, null),
                ("SAC0", standardFeatureId,     false, null),
                ("SAC0", saMetricFeatureId,     false, null),
                ("SAC0", saLengthFeatureId,     false, null),
                // SAC1 → CİVATA MB DUZ 8.8
                ("SAC1", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "MB_DUZ")),
                ("SAC1", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAC1", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC1", materialFeatureId,     false, null),
                ("SAC1", coatingFeatureId,      false, null),
                ("SAC1", standardFeatureId,     false, null),
                ("SAC1", saMetricFeatureId,     false, null),
                ("SAC1", saLengthFeatureId,     false, null),
                // SAC2 → CİVATA MB TORNAVİDA YARIKLI 8.8
                ("SAC2", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "MB_YARIKLI")),
                ("SAC2", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAC2", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC2", materialFeatureId,     false, null),
                ("SAC2", coatingFeatureId,      false, null),
                ("SAC2", standardFeatureId,     false, null),
                ("SAC2", saMetricFeatureId,     false, null),
                ("SAC2", saLengthFeatureId,     false, null),
                // SAC3 → CİVATA MB YILDIZ KANALLI 8.8
                ("SAC3", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "MB_YILDIZ")),
                ("SAC3", strengthFeatureId,     true,  FV("STRENGTH",      "8.8")),
                ("SAC3", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC3", materialFeatureId,     false, null),
                ("SAC3", coatingFeatureId,      false, null),
                ("SAC3", standardFeatureId,     false, null),
                ("SAC3", saMetricFeatureId,     false, null),
                ("SAC3", saLengthFeatureId,     false, null),
                // SAC4 → CİVATA MB İNBUS CROM
                ("SAC4", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "MB_INBUS")),
                ("SAC4", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC4", materialFeatureId,     false, null),
                ("SAC4", strengthFeatureId,     false, null),
                ("SAC4", coatingFeatureId,      false, null),
                ("SAC4", standardFeatureId,     false, null),
                ("SAC4", saMetricFeatureId,     false, null),
                ("SAC4", saLengthFeatureId,     false, null),
                // SAC5 → CİVATA MB SAC VİDASI/AKILLI VİDA CROM
                ("SAC5", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "MB_SAC")),
                ("SAC5", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC5", materialFeatureId,     false, null),
                ("SAC5", strengthFeatureId,     false, null),
                ("SAC5", coatingFeatureId,      false, null),
                ("SAC5", standardFeatureId,     false, null),
                ("SAC5", saMetricFeatureId,     false, null),
                ("SAC5", saLengthFeatureId,     false, null),
                // SAC6 → CİVATA KB (KELEBEK BASLI)
                ("SAC6", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "KB")),
                ("SAC6", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAC6", materialFeatureId,     false, null),
                ("SAC6", strengthFeatureId,     false, null),
                ("SAC6", coatingFeatureId,      false, null),
                ("SAC6", standardFeatureId,     false, null),
                ("SAC6", saMetricFeatureId,     false, null),
                ("SAC6", saLengthFeatureId,     false, null),
                // SAD0 → CİVATA AKB A193 B7
                ("SAD0", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAD0", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAD0", materialFeatureId,     false, null),
                ("SAD0", strengthFeatureId,     false, null),
                ("SAD0", coatingFeatureId,      false, null),
                ("SAD0", standardFeatureId,     false, null),
                ("SAD0", saMetricFeatureId,     false, null),
                ("SAD0", saLengthFeatureId,     false, null),
                // SAD1 → CİVATA AKB A320 L7
                ("SAD1", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAD1", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAD1", materialFeatureId,     false, null),
                ("SAD1", strengthFeatureId,     false, null),
                ("SAD1", coatingFeatureId,      false, null),
                ("SAD1", standardFeatureId,     false, null),
                ("SAD1", saMetricFeatureId,     false, null),
                ("SAD1", saLengthFeatureId,     false, null),
                // SAE0 → CİVATA WHITWORTH / UNC / UNF
                ("SAE0", headTypeFeatureId,     true,  FV("HEAD_TYPE",     "AKB")),
                ("SAE0", threadSystemFeatureId, false, null),
                ("SAE0", materialFeatureId,     false, null),
                ("SAE0", strengthFeatureId,     false, null),
                ("SAE0", coatingFeatureId,      false, null),
                ("SAE0", standardFeatureId,     false, null),
                ("SAE0", saMetricFeatureId,     false, null),
                ("SAE0", saLengthFeatureId,     false, null),
                // SAE1 → CİVATA ÖZEL GRUP (tüm feature'lar dynamic)
                ("SAE1", headTypeFeatureId,     false, null),
                ("SAE1", threadSystemFeatureId, false, null),
                ("SAE1", materialFeatureId,     false, null),
                ("SAE1", strengthFeatureId,     false, null),
                ("SAE1", coatingFeatureId,      false, null),
                ("SAE1", standardFeatureId,     false, null),
                ("SAE1", saMetricFeatureId,     false, null),
                ("SAE1", saLengthFeatureId,     false, null),
                // SAE2 → PERCIN (tüm feature'lar dynamic)
                ("SAE2", headTypeFeatureId,     false, null),
                ("SAE2", threadSystemFeatureId, false, null),
                ("SAE2", materialFeatureId,     false, null),
                ("SAE2", strengthFeatureId,     false, null),
                ("SAE2", coatingFeatureId,      false, null),
                ("SAE2", standardFeatureId,     false, null),
                ("SAE2", saMetricFeatureId,     false, null),
                ("SAE2", saLengthFeatureId,     false, null),
                // SAE3 → PERCIN (tüm feature'lar dynamic)
                ("SAE3", headTypeFeatureId,     false, null),
                ("SAE3", threadSystemFeatureId, false, null),
                ("SAE3", materialFeatureId,     false, null),
                ("SAE3", strengthFeatureId,     false, null),
                ("SAE3", coatingFeatureId,      false, null),
                ("SAE3", standardFeatureId,     false, null),
                ("SAE3", saMetricFeatureId,     false, null),
                ("SAE3", saLengthFeatureId,     false, null),
                // SAE4 → PERCIN (tüm feature'lar dynamic)
                ("SAE4", headTypeFeatureId,     false, null),
                ("SAE4", threadSystemFeatureId, false, null),
                ("SAE4", materialFeatureId,     false, null),
                ("SAE4", strengthFeatureId,     false, null),
                ("SAE4", coatingFeatureId,      false, null),
                ("SAE4", standardFeatureId,     false, null),
                ("SAE4", saMetricFeatureId,     false, null),
                ("SAE4", saLengthFeatureId,     false, null),
                // SAE5 → PERCIN (tüm feature'lar dynamic)
                ("SAE5", headTypeFeatureId,     false, null),
                ("SAE5", threadSystemFeatureId, false, null),
                ("SAE5", materialFeatureId,     false, null),
                ("SAE5", strengthFeatureId,     false, null),
                ("SAE5", coatingFeatureId,      false, null),
                ("SAE5", standardFeatureId,     false, null),
                ("SAE5", saMetricFeatureId,     false, null),
                ("SAE5", saLengthFeatureId,     false, null),
                // SAE6 → SAPLAMALAR (tüm feature'lar dynamic)
                ("SAE6", headTypeFeatureId,     false, null),
                ("SAE6", threadSystemFeatureId, false, null),
                ("SAE6", materialFeatureId,     false, null),
                ("SAE6", strengthFeatureId,     false, null),
                ("SAE6", coatingFeatureId,      false, null),
                ("SAE6", standardFeatureId,     false, null),
                ("SAE6", saMetricFeatureId,     false, null),
                ("SAE6", saLengthFeatureId,     false, null),
                // SAE7 → CİVATA SETŞKUR
                ("SAE7", threadSystemFeatureId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SAE7", headTypeFeatureId,     false, null),
                ("SAE7", materialFeatureId,     false, null),
                ("SAE7", strengthFeatureId,     false, null),
                ("SAE7", coatingFeatureId,      false, null),
                ("SAE7", standardFeatureId,     false, null),
                ("SAE7", saMetricFeatureId,     false, null),
                ("SAE7", saLengthFeatureId,     false, null),
                // SAE8 → U-BOLT (tüm feature'lar dynamic)
                ("SAE8", headTypeFeatureId,     false, null),
                ("SAE8", threadSystemFeatureId, false, null),
                ("SAE8", materialFeatureId,     false, null),
                ("SAE8", strengthFeatureId,     false, null),
                ("SAE8", coatingFeatureId,      false, null),
                ("SAE8", standardFeatureId,     false, null),
                ("SAE8", saMetricFeatureId,     false, null),
                ("SAE8", saLengthFeatureId,     false, null),
            };

            await EnsureFixedProductFeatureRulesAsync(saProductRules, cancellationToken);

            var standardProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SA") || p.Code.StartsWith("SB") || p.Code.StartsWith("SC"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            // Value rule olup product feature rule olmayan feature'ları otomatik ekle (dropdown görünürlük için)
            var existingProductFeaturePairs = await _db.SProductFeatureRules
                .AsNoTracking()
                .Where(r => standardProductIds.Contains(r.SProductId))
                .Select(r => new { r.SProductId, r.SFeatureId })
                .ToListAsync(cancellationToken);

            var valueRuleFeaturePairs = await _db.SFeatureValueRules
                .AsNoTracking()
                .Where(v => standardProductIds.Contains(v.SProductId))
                .Select(v => new { v.SProductId, v.SFeatureId })
                .Distinct()
                .ToListAsync(cancellationToken);

            var missingFeatureRules = valueRuleFeaturePairs
                .Where(v => !existingProductFeaturePairs.Any(e => e.SProductId == v.SProductId && e.SFeatureId == v.SFeatureId))
                .ToList();

            if (missingFeatureRules.Count > 0)
            {
                var ruleInserts = missingFeatureRules.Select(x => new SProductFeatureRule
                {
                    Id = SeedId.From($"Runtime:SProductFeatureRule:{x.SProductId}:{x.SFeatureId}"),
                    SProductId = x.SProductId,
                    SFeatureId = x.SFeatureId,
                    IsFixed = false,
                    FixedValueId = null,
                    CreatedBy = "RUNTIME_SYNC",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                });

                _db.SProductFeatureRules.AddRange(ruleInserts);
                await _db.SaveChangesAsync(cancellationToken);
            }

            var dynamicRules = await _db.SProductFeatureRules
                .AsNoTracking()
                .Where(r => standardProductIds.Contains(r.SProductId) && !r.IsFixed &&
                            (r.SFeatureId == saMetricFeatureId || r.SFeatureId == sbMetricFeatureId || r.SFeatureId == scMetricFeatureId || r.SFeatureId == saLengthFeatureId))
                .Select(r => new { r.SProductId, r.SFeatureId })
                .ToListAsync(cancellationToken);

            var allValueRules = await _db.SFeatureValueRules
                .AsNoTracking()
                .Where(v => standardProductIds.Contains(v.SProductId) &&
                            (v.SFeatureId == saMetricFeatureId || v.SFeatureId == sbMetricFeatureId || v.SFeatureId == scMetricFeatureId || v.SFeatureId == saLengthFeatureId))
                .Select(v => new { v.SProductId, v.SFeatureId, v.SFeatureValueId })
                .ToListAsync(cancellationToken);

            var metricValues = await _db.Set<SFeatureValue>().AsNoTracking().Where(v => v.SFeatureId == saMetricFeatureId).OrderBy(v => v.SortOrder).ToListAsync(cancellationToken);
            var scMetricValues = await _db.Set<SFeatureValue>().AsNoTracking().Where(v => v.SFeatureId == scMetricFeatureId).OrderBy(v => v.SortOrder).ToListAsync(cancellationToken);
            var lengthValues = await _db.Set<SFeatureValue>().AsNoTracking().Where(v => v.SFeatureId == saLengthFeatureId).OrderBy(v => v.SortOrder).ToListAsync(cancellationToken);

            var inserts = new List<SFeatureValueRule>();

            foreach (var rule in dynamicRules)
            {
                var values = rule.SFeatureId == saLengthFeatureId
                    ? lengthValues
                    : (rule.SFeatureId == scMetricFeatureId ? scMetricValues : metricValues);
                for (int i = 0; i < values.Count; i++)
                {
                    var value = values[i];
                    var exists = allValueRules.Any(x => x.SProductId == rule.SProductId && x.SFeatureId == rule.SFeatureId && x.SFeatureValueId == value.Id);
                    if (exists) continue;

                    var featureName = rule.SFeatureId == saLengthFeatureId
                        ? "LENGTH"
                        : (rule.SFeatureId == scMetricFeatureId ? "SC_METRIC" : "METRIC");
                    inserts.Add(new SFeatureValueRule
                    {
                        Id = SeedId.From($"Runtime:SFeatureValueRule:{rule.SProductId}:{featureName}:{value.Code}"),
                        SProductId = rule.SProductId,
                        SFeatureId = rule.SFeatureId,
                        SFeatureValueId = value.Id,
                        SortOrder = i,
                        CreatedBy = "RUNTIME_SYNC",
                        CreatedDate = DateTime.UtcNow,
                        Status = Domain.Enums.Status.Added
                    });
                }
            }

            if (inserts.Count > 0)
            {
                _db.SFeatureValueRules.AddRange(inserts);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// SD: CONNECTION_SIZE feature için DN serisini yazar ve eksik SProductFeatureRule kayıtlarını tamamlar.
        /// </summary>
        private async Task SyncSdAsync(CancellationToken cancellationToken)
        {
            var connectionSizeFeatureId = SeedId.From("SFeature:CONNECTION_SIZE");

            var dnCodes = new List<string>
            {
                "DN6", "DN8", "DN10", "DN15", "DN20", "DN25", "DN32", "DN40",
                "DN50", "DN65", "DN80", "DN100", "DN125", "DN150", "DN200", "DN250", "DN300"
            };

            await EnsureFeatureValuesAsync(connectionSizeFeatureId, "CONNECTION_SIZE", dnCodes, cancellationToken);

            var sdProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SD"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (sdProductIds.Count == 0) return;

            await EnsureMissingProductFeatureRulesAsync(sdProductIds, cancellationToken);
            await EnsureFeatureValueRulesAsync(sdProductIds, connectionSizeFeatureId, "CONNECTION_SIZE", cancellationToken);
        }

        /// <summary>
        /// SE: CROSS_SECTION ve VOLTAGE feature value'larını yazar ve eksik SProductFeatureRule kayıtlarını tamamlar.
        /// </summary>
        private async Task SyncSeAsync(CancellationToken cancellationToken)
        {
            var crossSectionFeatureId = SeedId.From("SFeature:CROSS_SECTION");
            var voltageFeatureId = SeedId.From("SFeature:VOLTAGE");

            var crossSectionCodes = new List<string>
            {
                "1.5mm²", "2.5mm²", "4mm²", "6mm²", "10mm²",
                "16mm²", "25mm²", "35mm²", "50mm²", "70mm²", "95mm²", "120mm²"
            };

            var voltageCodes = new List<string>
            {
                "12V", "24V", "48V", "110V", "220V", "230V",
                "240V", "380V", "400V", "415V", "500V", "690V", "1000V"
            };

            await EnsureFeatureValuesAsync(crossSectionFeatureId, "CROSS_SECTION", crossSectionCodes, cancellationToken);
            await EnsureFeatureValuesAsync(voltageFeatureId, "VOLTAGE", voltageCodes, cancellationToken);

            var seProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SE"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (seProductIds.Count == 0) return;

            await EnsureMissingProductFeatureRulesAsync(seProductIds, cancellationToken);
            await EnsureFeatureValueRulesAsync(seProductIds, crossSectionFeatureId, "CROSS_SECTION", cancellationToken);
            await EnsureFeatureValueRulesAsync(seProductIds, voltageFeatureId, "VOLTAGE", cancellationToken);
        }

        /// <summary>
        /// SF: SF_DN feature için DN serisini yazar ve eksik SProductFeatureRule kayıtlarını tamamlar.
        /// </summary>
        private async Task SyncSfAsync(CancellationToken cancellationToken)
        {
            var sfDnFeatureId = SeedId.From("SFeature:SF_DN");

            var dnCodes = new List<string>
            {
                "DN10", "DN15", "DN20", "DN25", "DN32", "DN40", "DN50",
                "DN65", "DN80", "DN100", "DN125", "DN150", "DN200",
                "DN250", "DN300", "DN350", "DN400", "DN500", "DN600"
            };

            await EnsureFeatureValuesAsync(sfDnFeatureId, "SF_DN", dnCodes, cancellationToken);

            var sfProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SF"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (sfProductIds.Count == 0) return;

            await EnsureMissingProductFeatureRulesAsync(sfProductIds, cancellationToken);
            await EnsureFeatureValueRulesAsync(sfProductIds, sfDnFeatureId, "SF_DN", cancellationToken);
        }

        /// <summary>
        /// SG: SG_DIAMETER ve SG_LENGTH feature value'larını yazar ve eksik SProductFeatureRule kayıtlarını tamamlar.
        /// </summary>
        private async Task SyncSgAsync(CancellationToken cancellationToken)
        {
            var sgDiameterFeatureId = SeedId.From("SFeature:SG:DIAMETER");
            var sgLengthFeatureId = SeedId.From("SFeature:SG:LENGTH");

            var diameterCodes = new List<string>
            {
                "1mm", "1.5mm", "2mm", "2.5mm", "3mm", "4mm", "5mm", "6mm", "7mm", "8mm",
                "10mm", "12mm", "13mm", "14mm", "16mm", "18mm", "20mm", "22mm", "25mm", "30mm",
                "M6", "M8", "M10", "M12", "M14", "M16", "M18", "M20", "M22", "M24", "M27", "M30"
            };

            var lengthCodes = new List<string>
            {
                "6mm", "8mm", "10mm", "12mm", "14mm", "16mm", "18mm", "20mm", "22mm", "25mm",
                "28mm", "30mm", "32mm", "35mm", "40mm", "45mm", "50mm", "55mm", "60mm", "65mm",
                "70mm", "75mm", "80mm", "90mm", "100mm", "110mm", "120mm", "140mm", "150mm", "160mm",
                "180mm", "200mm"
            };

            await EnsureFeatureValuesAsync(sgDiameterFeatureId, "SG_DIAMETER", diameterCodes, cancellationToken);
            await EnsureFeatureValuesAsync(sgLengthFeatureId, "SG_LENGTH", lengthCodes, cancellationToken);

            var sgProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SG"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (sgProductIds.Count == 0) return;

            await EnsureMissingProductFeatureRulesAsync(sgProductIds, cancellationToken);
            await EnsureFeatureValueRulesAsync(sgProductIds, sgDiameterFeatureId, "SG_DIAMETER", cancellationToken);
            await EnsureFeatureValueRulesAsync(sgProductIds, sgLengthFeatureId, "SG_LENGTH", cancellationToken);
        }

        /// <summary>
        /// SH: Placeholder — SH grubu ürünleri hazır olduğunda buraya sync mantığı eklenecek.
        /// </summary>
        private Task SyncShAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// SA ürünleri için sabit (IsFixed=true) ve dinamik (IsFixed=false) SProductFeatureRule kayıtlarını upsert eder.
        /// Kayıt zaten varsa (aynı SProductId + SFeatureId) ekleme yapmaz.
        /// </summary>
        private async Task EnsureFixedProductFeatureRulesAsync(
            List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)> rules,
            CancellationToken cancellationToken)
        {
            var productCodes = rules.Select(r => r.ProductCode).Distinct().ToList();
            var productIdMap = await _db.SProducts
                .AsNoTracking()
                .Where(p => productCodes.Contains(p.Code))
                .ToDictionaryAsync(p => p.Code, p => p.Id, cancellationToken);

            var productIds = productIdMap.Values.ToList();
            var existingRules = await _db.SProductFeatureRules
                .AsNoTracking()
                .Where(r => productIds.Contains(r.SProductId))
                .Select(r => new { r.SProductId, r.SFeatureId })
                .ToListAsync(cancellationToken);

            var toInsert = new List<SProductFeatureRule>();

            foreach (var (productCode, featureId, isFixed, fixedValueId) in rules)
            {
                if (!productIdMap.TryGetValue(productCode, out var productId)) continue;

                var exists = existingRules.Any(e => e.SProductId == productId && e.SFeatureId == featureId);
                if (exists) continue;

                toInsert.Add(new SProductFeatureRule
                {
                    Id = SeedId.From($"Runtime:SProductFeatureRule:{productId}:{featureId}"),
                    SProductId = productId,
                    SFeatureId = featureId,
                    IsFixed = isFixed,
                    FixedValueId = fixedValueId,
                    CreatedBy = "RUNTIME_SYNC",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                });
            }

            if (toInsert.Count > 0)
            {
                _db.SProductFeatureRules.AddRange(toInsert);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Belirtilen feature için eksik SFeatureValue kayıtlarını ekler.
        /// </summary>
        private async Task EnsureFeatureValuesAsync(Guid featureId, string featureName, List<string> codes, CancellationToken cancellationToken)
        {
            var existing = await _db.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(v => v.SFeatureId == featureId)
                .Select(v => v.Code)
                .ToListAsync(cancellationToken);

            var toInsert = new List<SFeatureValue>();
            for (int i = 0; i < codes.Count; i++)
            {
                var code = codes[i];
                if (existing.Contains(code)) continue;

                toInsert.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:{featureName}:{code}"),
                    SFeatureId = featureId,
                    Code = code,
                    Name = featureName == "LENGTH" ? $"{code} mm" : code,
                    SortOrder = i,
                    CreatedBy = "RUNTIME_SYNC",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                });
            }

            if (toInsert.Count > 0)
            {
                _db.Set<SFeatureValue>().AddRange(toInsert);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// SFeatureValueRule kaydı olan ama SProductFeatureRule kaydı olmayan product-feature çiftlerini tamamlar.
        /// </summary>
        private async Task EnsureMissingProductFeatureRulesAsync(List<Guid> productIds, CancellationToken cancellationToken)
        {
            var existingProductFeaturePairs = await _db.SProductFeatureRules
                .AsNoTracking()
                .Where(r => productIds.Contains(r.SProductId))
                .Select(r => new { r.SProductId, r.SFeatureId })
                .ToListAsync(cancellationToken);

            var valueRuleFeaturePairs = await _db.SFeatureValueRules
                .AsNoTracking()
                .Where(v => productIds.Contains(v.SProductId))
                .Select(v => new { v.SProductId, v.SFeatureId })
                .Distinct()
                .ToListAsync(cancellationToken);

            var missingFeatureRules = valueRuleFeaturePairs
                .Where(v => !existingProductFeaturePairs.Any(e => e.SProductId == v.SProductId && e.SFeatureId == v.SFeatureId))
                .ToList();

            if (missingFeatureRules.Count > 0)
            {
                var ruleInserts = missingFeatureRules.Select(x => new SProductFeatureRule
                {
                    Id = SeedId.From($"Runtime:SProductFeatureRule:{x.SProductId}:{x.SFeatureId}"),
                    SProductId = x.SProductId,
                    SFeatureId = x.SFeatureId,
                    IsFixed = false,
                    FixedValueId = null,
                    CreatedBy = "RUNTIME_SYNC",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                });

                _db.SProductFeatureRules.AddRange(ruleInserts);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Belirtilen ürünler ve feature için dinamik (IsFixed=false) SProductFeatureRule'lara
        /// eksik SFeatureValueRule kayıtlarını ekler.
        /// </summary>
        private async Task EnsureFeatureValueRulesAsync(List<Guid> productIds, Guid featureId, string featureName, CancellationToken cancellationToken)
        {
            var dynamicRules = await _db.SProductFeatureRules
                .AsNoTracking()
                .Where(r => productIds.Contains(r.SProductId) && !r.IsFixed && r.SFeatureId == featureId)
                .Select(r => new { r.SProductId, r.SFeatureId })
                .ToListAsync(cancellationToken);

            if (dynamicRules.Count == 0) return;

            var allValueRules = await _db.SFeatureValueRules
                .AsNoTracking()
                .Where(v => productIds.Contains(v.SProductId) && v.SFeatureId == featureId)
                .Select(v => new { v.SProductId, v.SFeatureValueId })
                .ToListAsync(cancellationToken);

            var featureValues = await _db.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(v => v.SFeatureId == featureId)
                .OrderBy(v => v.SortOrder)
                .ToListAsync(cancellationToken);

            var inserts = new List<SFeatureValueRule>();

            foreach (var rule in dynamicRules)
            {
                for (int i = 0; i < featureValues.Count; i++)
                {
                    var value = featureValues[i];
                    var exists = allValueRules.Any(x => x.SProductId == rule.SProductId && x.SFeatureValueId == value.Id);
                    if (exists) continue;

                    inserts.Add(new SFeatureValueRule
                    {
                        Id = SeedId.From($"Runtime:SFeatureValueRule:{rule.SProductId}:{featureName}:{value.Code}"),
                        SProductId = rule.SProductId,
                        SFeatureId = featureId,
                        SFeatureValueId = value.Id,
                        SortOrder = i,
                        CreatedBy = "RUNTIME_SYNC",
                        CreatedDate = DateTime.UtcNow,
                        Status = Domain.Enums.Status.Added
                    });
                }
            }

            if (inserts.Count > 0)
            {
                _db.SFeatureValueRules.AddRange(inserts);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
