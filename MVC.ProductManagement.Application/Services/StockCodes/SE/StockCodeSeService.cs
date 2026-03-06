using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SE;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;

namespace MVC.ProductManagement.Application.Services.StockCodes.SE
{
    public class StockCodeSeService : IStockCodeSeService
    {
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly AppDbContext _context;

        public StockCodeSeService(
            ISProductRepositories productRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            ISProductGroupRepositories groupRepo,
            AppDbContext context)
        {
            _productRepo = productRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _groupRepo = groupRepo;
            _context = context;
        }

        /// <summary>
        /// Tüm SE ürünlerini getirir (SEA0, SEB1, SEC2...)
        /// </summary>
        public async Task<IReadOnlyList<LookupDto>> GetSeProductsAsync(CancellationToken cancellationToken = default)
        {
            var seGroupId = await GetSeGroupIdAsync();

            var products = await _productRepo.GetAllAsync(
                x => x.SProductGroupId == seGroupId,
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
        /// SE stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        public async Task<SeStockCodeGenerateResultDto> GenerateSeAsync(
            SeStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var seGroupId = await GetSeGroupIdAsync();

            // 1) Ürün kontrolü
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SE ürünü bulunamadı.");

            var prefix4 = product.Code; // SEA0, SEB1...

            // 3) ✅ OptionKey oluştur (feature seçimlerinden)
            var optionKey = await BuildOptionKeyAsync(request.SelectedFeatureValues, cancellationToken);

            // ✅ DEBUG
            Console.WriteLine($"[SE DEBUG] OptionKey: '{optionKey}'");
            Console.WriteLine($"[SE DEBUG] Feature Count: {request.SelectedFeatureValues?.Count ?? 0}");

            // 4) ✅ Duplicate kontrol (ürün + optionKey)
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.SProductGroupId == seGroupId &&
                    x.SProductId == request.SProductId &&
                    x.OptionKey == optionKey,
                tracking: false);

            if (existing != null)
            {
                return new SeStockCodeGenerateResultDto
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
            var group = await _groupRepo.GetByIdAsync(seGroupId, tracking: false);
            if (group == null)
                throw new InvalidOperationException("SE grubu bulunamadı.");

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
                SProductGroupId = seGroupId,
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

            return new SeStockCodeGenerateResultDto
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

        private async Task<Guid> GetSeGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var seGroup = groups.FirstOrDefault(x => x.Code == "E");
            if (seGroup == null)
                throw new InvalidOperationException("SE (E) grubu tanımlı değil.");
            return seGroup.Id;
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