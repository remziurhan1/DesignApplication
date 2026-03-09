using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SG;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SG
{
    public class StockCodeSgService : IStockCodeSgService
    {
        private readonly AppDbContext _db;

        private const string FEATURE_NUT_TYPE = "NUT_TYPE";
        private const string FEATURE_MATERIAL = "MATERIAL";
        private const string FEATURE_THREAD_SYSTEM = "THREAD_SYSTEM";
        private const string FEATURE_STANDARD = "STANDARD";
        private const string FEATURE_METRIC = "METRIC";
        private const string FEATURE_STRENGTH = "STRENGTH";
        private const string FEATURE_COATING = "COATING";

        public StockCodeSgService(AppDbContext db)
        {
            _db = db;
        }

        // ========== ÜRÜN LİSTESİ ==========
        public async Task<List<SgProductDto>> GetSgProductsAsync(CancellationToken ct = default)
        {
            return await _db.SProducts
                .Where(p => p.SProductGroup.Code == "G" && p.Status != Domain.Enums.Status.Deleted)
                .OrderBy(p => p.PrefixIndex)
                .Select(p => new SgProductDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name
                })
                .ToListAsync(ct);
        }

        // ========== FORM DATA (Rule-Based) ==========
        public async Task<StockCodeSgFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default)
        {
            var product = await _db.SProducts
                .FirstOrDefaultAsync(p => p.Id == productId, ct)
                ?? throw new InvalidOperationException("Ürün bulunamadı.");

            var productRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == productId)
                .OrderBy(r => r.SFeature.SortOrder)
                .ToListAsync(ct);

            var valueRules = await _db.SFeatureValueRules
                .Include(r => r.SFeatureValue)
                .Where(r => r.SProductId == productId)
                .OrderBy(r => r.SortOrder)
                .ToListAsync(ct);

            var features = new List<StockCodeSgFormFeatureDto>();

            foreach (var rule in productRules)
            {
                var feature = new StockCodeSgFormFeatureDto
                {
                    FeatureId = rule.SFeatureId,
                    FeatureCode = rule.SFeature.Code,
                    FeatureName = rule.SFeature.Name,
                    IsFixed = rule.IsFixed
                };

                if (rule.IsFixed && rule.FixedValue != null)
                {
                    feature.FixedValueId = rule.FixedValueId;
                    feature.FixedValueCode = rule.FixedValue.Code;
                    feature.FixedValueName = rule.FixedValue.Name;
                }
                else
                {
                    var sorted = FeatureValueSortHelper.SortForUi(valueRules
                        .Where(v => v.SFeatureId == rule.SFeatureId)
                        .Select(v => new FeatureValueDto
                        {
                            Id = v.SFeatureValueId,
                            Code = v.SFeatureValue.Code,
                            Name = v.SFeatureValue.Name,
                            SortOrder = v.SortOrder
                        }));

                    feature.AvailableValues = sorted
                        .Select(v => new SgFeatureValueOptionDto
                        {
                            Id = v.Id,
                            Code = v.Code,
                            Name = v.Name
                        })
                        .ToList();
                }

                features.Add(feature);
            }

            return new StockCodeSgFormDto
            {
                ProductId = product.Id,
                ProductCode = product.Code,
                ProductName = product.Name,
                Features = features
            };
        }

        public async Task<SgStockCodeGenerateResultDto> GenerateSgAsync(
    SgStockCodeGenerateRequestDto request,
    CancellationToken ct = default)
        {
            // 1️⃣ Ürünü Group ile birlikte çek
            var product = await _db.SProducts
                .Include(p => p.SProductGroup)
                .FirstOrDefaultAsync(p => p.Id == request.SProductId, ct)
                ?? throw new InvalidOperationException("Ürün bulunamadı.");

            // 2️⃣ Seçilen FeatureValue'ları al
            var selectedValueIds = request.SelectedFeatureValues.Values.ToList();

            var selectedValues = await _db.Set<Domain.Entities.StockCodes.Features.SFeatureValue>()
                .Include(v => v.SFeature)
                .Where(v => selectedValueIds.Contains(v.Id))
                .ToListAsync(ct);

            // 3️⃣ Fixed rule'ları al
            var fixedRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == request.SProductId
                         && r.IsFixed
                         && r.FixedValueId != null)
                .ToListAsync(ct);

            // 4️⃣ Tüm seçimleri birleştir
            var allSelections = new Dictionary<string, (string Code, string Name)>();

            foreach (var rule in fixedRules)
            {
                if (rule.FixedValue != null)
                    allSelections[rule.SFeature.Code] =
                        (rule.FixedValue.Code, rule.FixedValue.Name);
            }

            foreach (var kvp in request.SelectedFeatureValues)
            {
                var val = selectedValues.FirstOrDefault(v => v.Id == kvp.Value);
                if (val != null)
                    allSelections[val.SFeature.Code] = (val.Code, val.Name);
            }

            // 5️⃣ Description üret
            var description = BuildDescription(product.Code, allSelections);

            // 6️⃣ OptionKey üret
            var optionKey = string.Join("|",
                allSelections
                    .OrderBy(x => x.Key)
                    .Select(x => $"{x.Key}:{x.Value.Code}")
            );

            // 7️⃣ Duplicate kontrolü
            var existing = await _db.Set<StockCard>()
                .FirstOrDefaultAsync(s =>
                    s.SProductId == request.SProductId &&
                    s.OptionKey == optionKey,
                    ct);

            if (existing != null)
            {
                return new SgStockCodeGenerateResultDto
                {
                    StockCode8 = existing.StockCode8,
                    Description = existing.Description,
                    AlreadyExists = true
                };
            }

            // 8️⃣ Sequence al
            var sequence = await _db.StockSequences
                .FirstOrDefaultAsync(s => s.Prefix4 == product.Code, ct)
                ?? throw new InvalidOperationException($"Sequence bulunamadı: {product.Code}");

            sequence.LastNumber++;
            var serial = sequence.LastNumber;
            // DEFAULT FLUID (SG için)
            var defaultFluid = await _db.Set<Fluid>()
                .FirstOrDefaultAsync(x => x.Code == "G", ct);

            if (defaultFluid == null)
                throw new InvalidOperationException("Default fluid tanımlı değil.");


            // 9️⃣ StockCard oluştur (FluidId artık NULL olabilir)
            var stockCard = new StockCard
            {
                Id = Guid.NewGuid(),

                FluidId = defaultFluid.Id,          // 🔥 EKLENDİ
                SProductGroupId = product.SProductGroupId,
                SProductId = product.Id,
                StockSequenceId = sequence.Id,

                StockCode8 = $"{product.Code}{serial:D4}",
                Prefix4 = product.Code,
                Serial4 = serial,

                Description = description,
                OptionKey = optionKey,

                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.Status.Added
            };


            _db.Set<StockCard>().Add(stockCard);

            // 🔟 FeatureSelections ekle
            foreach (var kvp in allSelections)
            {
                var feature = await _db.Set<Domain.Entities.StockCodes.Features.SFeature>()
                    .FirstOrDefaultAsync(f => f.Code == kvp.Key, ct);

                if (feature == null) continue;

                var value = await _db.Set<Domain.Entities.StockCodes.Features.SFeatureValue>()
                    .FirstOrDefaultAsync(v =>
                        v.SFeatureId == feature.Id &&
                        v.Code == kvp.Value.Code,
                        ct);

                if (value == null) continue;

                _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>().Add(
                    new Domain.Entities.StockCodes.Features.StockCardFeatureSelection
                    {
                        Id = Guid.NewGuid(),
                        StockCardId = stockCard.Id,
                        SFeatureId = feature.Id,
                        SFeatureValueId = value.Id,
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now,
                        Status = Domain.Enums.Status.Added
                    });
            }

            await _db.SaveChangesAsync(ct);

            return new SgStockCodeGenerateResultDto
            {
                StockCode8 = stockCard.StockCode8,
                Description = stockCard.Description,
                AlreadyExists = false
            };
        }




        // ========== LİSTE ==========
        public async Task<SGStockCardListResultDto> GetStockCardsAsync(
            SGStockCardFilterDto filter,
            CancellationToken ct = default)
        {
            var query = _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .Where(s => s.SProduct.SProductGroup.Code == "G"
                         && s.Status != Domain.Enums.Status.Deleted);

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
                query = query.Where(s =>
                    s.StockCode8.Contains(filter.SearchTerm) ||
                    s.Description.Contains(filter.SearchTerm) ||
                    s.SProduct.Code.Contains(filter.SearchTerm));

            if (filter.ProductId.HasValue)
                query = query.Where(s => s.SProductId == filter.ProductId.Value);

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .OrderByDescending(s => s.CreatedDate)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(s => new SGStockCardListItemDto
                {
                    Id = s.Id,
                    StockCode8 = s.StockCode8,
                    ProductCode = s.SProduct.Code,
                    ProductName = s.SProduct.Name,
                    Description = s.Description,
                    CreatedDate = s.CreatedDate,
                    CreatedBy = s.CreatedBy
                })
                .ToListAsync(ct);

            return new SGStockCardListResultDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        // ========== DETAY ==========
        public async Task<SGStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .FirstOrDefaultAsync(s => s.Id == stockCardId, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            var selections = await _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>()
                .Include(s => s.SFeature)
                .Include(s => s.SFeatureValue)
                .Where(s => s.StockCardId == stockCardId)
                .OrderBy(s => s.SFeature.SortOrder)
                .ToListAsync(ct);

            return new SGStockCardDetailDto
            {
                Id = stockCard.Id,
                StockCode8 = stockCard.StockCode8,
                Prefix4 = stockCard.Prefix4,
                Serial4 = stockCard.Serial4,
                ProductId = stockCard.SProductId,
                ProductCode = stockCard.SProduct.Code,
                ProductName = stockCard.SProduct.Name,
                Description = stockCard.Description,
                CreatedDate = stockCard.CreatedDate,
                CreatedBy = stockCard.CreatedBy,
                FeatureSelections = selections.Select((s, i) => new SGFeatureSelectionDto
                {
                    FeatureId = s.SFeatureId,
                    FeatureCode = s.SFeature.Code,
                    FeatureName = s.SFeature.Name,
                    ValueId = s.SFeatureValueId,
                    ValueCode = s.SFeatureValue.Code,
                    ValueName = s.SFeatureValue.Name,
                    SortOrder = i
                }).ToList()
            };
        }

        // ========== GÜNCELLEME ==========
        public async Task UpdateStockCardAsync(
            SGStockCardUpdateDto dto,
            string updatedBy,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .FirstOrDefaultAsync(s => s.Id == dto.StockCardId, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            var existingSelections = await _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>()
                .Where(s => s.StockCardId == dto.StockCardId)
                .ToListAsync(ct);
            _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>().RemoveRange(existingSelections);

            var productRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == stockCard.SProductId && r.IsFixed && r.FixedValueId != null)
                .ToListAsync(ct);

            var allSelections = new Dictionary<string, (string Code, string Name)>();

            foreach (var rule in productRules)
            {
                if (rule.FixedValue != null)
                    allSelections[rule.SFeature.Code] = (rule.FixedValue.Code, rule.FixedValue.Name);
            }

            var selectedValueIds = dto.FeatureSelections.Values.ToList();
            var selectedValues = await _db.Set<Domain.Entities.StockCodes.Features.SFeatureValue>()
                .Include(v => v.SFeature)
                .Where(v => selectedValueIds.Contains(v.Id))
                .ToListAsync(ct);

            foreach (var kvp in dto.FeatureSelections)
            {
                var val = selectedValues.FirstOrDefault(v => v.Id == kvp.Value);
                if (val != null)
                    allSelections[val.SFeature.Code] = (val.Code, val.Name);
            }

            stockCard.Description = BuildDescription(stockCard.SProduct.Code, allSelections);
            stockCard.ModifiedBy = updatedBy;
            stockCard.ModifiedDate = DateTime.Now;

            foreach (var kvp in allSelections)
            {
                var feature = await _db.Set<Domain.Entities.StockCodes.Features.SFeature>()
                    .FirstOrDefaultAsync(f => f.Code == kvp.Key, ct);
                var value = await _db.Set<Domain.Entities.StockCodes.Features.SFeatureValue>()
                    .FirstOrDefaultAsync(v => v.SFeatureId == feature!.Id && v.Code == kvp.Value.Code, ct);

                if (feature != null && value != null)
                {
                    _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>().Add(
                        new Domain.Entities.StockCodes.Features.StockCardFeatureSelection
                        {
                            Id = Guid.NewGuid(),
                            StockCardId = stockCard.Id,
                            SFeatureId = feature.Id,
                            SFeatureValueId = value.Id,
                            CreatedBy = updatedBy,
                            CreatedDate = DateTime.Now,
                            Status = Domain.Enums.Status.Added
                        });
                }
            }

            await _db.SaveChangesAsync(ct);
        }

        // ========== SİLME ==========
        public async Task DeleteStockCardAsync(
            Guid stockCardId,
            string deletedBy,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .FirstOrDefaultAsync(s => s.Id == stockCardId, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            stockCard.Status = Domain.Enums.Status.Deleted;
            stockCard.DeletedBy = deletedBy;
            stockCard.DeletedDate = DateTime.Now;

            await _db.SaveChangesAsync(ct);
        }

        // ========== DESCRIPTION BUILDER ==========
        private string BuildDescription(
            string productCode,
            Dictionary<string, (string Code, string Name)> selections)
        {
            var parts = new List<string> { "SOMUN" };

            if (selections.TryGetValue(FEATURE_NUT_TYPE, out var nutType))
                parts.Add(nutType.Code);

            if (selections.TryGetValue(FEATURE_STANDARD, out var standard))
                parts.Add(standard.Code);

            if (selections.TryGetValue(FEATURE_THREAD_SYSTEM, out var threadSystem))
                parts.Add(threadSystem.Code);

            if (selections.TryGetValue(FEATURE_METRIC, out var metric))
                parts.Add(metric.Code);

            if (selections.TryGetValue(FEATURE_MATERIAL, out var material))
                parts.Add(material.Code);

            if (selections.TryGetValue(FEATURE_STRENGTH, out var strength))
                parts.Add(strength.Code);

            if (selections.TryGetValue(FEATURE_COATING, out var coating))
                parts.Add(coating.Code);

            return string.Join(" | ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
        }
    }
}
