using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Domain.Entities;
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
        /// ✅ 1. SA Ürün listesi
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
        /// ✅ 2. Ürüne göre feature'ları getir
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
        /// ✅ 3. Kod üretimi
        /// </summary>
        public async Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            // 1) Product
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SA ürünü bulunamadı.");

            var prefix4 = product.Code;

            // 2) Default fluid
            var allFluids = await _fluidRepo.GetAllAsync(tracking: false);
            var defaultFluid = allFluids.FirstOrDefault(x => x.Code == "A") ?? allFluids.First();

            // 3) OptionKey oluştur
            var optionKey = await BuildOptionKeyAsync(request.SelectedFeatureValues, cancellationToken);

            // 4) Duplicate kontrol
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

            // 5) Description
            var description = await BuildFeatureDescriptionAsync(request.SelectedFeatureValues, cancellationToken);

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

        /// <summary>
        /// ✅ 4. Liste (filtreleme + pagination)
        /// </summary>
        public async Task<SAStockCardListResultDto> GetStockCardsAsync(
            SAStockCardFilterDto filter,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Set<StockCard>()
                .AsNoTracking()
                .Include(sc => sc.SProduct)
                .Include(sc => sc.Fluid)
                .Where(sc => !sc.IsDeleted);

            // Filtreleme
            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                query = query.Where(sc =>
                    sc.StockCode8.Contains(filter.SearchTerm) ||
                    sc.Description.Contains(filter.SearchTerm));
            }

            if (filter.ProductId.HasValue)
            {
                query = query.Where(sc => sc.SProductId == filter.ProductId.Value);
            }

            if (filter.StartDate.HasValue)
            {
                query = query.Where(sc => sc.CreatedDate >= filter.StartDate.Value);
            }

            if (filter.EndDate.HasValue)
            {
                query = query.Where(sc => sc.CreatedDate <= filter.EndDate.Value);
            }

            // Toplam sayı
            var totalCount = await query.CountAsync(cancellationToken);

            // Pagination
            var items = await query
                .OrderByDescending(sc => sc.CreatedDate)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(sc => new SAStockCardListItemDto
                {
                    Id = sc.Id,
                    StockCode8 = sc.StockCode8,
                    Prefix4 = sc.Prefix4,
                    Serial4 = sc.Serial4,
                    ProductCode = sc.SProduct.Code,
                    ProductName = sc.SProduct.Name,
                    FluidCode = sc.Fluid.Code,
                    FluidName = sc.Fluid.Name,
                    Description = sc.Description,
                    CreatedDate = sc.CreatedDate,
                    CreatedBy = sc.CreatedBy
                })
                .ToListAsync(cancellationToken);

            return new SAStockCardListResultDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        /// <summary>
        /// ✅ 5. Detay görüntüleme
        /// </summary>
        public async Task<SAStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var card = await _context.Set<StockCard>()
                .AsNoTracking()
                .Include(sc => sc.SProduct)
                .Include(sc => sc.Fluid)
                .FirstOrDefaultAsync(sc => sc.Id == stockCardId && !sc.IsDeleted, cancellationToken);

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
                    FeatureId = s.SFeatureId,
                    FeatureName = s.SFeature.Name,
                    ValueId = s.SFeatureValueId,
                    ValueCode = s.SFeatureValue.Code,
                    ValueName = s.SFeatureValue.Name,
                    SortOrder = s.SFeature.SortOrder
                })
                .ToListAsync(cancellationToken);

            return new SAStockCardDetailDto
            {
                Id = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                ProductId = card.SProductId,
                ProductCode = card.SProduct.Code,
                ProductName = card.SProduct.Name,
                FluidId = card.FluidId,
                FluidCode = card.Fluid.Code,
                FluidName = card.Fluid.Name,
                Description = card.Description,
                OptionKey = card.OptionKey,
                CreatedDate = card.CreatedDate,
                CreatedBy = card.CreatedBy,
                FeatureSelections = selections
            };
        }

        /// <summary>
        /// ✅ 6. Düzenleme için veri getir
        /// </summary>
        public async Task<SAStockCardUpdateDto> GetStockCardForEditAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var selections = await _context.Set<StockCardFeatureSelection>()
                .AsNoTracking()
                .Where(sc => sc.StockCardId == stockCardId)
                .ToListAsync(cancellationToken);

            if (!selections.Any())
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            return new SAStockCardUpdateDto
            {
                StockCardId = stockCardId,
                FeatureSelections = selections.ToDictionary(
                    fs => fs.SFeatureId,
                    fs => fs.SFeatureValueId)
            };
        }

        /// <summary>
        /// ✅ 7. Güncelleme
        /// </summary>
        public async Task<bool> UpdateStockCardAsync(
            SAStockCardUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var card = await _context.Set<StockCard>()
                .FirstOrDefaultAsync(sc => sc.Id == updateDto.StockCardId && !sc.IsDeleted, cancellationToken);

            if (card == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Eski feature seçimlerini sil
            var oldSelections = await _context.Set<StockCardFeatureSelection>()
                .Where(fs => fs.StockCardId == updateDto.StockCardId)
                .ToListAsync(cancellationToken);

            _context.Set<StockCardFeatureSelection>().RemoveRange(oldSelections);

            // Yeni feature seçimlerini ekle
            var newSelections = updateDto.FeatureSelections.Select(kvp => new StockCardFeatureSelection
            {
                Id = Guid.NewGuid(),
                StockCardId = card.Id,
                SFeatureId = kvp.Key,
                SFeatureValueId = kvp.Value,
                CreatedBy = userName,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.Status.Added
            }).ToList();

            _context.Set<StockCardFeatureSelection>().AddRange(newSelections);

            // Description'ı yeniden oluştur
            card.Description = await BuildFeatureDescriptionAsync(updateDto.FeatureSelections, cancellationToken);
            card.ModifiedDate = DateTime.Now;
            card.ModifiedBy = userName;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// ✅ 8. Silme (soft delete)
        /// </summary>
        public async Task<bool> DeleteStockCardAsync(
            Guid stockCardId,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var card = await _context.Set<StockCard>()
                .FirstOrDefaultAsync(sc => sc.Id == stockCardId && !sc.IsDeleted, cancellationToken);

            if (card == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            card.IsDeleted = true;
            card.DeletedDate = DateTime.Now;
            card.DeletedBy = userName;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// ✅ 9. Feature değerleri getir
        /// </summary>
        public async Task<List<FeatureValueDto>> GetFeatureValuesAsync(Guid featureId)
        {
            var values = await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(fv => fv.SFeatureId == featureId)
                .OrderBy(fv => fv.SortOrder)
                .Select(fv => new FeatureValueDto
                {
                    Id = fv.Id,
                    Code = fv.Code,
                    Name = fv.Name,
                    SortOrder = fv.SortOrder
                })
                .ToListAsync();

            return values;
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

            var valueIds = selectedFeatureValues.Values.ToList();

            var values = await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Include(fv => fv.SFeature)
                .Where(fv => valueIds.Contains(fv.Id))
                .OrderBy(fv => fv.SFeature.SortOrder)
                .Select(fv => fv.Name)
                .ToListAsync(cancellationToken);

            return string.Join(" | ", values);
        }
    }
}