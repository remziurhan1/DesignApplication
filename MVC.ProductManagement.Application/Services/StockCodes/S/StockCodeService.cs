using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S
{
    public class StockCodeService : IStockCodeService
    {
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly AppDbContext _context;

        public StockCodeService(
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo,
            ISProductRepositories productRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            AppDbContext context)
        {
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
            _productRepo = productRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _context = context;
        }

        public async Task<IReadOnlyList<LookupDto>> GetAllFluidsAsync(CancellationToken cancellationToken = default)
        {
            var fluids = await _fluidRepo.GetAllAsync(tracking: false);

            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default)
        {
            var list = await _groupRepo.GetAllAsync(tracking: false);
            return list
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetFluidsByGroupAsync(Guid sProductGroupId, CancellationToken cancellationToken = default)
        {
            // SPrefixRule üzerinden distinct fluid getiriyoruz
            var fluidIds = await _context.SPrefixRules
                .AsNoTracking()
                .Where(x => x.SProductGroupId == sProductGroupId)
                .Select(x => x.FluidId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var fluids = await _fluidRepo.GetAllAsync(x => fluidIds.Contains(x.Id), tracking: false);

            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductsAsync(Guid sProductGroupId, Guid fluidId, CancellationToken cancellationToken = default)
        {
            var productIds = await _context.SPrefixRules
                .AsNoTracking()
                .Where(x => x.SProductGroupId == sProductGroupId && x.FluidId == fluidId)
                .Select(x => x.SProductId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var products = await _productRepo.GetAllAsync(x => productIds.Contains(x.Id), tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<StockCardListItemDto>> ListSStockCardsAsync(int take = 200, CancellationToken cancellationToken = default)
        {
            var list = await _stockCardRepo.GetAllAsync(tracking: false);

            return list
                .OrderByDescending(x => x.CreatedDate)
                .Take(take)
                .Select(x => new StockCardListItemDto
                {
                    Id = x.Id,
                    StockCode8 = x.StockCode8,
                    Description = x.Description,
                    Prefix4 = x.Prefix4,
                    Serial4 = x.Serial4,
                    FluidCode = "",
                    GroupCode = "",
                    ProductCode = "",
                })
                .ToList();
        }

        public async Task<SStockCodeGenerateResultDto> GenerateSAsync(
            SStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            // 0) SPrefixRule’dan Prefix al
            var rule = await _context.SPrefixRules
                .AsNoTracking()
                .SingleOrDefaultAsync(x =>
                    x.FluidId == request.FluidId &&
                    x.SProductGroupId == request.SProductGroupId &&
                    x.SProductId == request.SProductId,
                    cancellationToken);

            if (rule == null)
                throw new InvalidOperationException("SPrefixRule bulunamadı (Group+Fluid+Product).");

            var prefix4 = rule.Prefix;

            // 0.1) ✅ SFC0 için FluidId sabitle (mevcut mantığın korunuyor)
            var effectiveFluidId = request.FluidId;
            string? fluidNameForDescription = null;

            if (string.Equals(prefix4, "SFC0", StringComparison.OrdinalIgnoreCase))
            {
                var allFluids = await _fluidRepo.GetAllAsync(tracking: false);
                var canonical = allFluids.FirstOrDefault(x => x.Code == "LIN") ?? allFluids.FirstOrDefault();

                if (canonical == null)
                    throw new InvalidOperationException("Sistemde akışkan tanımı yok.");

                effectiveFluidId = canonical.Id;
                fluidNameForDescription = "CRYO";
            }

            // 1) ✅ OptionKey üret
            var optionKey = await BuildOptionKeyAsync(request.SelectedFeatureValues, cancellationToken);

            // 2) ✅ Duplicate kontrol: (FluidId, GroupId, ProductId, OptionKey)
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == effectiveFluidId &&
                    x.SProductGroupId == request.SProductGroupId &&
                    x.SProductId == request.SProductId &&
                    x.OptionKey == optionKey,
                tracking: false);

            if (existing != null)
            {
                return new SStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 3) Lookup (Description için)
            var fluid = await _fluidRepo.GetByIdAsync(effectiveFluidId, tracking: false);
            var group = await _groupRepo.GetByIdAsync(request.SProductGroupId, tracking: false);
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);

            if (fluid == null || group == null || product == null)
                throw new InvalidOperationException("Fluid / Group / Product bulunamadı.");

            // 4) Transaction: sequence + card + selections
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

            var fluidName = fluidNameForDescription ?? fluid.Name;
            var description = $"{fluidName} | {group.Name} | {product.Name}";

            var card = new StockCard
            {
                Id = Guid.NewGuid(),

                FluidId = effectiveFluidId,
                SProductGroupId = request.SProductGroupId,
                SProductId = request.SProductId,

                Prefix4 = prefix4,
                Serial4 = nextSerial,
                StockCode8 = $"{prefix4}{nextSerial:0000}",
                Description = description,

                StockSequenceId = seq.Id,

                // ✅ NEW
                OptionKey = optionKey
            };

            await _stockCardRepo.AddAsync(card);
            await _stockCardRepo.SaveChangeAsync();

            // 5) ✅ Feature seçimlerini kaydet
            if (request.SelectedFeatureValues != null && request.SelectedFeatureValues.Count > 0)
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

            return new SStockCodeGenerateResultDto
            {
                AlreadyExists = false,
                StockCardId = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                Description = card.Description
            };
        }

        private async Task<string> BuildOptionKeyAsync(
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            if (selectedFeatureValues == null || selectedFeatureValues.Count == 0)
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

            var featureMap = features.ToDictionary(x => x.Id);
            var valueMap = values.ToDictionary(x => x.Id);

            var parts = selectedFeatureValues
                .Select(kvp =>
                {
                    if (!featureMap.TryGetValue(kvp.Key, out var f))
                        throw new InvalidOperationException("Feature bulunamadı (OptionKey).");

                    if (!valueMap.TryGetValue(kvp.Value, out var v))
                        throw new InvalidOperationException("FeatureValue bulunamadı (OptionKey).");

                    return new { f.SortOrder, f.Code, ValueCode = v.Code };
                })
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Code)
                .Select(x => $"{x.Code}={x.ValueCode}")
                .ToList();

            return string.Join("|", parts);
        }
    }
}
