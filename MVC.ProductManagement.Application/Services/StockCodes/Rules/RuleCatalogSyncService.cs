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
            await SyncSbAsync(cancellationToken);
            await SyncScAsync(cancellationToken);
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
        /// SB: Somunlar için feature value'ları ve SProductFeatureRule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncSbAsync(CancellationToken cancellationToken)
        {
            var nutTypeId      = SeedId.From("SFeature:NUT_TYPE");
            var materialId     = SeedId.From("SFeature:MATERIAL");
            var threadSystemId = SeedId.From("SFeature:THREAD_SYSTEM");
            var standardId     = SeedId.From("SFeature:STANDARD");
            var metricId       = SeedId.From("SFeature:METRIC");
            var strengthId     = SeedId.From("SFeature:STRENGTH");
            var coatingId      = SeedId.From("SFeature:COATING");

            await EnsureFeatureValuesAsync(nutTypeId, "NUT_TYPE", new List<string>
            {
                "AKB", "SAPKALI", "FIBERLI", "KONTRALI", "KAYNAK", "TACLI", "HALKALI", "KELEBEK"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(strengthId,     "STRENGTH",      new List<string> { "8.8", "10.9", "12.9" }, cancellationToken);
            await EnsureFeatureValuesAsync(materialId,     "MATERIAL",      new List<string> { "KARBON", "ALAŞIMLI" }, cancellationToken);
            await EnsureFeatureValuesAsync(coatingId,      "COATING",       new List<string> { "CINKO", "GALVANIZ", "SIYAH OKSIT", "-" }, cancellationToken);
            await EnsureFeatureValuesAsync(threadSystemId, "THREAD_SYSTEM", new List<string> { "METRIK", "UNC", "UNF", "BSW" }, cancellationToken);
            await EnsureFeatureValuesAsync(standardId,     "STANDARD",      new List<string> { "DIN 934", "ISO 4032" }, cancellationToken);
            // METRIC already written in SyncSaAsync

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var sbProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // SBA0: NUT_TYPE=AKB(sabit), STRENGTH=8.8(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBA0", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBA0", strengthId,     true,  FV("STRENGTH",      "8.8")),
                ("SBA0", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA0", materialId,     false, null),
                ("SBA0", coatingId,      false, null),
                ("SBA0", standardId,     false, null),
                ("SBA0", metricId,       false, null),
                // SBA1: NUT_TYPE=AKB(sabit), STRENGTH=10.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBA1", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBA1", strengthId,     true,  FV("STRENGTH",      "10.9")),
                ("SBA1", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA1", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBA1", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBA1", standardId,     false, null),
                ("SBA1", metricId,       false, null),
                // SBA2: NUT_TYPE=AKB(sabit), STRENGTH=12.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBA2", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBA2", strengthId,     true,  FV("STRENGTH",      "12.9")),
                ("SBA2", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA2", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBA2", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBA2", standardId,     false, null),
                ("SBA2", metricId,       false, null),
                // SBA3: NUT_TYPE=SAPKALI(sabit), STRENGTH=8.8(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=KARBON(sabit)
                ("SBA3", nutTypeId,      true,  FV("NUT_TYPE",      "SAPKALI")),
                ("SBA3", strengthId,     true,  FV("STRENGTH",      "8.8")),
                ("SBA3", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA3", materialId,     true,  FV("MATERIAL",      "KARBON")),
                ("SBA3", coatingId,      false, null),
                ("SBA3", standardId,     false, null),
                ("SBA3", metricId,       false, null),
                // SBA4: NUT_TYPE=SAPKALI(sabit), STRENGTH=10.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBA4", nutTypeId,      true,  FV("NUT_TYPE",      "SAPKALI")),
                ("SBA4", strengthId,     true,  FV("STRENGTH",      "10.9")),
                ("SBA4", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA4", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBA4", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBA4", standardId,     false, null),
                ("SBA4", metricId,       false, null),
                // SBA5: NUT_TYPE=SAPKALI(sabit), STRENGTH=12.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBA5", nutTypeId,      true,  FV("NUT_TYPE",      "SAPKALI")),
                ("SBA5", strengthId,     true,  FV("STRENGTH",      "12.9")),
                ("SBA5", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA5", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBA5", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBA5", standardId,     false, null),
                ("SBA5", metricId,       false, null),
                // SBA6: NUT_TYPE=AKB(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBA6", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBA6", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA6", materialId,     false, null),
                ("SBA6", strengthId,     false, null),
                ("SBA6", coatingId,      false, null),
                ("SBA6", standardId,     false, null),
                ("SBA6", metricId,       false, null),
                // SBA7: NUT_TYPE=SAPKALI(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBA7", nutTypeId,      true,  FV("NUT_TYPE",      "SAPKALI")),
                ("SBA7", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA7", materialId,     false, null),
                ("SBA7", strengthId,     false, null),
                ("SBA7", coatingId,      false, null),
                ("SBA7", standardId,     false, null),
                ("SBA7", metricId,       false, null),
                // SBA8: NUT_TYPE=FIBERLI(sabit), STRENGTH=8.8(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBA8", nutTypeId,      true,  FV("NUT_TYPE",      "FIBERLI")),
                ("SBA8", strengthId,     true,  FV("STRENGTH",      "8.8")),
                ("SBA8", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA8", materialId,     false, null),
                ("SBA8", coatingId,      false, null),
                ("SBA8", standardId,     false, null),
                ("SBA8", metricId,       false, null),
                // SBA9: NUT_TYPE=FIBERLI(sabit), STRENGTH=10.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBA9", nutTypeId,      true,  FV("NUT_TYPE",      "FIBERLI")),
                ("SBA9", strengthId,     true,  FV("STRENGTH",      "10.9")),
                ("SBA9", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBA9", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBA9", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBA9", standardId,     false, null),
                ("SBA9", metricId,       false, null),
                // SBB0: NUT_TYPE=FIBERLI(sabit), STRENGTH=12.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBB0", nutTypeId,      true,  FV("NUT_TYPE",      "FIBERLI")),
                ("SBB0", strengthId,     true,  FV("STRENGTH",      "12.9")),
                ("SBB0", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB0", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBB0", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBB0", standardId,     false, null),
                ("SBB0", metricId,       false, null),
                // SBB1: NUT_TYPE=FIBERLI(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBB1", nutTypeId,      true,  FV("NUT_TYPE",      "FIBERLI")),
                ("SBB1", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB1", materialId,     false, null),
                ("SBB1", strengthId,     false, null),
                ("SBB1", coatingId,      false, null),
                ("SBB1", standardId,     false, null),
                ("SBB1", metricId,       false, null),
                // SBB2: NUT_TYPE=KONTRALI(sabit), STRENGTH=8.8(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=KARBON(sabit)
                ("SBB2", nutTypeId,      true,  FV("NUT_TYPE",      "KONTRALI")),
                ("SBB2", strengthId,     true,  FV("STRENGTH",      "8.8")),
                ("SBB2", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB2", materialId,     true,  FV("MATERIAL",      "KARBON")),
                ("SBB2", coatingId,      false, null),
                ("SBB2", standardId,     false, null),
                ("SBB2", metricId,       false, null),
                // SBB3: NUT_TYPE=KONTRALI(sabit), STRENGTH=10.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBB3", nutTypeId,      true,  FV("NUT_TYPE",      "KONTRALI")),
                ("SBB3", strengthId,     true,  FV("STRENGTH",      "10.9")),
                ("SBB3", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB3", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBB3", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBB3", standardId,     false, null),
                ("SBB3", metricId,       false, null),
                // SBB4: NUT_TYPE=KONTRALI(sabit), STRENGTH=12.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBB4", nutTypeId,      true,  FV("NUT_TYPE",      "KONTRALI")),
                ("SBB4", strengthId,     true,  FV("STRENGTH",      "12.9")),
                ("SBB4", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB4", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBB4", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBB4", standardId,     false, null),
                ("SBB4", metricId,       false, null),
                // SBB5: NUT_TYPE=KONTRALI(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBB5", nutTypeId,      true,  FV("NUT_TYPE",      "KONTRALI")),
                ("SBB5", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB5", materialId,     false, null),
                ("SBB5", strengthId,     false, null),
                ("SBB5", coatingId,      false, null),
                ("SBB5", standardId,     false, null),
                ("SBB5", metricId,       false, null),
                // SBB6: NUT_TYPE=KAYNAK(sabit), STRENGTH=8.8(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=KARBON(sabit), COATING=CINZO(sabit)
                ("SBB6", nutTypeId,      true,  FV("NUT_TYPE",      "KAYNAK")),
                ("SBB6", strengthId,     true,  FV("STRENGTH",      "8.8")),
                ("SBB6", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB6", materialId,     true,  FV("MATERIAL",      "KARBON")),
                ("SBB6", coatingId,      true,  FV("COATING",       "CINKO")),
                ("SBB6", standardId,     false, null),
                ("SBB6", metricId,       false, null),
                // SBB7: NUT_TYPE=KAYNAK(sabit), STRENGTH=10.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBB7", nutTypeId,      true,  FV("NUT_TYPE",      "KAYNAK")),
                ("SBB7", strengthId,     true,  FV("STRENGTH",      "10.9")),
                ("SBB7", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB7", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBB7", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBB7", standardId,     false, null),
                ("SBB7", metricId,       false, null),
                // SBB8: NUT_TYPE=KAYNAK(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBB8", nutTypeId,      true,  FV("NUT_TYPE",      "KAYNAK")),
                ("SBB8", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB8", materialId,     false, null),
                ("SBB8", strengthId,     false, null),
                ("SBB8", coatingId,      false, null),
                ("SBB8", standardId,     false, null),
                ("SBB8", metricId,       false, null),
                // SBB9: NUT_TYPE=TACLI(sabit), STRENGTH=8.8(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=KARBON(sabit)
                ("SBB9", nutTypeId,      true,  FV("NUT_TYPE",      "TACLI")),
                ("SBB9", strengthId,     true,  FV("STRENGTH",      "8.8")),
                ("SBB9", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBB9", materialId,     true,  FV("MATERIAL",      "KARBON")),
                ("SBB9", coatingId,      false, null),
                ("SBB9", standardId,     false, null),
                ("SBB9", metricId,       false, null),
                // SBC0: NUT_TYPE=TACLI(sabit), STRENGTH=10.9(sabit), THREAD_SYSTEM=METRIK(sabit), MATERIAL=ALAŞIMLI(sabit), COATING=SIYAH OKSIT(sabit)
                ("SBC0", nutTypeId,      true,  FV("NUT_TYPE",      "TACLI")),
                ("SBC0", strengthId,     true,  FV("STRENGTH",      "10.9")),
                ("SBC0", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBC0", materialId,     true,  FV("MATERIAL",      "ALAŞIMLI")),
                ("SBC0", coatingId,      true,  FV("COATING",       "SIYAH OKSIT")),
                ("SBC0", standardId,     false, null),
                ("SBC0", metricId,       false, null),
                // SBC1: NUT_TYPE=TACLI(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBC1", nutTypeId,      true,  FV("NUT_TYPE",      "TACLI")),
                ("SBC1", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBC1", materialId,     false, null),
                ("SBC1", strengthId,     false, null),
                ("SBC1", coatingId,      false, null),
                ("SBC1", standardId,     false, null),
                ("SBC1", metricId,       false, null),
                // SBC2: NUT_TYPE=HALKALI(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBC2", nutTypeId,      true,  FV("NUT_TYPE",      "HALKALI")),
                ("SBC2", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBC2", materialId,     false, null),
                ("SBC2", strengthId,     false, null),
                ("SBC2", coatingId,      false, null),
                ("SBC2", standardId,     false, null),
                ("SBC2", metricId,       false, null),
                // SBC3: NUT_TYPE=KELEBEK(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBC3", nutTypeId,      true,  FV("NUT_TYPE",      "KELEBEK")),
                ("SBC3", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBC3", materialId,     false, null),
                ("SBC3", strengthId,     false, null),
                ("SBC3", coatingId,      false, null),
                ("SBC3", standardId,     false, null),
                ("SBC3", metricId,       false, null),
                // SBD0: NUT_TYPE=AKB(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBD0", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBD0", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBD0", materialId,     false, null),
                ("SBD0", strengthId,     false, null),
                ("SBD0", coatingId,      false, null),
                ("SBD0", standardId,     false, null),
                ("SBD0", metricId,       false, null),
                // SBD1: NUT_TYPE=AKB(sabit), THREAD_SYSTEM=METRIK(sabit), others dynamic
                ("SBD1", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBD1", threadSystemId, true,  FV("THREAD_SYSTEM", "METRIK")),
                ("SBD1", materialId,     false, null),
                ("SBD1", strengthId,     false, null),
                ("SBD1", coatingId,      false, null),
                ("SBD1", standardId,     false, null),
                ("SBD1", metricId,       false, null),
                // SBE0: NUT_TYPE=AKB(sabit), THREAD_SYSTEM=dynamic, others dynamic
                ("SBE0", nutTypeId,      true,  FV("NUT_TYPE",      "AKB")),
                ("SBE0", threadSystemId, false, null),
                ("SBE0", materialId,     false, null),
                ("SBE0", strengthId,     false, null),
                ("SBE0", coatingId,      false, null),
                ("SBE0", standardId,     false, null),
                ("SBE0", metricId,       false, null),
                // SBE1: all dynamic
                ("SBE1", nutTypeId,      false, null),
                ("SBE1", threadSystemId, false, null),
                ("SBE1", materialId,     false, null),
                ("SBE1", strengthId,     false, null),
                ("SBE1", coatingId,      false, null),
                ("SBE1", standardId,     false, null),
                ("SBE1", metricId,       false, null),
            };

            await EnsureFixedProductFeatureRulesAsync(sbProductRules, cancellationToken);
        }

        /// <summary>
        /// SC: Pul ve Rondelalar için feature value'ları ve SProductFeatureRule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncScAsync(CancellationToken cancellationToken)
        {
            var washerTypeId = SeedId.From("SFeature:WASHER_TYPE");
            var scMaterialId = SeedId.From("SFeature:SC_MATERIAL");
            var scStandardId = SeedId.From("SFeature:SC_STANDARD");
            var scMetricId   = SeedId.From("SFeature:SC_METRIC");
            var scCoatingId  = SeedId.From("SFeature:SC_COATING");

            await EnsureFeatureValuesAsync(washerTypeId, "WASHER_TYPE", new List<string>
            {
                "DUZ", "YAYLI", "TIRTIRLI", "KESIK", "KAMA", "SIZDIRMAZ", "OZELDEN"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(scMaterialId, "SC_MATERIAL", new List<string>
            {
                "CELiK", "ALUMiNYUM", "BAKIR", "PASLANMAZ", "PLASTIK"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(scCoatingId, "SC_COATING", new List<string>
            {
                "CINKO", "GALVANIZ", "KROM", "-"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(scStandardId, "SC_STANDARD", new List<string>
            {
                "DIN 125", "DIN 127", "ISO 7089"
            }, cancellationToken);
            // SC_METRIC already written in SyncSaAsync

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var scProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // SCA0: RONDELA DÜZ ÇELİK
                ("SCA0", washerTypeId, true,  FV("WASHER_TYPE", "DUZ")),
                ("SCA0", scMaterialId, true,  FV("SC_MATERIAL", "CELiK")),
                ("SCA0", scCoatingId,  false, null),
                ("SCA0", scStandardId, false, null),
                ("SCA0", scMetricId,   false, null),
                // SCA1: RONDELA DÜZ ALÜMİNYUM
                ("SCA1", washerTypeId, true,  FV("WASHER_TYPE", "DUZ")),
                ("SCA1", scMaterialId, true,  FV("SC_MATERIAL", "ALUMiNYUM")),
                ("SCA1", scCoatingId,  false, null),
                ("SCA1", scStandardId, false, null),
                ("SCA1", scMetricId,   false, null),
                // SCA2: RONDELA DÜZ BAKIR
                ("SCA2", washerTypeId, true,  FV("WASHER_TYPE", "DUZ")),
                ("SCA2", scMaterialId, true,  FV("SC_MATERIAL", "BAKIR")),
                ("SCA2", scCoatingId,  false, null),
                ("SCA2", scStandardId, false, null),
                ("SCA2", scMetricId,   false, null),
                // SCA3: RONDELA DÜZ CROM (paslanmaz)
                ("SCA3", washerTypeId, true,  FV("WASHER_TYPE", "DUZ")),
                ("SCA3", scMaterialId, true,  FV("SC_MATERIAL", "PASLANMAZ")),
                ("SCA3", scCoatingId,  false, null),
                ("SCA3", scStandardId, false, null),
                ("SCA3", scMetricId,   false, null),
                // SCA4: RONDELA YAYLI ÇELİK
                ("SCA4", washerTypeId, true,  FV("WASHER_TYPE", "YAYLI")),
                ("SCA4", scMaterialId, true,  FV("SC_MATERIAL", "CELiK")),
                ("SCA4", scCoatingId,  false, null),
                ("SCA4", scStandardId, false, null),
                ("SCA4", scMetricId,   false, null),
                // SCA5: RONDELA YAYLI CROM
                ("SCA5", washerTypeId, true,  FV("WASHER_TYPE", "YAYLI")),
                ("SCA5", scMaterialId, true,  FV("SC_MATERIAL", "PASLANMAZ")),
                ("SCA5", scCoatingId,  false, null),
                ("SCA5", scStandardId, false, null),
                ("SCA5", scMetricId,   false, null),
                // SCA6: RONDELA TIRTIRLI ÇELİK
                ("SCA6", washerTypeId, true,  FV("WASHER_TYPE", "TIRTIRLI")),
                ("SCA6", scMaterialId, true,  FV("SC_MATERIAL", "CELiK")),
                ("SCA6", scCoatingId,  false, null),
                ("SCA6", scStandardId, false, null),
                ("SCA6", scMetricId,   false, null),
            };

            // All remaining SC products: add all features as dynamic
            var specificScCodes = new HashSet<string> { "SCA0", "SCA1", "SCA2", "SCA3", "SCA4", "SCA5", "SCA6" };
            var allScCodes = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SC"))
                .Select(p => p.Code)
                .ToListAsync(cancellationToken);

            foreach (var code in allScCodes.Where(c => !specificScCodes.Contains(c)))
            {
                scProductRules.Add((code, washerTypeId, false, null));
                scProductRules.Add((code, scMaterialId, false, null));
                scProductRules.Add((code, scCoatingId,  false, null));
                scProductRules.Add((code, scStandardId, false, null));
                scProductRules.Add((code, scMetricId,   false, null));
            }

            await EnsureFixedProductFeatureRulesAsync(scProductRules, cancellationToken);
        }

        /// <summary>
        /// SD: Rekorlar ve Dirsekler için feature value'ları ve SProductFeatureRule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncSdAsync(CancellationToken cancellationToken)
        {
            var connectionTypeId = SeedId.From("SFeature:CONNECTION_TYPE");
            var sdMaterialId     = SeedId.From("SFeature:SD_MATERIAL");
            var sdStandardId     = SeedId.From("SFeature:SD_STANDARD");
            var connectionSizeId = SeedId.From("SFeature:CONNECTION_SIZE");
            var angleId          = SeedId.From("SFeature:ANGLE");
            var sdCoatingId      = SeedId.From("SFeature:SD_COATING");

            await EnsureFeatureValuesAsync(connectionTypeId, "CONNECTION_TYPE", new List<string>
            {
                "REKOR", "TEE", "DIRSEK", "REDUKSIYON", "DIGER"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sdMaterialId, "SD_MATERIAL", new List<string>
            {
                "CELIK", "PASLANMAZ", "ALUMINYUM", "PIRINC", "POLIETILEN", "BRONZ", "GALVANIZ"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sdStandardId, "SD_STANDARD", new List<string>
            {
                "DIN", "ISO", "ASTM", "BSP", "NPT"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(connectionSizeId, "CONNECTION_SIZE", new List<string>
            {
                "1/8", "1/4", "3/8", "1/2", "3/4", "1", "1.1/4", "1.1/2", "2", "2.1/2", "3", "4"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(angleId, "ANGLE", new List<string>
            {
                "90", "45", "straight"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sdCoatingId, "SD_COATING", new List<string>
            {
                "GALVANIZ", "CINKO", "-"
            }, cancellationToken);

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var sdProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // SDA0: HİDROLİK REKOR
                ("SDA0", connectionTypeId, true,  FV("CONNECTION_TYPE", "REKOR")),
                ("SDA0", sdMaterialId,     false, null),
                ("SDA0", connectionSizeId, false, null),
                ("SDA0", sdStandardId,     false, null),
                ("SDA0", sdCoatingId,      false, null),
                // SDA1: HİDROLİK TEE
                ("SDA1", connectionTypeId, true,  FV("CONNECTION_TYPE", "TEE")),
                ("SDA1", sdMaterialId,     false, null),
                ("SDA1", connectionSizeId, false, null),
                ("SDA1", sdStandardId,     false, null),
                ("SDA1", sdCoatingId,      false, null),
                // SDA2: HİDROLİK DİRSEK
                ("SDA2", connectionTypeId, true,  FV("CONNECTION_TYPE", "DIRSEK")),
                ("SDA2", sdMaterialId,     false, null),
                ("SDA2", connectionSizeId, false, null),
                ("SDA2", sdStandardId,     false, null),
                ("SDA2", sdCoatingId,      false, null),
                // SDA3: HİDROLİK REDÜKSİYON
                ("SDA3", connectionTypeId, true,  FV("CONNECTION_TYPE", "REDUKSIYON")),
                ("SDA3", sdMaterialId,     false, null),
                ("SDA3", connectionSizeId, false, null),
                ("SDA3", sdStandardId,     false, null),
                ("SDA3", sdCoatingId,      false, null),
            };

            // All remaining SD products: all features dynamic
            var specificSdCodes = new HashSet<string> { "SDA0", "SDA1", "SDA2", "SDA3" };
            var allSdCodes = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SD"))
                .Select(p => p.Code)
                .ToListAsync(cancellationToken);

            foreach (var code in allSdCodes.Where(c => !specificSdCodes.Contains(c)))
            {
                sdProductRules.Add((code, connectionTypeId, false, null));
                sdProductRules.Add((code, sdMaterialId,     false, null));
                sdProductRules.Add((code, connectionSizeId, false, null));
                sdProductRules.Add((code, sdStandardId,     false, null));
                sdProductRules.Add((code, sdCoatingId,      false, null));
            }

            await EnsureFixedProductFeatureRulesAsync(sdProductRules, cancellationToken);

            var sdProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SD"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (sdProductIds.Count == 0) return;

            await EnsureFeatureValueRulesAsync(sdProductIds, connectionSizeId, "CONNECTION_SIZE", cancellationToken);
        }

        /// <summary>
        /// SE: Elektrik Malzemeleri için feature value'ları ve SProductFeatureRule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncSeAsync(CancellationToken cancellationToken)
        {
            var categoryId     = SeedId.From("SFeature:PRODUCT_CATEGORY");
            var seMaterialId   = SeedId.From("SFeature:SE_MATERIAL");
            var crossSectionId = SeedId.From("SFeature:CROSS_SECTION");
            var voltageId      = SeedId.From("SFeature:VOLTAGE");
            var seStandardId   = SeedId.From("SFeature:SE_STANDARD");
            var colorTypeId    = SeedId.From("SFeature:COLOR_TYPE");

            await EnsureFeatureValuesAsync(categoryId, "PRODUCT_CATEGORY", new List<string>
            {
                "KABLO", "AKU", "SIGORTA", "SALTER", "ROLE", "KONNEKTOR", "AMPUL", "TERMINAL", "MAKARON", "MOTOR", "SENSOR", "DIGER"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(seMaterialId, "SE_MATERIAL", new List<string>
            {
                "BAKIR", "ALUMINYUM", "PVC", "XLPE", "SILIKON"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(crossSectionId, "CROSS_SECTION", new List<string>
            {
                "0.5", "0.75", "1", "1.5", "2.5", "4", "6", "10", "16", "25", "35", "50", "70", "95", "120"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(voltageId, "VOLTAGE", new List<string>
            {
                "12V", "24V", "48V", "220V", "380V"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(seStandardId, "SE_STANDARD", new List<string>
            {
                "TSE", "IEC", "DIN", "ISO"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(colorTypeId, "COLOR_TYPE", new List<string>
            {
                "SIYAH", "KIRMIZI", "MAVI", "SARI", "YESIL", "BEYAZ", "GRI"
            }, cancellationToken);

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var seProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // SEA0: KABLO TESİSAT
                ("SEA0", categoryId,     true,  FV("PRODUCT_CATEGORY", "KABLO")),
                ("SEA0", seMaterialId,   false, null),
                ("SEA0", crossSectionId, false, null),
                ("SEA0", voltageId,      false, null),
                ("SEA0", colorTypeId,    false, null),
                // SEA1: KABLO AKÜ
                ("SEA1", categoryId,     true,  FV("PRODUCT_CATEGORY", "KABLO")),
                ("SEA1", seMaterialId,   false, null),
                ("SEA1", crossSectionId, false, null),
                ("SEA1", voltageId,      false, null),
                ("SEA1", colorTypeId,    false, null),
                // SEA2: KABLO TTR
                ("SEA2", categoryId,     true,  FV("PRODUCT_CATEGORY", "KABLO")),
                ("SEA2", seMaterialId,   false, null),
                ("SEA2", crossSectionId, false, null),
                ("SEA2", voltageId,      false, null),
                ("SEA2", colorTypeId,    false, null),
                // SEA3: BAKIR KALAY KAPLI KABLO
                ("SEA3", categoryId,     true,  FV("PRODUCT_CATEGORY", "KABLO")),
                ("SEA3", seMaterialId,   false, null),
                ("SEA3", crossSectionId, false, null),
                ("SEA3", voltageId,      false, null),
                ("SEA3", colorTypeId,    false, null),
                // SEA4: AKÜ
                ("SEA4", categoryId,     true,  FV("PRODUCT_CATEGORY", "AKU")),
                ("SEA4", seMaterialId,   false, null),
                ("SEA4", crossSectionId, false, null),
                ("SEA4", voltageId,      false, null),
                ("SEA4", colorTypeId,    false, null),
                // SEA5: SİGORTA
                ("SEA5", categoryId,     true,  FV("PRODUCT_CATEGORY", "SIGORTA")),
                ("SEA5", seMaterialId,   false, null),
                ("SEA5", crossSectionId, false, null),
                ("SEA5", voltageId,      false, null),
                ("SEA5", colorTypeId,    false, null),
                // SEA6: ŞALTER
                ("SEA6", categoryId,     true,  FV("PRODUCT_CATEGORY", "SALTER")),
                ("SEA6", seMaterialId,   false, null),
                ("SEA6", crossSectionId, false, null),
                ("SEA6", voltageId,      false, null),
                ("SEA6", colorTypeId,    false, null),
                // SEA7: RÖLE
                ("SEA7", categoryId,     true,  FV("PRODUCT_CATEGORY", "ROLE")),
                ("SEA7", seMaterialId,   false, null),
                ("SEA7", crossSectionId, false, null),
                ("SEA7", voltageId,      false, null),
                ("SEA7", colorTypeId,    false, null),
                // SEA8: KONNEKTÖR & SOKET
                ("SEA8", categoryId,     true,  FV("PRODUCT_CATEGORY", "KONNEKTOR")),
                ("SEA8", seMaterialId,   false, null),
                ("SEA8", crossSectionId, false, null),
                ("SEA8", voltageId,      false, null),
                ("SEA8", colorTypeId,    false, null),
                // SEA9: DİYOT
                ("SEA9", categoryId,     true,  FV("PRODUCT_CATEGORY", "DIGER")),
                ("SEA9", seMaterialId,   false, null),
                ("SEA9", crossSectionId, false, null),
                ("SEA9", voltageId,      false, null),
                ("SEA9", colorTypeId,    false, null),
            };

            // All remaining SE products (SEAA and beyond): all dynamic
            var specificSeCodes = new HashSet<string> { "SEA0", "SEA1", "SEA2", "SEA3", "SEA4", "SEA5", "SEA6", "SEA7", "SEA8", "SEA9" };
            var allSeCodes = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SE"))
                .Select(p => p.Code)
                .ToListAsync(cancellationToken);

            foreach (var code in allSeCodes.Where(c => !specificSeCodes.Contains(c)))
            {
                seProductRules.Add((code, categoryId,     false, null));
                seProductRules.Add((code, seMaterialId,   false, null));
                seProductRules.Add((code, crossSectionId, false, null));
                seProductRules.Add((code, voltageId,      false, null));
                seProductRules.Add((code, colorTypeId,    false, null));
            }

            await EnsureFixedProductFeatureRulesAsync(seProductRules, cancellationToken);

            var seProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SE"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (seProductIds.Count == 0) return;

            await EnsureFeatureValueRulesAsync(seProductIds, crossSectionId, "CROSS_SECTION", cancellationToken);
            await EnsureFeatureValueRulesAsync(seProductIds, voltageId, "VOLTAGE", cancellationToken);
        }

        /// <summary>
        /// SF: Vanalar, Pompalar ve Aksesuarlar için feature value'ları ve SProductFeatureRule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncSfAsync(CancellationToken cancellationToken)
        {
            var akisMedyumuId  = SeedId.From("SFeature:SF_AKIS_MEDYUMU");
            var markaId        = SeedId.From("SFeature:SF_MARKA");
            var vanaTipiId     = SeedId.From("SFeature:SF_VANA_TIPI");
            var aktuatorId     = SeedId.From("SFeature:SF_AKTUATOR");
            var dnId           = SeedId.From("SFeature:SF_DN");
            var basincSinifiId = SeedId.From("SFeature:SF_BASINC_SINIFI");
            var baglantiTipiId = SeedId.From("SFeature:SF_BAGLANTI_TIPI");
            var malzemeId      = SeedId.From("SFeature:SF_MALZEME");
            var ayarBasinciId  = SeedId.From("SFeature:SF_AYAR_BASINCI");
            var girisBasinciId = SeedId.From("SFeature:SF_GIRIS_BASINCI");
            var cikisBasinciId = SeedId.From("SFeature:SF_CIKIS_BASINCI");
            var baglantiCapiId = SeedId.From("SFeature:SF_BAGLANTI_CAPI");
            var olcumTipiId    = SeedId.From("SFeature:SF_OLCUM_TIPI");
            var cikisSinyaliId = SeedId.From("SFeature:SF_CIKIS_SINYALI");
            var valfTipiId     = SeedId.From("SFeature:SF_VALF_TIPI");
            var sayacTipiId    = SeedId.From("SFeature:SF_SAYAC_TIPI");
            var goznekId       = SeedId.From("SFeature:SF_GOZNEK");
            var pompaTipiId    = SeedId.From("SFeature:SF_POMPA_TIPI");
            var gucKwId        = SeedId.From("SFeature:SF_GUC_KW");
            var adaptorTipiId  = SeedId.From("SFeature:SF_ADAPTOR_TIPI");
            var baglanti1Id    = SeedId.From("SFeature:SF_BAGLANTI_1");
            var baglanti2Id    = SeedId.From("SFeature:SF_BAGLANTI_2");
            var capiMmId       = SeedId.From("SFeature:SF_CAPI_MM");
            var olcumAraligiId = SeedId.From("SFeature:SF_OLCUM_ARALIGI");
            var manomTipiId    = SeedId.From("SFeature:SF_MANOMETRE_TIPI");
            var daldirmaId     = SeedId.From("SFeature:SF_DALDIRMA_BOYU");
            var contaTipiId    = SeedId.From("SFeature:SF_CONTA_TIPI");
            var tipId          = SeedId.From("SFeature:SF_TIP");
            var kapasiteId     = SeedId.From("SFeature:SF_KAPASITE");

            await EnsureFeatureValuesAsync(akisMedyumuId, "SF_AKIS_MEDYUMU", new List<string>
            {
                "LPG", "Cryogenic", "Akaryakıt", "Su", "Hidrolik", "Pnömatik", "Doğal Gaz", "Kimyasal", "Proses Gaz", "Diğer"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(dnId, "SF_DN", new List<string>
            {
                "DN15", "DN20", "DN25", "DN32", "DN40", "DN50", "DN65", "DN80", "DN100", "DN125", "DN150", "DN200"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(basincSinifiId, "SF_BASINC_SINIFI", new List<string>
            {
                "PN10", "PN16", "PN25", "PN40", "Class150", "Class300"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(baglantiTipiId, "SF_BAGLANTI_TIPI", new List<string>
            {
                "Flanşlı", "Vidalı", "Kaynaklı", "Flanşsız"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(malzemeId, "SF_MALZEME", new List<string>
            {
                "Dökme Demir", "Sfero Döküm", "Paslanmaz 316", "Pirinç", "Bronz", "Karbon Çelik"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(markaId,        "SF_MARKA",         new List<string> { "GENEL" }, cancellationToken);
            await EnsureFeatureValuesAsync(vanaTipiId,     "SF_VANA_TIPI",     new List<string> { "Küresel", "Kelebek", "Sürgülü", "İğne", "Çek", "Pistonlu" }, cancellationToken);
            await EnsureFeatureValuesAsync(aktuatorId,     "SF_AKTUATOR",      new List<string> { "Manuel", "Pnömatik", "Elektrikli", "Hidrolik" }, cancellationToken);
            await EnsureFeatureValuesAsync(pompaTipiId,    "SF_POMPA_TIPI",    new List<string> { "Santrifüj", "Dişli", "Dalgıç", "Pistonlu", "Vidalı" }, cancellationToken);
            await EnsureFeatureValuesAsync(gucKwId, "SF_GUC_KW", new List<string>
            {
                "0.37", "0.55", "0.75", "1.1", "1.5", "2.2", "3", "4", "5.5", "7.5", "11", "15", "18.5", "22", "30", "37", "45", "55", "75"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(tipId,          "SF_TIP",           new List<string> { "Standart", "Özel" }, cancellationToken);
            await EnsureFeatureValuesAsync(kapasiteId,     "SF_KAPASITE",      new List<string> { "50L", "100L", "200L", "500L", "1000L", "2000L", "5000L" }, cancellationToken);
            await EnsureFeatureValuesAsync(sayacTipiId,    "SF_SAYAC_TIPI",    new List<string> { "Hacimsel", "Türbin", "Manyetik", "Ultrasonik" }, cancellationToken);
            await EnsureFeatureValuesAsync(valfTipiId,     "SF_VALF_TIPI",     new List<string> { "Aşırı Akış", "Geri Dönüş", "Bypass" }, cancellationToken);
            await EnsureFeatureValuesAsync(cikisSinyaliId, "SF_CIKIS_SINYALI", new List<string> { "4-20mA", "0-10V", "Puls", "Modbus", "Hart" }, cancellationToken);
            await EnsureFeatureValuesAsync(olcumTipiId,    "SF_OLCUM_TIPI",    new List<string> { "Şamandıra", "Manyetik", "Ultrasonik", "Basınçlı" }, cancellationToken);
            await EnsureFeatureValuesAsync(goznekId,       "SF_GOZNEK",        new List<string> { "50 mikron", "100 mikron", "200 mikron", "500 mikron" }, cancellationToken);
            await EnsureFeatureValuesAsync(adaptorTipiId,  "SF_ADAPTOR_TIPI",  new List<string> { "Male-Male", "Male-Female", "Female-Female" }, cancellationToken);
            await EnsureFeatureValuesAsync(baglanti1Id,    "SF_BAGLANTI_1",    new List<string> { "BSP 1/4", "BSP 1/2", "BSP 3/4", "BSP 1", "NPT 1/4", "NPT 1/2", "NPT 3/4", "NPT 1" }, cancellationToken);
            await EnsureFeatureValuesAsync(baglanti2Id,    "SF_BAGLANTI_2",    new List<string> { "BSP 1/4", "BSP 1/2", "BSP 3/4", "BSP 1", "NPT 1/4", "NPT 1/2", "NPT 3/4", "NPT 1" }, cancellationToken);
            await EnsureFeatureValuesAsync(capiMmId,       "SF_CAPI_MM",       new List<string> { "40", "50", "63", "80", "100" }, cancellationToken);
            await EnsureFeatureValuesAsync(olcumAraligiId, "SF_OLCUM_ARALIGI", new List<string> { "-60/+60", "0/100", "0/160", "0/250", "0/400", "0/600" }, cancellationToken);
            await EnsureFeatureValuesAsync(manomTipiId,    "SF_MANOMETRE_TIPI",new List<string> { "Kuru", "Gliserinli", "Dijital" }, cancellationToken);
            await EnsureFeatureValuesAsync(daldirmaId,     "SF_DALDIRMA_BOYU", new List<string> { "100mm", "150mm", "200mm", "250mm", "300mm" }, cancellationToken);
            await EnsureFeatureValuesAsync(contaTipiId,    "SF_CONTA_TIPI",    new List<string> { "EPDM", "NBR", "PTFE", "Spiral" }, cancellationToken);
            await EnsureFeatureValuesAsync(ayarBasinciId,  "SF_AYAR_BASINCI",  new List<string> { "0.5", "1", "2", "3", "5", "7", "10", "12", "16", "20", "25" }, cancellationToken);
            await EnsureFeatureValuesAsync(girisBasinciId, "SF_GIRIS_BASINCI", new List<string> { "1", "2", "3", "5", "10", "16" }, cancellationToken);
            await EnsureFeatureValuesAsync(cikisBasinciId, "SF_CIKIS_BASINCI", new List<string> { "0.5", "1", "2", "3", "5", "10" }, cancellationToken);
            await EnsureFeatureValuesAsync(baglantiCapiId, "SF_BAGLANTI_CAPI", new List<string> { "1/4", "3/8", "1/2", "3/4", "1", "1.1/4", "1.1/2", "2" }, cancellationToken);

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var sfProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // ===== VANALAR =====
                // SFA0 → LPG Vana
                ("SFA0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA0", vanaTipiId,     false, null), ("SFA0", aktuatorId,     false, null),
                ("SFA0", dnId,           false, null), ("SFA0", basincSinifiId, false, null),
                ("SFA0", baglantiTipiId, false, null), ("SFA0", malzemeId,      false, null),
                ("SFA0", markaId,        false, null),
                // SFC0 → Cryogenic Vana
                ("SFC0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC0", vanaTipiId,     false, null), ("SFC0", aktuatorId,     false, null),
                ("SFC0", dnId,           false, null), ("SFC0", basincSinifiId, false, null),
                ("SFC0", baglantiTipiId, false, null), ("SFC0", malzemeId,      false, null),
                ("SFC0", markaId,        false, null),
                // SFF0 → Akaryakıt Vana
                ("SFF0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF0", vanaTipiId,     false, null), ("SFF0", aktuatorId,     false, null),
                ("SFF0", dnId,           false, null), ("SFF0", basincSinifiId, false, null),
                ("SFF0", baglantiTipiId, false, null), ("SFF0", malzemeId,      false, null),
                ("SFF0", markaId,        false, null),
                // SFG0 → Su Vana
                ("SFG0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Su")),
                ("SFG0", vanaTipiId,     false, null), ("SFG0", aktuatorId,     false, null),
                ("SFG0", dnId,           false, null), ("SFG0", basincSinifiId, false, null),
                ("SFG0", baglantiTipiId, false, null), ("SFG0", malzemeId,      false, null),
                ("SFG0", markaId,        false, null),
                // SFG1 → Hidrolik Vana
                ("SFG1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Hidrolik")),
                ("SFG1", vanaTipiId,     false, null), ("SFG1", aktuatorId,     false, null),
                ("SFG1", dnId,           false, null), ("SFG1", basincSinifiId, false, null),
                ("SFG1", baglantiTipiId, false, null), ("SFG1", malzemeId,      false, null),
                ("SFG1", markaId,        false, null),
                // SFG7 → Pnömatik Vana
                ("SFG7", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Pnömatik")),
                ("SFG7", vanaTipiId,     false, null), ("SFG7", aktuatorId,     false, null),
                ("SFG7", dnId,           false, null), ("SFG7", basincSinifiId, false, null),
                ("SFG7", baglantiTipiId, false, null), ("SFG7", malzemeId,      false, null),
                ("SFG7", markaId,        false, null),
                // SFJ0 → Doğal Gaz Vana
                ("SFJ0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ0", vanaTipiId,     false, null), ("SFJ0", aktuatorId,     false, null),
                ("SFJ0", dnId,           false, null), ("SFJ0", basincSinifiId, false, null),
                ("SFJ0", baglantiTipiId, false, null), ("SFJ0", malzemeId,      false, null),
                ("SFJ0", markaId,        false, null),
                // SFK0 → Kimyasal Vana
                ("SFK0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK0", vanaTipiId,     false, null), ("SFK0", aktuatorId,     false, null),
                ("SFK0", dnId,           false, null), ("SFK0", basincSinifiId, false, null),
                ("SFK0", baglantiTipiId, false, null), ("SFK0", malzemeId,      false, null),
                ("SFK0", markaId,        false, null),
                // SFL0 → Proses Gaz Vana
                ("SFL0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Proses Gaz")),
                ("SFL0", vanaTipiId,     false, null), ("SFL0", aktuatorId,     false, null),
                ("SFL0", dnId,           false, null), ("SFL0", basincSinifiId, false, null),
                ("SFL0", baglantiTipiId, false, null), ("SFL0", malzemeId,      false, null),
                ("SFL0", markaId,        false, null),

                // ===== EMNİYET / RELIEF =====
                // SFA1 → LPG
                ("SFA1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA1", dnId,           false, null), ("SFA1", ayarBasinciId,  false, null),
                ("SFA1", baglantiTipiId, false, null), ("SFA1", malzemeId,      false, null),
                ("SFA1", markaId,        false, null),
                // SFC1 → Cryogenic
                ("SFC1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC1", dnId,           false, null), ("SFC1", ayarBasinciId,  false, null),
                ("SFC1", baglantiTipiId, false, null), ("SFC1", malzemeId,      false, null),
                ("SFC1", markaId,        false, null),
                // SFF1 → Akaryakıt
                ("SFF1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF1", dnId,           false, null), ("SFF1", ayarBasinciId,  false, null),
                ("SFF1", baglantiTipiId, false, null), ("SFF1", malzemeId,      false, null),
                ("SFF1", markaId,        false, null),
                // SFJ1 → Doğal Gaz
                ("SFJ1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ1", dnId,           false, null), ("SFJ1", ayarBasinciId,  false, null),
                ("SFJ1", baglantiTipiId, false, null), ("SFJ1", malzemeId,      false, null),
                ("SFJ1", markaId,        false, null),
                // SFK1 → Kimyasal
                ("SFK1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK1", dnId,           false, null), ("SFK1", ayarBasinciId,  false, null),
                ("SFK1", baglantiTipiId, false, null), ("SFK1", malzemeId,      false, null),
                ("SFK1", markaId,        false, null),
                // SFL1 → Proses Gaz
                ("SFL1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Proses Gaz")),
                ("SFL1", dnId,           false, null), ("SFL1", ayarBasinciId,  false, null),
                ("SFL1", baglantiTipiId, false, null), ("SFL1", malzemeId,      false, null),
                ("SFL1", markaId,        false, null),

                // ===== REGÜLATÖRLER =====
                // SFA2 → LPG
                ("SFA2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA2", girisBasinciId, false, null), ("SFA2", cikisBasinciId, false, null),
                ("SFA2", baglantiCapiId, false, null), ("SFA2", malzemeId,      false, null),
                ("SFA2", markaId,        false, null),
                // SFC2 → Cryogenic
                ("SFC2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC2", girisBasinciId, false, null), ("SFC2", cikisBasinciId, false, null),
                ("SFC2", baglantiCapiId, false, null), ("SFC2", malzemeId,      false, null),
                ("SFC2", markaId,        false, null),
                // SFF2 → Akaryakıt
                ("SFF2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF2", girisBasinciId, false, null), ("SFF2", cikisBasinciId, false, null),
                ("SFF2", baglantiCapiId, false, null), ("SFF2", malzemeId,      false, null),
                ("SFF2", markaId,        false, null),
                // SFJ2 → Doğal Gaz
                ("SFJ2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ2", girisBasinciId, false, null), ("SFJ2", cikisBasinciId, false, null),
                ("SFJ2", baglantiCapiId, false, null), ("SFJ2", malzemeId,      false, null),
                ("SFJ2", markaId,        false, null),
                // SFK2 → Kimyasal
                ("SFK2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK2", girisBasinciId, false, null), ("SFK2", cikisBasinciId, false, null),
                ("SFK2", baglantiCapiId, false, null), ("SFK2", malzemeId,      false, null),
                ("SFK2", markaId,        false, null),
                // SFL2 → Proses Gaz
                ("SFL2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Proses Gaz")),
                ("SFL2", girisBasinciId, false, null), ("SFL2", cikisBasinciId, false, null),
                ("SFL2", baglantiCapiId, false, null), ("SFL2", malzemeId,      false, null),
                ("SFL2", markaId,        false, null),

                // ===== SEVİYE / ÖLÇÜM =====
                // SFA3 → LPG
                ("SFA3", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA3", olcumTipiId,    false, null), ("SFA3", cikisSinyaliId, false, null),
                ("SFA3", baglantiCapiId, false, null), ("SFA3", malzemeId,      false, null),
                ("SFA3", markaId,        false, null),
                // SFC3 → Cryogenic
                ("SFC3", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC3", olcumTipiId,    false, null), ("SFC3", cikisSinyaliId, false, null),
                ("SFC3", baglantiCapiId, false, null), ("SFC3", malzemeId,      false, null),
                ("SFC3", markaId,        false, null),
                // SFF3 → Akaryakıt
                ("SFF3", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF3", olcumTipiId,    false, null), ("SFF3", cikisSinyaliId, false, null),
                ("SFF3", baglantiCapiId, false, null), ("SFF3", malzemeId,      false, null),
                ("SFF3", markaId,        false, null),
                // SFJ3 → Doğal Gaz
                ("SFJ3", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ3", olcumTipiId,    false, null), ("SFJ3", cikisSinyaliId, false, null),
                ("SFJ3", baglantiCapiId, false, null), ("SFJ3", malzemeId,      false, null),
                ("SFJ3", markaId,        false, null),
                // SFK3 → Kimyasal
                ("SFK3", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK3", olcumTipiId,    false, null), ("SFK3", cikisSinyaliId, false, null),
                ("SFK3", baglantiCapiId, false, null), ("SFK3", malzemeId,      false, null),
                ("SFK3", markaId,        false, null),

                // ===== AŞIRI AKIŞ =====
                // SFA4 → LPG
                ("SFA4", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA4", valfTipiId,     false, null), ("SFA4", dnId,           false, null),
                ("SFA4", basincSinifiId, false, null), ("SFA4", baglantiTipiId, false, null),
                ("SFA4", malzemeId,      false, null), ("SFA4", markaId,        false, null),
                // SFC4 → Cryogenic
                ("SFC4", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC4", valfTipiId,     false, null), ("SFC4", dnId,           false, null),
                ("SFC4", basincSinifiId, false, null), ("SFC4", baglantiTipiId, false, null),
                ("SFC4", malzemeId,      false, null), ("SFC4", markaId,        false, null),
                // SFF4 → Akaryakıt
                ("SFF4", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF4", valfTipiId,     false, null), ("SFF4", dnId,           false, null),
                ("SFF4", basincSinifiId, false, null), ("SFF4", baglantiTipiId, false, null),
                ("SFF4", malzemeId,      false, null), ("SFF4", markaId,        false, null),
                // SFJ4 → Doğal Gaz
                ("SFJ4", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ4", valfTipiId,     false, null), ("SFJ4", dnId,           false, null),
                ("SFJ4", basincSinifiId, false, null), ("SFJ4", baglantiTipiId, false, null),
                ("SFJ4", malzemeId,      false, null), ("SFJ4", markaId,        false, null),
                // SFK4 → Kimyasal
                ("SFK4", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK4", valfTipiId,     false, null), ("SFK4", dnId,           false, null),
                ("SFK4", basincSinifiId, false, null), ("SFK4", baglantiTipiId, false, null),
                ("SFK4", malzemeId,      false, null), ("SFK4", markaId,        false, null),

                // ===== SAYAÇLAR =====
                // SFA5 → LPG
                ("SFA5", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA5", sayacTipiId,    false, null), ("SFA5", dnId,           false, null),
                ("SFA5", basincSinifiId, false, null), ("SFA5", cikisSinyaliId, false, null),
                ("SFA5", markaId,        false, null),
                // SFC5 → Cryogenic
                ("SFC5", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC5", sayacTipiId,    false, null), ("SFC5", dnId,           false, null),
                ("SFC5", basincSinifiId, false, null), ("SFC5", cikisSinyaliId, false, null),
                ("SFC5", markaId,        false, null),
                // SFF5 → Akaryakıt
                ("SFF5", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF5", sayacTipiId,    false, null), ("SFF5", dnId,           false, null),
                ("SFF5", basincSinifiId, false, null), ("SFF5", cikisSinyaliId, false, null),
                ("SFF5", markaId,        false, null),
                // SFG9 → Su Sayaç
                ("SFG9", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Su")),
                ("SFG9", sayacTipiId,    false, null), ("SFG9", dnId,           false, null),
                ("SFG9", basincSinifiId, false, null), ("SFG9", cikisSinyaliId, false, null),
                ("SFG9", markaId,        false, null),
                // SFJ5 → Doğal Gaz
                ("SFJ5", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ5", sayacTipiId,    false, null), ("SFJ5", dnId,           false, null),
                ("SFJ5", basincSinifiId, false, null), ("SFJ5", cikisSinyaliId, false, null),
                ("SFJ5", markaId,        false, null),
                // SFK5 → Kimyasal
                ("SFK5", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK5", sayacTipiId,    false, null), ("SFK5", dnId,           false, null),
                ("SFK5", basincSinifiId, false, null), ("SFK5", cikisSinyaliId, false, null),
                ("SFK5", markaId,        false, null),

                // ===== FİLTRELER =====
                // SFA6 → LPG
                ("SFA6", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA6", dnId,           false, null), ("SFA6", basincSinifiId, false, null),
                ("SFA6", goznekId,       false, null), ("SFA6", baglantiTipiId, false, null),
                ("SFA6", malzemeId,      false, null), ("SFA6", markaId,        false, null),
                // SFC6 → Cryogenic
                ("SFC6", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC6", dnId,           false, null), ("SFC6", basincSinifiId, false, null),
                ("SFC6", goznekId,       false, null), ("SFC6", baglantiTipiId, false, null),
                ("SFC6", malzemeId,      false, null), ("SFC6", markaId,        false, null),
                // SFF6 → Akaryakıt
                ("SFF6", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF6", dnId,           false, null), ("SFF6", basincSinifiId, false, null),
                ("SFF6", goznekId,       false, null), ("SFF6", baglantiTipiId, false, null),
                ("SFF6", malzemeId,      false, null), ("SFF6", markaId,        false, null),
                // SFJ6 → Doğal Gaz
                ("SFJ6", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ6", dnId,           false, null), ("SFJ6", basincSinifiId, false, null),
                ("SFJ6", goznekId,       false, null), ("SFJ6", baglantiTipiId, false, null),
                ("SFJ6", malzemeId,      false, null), ("SFJ6", markaId,        false, null),
                // SFK6 → Kimyasal
                ("SFK6", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK6", dnId,           false, null), ("SFK6", basincSinifiId, false, null),
                ("SFK6", goznekId,       false, null), ("SFK6", baglantiTipiId, false, null),
                ("SFK6", malzemeId,      false, null), ("SFK6", markaId,        false, null),

                // ===== POMPALAR =====
                // SFA7 → LPG
                ("SFA7", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA7", pompaTipiId,    false, null), ("SFA7", gucKwId,        false, null),
                ("SFA7", cikisBasinciId, false, null), ("SFA7", dnId,           false, null),
                ("SFA7", markaId,        false, null),
                // SFC7 → Cryogenic
                ("SFC7", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC7", pompaTipiId,    false, null), ("SFC7", gucKwId,        false, null),
                ("SFC7", cikisBasinciId, false, null), ("SFC7", dnId,           false, null),
                ("SFC7", markaId,        false, null),
                // SFF7 → Akaryakıt
                ("SFF7", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF7", pompaTipiId,    false, null), ("SFF7", gucKwId,        false, null),
                ("SFF7", cikisBasinciId, false, null), ("SFF7", dnId,           false, null),
                ("SFF7", markaId,        false, null),
                // SFG8 → Su Pompa
                ("SFG8", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Su")),
                ("SFG8", pompaTipiId,    false, null), ("SFG8", gucKwId,        false, null),
                ("SFG8", cikisBasinciId, false, null), ("SFG8", dnId,           false, null),
                ("SFG8", markaId,        false, null),
                // SFH5 → Diğer Pompa
                ("SFH5", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Diğer")),
                ("SFH5", pompaTipiId,    false, null), ("SFH5", gucKwId,        false, null),
                ("SFH5", cikisBasinciId, false, null), ("SFH5", dnId,           false, null),
                ("SFH5", markaId,        false, null),
                // SFJ7 → Doğal Gaz
                ("SFJ7", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ7", pompaTipiId,    false, null), ("SFJ7", gucKwId,        false, null),
                ("SFJ7", cikisBasinciId, false, null), ("SFJ7", dnId,           false, null),
                ("SFJ7", markaId,        false, null),
                // SFK7 → Kimyasal
                ("SFK7", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK7", pompaTipiId,    false, null), ("SFK7", gucKwId,        false, null),
                ("SFK7", cikisBasinciId, false, null), ("SFK7", dnId,           false, null),
                ("SFK7", markaId,        false, null),

                // ===== ADAPTÖRLER =====
                // SFA8 → LPG
                ("SFA8", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFA8", adaptorTipiId,  false, null), ("SFA8", baglanti1Id,    false, null),
                ("SFA8", baglanti2Id,    false, null), ("SFA8", malzemeId,      false, null),
                ("SFA8", markaId,        false, null),
                // SFC8 → Cryogenic
                ("SFC8", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Cryogenic")),
                ("SFC8", adaptorTipiId,  false, null), ("SFC8", baglanti1Id,    false, null),
                ("SFC8", baglanti2Id,    false, null), ("SFC8", malzemeId,      false, null),
                ("SFC8", markaId,        false, null),
                // SFF8 → Akaryakıt
                ("SFF8", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF8", adaptorTipiId,  false, null), ("SFF8", baglanti1Id,    false, null),
                ("SFF8", baglanti2Id,    false, null), ("SFF8", malzemeId,      false, null),
                ("SFF8", markaId,        false, null),
                // SFJ8 → Doğal Gaz
                ("SFJ8", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Doğal Gaz")),
                ("SFJ8", adaptorTipiId,  false, null), ("SFJ8", baglanti1Id,    false, null),
                ("SFJ8", baglanti2Id,    false, null), ("SFJ8", malzemeId,      false, null),
                ("SFJ8", markaId,        false, null),
                // SFK8 → Kimyasal
                ("SFK8", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Kimyasal")),
                ("SFK8", adaptorTipiId,  false, null), ("SFK8", baglanti1Id,    false, null),
                ("SFK8", baglanti2Id,    false, null), ("SFK8", malzemeId,      false, null),
                ("SFK8", markaId,        false, null),

                // ===== AKSESUARLAR =====
                ("SFA9", tipId,          false, null), ("SFA9", malzemeId,      false, null), ("SFA9", markaId, false, null),
                ("SFK9", tipId,          false, null), ("SFK9", malzemeId,      false, null), ("SFK9", markaId, false, null),

                // ===== MENHOL KAPA =====
                ("SFF9", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "Akaryakıt")),
                ("SFF9", tipId,          false, null), ("SFF9", dnId,           false, null),
                ("SFF9", malzemeId,      false, null), ("SFF9", markaId,        false, null),

                // ===== MANOMETRE =====
                ("SFG4", capiMmId,       false, null), ("SFG4", olcumAraligiId, false, null),
                ("SFG4", baglantiTipiId, false, null), ("SFG4", manomTipiId,    false, null),
                ("SFG4", markaId,        false, null),

                // ===== TERMOMETRE =====
                ("SFG5", capiMmId,       false, null), ("SFG5", olcumAraligiId, false, null),
                ("SFG5", daldirmaId,     false, null), ("SFG5", baglantiTipiId, false, null),
                ("SFG5", markaId,        false, null),

                // ===== CONTALAR =====
                ("SFG6", contaTipiId,    false, null), ("SFG6", dnId,           false, null),
                ("SFG6", basincSinifiId, false, null), ("SFG6", malzemeId,      false, null),

                // ===== TOPRAKLAMA =====
                ("SFG2", tipId,          false, null), ("SFG2", kapasiteId,     false, null), ("SFG2", malzemeId, false, null),

                // ===== HORTUM MAKARASI =====
                ("SFG3", tipId,          false, null), ("SFG3", kapasiteId,     false, null), ("SFG3", baglantiCapiId, false, null),

                // ===== AIR COMPRESSORS =====
                ("SFH3", pompaTipiId,    false, null), ("SFH3", gucKwId,        false, null),
                ("SFH3", cikisBasinciId, false, null), ("SFH3", kapasiteId,     false, null),
                ("SFH3", markaId,        false, null),

                // ===== FANLAR =====
                ("SFH4", tipId,          false, null), ("SFH4", gucKwId,        false, null),
                ("SFH4", kapasiteId,     false, null), ("SFH4", markaId,        false, null),

                // ===== LPG CYLINDER =====
                ("SFH0", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFH0", tipId,          false, null), ("SFH0", kapasiteId,     false, null), ("SFH0", markaId, false, null),

                // ===== LPG DEDEKTÖR =====
                ("SFH1", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFH1", tipId,          false, null), ("SFH1", cikisSinyaliId, false, null), ("SFH1", markaId, false, null),

                // ===== LPG TARTISI =====
                ("SFH2", akisMedyumuId,  true,  FV("SF_AKIS_MEDYUMU", "LPG")),
                ("SFH2", tipId,          false, null), ("SFH2", kapasiteId,     false, null), ("SFH2", markaId, false, null),

                // ===== DİĞER SENSÖRLER =====
                ("SFH6", tipId,          false, null), ("SFH6", cikisSinyaliId, false, null), ("SFH6", markaId, false, null),
            };

            await EnsureFixedProductFeatureRulesAsync(sfProductRules, cancellationToken);

            var sfProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SF"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            if (sfProductIds.Count == 0) return;

            await EnsureFeatureValueRulesAsync(sfProductIds, dnId, "SF_DN", cancellationToken);
        }

        /// <summary>
        /// SG: Pim, Gresörlük, Gupilya için feature value'ları ve SProductFeatureRule kayıtlarını senkronize eder.
        /// </summary>
        private async Task SyncSgAsync(CancellationToken cancellationToken)
        {
            var sgMaterialId = SeedId.From("SFeature:SG:MATERIAL");
            var sgStandardId = SeedId.From("SFeature:SG:STANDARD");
            var sgDiameterId = SeedId.From("SFeature:SG:DIAMETER");
            var sgLengthId   = SeedId.From("SFeature:SG:LENGTH");
            var sgCoatingId  = SeedId.From("SFeature:SG:COATING");

            await EnsureFeatureValuesAsync(sgMaterialId, "SG_MATERIAL", new List<string>
            {
                "CELiK", "PASLANMAZ", "ALUMiNYUM", "PIRINC"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sgStandardId, "SG_STANDARD", new List<string>
            {
                "DIN", "ISO", "TSE"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sgDiameterId, "SG_DIAMETER", new List<string>
            {
                "3", "4", "5", "6", "8", "10", "12", "14", "16", "20", "25", "30", "35", "40", "50"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sgLengthId, "SG_LENGTH", new List<string>
            {
                "10", "15", "20", "25", "30", "35", "40", "50", "60", "70", "80", "100", "120", "150", "200"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(sgCoatingId, "SG_COATING", new List<string>
            {
                "CINKO", "GALVANIZ", "KROM", "FOSFORLAMA", "-"
            }, cancellationToken);

            var sgCodes = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SG"))
                .Select(p => p.Code)
                .ToListAsync(cancellationToken);

            if (sgCodes.Count == 0) return;

            var sgProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>();
            foreach (var code in sgCodes)
            {
                sgProductRules.Add((code, sgMaterialId, false, null));
                sgProductRules.Add((code, sgStandardId, false, null));
                sgProductRules.Add((code, sgDiameterId, false, null));
                sgProductRules.Add((code, sgLengthId,   false, null));
                sgProductRules.Add((code, sgCoatingId,  false, null));
            }

            await EnsureFixedProductFeatureRulesAsync(sgProductRules, cancellationToken);

            var sgProductIds = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith("SG"))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            await EnsureFeatureValueRulesAsync(sgProductIds, sgMaterialId, "SG_MATERIAL", cancellationToken);
            await EnsureFeatureValueRulesAsync(sgProductIds, sgStandardId, "SG_STANDARD", cancellationToken);
            await EnsureFeatureValueRulesAsync(sgProductIds, sgDiameterId, "SG_DIAMETER", cancellationToken);
            await EnsureFeatureValueRulesAsync(sgProductIds, sgLengthId,   "SG_LENGTH",   cancellationToken);
            await EnsureFeatureValueRulesAsync(sgProductIds, sgCoatingId,  "SG_COATING",  cancellationToken);
        }

        /// <summary>
        /// SH: Hortumlar, Kelepçeler, Klipsler için SFeature kayıtları, feature value'ları ve SProductFeatureRule'ları senkronize eder.
        /// </summary>
        private async Task SyncShAsync(CancellationToken cancellationToken)
        {
            var shMalzemeId = SeedId.From("SFeature:SH_MALZEME");
            var shTipId     = SeedId.From("SFeature:SH_TIP");
            var shCapiId    = SeedId.From("SFeature:SH_CAPI");
            var shBoyId     = SeedId.From("SFeature:SH_BOY");
            var shBasincId  = SeedId.From("SFeature:SH_BASINC");

            // SH SFeature kayıtlarını oluştur (yoksa)
            await EnsureSFeatureAsync(shMalzemeId, "SH_MALZEME", "Malzeme",      1, cancellationToken);
            await EnsureSFeatureAsync(shTipId,     "SH_TIP",     "Tip",          2, cancellationToken);
            await EnsureSFeatureAsync(shCapiId,    "SH_CAPI",    "Çap (mm/inç)", 3, cancellationToken);
            await EnsureSFeatureAsync(shBoyId,     "SH_BOY",     "Boy (m)",      4, cancellationToken);
            await EnsureSFeatureAsync(shBasincId,  "SH_BASINC",  "Basınç (bar)", 5, cancellationToken);

            await EnsureFeatureValuesAsync(shMalzemeId, "SH_MALZEME", new List<string>
            {
                "POLYAMID", "KAUCUK", "PVC", "PASLANMAZ", "GALVANIZ", "DIGER"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(shTipId, "SH_TIP", new List<string>
            {
                "HORTUM", "KELEPCE", "KLIPS", "KABLO_BAGI"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(shCapiId, "SH_CAPI", new List<string>
            {
                "6", "8", "10", "12", "16", "19", "25", "32", "38", "51", "63", "76", "102"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(shBoyId, "SH_BOY", new List<string>
            {
                "1", "2", "5", "10", "20", "50", "100"
            }, cancellationToken);
            await EnsureFeatureValuesAsync(shBasincId, "SH_BASINC", new List<string>
            {
                "10", "16", "25", "40", "63", "100", "250", "350", "400"
            }, cancellationToken);

            Guid FV(string fc, string vc) => SeedId.From($"SFeatureValue:{fc}:{vc}");

            var shProductRules = new List<(string ProductCode, Guid FeatureId, bool IsFixed, Guid? FixedValueId)>
            {
                // SHA0..SHA9: SH_TIP=HORTUM(sabit), others dynamic
                ("SHA0", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA0", shMalzemeId, false, null), ("SHA0", shCapiId, false, null), ("SHA0", shBoyId, false, null), ("SHA0", shBasincId, false, null),
                ("SHA1", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA1", shMalzemeId, false, null), ("SHA1", shCapiId, false, null), ("SHA1", shBoyId, false, null), ("SHA1", shBasincId, false, null),
                ("SHA2", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA2", shMalzemeId, false, null), ("SHA2", shCapiId, false, null), ("SHA2", shBoyId, false, null), ("SHA2", shBasincId, false, null),
                ("SHA3", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA3", shMalzemeId, false, null), ("SHA3", shCapiId, false, null), ("SHA3", shBoyId, false, null), ("SHA3", shBasincId, false, null),
                ("SHA4", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA4", shMalzemeId, false, null), ("SHA4", shCapiId, false, null), ("SHA4", shBoyId, false, null), ("SHA4", shBasincId, false, null),
                ("SHA5", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA5", shMalzemeId, false, null), ("SHA5", shCapiId, false, null), ("SHA5", shBoyId, false, null), ("SHA5", shBasincId, false, null),
                ("SHA6", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA6", shMalzemeId, false, null), ("SHA6", shCapiId, false, null), ("SHA6", shBoyId, false, null), ("SHA6", shBasincId, false, null),
                ("SHA7", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA7", shMalzemeId, false, null), ("SHA7", shCapiId, false, null), ("SHA7", shBoyId, false, null), ("SHA7", shBasincId, false, null),
                ("SHA8", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA8", shMalzemeId, false, null), ("SHA8", shCapiId, false, null), ("SHA8", shBoyId, false, null), ("SHA8", shBasincId, false, null),
                ("SHA9", shTipId, true, FV("SH_TIP", "HORTUM")), ("SHA9", shMalzemeId, false, null), ("SHA9", shCapiId, false, null), ("SHA9", shBoyId, false, null), ("SHA9", shBasincId, false, null),
                // SHC0, SHC5: SH_TIP=KLIPS(sabit), others dynamic
                ("SHC0", shTipId, true, FV("SH_TIP", "KLIPS")), ("SHC0", shMalzemeId, false, null), ("SHC0", shCapiId, false, null), ("SHC0", shBoyId, false, null), ("SHC0", shBasincId, false, null),
                ("SHC5", shTipId, true, FV("SH_TIP", "KLIPS")), ("SHC5", shMalzemeId, false, null), ("SHC5", shCapiId, false, null), ("SHC5", shBoyId, false, null), ("SHC5", shBasincId, false, null),
                // SHC1: SH_TIP=KELEPCE(sabit), others dynamic
                ("SHC1", shTipId, true, FV("SH_TIP", "KELEPCE")), ("SHC1", shMalzemeId, false, null), ("SHC1", shCapiId, false, null), ("SHC1", shBoyId, false, null), ("SHC1", shBasincId, false, null),
            };

            await EnsureFixedProductFeatureRulesAsync(shProductRules, cancellationToken);
        }

        /// <summary>
        /// Belirtilen ID ile bir SFeature kaydı yoksa oluşturur (idempotent).
        /// </summary>
        private async Task EnsureSFeatureAsync(Guid featureId, string code, string name, int sortOrder, CancellationToken cancellationToken)
        {
            var exists = await _db.Set<SFeature>()
                .AsNoTracking()
                .AnyAsync(f => f.Id == featureId, cancellationToken);

            if (!exists)
            {
                _db.Set<SFeature>().Add(new SFeature
                {
                    Id = featureId,
                    Code = code,
                    Name = name,
                    SortOrder = sortOrder,
                    CreatedBy = "RUNTIME_SYNC",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                });
                await _db.SaveChangesAsync(cancellationToken);
            }
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
