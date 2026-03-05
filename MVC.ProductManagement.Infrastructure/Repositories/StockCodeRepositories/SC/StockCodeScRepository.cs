using MVC.ProductManagement.Application.Services.StockCodes.SC;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SC
{
    public class StockCodeScRepository : IStockCodeScService
    {
        private readonly AppDbContext _db;

        // SC grubuna özgü sabitler
        private const string SC_GROUP_ID_KEY = "SProductGroup:C";
        private const string FEATURE_WASHER_TYPE = "WASHER_TYPE";
        private const string FEATURE_MATERIAL = "SC_MATERIAL";
        private const string FEATURE_STANDARD = "SC_STANDARD";
        private const string FEATURE_METRIC = "SC_METRIC";
        private const string FEATURE_COATING = "SC_COATING";

        public StockCodeScRepository(AppDbContext db)
        {
            _db = db;
        }

        // ========== ÜRÜN LİSTESİ ==========
        public async Task<List<ScProductDto>> GetScProductsAsync(CancellationToken ct = default)
        {
            return await _db.SProducts
                .Where(p => p.SProductGroup.Code == "C" && p.Status != Domain.Enums.Status.Deleted)
                .OrderBy(p => p.PrefixIndex)
                .Select(p => new ScProductDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name
                })
                .ToListAsync(ct);
        }

        // ========== FORM DATA (Rule-Based) ==========
        public async Task<StockCodeScFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default)
        {
            var product = await _db.SProducts
                .FirstOrDefaultAsync(p => p.Id == productId, ct)
                ?? throw new InvalidOperationException("Ürün bulunamadı.");

            // Bu ürün için kuralları çek
            var productRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == productId)
                .OrderBy(r => r.SFeature.SortOrder)
                .ToListAsync(ct);

            // Bu ürün için izinli değerleri çek
            var valueRules = await _db.SFeatureValueRules
                .Include(r => r.SFeatureValue)
                .Where(r => r.SProductId == productId)
                .OrderBy(r => r.SortOrder)
                .ToListAsync(ct);

            var features = new List<StockCodeScFormFeatureDto>();

            foreach (var rule in productRules)
            {
                var feature = new StockCodeScFormFeatureDto
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
                        .Select(v => new ScFeatureValueOptionDto
                        {
                            Id = v.Id,
                            Code = v.Code,
                            Name = v.Name
                        })
                        .ToList();
                }

                features.Add(feature);
            }

            return new StockCodeScFormDto
            {
                ProductId = product.Id,
                ProductCode = product.Code,
                ProductName = product.Name,
                Features = features
            };
        }

        // ========== KOD ÜRETME ==========
        public async Task<ScStockCodeGenerateResultDto> GenerateScAsync(
     ScStockCodeGenerateRequestDto request,
     CancellationToken ct = default)
        {
            // 1️⃣ Product
            var product = await _db.SProducts
                .FirstOrDefaultAsync(p => p.Id == request.SProductId, ct)
                ?? throw new InvalidOperationException("Ürün bulunamadı.");

            // 2️⃣ Default Fluid (SC = C)
            var fluid = await _db.Set<Fluid>()
                .FirstOrDefaultAsync(f => f.Code == "C", ct);

            if (fluid == null)
                throw new InvalidOperationException("C fluid tanımlı değil.");

            // 3️⃣ Selected values
            var selectedValueIds = request.SelectedFeatureValues.Values.ToList();

            var selectedValues = await _db.Set<SFeatureValue>()
                .Include(v => v.SFeature)
                .Where(v => selectedValueIds.Contains(v.Id))
                .ToListAsync(ct);

            // 4️⃣ Fixed rules
            var productRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == request.SProductId
                         && r.IsFixed
                         && r.FixedValueId != null)
                .ToListAsync(ct);

            var allSelections = new Dictionary<string, (string Code, string Name)>();

            foreach (var rule in productRules)
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

            // 5️⃣ Description
            var description = BuildDescription(product.Code, allSelections);

            // 6️⃣ OPTION KEY (deterministic)
            var optionKey = string.Join("|",
                allSelections
                    .OrderBy(x => x.Key)
                    .Select(x => $"{x.Key}:{x.Value.Code}")
            );

            // 7️⃣ Duplicate kontrol
            var existing = await _db.Set<StockCard>()
                .FirstOrDefaultAsync(s =>
                    s.SProductId == product.Id &&
                    s.OptionKey == optionKey,
                    ct);

            if (existing != null)
            {
                return new ScStockCodeGenerateResultDto
                {
                    StockCode8 = existing.StockCode8,
                    Description = existing.Description,
                    AlreadyExists = true
                };
            }

            // 8️⃣ Sequence
            var sequence = await _db.StockSequences
                .FirstOrDefaultAsync(s => s.Prefix4 == product.Code, ct)
                ?? throw new InvalidOperationException($"Sequence bulunamadı: {product.Code}");

            sequence.LastNumber++;
            var serial = sequence.LastNumber;

            // 9️⃣ StockCard
            var stockCard = new StockCard
            {
                Id = Guid.NewGuid(),

                FluidId = fluid.Id,
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

            // 🔟 FeatureSelections
            foreach (var kvp in allSelections)
            {
                var feature = await _db.Set<SFeature>()
                    .FirstOrDefaultAsync(f => f.Code == kvp.Key, ct);

                if (feature == null) continue;

                var value = await _db.Set<SFeatureValue>()
                    .FirstOrDefaultAsync(v =>
                        v.SFeatureId == feature.Id &&
                        v.Code == kvp.Value.Code,
                        ct);

                if (value == null) continue;

                _db.Set<StockCardFeatureSelection>().Add(
                    new StockCardFeatureSelection
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

            return new ScStockCodeGenerateResultDto
            {
                StockCode8 = stockCard.StockCode8,
                Description = stockCard.Description,
                AlreadyExists = false
            };
        }


        // ========== LİSTE ==========
        public async Task<SCStockCardListResultDto> GetStockCardsAsync(
            SCStockCardFilterDto filter,
            CancellationToken ct = default)
        {
            var query = _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .Where(s => s.SProduct.SProductGroup.Code == "C"
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
                .Select(s => new SCStockCardListItemDto
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

            return new SCStockCardListResultDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        // ========== DETAY ==========
        public async Task<SCStockCardDetailDto> GetStockCardDetailAsync(
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

            return new SCStockCardDetailDto
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
                FeatureSelections = selections.Select((s, i) => new SCFeatureSelectionDto
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
            SCStockCardUpdateDto dto,
            string updatedBy,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .FirstOrDefaultAsync(s => s.Id == dto.StockCardId, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Mevcut seçimleri sil
            var existingSelections = await _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>()
                .Where(s => s.StockCardId == dto.StockCardId)
                .ToListAsync(ct);
            _db.Set<Domain.Entities.StockCodes.Features.StockCardFeatureSelection>().RemoveRange(existingSelections);

            // Sabit değerleri ekle
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

            // Dinamik seçimleri ekle
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

            // Yeni description
            stockCard.Description = BuildDescription(stockCard.SProduct.Code, allSelections);
            stockCard.ModifiedBy = updatedBy;
            stockCard.ModifiedDate = DateTime.Now;

            // Yeni seçimleri kaydet
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
            // SC Description formatı:
            // RONDELA | WASHER_TYPE | MATERIAL | STANDARD | METRIC | COATING
            var parts = new List<string>();

            parts.Add("RONDELA");

            if (selections.TryGetValue(FEATURE_WASHER_TYPE, out var washerType))
                parts.Add(washerType.Code);

            if (selections.TryGetValue(FEATURE_MATERIAL, out var material))
                parts.Add(material.Code);

            if (selections.TryGetValue(FEATURE_STANDARD, out var standard))
                parts.Add(standard.Code);

            if (selections.TryGetValue(FEATURE_METRIC, out var metric))
                parts.Add(metric.Code);

            if (selections.TryGetValue(FEATURE_COATING, out var coating))
                parts.Add(coating.Code);

            return string.Join(" | ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
        }
    }
}