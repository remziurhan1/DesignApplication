using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Services.StockCards
{
    public class StockCardGroupService : IStockCardGroupService
    {
        private readonly AppDbContext _context;
        private const string GroupCurrencyCode = "EUR";

        public StockCardGroupService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateGroupAsync(StockCardGroupCreateDto dto, string userName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new InvalidOperationException("Grup adı zorunludur.");

            var group = new StockCardGroup
            {
                Id = Guid.NewGuid(),
                GroupCode = await GenerateGroupCodeAsync(cancellationToken),
                Name = dto.Name.Trim(),
                CurrencyCode = GroupCurrencyCode,
                TotalAmount = 0,
                CreatedBy = userName,
                CreatedDate = DateTime.UtcNow,
                Status = Status.Added
            };

            _context.StockCardGroups.Add(group);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var item in dto.Items ?? new List<StockCardGroupCreateItemDto>())
            {
                if (item.StockCardId == Guid.Empty || item.Quantity <= 0) continue;
                await AddItemInternalAsync(group.Id, item.StockCardId, item.Quantity, userName, cancellationToken);
            }

            await RecalculateGroupTotalAsync(group.Id, userName, cancellationToken);
            return group.Id;
        }

        public async Task<IReadOnlyList<StockCardGroupListItemDto>> GetGroupsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StockCardGroups
                .AsNoTracking()
                .Where(g => g.Status != Status.Deleted)
                .OrderByDescending(g => g.CreatedDate)
                .Select(g => new StockCardGroupListItemDto
                {
                    Id = g.Id,
                    GroupCode = g.GroupCode,
                    Name = g.Name,
                    CurrencyCode = g.CurrencyCode,
                    ItemCount = g.Items.Count(i => i.Status != Status.Deleted),
                    TotalAmount = g.TotalAmount,
                    CreatedDate = g.CreatedDate
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<StockCardGroupDetailDto?> GetGroupDetailAsync(Guid groupId, CancellationToken cancellationToken = default)
        {
            return await _context.StockCardGroups
                .AsNoTracking()
                .Where(g => g.Id == groupId && g.Status != Status.Deleted)
                .Select(g => new StockCardGroupDetailDto
                {
                    Id = g.Id,
                    GroupCode = g.GroupCode,
                    Name = g.Name,
                    CurrencyCode = g.CurrencyCode,
                    TotalAmount = g.TotalAmount,
                    Items = g.Items
                        .Where(i => i.Status != Status.Deleted)
                        .OrderBy(i => i.SortOrder)
                        .Select(i => new StockCardGroupItemDto
                        {
                            ItemId = i.Id,
                            StockCardId = i.StockCardId,
                            StockCode8 = i.StockCard.StockCode8,
                            Description = i.StockCard.Description,
                            Quantity = i.Quantity,
                            UnitPrice = i.UnitPrice,
                            LineTotal = i.LineTotal
                        }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddItemAsync(Guid groupId, Guid stockCardId, int quantity, string userName, CancellationToken cancellationToken = default)
        {
            var group = await _context.StockCardGroups.FirstOrDefaultAsync(g => g.Id == groupId && g.Status != Status.Deleted, cancellationToken)
                ?? throw new InvalidOperationException("Grup bulunamadı.");

            await AddItemInternalAsync(groupId, stockCardId, quantity, userName, cancellationToken);
            await RecalculateGroupTotalAsync(groupId, userName, cancellationToken);
        }

        public async Task UpdateItemQuantityAsync(Guid groupItemId, int quantity, string userName, CancellationToken cancellationToken = default)
        {
            var item = await _context.StockCardGroupItems.FirstOrDefaultAsync(i => i.Id == groupItemId && i.Status != Status.Deleted, cancellationToken)
                ?? throw new InvalidOperationException("Grup satırı bulunamadı.");

            if (quantity <= 0)
                throw new InvalidOperationException("Adet 1 veya daha büyük olmalıdır.");

            item.Quantity = quantity;
            item.LineTotal = item.UnitPrice * item.Quantity;
            item.ModifiedBy = userName;
            item.ModifiedDate = DateTime.UtcNow;
            item.Status = Status.Modified;

            await _context.SaveChangesAsync(cancellationToken);
            await RecalculateGroupTotalAsync(item.StockCardGroupId, userName, cancellationToken);
        }

        public async Task RemoveItemAsync(Guid groupItemId, string userName, CancellationToken cancellationToken = default)
        {
            var item = await _context.StockCardGroupItems.FirstOrDefaultAsync(i => i.Id == groupItemId && i.Status != Status.Deleted, cancellationToken)
                ?? throw new InvalidOperationException("Grup satırı bulunamadı.");

            item.Status = Status.Deleted;
            item.DeletedBy = userName;
            item.DeletedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            await RecalculateGroupTotalAsync(item.StockCardGroupId, userName, cancellationToken);
        }

        public async Task<IReadOnlyList<StockCardLookupDto>> SearchStockCardsAsync(string? term, int take = 50, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<StockCard>()
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted);

            if (!string.IsNullOrWhiteSpace(term))
            {
                term = term.Trim();
                query = query.Where(x => x.StockCode8.Contains(term) || x.Description.Contains(term));
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Take(Math.Clamp(take, 1, 200))
                .Select(x => new StockCardLookupDto
                {
                    StockCardId = x.Id,
                    StockCode8 = x.StockCode8,
                    Description = x.Description
                })
                .ToListAsync(cancellationToken);
        }

        private async Task AddItemInternalAsync(Guid groupId, Guid stockCardId, int quantity, string userName, CancellationToken cancellationToken)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Adet 1 veya daha büyük olmalıdır.");

            var stockCardExists = await _context.Set<StockCard>().AnyAsync(x => x.Id == stockCardId && x.Status != Status.Deleted, cancellationToken);
            if (!stockCardExists)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            var existing = await _context.StockCardGroupItems
                .FirstOrDefaultAsync(i => i.StockCardGroupId == groupId && i.StockCardId == stockCardId && i.Status != Status.Deleted, cancellationToken);

            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.LineTotal = existing.Quantity * existing.UnitPrice;
                existing.ModifiedBy = userName;
                existing.ModifiedDate = DateTime.UtcNow;
                existing.Status = Status.Modified;
                await _context.SaveChangesAsync(cancellationToken);
                return;
            }

            var unitPrice = await ResolveUnitPriceAsync(stockCardId, cancellationToken);
            var sortOrder = await _context.StockCardGroupItems.Where(i => i.StockCardGroupId == groupId && i.Status != Status.Deleted).CountAsync(cancellationToken);

            _context.StockCardGroupItems.Add(new StockCardGroupItem
            {
                Id = Guid.NewGuid(),
                StockCardGroupId = groupId,
                StockCardId = stockCardId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                LineTotal = unitPrice * quantity,
                SortOrder = sortOrder,
                CreatedBy = userName,
                CreatedDate = DateTime.UtcNow,
                Status = Status.Added
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task<decimal> ResolveUnitPriceAsync(Guid stockCardId, CancellationToken cancellationToken)
        {
            var latestPrice = await _context.StockCardPrices
                .AsNoTracking()
                .Where(p => p.StockCardId == stockCardId
                    && p.Status != Status.Deleted
                    && (p.Currency ?? string.Empty).Trim().ToUpper() == GroupCurrencyCode)
                .OrderByDescending(p => p.CreatedDate)
                .ThenByDescending(p => p.ValidFrom)
                .Select(p => p.UnitPrice)
                .FirstOrDefaultAsync(cancellationToken);

            return latestPrice;
        }

        private async Task RecalculateGroupTotalAsync(Guid groupId, string userName, CancellationToken cancellationToken)
        {
            var group = await _context.StockCardGroups.FirstOrDefaultAsync(g => g.Id == groupId && g.Status != Status.Deleted, cancellationToken);
            if (group == null) return;

            group.TotalAmount = await _context.StockCardGroupItems
                .Where(i => i.StockCardGroupId == groupId && i.Status != Status.Deleted)
                .SumAsync(i => (decimal?)i.LineTotal, cancellationToken) ?? 0m;

            group.ModifiedBy = userName;
            group.ModifiedDate = DateTime.UtcNow;
            group.Status = Status.Modified;

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task<string> GenerateGroupCodeAsync(CancellationToken cancellationToken)
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var prefix = $"GRP-{datePart}-";

            var last = await _context.StockCardGroups
                .AsNoTracking()
                .Where(g => g.GroupCode.StartsWith(prefix))
                .OrderByDescending(g => g.GroupCode)
                .Select(g => g.GroupCode)
                .FirstOrDefaultAsync(cancellationToken);

            var seq = 1;
            if (!string.IsNullOrWhiteSpace(last))
            {
                var piece = last.Replace(prefix, string.Empty);
                if (int.TryParse(piece, out var parsed))
                    seq = parsed + 1;
            }

            return $"{prefix}{seq:000}";
        }
    }
}
