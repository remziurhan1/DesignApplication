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
