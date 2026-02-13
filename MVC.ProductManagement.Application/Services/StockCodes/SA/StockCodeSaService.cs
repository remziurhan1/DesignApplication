using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA
{
    public class StockCodeSaService : IStockCodeSaService
    {
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly AppDbContext _context;

        public StockCodeSaService(
            ISProductRepositories productRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo,
            AppDbContext context)
        {
            _productRepo = productRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
            _context = context;
        }

        /// <summary>
        /// ✅ 1. Prefix listesi getir
        /// </summary>
        public async Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            var products = await _productRepo.GetAllAsync(
                x => x.SProductGroupId == saGroupId,
                tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .ThenBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        /// <summary>
        /// ✅ 2. YENİ: Prefix seçildiğinde kural bazlı form verilerini getir
        /// </summary>
        public async Task<StockCodeSaFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            // Ürün bilgisi
            var product = await _productRepo.GetByIdAsync(productId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("Ürün bulunamadı.");

            // Tüm feature'ları getir
            var features = await _context.Set<SFeature>()
                .AsNoTracking()
                .OrderBy(f => f.SortOrder)
                .ToListAsync(cancellationToken);

            // Bu ürün için feature kurallarını getir
            var featureRules = await _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == productId)
                .ToListAsync(cancellationToken);

            var formFeatures = new List<StockCodeSaFormFeatureDto>();

            foreach (var feature in features)
            {
                var rule = featureRules.FirstOrDefault(r => r.SFeatureId == feature.Id);

                if (rule == null) continue; // Bu feature bu ürün için kullanılmıyor

                var formFeature = new StockCodeSaFormFeatureDto
                {
                    FeatureId = feature.Id,
                    FeatureCode = feature.Code,
                    FeatureName = feature.Name,
                    IsFixed = rule.IsFixed,
                    FixedValueId = rule.FixedValueId,
                    FixedValueCode = rule.FixedValue?.Code,
                    FixedValueName = rule.FixedValue?.Name,
                    AvailableValues = new List<FeatureValueDto>()
                };

                // Eğer sabit değilse, izinli değerleri getir
                if (!rule.IsFixed)
                {
                    var allowedValues = await _context.Set<SFeatureValueRule>()
                        .AsNoTracking()
                        .Include(r => r.SFeatureValue)
                        .Where(r => r.SProductId == productId && r.SFeatureId == feature.Id)
                        .OrderBy(r => r.SortOrder)
                        .Select(r => new FeatureValueDto
                        {
                            Id = r.SFeatureValue.Id,
                            Code = r.SFeatureValue.Code,
                            Name = r.SFeatureValue.Name,
                            SortOrder = r.SortOrder
                        })
                        .ToListAsync(cancellationToken);

                    formFeature.AvailableValues = allowedValues;
                }

                formFeatures.Add(formFeature);
            }

            return new StockCodeSaFormDto
            {
                ProductId = productId,
                ProductCode = product.Code,
                ProductName = product.Name,
                Features = formFeatures
            };
        }

        /// <summary>
        /// ✅ 3. YENİ: Kullanıcı bir feature değeri seçtiğinde, bağımlı feature'ların değerlerini filtrele
        /// </summary>
        public async Task<List<FeatureValueDto>> GetFilteredValuesAsync(
            Guid productId,
            Guid featureId,
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken = default)
        {
            // İzinli değerleri getir
            var allowedValues = await _context.Set<SFeatureValueRule>()
                .AsNoTracking()
                .Include(r => r.SFeatureValue)
                .Where(r => r.SProductId == productId && r.SFeatureId == featureId)
                .OrderBy(r => r.SortOrder)
                .Select(r => r.SFeatureValue)
                .ToListAsync(cancellationToken);

            // Bağımlılık kurallarını uygula
            var filteredValues = new List<SFeatureValue>();

            foreach (var value in allowedValues)
            {
                var isAllowed = await CheckDependenciesAsync(
                    productId,
                    featureId,
                    value.Id,
                    selectedFeatureValues,
                    cancellationToken);

                if (isAllowed)
                    filteredValues.Add(value);
            }

            return filteredValues.Select(v => new FeatureValueDto
            {
                Id = v.Id,
                Code = v.Code,
                Name = v.Name,
                SortOrder = 0
            }).ToList();
        }

        /// <summary>
        /// ✅ 4. ESKİ METOD - GERİYE UYUMLULUK İÇİN (deprecated)
        /// </summary>
        [Obsolete("GetFormDataAsync kullanın")]
        public async Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            var features = await _context.Set<SProductFeature>()
                .AsNoTracking()
                .Include(pf => pf.SFeature)
                    .ThenInclude(f => f.Values)
                .Where(pf => pf.SProductId == productId)
                .OrderBy(pf => pf.SFeature.SortOrder)
                .Select(pf => new FeatureDto
                {
                    Id = pf.SFeatureId,
                    Code = pf.SFeature.Code,
                    Name = pf.SFeature.Name,
                    IsRequired = pf.IsRequired,
                    SortOrder = pf.SFeature.SortOrder,
                    Values = pf.SFeature.Values
                        .OrderBy(v => v.SortOrder)
                        .Select(v => new FeatureValueDto
                        {
                            Id = v.Id,
                            Code = v.Code,
                            Name = v.Name,
                            SortOrder = v.SortOrder
                        }).ToList()
                })
                .ToListAsync(cancellationToken);

            return features;
        }

        /// <summary>
        /// ✅ 5. Stok kodu oluştur (KURAL SİSTEMİ İLE)
        /// </summary>
        public async Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            // 1) Product kontrolü
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SA ürünü bulunamadı.");

            var prefix4 = product.Code;

            // 2) Default fluid
            var allFluids = await _fluidRepo.GetAllAsync(tracking: false);
            var defaultFluid = allFluids.FirstOrDefault(x => x.Code == "A") ?? allFluids.First();

            // ✅ 3) Validasyon: Zorunlu feature'lar seçilmiş mi?
            await ValidateRequiredFeaturesAsync(request.SProductId, request.SelectedFeatureValues, cancellationToken);

            // ✅ 4) Validasyon: Bağımlılık kuralları ihlal ediliyor mu?
            await ValidateDependenciesAsync(request.SProductId, request.SelectedFeatureValues, cancellationToken);

            // ✅ 5) Sabit feature'ları otomatik ekle
            var finalFeatureValues = await AddFixedFeaturesAsync(request.SProductId, request.SelectedFeatureValues, cancellationToken);

            // ✅ 6) OptionKey oluştur
            var optionKey = await BuildOptionKeyAsync(finalFeatureValues, cancellationToken);

            // ✅ 7) Duplicate kontrol
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == defaultFluid.Id &&
                    x.SProductGroupId == saGroupId &&
                    x.SProductId == request.SProductId &&
                    x.OptionKey == optionKey,
                tracking: false);

            if (existing != null)
            {
                return new SaStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 8) Lookup
            var group = await _groupRepo.GetByIdAsync(saGroupId, tracking: false);
            if (group == null)
                throw new InvalidOperationException("SA grubu bulunamadı.");

            // ✅ 9) YENİ FORMAT: Feature açıklaması (CIVATA | DIN 933 | METRIK | M16x60 | KARBON | 8.8 | CINKO)
            var featureDescription = await BuildFeatureDescriptionAsync(finalFeatureValues, cancellationToken);

            // ✅ YENİ: Sadece Fluid + Feature Description (group.Name kaldırıldı)
            // ✅ YENİ: Sadece Feature Description (Fluid ve Group kaldırıldı)
            var description = featureDescription;            // 10) Transaction
            await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

            var seq = await _sequenceRepo.GetAsync(x => x.Prefix4 == prefix4, tracking: true);
            if (seq == null)
                throw new InvalidOperationException($"StockSequence yok: {prefix4}");

            var nextSerial = seq.LastNumber + 1;
            if (nextSerial > 9999)
                throw new InvalidOperationException($"Seri no limiti aşıldı: {prefix4}");

            seq.LastNumber = nextSerial;
            await _sequenceRepo.UpdateAsync(seq);
            await _sequenceRepo.SaveChangeAsync();

            var card = new StockCard
            {
                Id = Guid.NewGuid(),
                FluidId = defaultFluid.Id,
                SProductGroupId = saGroupId,
                SProductId = request.SProductId,
                Prefix4 = prefix4,
                Serial4 = nextSerial,
                StockCode8 = $"{prefix4}{nextSerial:0000}",
                Description = description,
                StockSequenceId = seq.Id,
                OptionKey = optionKey,
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.UtcNow,
                Status = Domain.Enums.Status.Added
            };

            await _stockCardRepo.AddAsync(card);
            await _stockCardRepo.SaveChangeAsync();

            // 11) Feature seçimlerini kaydet
            if (finalFeatureValues != null && finalFeatureValues.Any())
            {
                var selections = finalFeatureValues.Select(kvp => new StockCardFeatureSelection
                {
                    Id = Guid.NewGuid(),
                    StockCardId = card.Id,
                    SFeatureId = kvp.Key,
                    SFeatureValueId = kvp.Value,
                    CreatedBy = "SYSTEM",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                }).ToList();

                _context.Set<StockCardFeatureSelection>().AddRange(selections);
                await _context.SaveChangesAsync(cancellationToken);
            }

            await tx.CommitAsync(cancellationToken);

            return new SaStockCodeGenerateResultDto
            {
                AlreadyExists = false,
                StockCardId = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                Description = card.Description
            };
        }

        // ========== HELPER METHODS ==========

        private async Task<Guid> GetSaGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var saGroup = groups.FirstOrDefault(x => x.Code == "A");
            if (saGroup == null)
                throw new InvalidOperationException("SA (A) grubu tanımlı değil.");
            return saGroup.Id;
        }

        /// <summary>
        /// ✅ Bağımlılık kurallarını kontrol et
        /// </summary>
        private async Task<bool> CheckDependenciesAsync(
            Guid productId,
            Guid targetFeatureId,
            Guid targetValueId,
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            var dependencies = await _context.Set<SFeatureValueDependency>()
                .AsNoTracking()
                .Where(d =>
                    (d.SProductId == null || d.SProductId == productId) &&
                    d.TargetFeatureId == targetFeatureId &&
                    d.TargetValueId == targetValueId)
                .ToListAsync(cancellationToken);

            foreach (var dep in dependencies)
            {
                if (!selectedFeatureValues.ContainsKey(dep.SourceFeatureId))
                    continue;

                var selectedSourceValue = selectedFeatureValues[dep.SourceFeatureId];

                if (selectedSourceValue != dep.SourceValueId)
                    continue;

                if (dep.Type == DependencyType.FORBIDDEN)
                    return false;

                if (dep.Type == DependencyType.REQUIRED)
                    return true;
            }

            return true;
        }

        /// <summary>
        /// ✅ Zorunlu feature'lar seçilmiş mi kontrol et
        /// </summary>
        private async Task ValidateRequiredFeaturesAsync(
            Guid productId,
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            var requiredFeatures = await _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Include(r => r.SFeature)
                .Where(r => r.SProductId == productId && !r.IsFixed)
                .ToListAsync(cancellationToken);

            foreach (var rule in requiredFeatures)
            {
                if (!selectedFeatureValues.ContainsKey(rule.SFeatureId))
                    throw new InvalidOperationException($"{rule.SFeature.Name} seçilmesi zorunludur.");
            }
        }

        /// <summary>
        /// ✅ Bağımlılık kuralları ihlal ediliyor mu kontrol et
        /// </summary>
        private async Task ValidateDependenciesAsync(
            Guid productId,
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            var dependencies = await _context.Set<SFeatureValueDependency>()
                .AsNoTracking()
                .Include(d => d.SourceFeature)
                .Include(d => d.SourceValue)
                .Include(d => d.TargetFeature)
                .Include(d => d.TargetValue)
                .Where(d => d.SProductId == null || d.SProductId == productId)
                .ToListAsync(cancellationToken);

            foreach (var dep in dependencies)
            {
                if (!selectedFeatureValues.ContainsKey(dep.SourceFeatureId))
                    continue;

                var selectedSourceValue = selectedFeatureValues[dep.SourceFeatureId];

                if (selectedSourceValue != dep.SourceValueId)
                    continue;

                if (!selectedFeatureValues.ContainsKey(dep.TargetFeatureId))
                {
                    if (dep.Type == DependencyType.REQUIRED)
                        throw new InvalidOperationException($"{dep.SourceValue.Code} seçildiğinde {dep.TargetFeature.Name} = {dep.TargetValue.Code} olmalıdır.");
                    continue;
                }

                var selectedTargetValue = selectedFeatureValues[dep.TargetFeatureId];

                if (dep.Type == DependencyType.FORBIDDEN && selectedTargetValue == dep.TargetValueId)
                    throw new InvalidOperationException($"{dep.SourceValue.Code} ile {dep.TargetValue.Code} birlikte kullanılamaz.");

                if (dep.Type == DependencyType.REQUIRED && selectedTargetValue != dep.TargetValueId)
                    throw new InvalidOperationException($"{dep.SourceValue.Code} seçildiğinde {dep.TargetFeature.Name} = {dep.TargetValue.Code} olmalıdır.");
            }
        }

        /// <summary>
        /// ✅ Sabit feature'ları otomatik ekle
        /// </summary>
        private async Task<Dictionary<Guid, Guid>> AddFixedFeaturesAsync(
            Guid productId,
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            var result = new Dictionary<Guid, Guid>(selectedFeatureValues);

            var fixedRules = await _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Where(r => r.SProductId == productId && r.IsFixed && r.FixedValueId != null)
                .ToListAsync(cancellationToken);

            foreach (var rule in fixedRules)
            {
                result[rule.SFeatureId] = rule.FixedValueId!.Value;
            }

            return result;
        }

        private async Task<string> BuildOptionKeyAsync(
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            if (selectedFeatureValues == null || !selectedFeatureValues.Any())
                return string.Empty;

            var featureIds = selectedFeatureValues.Keys.ToList();
            var valueIds = selectedFeatureValues.Values.ToList();

            var features = await _context.Set<SFeature>()
                .AsNoTracking()
                .Where(f => featureIds.Contains(f.Id))
                .Select(f => new { f.Id, f.Code, f.SortOrder })
                .ToListAsync(cancellationToken);

            var values = await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(v => valueIds.Contains(v.Id))
                .Select(v => new { v.Id, v.Code })
                .ToListAsync(cancellationToken);

            var parts = selectedFeatureValues
                .Select(kvp =>
                {
                    var f = features.FirstOrDefault(x => x.Id == kvp.Key);
                    var v = values.FirstOrDefault(x => x.Id == kvp.Value);
                    if (f == null || v == null) return null;
                    return new { f.SortOrder, f.Code, ValueCode = v.Code };
                })
                .Where(x => x != null)
                .OrderBy(x => x.SortOrder)
                .Select(x => $"{x.Code}={x.ValueCode}")
                .ToList();

            return string.Join("|", parts);
        }

        /// <summary>
        /// ✅ YENİ FORMAT: DIN 933 | METRIK | M16x60 | KARBON | 8.8 | CINKO | AKB
        /// (CIVATA kelimesi kaldırıldı, HEAD_TYPE eklendi)
        /// </summary>
        private async Task<string> BuildFeatureDescriptionAsync(
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            if (selectedFeatureValues == null || !selectedFeatureValues.Any())
                return string.Empty;

            var featureIds = selectedFeatureValues.Keys.ToList();
            var valueIds = selectedFeatureValues.Values.ToList();

            var features = await _context.Set<SFeature>()
                .AsNoTracking()
                .Where(f => featureIds.Contains(f.Id))
                .Select(f => new { f.Id, f.Code, f.SortOrder })
                .ToListAsync(cancellationToken);

            var values = await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(v => valueIds.Contains(v.Id))
                .Select(v => new { v.Id, v.Code })
                .ToListAsync(cancellationToken);

            var featureDict = selectedFeatureValues
                .Select(kvp =>
                {
                    var f = features.FirstOrDefault(x => x.Id == kvp.Key);
                    var v = values.FirstOrDefault(x => x.Id == kvp.Value);
                    if (f == null || v == null) return null;
                    return new { f.Code, Value = v.Code };
                })
                .Where(x => x != null)
                .ToDictionary(x => x.Code, x => x.Value);

            var parts = new List<string>();

            // ❌ CIVATA KALDIRILDI

            // STANDARD
            if (featureDict.ContainsKey("STANDARD"))
                parts.Add(featureDict["STANDARD"]);

            // THREAD_SYSTEM
            if (featureDict.ContainsKey("THREAD_SYSTEM"))
                parts.Add(featureDict["THREAD_SYSTEM"]);

            // METRIC x LENGTH
            var metric = featureDict.ContainsKey("METRIC") ? featureDict["METRIC"] : "";
            var length = featureDict.ContainsKey("LENGTH") ? featureDict["LENGTH"] : "";
            if (!string.IsNullOrEmpty(metric) && !string.IsNullOrEmpty(length))
                parts.Add($"{metric}x{length}");

            // MATERIAL
            if (featureDict.ContainsKey("MATERIAL"))
                parts.Add(featureDict["MATERIAL"]);

            // STRENGTH
            if (featureDict.ContainsKey("STRENGTH"))
                parts.Add(featureDict["STRENGTH"]);

            // COATING (- ise KAPLAMASIZ yaz)
            if (featureDict.ContainsKey("COATING"))
            {
                var coating = featureDict["COATING"];
                parts.Add(coating == "-" ? "KAPLAMASIZ" : coating);
            }

            // ✅ HEAD_TYPE (BAŞ TİPİ)
            if (featureDict.ContainsKey("HEAD_TYPE"))
                parts.Add(featureDict["HEAD_TYPE"]);

            return string.Join(" | ", parts);
        }

        /// <summary>
        /// ✅ 6. SA Stok Kartlarını listele ve filtrele
        /// </summary>
        public async Task<PagedResult<SAStockCardListDto>> GetStockCardsAsync(
            SAStockCardFilterDto filter,
            CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            var query = _context.Set<StockCard>()
                .AsNoTracking()
                .Include(sc => sc.SProduct)
                .Where(sc => sc.SProductGroupId == saGroupId);

            // ✅ Filtre: Ürün
            if (filter.ProductId.HasValue)
            {
                query = query.Where(sc => sc.SProductId == filter.ProductId.Value);
            }

            // ✅ Filtre: Stok Kodu (kısmi arama)
            if (!string.IsNullOrWhiteSpace(filter.StockCode))
            {
                var searchCode = filter.StockCode.Trim().ToUpper();
                query = query.Where(sc => sc.StockCode8.Contains(searchCode));
            }

            // ✅ Filtre: Feature'lara göre
            if (filter.FeatureFilters != null && filter.FeatureFilters.Any())
            {
                foreach (var featureFilter in filter.FeatureFilters)
                {
                    var featureId = featureFilter.Key;
                    var valueId = featureFilter.Value;

                    query = query.Where(sc =>
                        _context.Set<StockCardFeatureSelection>()
                            .Any(s =>
                                s.StockCardId == sc.Id &&
                                s.SFeatureId == featureId &&
                                s.SFeatureValueId == valueId));
                }
            }

            // ✅ Toplam kayıt sayısı
            var totalCount = await query.CountAsync(cancellationToken);

            // ✅ Sayfalama
            var items = await query
                .OrderByDescending(sc => sc.CreatedDate)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(sc => new SAStockCardListDto
                {
                    Id = sc.Id,
                    StockCode8 = sc.StockCode8,
                    Description = sc.Description,
                    ProductCode = sc.SProduct.Code,
                    ProductName = sc.SProduct.Name,
                    CreatedDate = sc.CreatedDate,
                    CreatedBy = sc.CreatedBy
                })
                .ToListAsync(cancellationToken);

            return new PagedResult<SAStockCardListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        /// <summary>
        /// ✅ 7. SA Stok Kartı detayını getir
        /// </summary>
        public async Task<SAStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var card = await _context.Set<StockCard>()
                .AsNoTracking()
                .Include(sc => sc.SProduct)
                .Include(sc => sc.Fluid)
                .FirstOrDefaultAsync(sc => sc.Id == stockCardId, cancellationToken);

            if (card == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Feature seçimlerini getir
            var selections = await _context.Set<StockCardFeatureSelection>()
                .AsNoTracking()
                .Include(s => s.SFeature)
                .Include(s => s.SFeatureValue)
                .Where(s => s.StockCardId == stockCardId)
                .OrderBy(s => s.SFeature.SortOrder)
                .Select(s => new FeatureSelectionDto
                {
                    FeatureCode = s.SFeature.Code,
                    FeatureName = s.SFeature.Name,
                    ValueCode = s.SFeatureValue.Code,
                    ValueName = s.SFeatureValue.Name,
                    SortOrder = s.SFeature.SortOrder
                })
                .ToListAsync(cancellationToken);

            return new SAStockCardDetailDto
            {
                Id = card.Id,
                StockCode8 = card.StockCode8,
                Description = card.Description,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                OptionKey = card.OptionKey,
                ProductId = card.SProductId,
                ProductCode = card.SProduct.Code,
                ProductName = card.SProduct.Name,
                FluidId = card.FluidId,
                FluidCode = card.Fluid.Code,
                FluidName = card.Fluid.Name,
                FeatureSelections = selections,
                CreatedDate = card.CreatedDate,
                CreatedBy = card.CreatedBy
            };
        }
    }
}