using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Services.StockCards
{
    public class StockCardInventoryService : IStockCardInventoryService
    {
        private readonly AppDbContext _context;

        public StockCardInventoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CurrentInventoryDto> GetCurrentInventoryAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var stockCard = await _context.Set<StockCard>()
                .AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.Id == stockCardId && sc.Status != Status.Deleted, cancellationToken); // ✅ Değişti

            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Son hareketi bul
            var lastMovement = await _context.StockCardInventories
                .AsNoTracking()
                .Where(i => i.StockCardId == stockCardId && i.Status != Status.Deleted) // ✅ Değişti
                .OrderByDescending(i => i.MovementDate)
                .ThenByDescending(i => i.CreatedDate)
                .FirstOrDefaultAsync(cancellationToken);

            // Lokasyonlara göre stok
            var byLocation = await _context.StockCardInventories
                .AsNoTracking()
                .Where(i => i.StockCardId == stockCardId && i.Status != Status.Deleted) // ✅ Değişti
                .GroupBy(i => i.Location ?? "Genel")
                .Select(g => new
                {
                    Location = g.Key,
                    LastMovement = g.OrderByDescending(x => x.MovementDate).FirstOrDefault()
                })
                .ToListAsync(cancellationToken);

            return new CurrentInventoryDto
            {
                StockCardId = stockCardId,
                StockCode = stockCard.StockCode8,
                CurrentStock = lastMovement?.StockAfter ?? 0,
                LastMovementDate = lastMovement?.MovementDate,
                ByLocation = byLocation.Select(l => new InventoryByLocationDto
                {
                    Location = l.Location,
                    Quantity = l.LastMovement?.StockAfter ?? 0,
                    LastUpdate = l.LastMovement?.MovementDate
                }).ToList()
            };
        }

        public async Task<IReadOnlyList<InventoryDto>> GetInventoryMovementsAsync(
            Guid stockCardId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            CancellationToken cancellationToken = default)
        {
            var query = _context.StockCardInventories
                .AsNoTracking()
                .Where(i => i.StockCardId == stockCardId && i.Status != Status.Deleted); // ✅ Değişti

            if (startDate.HasValue)
                query = query.Where(i => i.MovementDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(i => i.MovementDate <= endDate.Value);

            return await query
                .OrderByDescending(i => i.MovementDate)
                .ThenByDescending(i => i.CreatedDate)
                .Select(i => new InventoryDto
                {
                    Id = i.Id,
                    StockCardId = i.StockCardId,
                    StockCode = i.StockCard.StockCode8,
                    MovementType = i.MovementType,
                    Quantity = i.Quantity,
                    StockBefore = i.StockBefore,
                    StockAfter = i.StockAfter,
                    MovementDate = i.MovementDate,
                    Location = i.Location,
                    ReferenceDocument = i.ReferenceDocument,
                    Description = i.Description,
                    CreatedDate = i.CreatedDate,
                    CreatedBy = i.CreatedBy
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<InventoryDto> CreateMovementAsync(
            InventoryMovementCreateDto createDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            // Stok kartını kontrol et
            var stockCard = await _context.Set<StockCard>()
                .FirstOrDefaultAsync(sc => sc.Id == createDto.StockCardId && sc.Status != Status.Deleted, cancellationToken); // ✅ Değişti

            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Mevcut stok miktarını al
            var currentInventory = await GetCurrentInventoryAsync(createDto.StockCardId, cancellationToken);
            var stockBefore = currentInventory.CurrentStock;

            // Yeni stok miktarını hesapla
            int stockAfter;
            switch (createDto.MovementType)
            {
                case InventoryMovementType.In:
                    stockAfter = stockBefore + createDto.Quantity;
                    break;
                case InventoryMovementType.Out:
                    if (stockBefore < createDto.Quantity)
                        throw new InvalidOperationException($"Yetersiz stok! Mevcut: {stockBefore}, İstenen: {createDto.Quantity}");
                    stockAfter = stockBefore - createDto.Quantity;
                    break;
                case InventoryMovementType.Adjustment:
                    stockAfter = createDto.Quantity; // Düzeltme: direkt yeni miktar
                    createDto.Quantity = stockAfter - stockBefore; // Fark kadar hareket
                    break;
                default:
                    throw new InvalidOperationException("Geçersiz hareket tipi.");
            }

            // Hareket kaydı oluştur
            var movement = new StockCardInventory
            {
                Id = Guid.NewGuid(),
                StockCardId = createDto.StockCardId,
                MovementType = createDto.MovementType,
                Quantity = Math.Abs(createDto.Quantity),
                StockBefore = stockBefore,
                StockAfter = stockAfter,
                MovementDate = createDto.MovementDate,
                Location = createDto.Location ?? "Genel",
                ReferenceDocument = createDto.ReferenceDocument,
                Description = createDto.Description,
                CreatedBy = userName,
                CreatedDate = DateTime.UtcNow,
                Status = Status.Added // ✅ Değişti
            };

            _context.StockCardInventories.Add(movement);
            await _context.SaveChangesAsync(cancellationToken);

            return new InventoryDto
            {
                Id = movement.Id,
                StockCardId = movement.StockCardId,
                StockCode = stockCard.StockCode8,
                MovementType = movement.MovementType,
                Quantity = movement.Quantity,
                StockBefore = movement.StockBefore,
                StockAfter = movement.StockAfter,
                MovementDate = movement.MovementDate,
                Location = movement.Location,
                ReferenceDocument = movement.ReferenceDocument,
                Description = movement.Description,
                CreatedDate = movement.CreatedDate,
                CreatedBy = movement.CreatedBy
            };
        }

        public async Task<InventoryDto> InitialStockAsync(
            Guid stockCardId,
            int quantity,
            string location,
            string userName,
            CancellationToken cancellationToken = default)
        {
            // Daha önce hareket var mı kontrol et
            var hasMovements = await _context.StockCardInventories
                .AnyAsync(i => i.StockCardId == stockCardId && i.Status != Status.Deleted, cancellationToken); // ✅ Değişti

            if (hasMovements)
                throw new InvalidOperationException("Bu stok kartı için zaten hareket kaydı mevcut!");

            var createDto = new InventoryMovementCreateDto
            {
                StockCardId = stockCardId,
                MovementType = InventoryMovementType.InitialStock,
                Quantity = quantity,
                MovementDate = DateTime.UtcNow,
                Location = location ?? "Genel",
                Description = "İlk stok girişi"
            };

            return await CreateMovementAsync(createDto, userName, cancellationToken);
        }
    }
}