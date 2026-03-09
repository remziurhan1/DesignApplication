using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SG;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.DataAccess;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Application.Services.StockCodes.SG
{
    public class StockCodeSgService : IStockCodeSgService
    {
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly AppDbContext _context;

        public StockCodeSgService(
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
        /// Tüm SG ürünlerini getirir (SGA0, SGA1, SGA2...)
        /// </summary>
        public async Task<IReadOnlyList<LookupDto>> GetSgProductsAsync(CancellationToken cancellationToken = default)
        {
            var sgGroupId = await GetSgGroupIdAsync();

            var products = await _productRepo.GetAllAsync(
                x => x.SProductGroupId == sgGroupId,
                tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .ThenBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        /// <summary>
        /// Seçilen ürüne göre feature'ları getirir
        /// </summary>
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
        /// SG stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        public async Task<SgStockCodeGenerateResultDto> GenerateSgAsync(
            SgStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var sgGroupId = await GetSgGroupIdAsync();

            // 1) Ürün kontrolü
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SG ürünü bulunamadı.");

            var prefix4 = product.Code; // SGA0, SGA1...

            // 2) ✅ Akışkan yok - Default kullan
            var allFluids = await _fluidRepo.GetAllAsync(tracking: false);
            var defaultFluid = allFluids.FirstOrDefault(x => x.Code == "NONE")
                                ?? allFluids.FirstOrDefault(x => x.Code == "A")
                                ?? allFluids.First();

            // 3) ✅ OptionKey oluştur (feature seçimlerinden)
            var optionKey = await BuildOptionKeyAsync(request.SelectedFeatureValues, cancellationToken);

            // ✅ DEBUG
            Console.WriteLine($"[SG DEBUG] OptionKey: '{optionKey}'");
            Console.WriteLine($"[SG DEBUG] Feature Count: {request.SelectedFeatureValues?.Count ?? 0}");

            // 4) ✅ Duplicate kontrol (ürün + optionKey)
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == defaultFluid.Id &&
                    x.SProductGroupId == sgGroupId &&
                    x.SProductId == request.SProductId &&
                    x.OptionKey == optionKey,
                tracking: false);

            if (existing != null)
            {
                return new SgStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 5) Lookup
            var group = await _groupRepo.GetByIdAsync(sgGroupId, tracking: false);
            if (group == null)
                throw new InvalidOperationException("SG grubu bulunamadı.");

            // 6) ✅ Feature açıklaması
            var featureDescription = await BuildFeatureDescriptionAsync(request.SelectedFeatureValues, cancellationToken);

            var description = string.IsNullOrWhiteSpace(featureDescription)
                ? $"{group.Name} | {product.Name}"
                : $"{group.Name} | {product.Name} | {featureDescription}";

            // 7) Transaction
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
                SProductGroupId = sgGroupId,
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

            // 8) ✅ Feature seçimlerini kaydet
            if (request.SelectedFeatureValues != null && request.SelectedFeatureValues.Any())
            {
                var selections = request.SelectedFeatureValues.Select(kvp => new StockCardFeatureSelection
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

            return new SgStockCodeGenerateResultDto
            {
                AlreadyExists = false,
                StockCardId = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                Description = card.Description
            };
        }

        public async Task<GenericStockCodeFormDto> GetFormDataAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await _context.SProducts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken)
                ?? throw new InvalidOperationException("SG ürünü bulunamadı.");

            var featureRules = await _context.SProductFeatureRules
                .AsNoTracking()
                .Include(x => x.SFeature)
                .Include(x => x.FixedValue)
                .Where(x => x.SProductId == productId)
                .OrderBy(x => x.SFeature.SortOrder)
                .ToListAsync(cancellationToken);

            var featureDtos = new List<GenericStockCodeFormFeatureDto>();

            if (featureRules.Any())
            {
                var valueRules = await _context.SFeatureValueRules
                    .AsNoTracking()
                    .Include(x => x.SFeatureValue)
                    .Where(x => x.SProductId == productId)
                    .OrderBy(x => x.SortOrder)
                    .ToListAsync(cancellationToken);

                foreach (var fr in featureRules)
                {
                    var availableValues = valueRules
                        .Where(x => x.SFeatureId == fr.SFeatureId)
                        .Select(x => new FeatureValueDto
                        {
                            Id = x.SFeatureValueId,
                            Code = x.SFeatureValue.Code,
                            Name = x.SFeatureValue.Name,
                            SortOrder = x.SortOrder
                        }).ToList();

                    featureDtos.Add(new GenericStockCodeFormFeatureDto
                    {
                        FeatureId = fr.SFeatureId,
                        FeatureCode = fr.SFeature.Code,
                        FeatureName = fr.SFeature.Name,
                        IsFixed = fr.IsFixed,
                        FixedValueId = fr.FixedValueId,
                        FixedValueCode = fr.FixedValue?.Code,
                        FixedValueName = fr.FixedValue?.Name,
                        AvailableValues = availableValues
                    });
                }
            }
            else
            {
                var productFeatures = await _context.Set<SProductFeature>()
                    .AsNoTracking()
                    .Include(pf => pf.SFeature)
                        .ThenInclude(f => f.Values)
                    .Where(pf => pf.SProductId == productId)
                    .OrderBy(pf => pf.SFeature.SortOrder)
                    .ToListAsync(cancellationToken);

                foreach (var pf in productFeatures)
                {
                    featureDtos.Add(new GenericStockCodeFormFeatureDto
                    {
                        FeatureId = pf.SFeatureId,
                        FeatureCode = pf.SFeature.Code,
                        FeatureName = pf.SFeature.Name,
                        IsFixed = false,
                        AvailableValues = pf.SFeature.Values
                            .OrderBy(v => v.SortOrder)
                            .Select(v => new FeatureValueDto
                            {
                                Id = v.Id,
                                Code = v.Code,
                                Name = v.Name,
                                SortOrder = v.SortOrder
                            }).ToList()
                    });
                }
            }

            return new GenericStockCodeFormDto
            {
                ProductId = product.Id,
                ProductCode = product.Code,
                ProductName = product.Name,
                Features = featureDtos
            };
        }

        public async Task<GenericStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken cancellationToken = default)
        {
            var stockCard = await _context.Set<StockCard>()
                .AsNoTracking()
                .Include(x => x.SProduct)
                .Include(x => x.Fluid)
                .Include(x => x.FeatureSelections)
                    .ThenInclude(fs => fs.SFeature)
                .Include(x => x.FeatureSelections)
                    .ThenInclude(fs => fs.SFeatureValue)
                .FirstOrDefaultAsync(x => x.Id == stockCardId && !x.IsDeleted, cancellationToken)
                ?? throw new InvalidOperationException("SG stok kartı bulunamadı.");

            return new GenericStockCardDetailDto
            {
                Id = stockCard.Id,
                StockCode8 = stockCard.StockCode8,
                Prefix4 = stockCard.Prefix4,
                Serial4 = stockCard.Serial4,
                ProductId = stockCard.SProductId,
                ProductCode = stockCard.SProduct.Code,
                ProductName = stockCard.SProduct.Name,
                FluidId = stockCard.FluidId,
                FluidCode = stockCard.Fluid?.Code,
                FluidName = stockCard.Fluid?.Name,
                Description = stockCard.Description,
                OptionKey = stockCard.OptionKey,
                CreatedDate = stockCard.CreatedDate,
                CreatedBy = stockCard.CreatedBy,
                FeatureSelections = stockCard.FeatureSelections
                    .OrderBy(fs => fs.SFeature.SortOrder)
                    .Select(fs => new GenericFeatureSelectionDto
                    {
                        FeatureId = fs.SFeatureId,
                        FeatureName = fs.SFeature.Name,
                        ValueId = fs.SFeatureValueId,
                        ValueCode = fs.SFeatureValue.Code,
                        ValueName = fs.SFeatureValue.Name,
                        SortOrder = fs.SFeature.SortOrder
                    }).ToList()
            };
        }

        // ========== HELPER METHODS ==========

        private async Task<Guid> GetSgGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var sgGroup = groups.FirstOrDefault(x => x.Code == "G");
            if (sgGroup == null)
                throw new InvalidOperationException("SG (G) grubu tanımlı değil.");
            return sgGroup.Id;
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
                .Select(f => new { f.Id, f.SortOrder })
                .ToListAsync(cancellationToken);

            var values = await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(v => valueIds.Contains(v.Id))
                .Select(v => new { v.Id, v.Name })
                .ToListAsync(cancellationToken);

            var parts = selectedFeatureValues
                .Select(kvp =>
                {
                    var f = features.FirstOrDefault(x => x.Id == kvp.Key);
                    var v = values.FirstOrDefault(x => x.Id == kvp.Value);
                    if (f == null || v == null) return null;
                    return new { f.SortOrder, Text = v.Name };
                })
                .Where(x => x != null)
                .OrderBy(x => x.SortOrder)
                .Select(x => x.Text)
                .ToList();

            return string.Join(" | ", parts);
        }
    }
}
