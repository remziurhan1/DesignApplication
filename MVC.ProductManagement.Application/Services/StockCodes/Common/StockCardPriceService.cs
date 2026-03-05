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
    public class StockCardPriceService : IStockCardPriceService
    {
        private readonly AppDbContext _context;

        public StockCardPriceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActivePriceDto> GetActivePriceAsync(
            Guid stockCardId,
            string currency = "TRY",
            CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            var today = now.Date;

            return await _context.StockCardPrices
                .AsNoTracking()
                .Where(p => p.StockCardId == stockCardId
                    && p.Currency == currency
                    && p.IsActive
                    && p.Status != Status.Deleted
                    && p.ValidFrom.Date <= today
                    && (p.ValidTo == null || p.ValidTo.Value.Date >= today))
                .OrderByDescending(p => p.ValidFrom)
                .Select(p => new ActivePriceDto
                {
                    Id = p.Id, // ✅ Id ekle
                    StockCardId = p.StockCardId,
                    StockCode = p.StockCard.StockCode8,
                    Currency = p.Currency,
                    UnitPrice = p.UnitPrice,
                    ValidFrom = p.ValidFrom,
                    ValidTo = p.ValidTo,
                    Notes = p.Notes // ✅ Notes ekle
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<PriceDto>> GetPriceHistoryAsync(
     Guid stockCardId,
     CancellationToken cancellationToken = default)
        {
            var prices = await _context.StockCardPrices
                .AsNoTracking()
                .Where(p => p.StockCardId == stockCardId && p.Status != Status.Deleted)
                .OrderByDescending(p => p.CreatedDate) // ✅ Oluşturulma tarihine göre sırala
                .Select(p => new PriceDto
                {
                    Id = p.Id,
                    StockCardId = p.StockCardId,
                    StockCode = p.StockCard.StockCode8,
                    Currency = p.Currency,
                    UnitPrice = p.UnitPrice,
                    ValidFrom = p.ValidFrom,
                    ValidTo = p.ValidTo,
                    IsActive = p.IsActive,
                    Notes = p.Notes,
                    CreatedDate = p.CreatedDate,
                    CreatedBy = p.CreatedBy
                })
                .ToListAsync(cancellationToken);

            // ✅ DEBUG: Console'a yaz
            Console.WriteLine($"=== GET PRICE HISTORY ===");
            Console.WriteLine($"StockCardId: {stockCardId}");
            Console.WriteLine($"Total Prices Found: {prices.Count}");
            foreach (var p in prices)
            {
                Console.WriteLine($"  - Price ID: {p.Id}, Currency: {p.Currency}, UnitPrice: {p.UnitPrice}, IsActive: {p.IsActive}, CreatedDate: {p.CreatedDate}");
            }

            return prices;
        }

        public async Task<PriceDto> CreatePriceAsync(
            PriceCreateDto createDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            // 1. Stok kartını kontrol et
            var stockCard = await _context.Set<StockCard>()
                .FirstOrDefaultAsync(sc => sc.Id == createDto.StockCardId && sc.Status != Status.Deleted, cancellationToken);

            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            // ✅ 2. Aynı currency için eski aktif fiyatları pasifleştir
            var existingActivePrices = await _context.StockCardPrices
                .Where(p => p.StockCardId == createDto.StockCardId
                         && p.Currency == createDto.Currency.ToUpper()
                         && p.IsActive
                         && p.Status != Status.Deleted)
                .ToListAsync(cancellationToken);

            foreach (var existingPrice in existingActivePrices)
            {
                existingPrice.IsActive = false;
                existingPrice.ModifiedBy = userName;
                existingPrice.ModifiedDate = DateTime.UtcNow;
                existingPrice.Status = Status.Modified;
            }

            // 3. Yeni fiyat oluştur
            var price = new StockCardPrice
            {
                Id = Guid.NewGuid(),
                StockCardId = createDto.StockCardId,
                Currency = createDto.Currency.ToUpper(),
                UnitPrice = createDto.UnitPrice,
                ValidFrom = createDto.ValidFrom.Date,
                ValidTo = createDto.ValidTo?.Date,
                IsActive = true, // ✅ Yeni fiyat aktif
                Notes = createDto.Notes ?? string.Empty, // ✅ Null kontrolü
                CreatedBy = userName,
                CreatedDate = DateTime.UtcNow,
                Status = Status.Added
            };

            _context.StockCardPrices.Add(price);
            await _context.SaveChangesAsync(cancellationToken);

            return new PriceDto
            {
                Id = price.Id,
                StockCardId = price.StockCardId,
                StockCode = stockCard.StockCode8,
                Currency = price.Currency,
                UnitPrice = price.UnitPrice,
                ValidFrom = price.ValidFrom,
                ValidTo = price.ValidTo,
                IsActive = price.IsActive,
                Notes = price.Notes,
                CreatedDate = price.CreatedDate,
                CreatedBy = price.CreatedBy
            };
        }

        public async Task<PriceDto> UpdatePriceAsync(
            PriceUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var price = await _context.StockCardPrices
                .Include(p => p.StockCard)
                .FirstOrDefaultAsync(p => p.Id == updateDto.Id && p.Status != Status.Deleted, cancellationToken);

            if (price == null)
                throw new InvalidOperationException("Fiyat kaydı bulunamadı.");

            // ✅ Eğer pasiften aktife çekiliyorsa, diğer aktif fiyatları pasifleştir
            if (updateDto.IsActive && !price.IsActive)
            {
                var existingActivePrices = await _context.StockCardPrices
                    .Where(p => p.StockCardId == price.StockCardId
                             && p.Currency == price.Currency
                             && p.IsActive
                             && p.Id != price.Id
                             && p.Status != Status.Deleted)
                    .ToListAsync(cancellationToken);

                foreach (var existingPrice in existingActivePrices)
                {
                    existingPrice.IsActive = false;
                    existingPrice.ModifiedBy = userName;
                    existingPrice.ModifiedDate = DateTime.UtcNow;
                    existingPrice.Status = Status.Modified;
                }
            }

            price.UnitPrice = updateDto.UnitPrice;
            price.ValidFrom = updateDto.ValidFrom.Date;
            price.ValidTo = updateDto.ValidTo?.Date;
            price.IsActive = updateDto.IsActive;
            price.Notes = updateDto.Notes ?? string.Empty; // ✅ Null kontrolü
            price.ModifiedBy = userName;
            price.ModifiedDate = DateTime.UtcNow;
            price.Status = Status.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return new PriceDto
            {
                Id = price.Id,
                StockCardId = price.StockCardId,
                StockCode = price.StockCard.StockCode8,
                Currency = price.Currency,
                UnitPrice = price.UnitPrice,
                ValidFrom = price.ValidFrom,
                ValidTo = price.ValidTo,
                IsActive = price.IsActive,
                Notes = price.Notes,
                CreatedDate = price.CreatedDate,
                CreatedBy = price.CreatedBy
            };
        }

        public async Task<bool> DeactivatePriceAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var price = await _context.StockCardPrices
                .FirstOrDefaultAsync(p => p.Id == id && p.Status != Status.Deleted, cancellationToken);

            if (price == null)
                return false;

            price.IsActive = false;
            price.ModifiedBy = userName;
            price.ModifiedDate = DateTime.UtcNow;
            price.Status = Status.Modified;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<PriceDto> GetPriceAtDateAsync(
            Guid stockCardId,
            DateTime date,
            string currency = "TRY",
            CancellationToken cancellationToken = default)
        {
            var atDate = date.Date;

            return await _context.StockCardPrices
                .AsNoTracking()
                .Where(p => p.StockCardId == stockCardId
                    && p.Currency == currency
                    && p.Status != Status.Deleted
                    && p.ValidFrom.Date <= atDate
                    && (p.ValidTo == null || p.ValidTo.Value.Date >= atDate))
                .OrderByDescending(p => p.ValidFrom)
                .Select(p => new PriceDto
                {
                    Id = p.Id,
                    StockCardId = p.StockCardId,
                    StockCode = p.StockCard.StockCode8,
                    Currency = p.Currency,
                    UnitPrice = p.UnitPrice,
                    ValidFrom = p.ValidFrom,
                    ValidTo = p.ValidTo,
                    IsActive = p.IsActive,
                    Notes = p.Notes,
                    CreatedDate = p.CreatedDate,
                    CreatedBy = p.CreatedBy
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> DeletePriceAsync(
    Guid id,
    string userName,
    CancellationToken cancellationToken = default)
        {
            var price = await _context.StockCardPrices
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (price == null)
                return false;

            _context.StockCardPrices.Remove(price);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }



        public async Task<bool> ReactivatePriceAsync(
    Guid id,
    string userName,
    CancellationToken cancellationToken = default)
        {
            var price = await _context.StockCardPrices
                .FirstOrDefaultAsync(p => p.Id == id && p.Status != Status.Deleted, cancellationToken);

            if (price == null)
                return false;

            // Aynı stok ve currency'deki diğer aktifleri pasifleştir
            var otherActivePrices = await _context.StockCardPrices
                .Where(p => p.StockCardId == price.StockCardId
                         && p.Currency == price.Currency
                         && p.IsActive
                         && p.Id != price.Id
                         && p.Status != Status.Deleted)
                .ToListAsync(cancellationToken);

            foreach (var item in otherActivePrices)
            {
                item.IsActive = false;
                item.ModifiedBy = userName;
                item.ModifiedDate = DateTime.UtcNow;
                item.Status = Status.Modified;
            }

            // Bu kaydı aktif yap
            price.IsActive = true;
            price.ModifiedBy = userName;
            price.ModifiedDate = DateTime.UtcNow;
            price.Status = Status.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }

}