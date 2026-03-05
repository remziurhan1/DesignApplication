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
    /// SA/SB/SC için yüksek değişkenlik gösteren metrik/boy kataloglarını runtime'da senkronize eder.
    /// Böylece HasData migration şişmesi azaltılır.
    /// </summary>
    public class SaRuleCatalogSyncService : ISaRuleCatalogSyncService
    {
        private readonly AppDbContext _db;

        public SaRuleCatalogSyncService(AppDbContext db)
        {
            _db = db;
        }

        public async Task SyncAsync(CancellationToken cancellationToken = default)
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
    }
}
