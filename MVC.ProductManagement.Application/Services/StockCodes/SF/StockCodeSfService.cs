using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SF
{
    public class StockCodeSfService : IStockCodeSfService
    {
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly AppDbContext _context;

        public StockCodeSfService(
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

        public async Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default)
        {
            var sfGroupId = await GetSfGroupIdAsync();

            // SPrefixRule'dan SF grubuna ait akışkanları getir
            var fluidIds = await _context.Set<Domain.Entities.StockCodes.S.SPrefixRule>()
                .AsNoTracking()
                .Where(x => x.SProductGroupId == sfGroupId)
                .Select(x => x.FluidId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var fluids = await _fluidRepo.GetAllAsync(
                x => fluidIds.Contains(x.Id),
                tracking: false);

            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSfProductsAsync(
            Guid fluidId,
            CancellationToken cancellationToken = default)
        {
            var sfGroupId = await GetSfGroupIdAsync();

            // SPrefixRule'dan fluid+group'a göre productId'leri al
            var productIds = await _context.Set<Domain.Entities.StockCodes.S.SPrefixRule>()
                .AsNoTracking()
                .Where(x => x.SProductGroupId == sfGroupId && x.FluidId == fluidId)
                .Select(x => x.SProductId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var products = await _productRepo.GetAllAsync(
                x => productIds.Contains(x.Id),
                tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

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

        public async Task<SfStockCodeGenerateResultDto> GenerateSfAsync(
            SfStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var sfGroupId = await GetSfGroupIdAsync();

            // 1) SPrefixRule'dan prefix bul
            var rule = await _context.Set<Domain.Entities.StockCodes.S.SPrefixRule>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.SProductGroupId == sfGroupId &&
                    x.FluidId == request.FluidId &&
                    x.SProductId == request.SProductId,
                    cancellationToken);

            if (rule == null)
                throw new InvalidOperationException("SF için prefix kuralı bulunamadı.");

            var prefix4 = rule.Prefix; // SFA0, SFC0, SFF0...

            // 2) OptionKey oluştur
            var optionKey = await BuildOptionKeyAsync(request.SelectedFeatureValues, cancellationToken);

            // 3) Duplicate kontrol
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == request.FluidId &&
                    x.SProductGroupId == sfGroupId &&
                    x.SProductId == request.SProductId &&
                    x.OptionKey == optionKey,
                tracking: false);

            if (existing != null)
            {
                return new SfStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 4) Lookup
            var fluid = await _fluidRepo.GetByIdAsync(request.FluidId, tracking: false);
            var group = await _groupRepo.GetByIdAsync(sfGroupId, tracking: false);
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);

            if (fluid == null || group == null || product == null)
                throw new InvalidOperationException("Fluid/Group/Product bulunamadı.");

            // 5) Feature açıklaması
            var featureDescription = await BuildFeatureDescriptionAsync(
                request.SelectedFeatureValues,
                cancellationToken);

            var description = string.IsNullOrWhiteSpace(featureDescription)
                ? $"{fluid.Name} | {group.Name} | {product.Name}"
                : $"{fluid.Name} | {group.Name} | {product.Name} | {featureDescription}";

            // 6) Transaction
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
                FluidId = request.FluidId,
                SProductGroupId = sfGroupId,
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

            // 7) Feature seçimlerini kaydet
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

            return new SfStockCodeGenerateResultDto
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

        private async Task<Guid> GetSfGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var sfGroup = groups.FirstOrDefault(x => x.Code == "F");
            if (sfGroup == null)
                throw new InvalidOperationException("SF (F) grubu tanımlı değil.");
            return sfGroup.Id;
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
                .Select(v => new { v.Id, v.Code })
                .ToListAsync(cancellationToken);

            var parts = selectedFeatureValues
                .Select(kvp =>
                {
                    var f = features.FirstOrDefault(x => x.Id == kvp.Key);
                    var v = values.FirstOrDefault(x => x.Id == kvp.Value);
                    if (f == null || v == null) return null;
                    return new { f.SortOrder, Text = v.Code };
                })
                .Where(x => x != null)
                .OrderBy(x => x.SortOrder)
                .Select(x => x.Text)
                .ToList();

            return string.Join(" | ", parts);
        }
    }
}
