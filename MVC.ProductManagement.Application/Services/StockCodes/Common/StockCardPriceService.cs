using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

namespace MVC.ProductManagement.Infrastructure.Services.StockCards
{
    public class StockCardPriceService : IStockCardPriceService
    {
        private readonly IStockCardPriceRepository _repository;
        private const string PriceCurrency = "EUR";

        public StockCardPriceService(IStockCardPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActivePriceDto> GetActivePriceAsync(
            Guid stockCardId,
            string currency = "EUR",
            CancellationToken cancellationToken = default)
        {
            var price = await _repository.GetActivePriceAsync(stockCardId, PriceCurrency, DateTime.UtcNow.Date, cancellationToken);
            return price == null ? null! : MapToActivePriceDto(price);
        }

        public async Task<IReadOnlyList<PriceDto>> GetPriceHistoryAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var prices = await _repository.GetPriceHistoryAsync(stockCardId, PriceCurrency, cancellationToken);
            var dtos = prices.Select(x => MapToPriceDto(x)).ToList();
            Console.WriteLine($"=== GET PRICE HISTORY ===");
            Console.WriteLine($"StockCardId: {stockCardId}");
            Console.WriteLine($"Total Prices Found: {dtos.Count}");
            foreach (var p in dtos)
            {
                Console.WriteLine($"  - Price ID: {p.Id}, Currency: {p.Currency}, UnitPrice: {p.UnitPrice}, IsActive: {p.IsActive}, CreatedDate: {p.CreatedDate}");
            }

            return dtos;
        }

        public async Task<PriceDto> CreatePriceAsync(
            PriceCreateDto createDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var stockCard = await _repository.GetStockCardAsync(createDto.StockCardId, cancellationToken);
            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            var existingActivePrices = await _repository.GetActivePricesAsync(createDto.StockCardId, PriceCurrency, cancellationToken: cancellationToken);
            DeactivatePrices(existingActivePrices, userName);

            var price = new StockCardPrice
            {
                Id = Guid.NewGuid(),
                StockCardId = createDto.StockCardId,
                Currency = PriceCurrency,
                UnitPrice = createDto.UnitPrice,
                TargetPrice = createDto.TargetPrice,
                PriceDate = (createDto.PriceDate ?? createDto.ValidFrom).Date,
                ValidFrom = createDto.ValidFrom.Date,
                ValidTo = createDto.ValidTo?.Date,
                IsActive = true,
                SupplierId = createDto.SupplierId,
                SupplierName = createDto.SupplierName,
                Notes = createDto.Notes ?? string.Empty,
                CreatedBy = userName,
                CreatedDate = DateTime.UtcNow,
                Status = Status.Added
            };

            await _repository.AddAsync(price, cancellationToken);
            await _repository.CommitAsync(cancellationToken);

            return MapToPriceDto(price, stockCard.StockCode8);
        }

        public async Task<PriceDto> UpdatePriceAsync(
            PriceUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var price = await _repository.GetByIdAsync(updateDto.Id, includeStockCard: true, cancellationToken: cancellationToken);
            if (price == null)
                throw new InvalidOperationException("Fiyat kaydı bulunamadı.");

            if (updateDto.IsActive && !price.IsActive)
            {
                var existingActivePrices = await _repository.GetActivePricesAsync(price.StockCardId, price.Currency, price.Id, cancellationToken);
                DeactivatePrices(existingActivePrices, userName);
            }

            price.UnitPrice = updateDto.UnitPrice;
            price.TargetPrice = updateDto.TargetPrice;
            price.PriceDate = (updateDto.PriceDate ?? updateDto.ValidFrom).Date;
            price.ValidFrom = updateDto.ValidFrom.Date;
            price.ValidTo = updateDto.ValidTo?.Date;
            price.IsActive = updateDto.IsActive;
            price.SupplierId = updateDto.SupplierId;
            price.SupplierName = updateDto.SupplierName;
            price.Notes = updateDto.Notes ?? string.Empty;
            price.ModifiedBy = userName;
            price.ModifiedDate = DateTime.UtcNow;
            price.Status = Status.Modified;

            await _repository.CommitAsync(cancellationToken);
            return MapToPriceDto(price);
        }

        public async Task<bool> DeactivatePriceAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var price = await _repository.GetByIdAsync(id, cancellationToken: cancellationToken);
            if (price == null)
                return false;

            price.IsActive = false;
            price.ModifiedBy = userName;
            price.ModifiedDate = DateTime.UtcNow;
            price.Status = Status.Modified;

            await _repository.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<PriceDto> GetPriceAtDateAsync(
            Guid stockCardId,
            DateTime date,
            string currency = "EUR",
            CancellationToken cancellationToken = default)
        {
            var price = await _repository.GetPriceAtDateAsync(stockCardId, PriceCurrency, date.Date, cancellationToken);
            return price == null ? null! : MapToPriceDto(price);
        }

        public async Task<bool> DeletePriceAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var price = await _repository.GetByIdAsync(id, includeDeleted: true, cancellationToken: cancellationToken);
            if (price == null)
                return false;

            _repository.Remove(price);
            await _repository.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ReactivatePriceAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var price = await _repository.GetByIdAsync(id, cancellationToken: cancellationToken);
            if (price == null)
                return false;

            var otherActivePrices = await _repository.GetActivePricesAsync(price.StockCardId, price.Currency, price.Id, cancellationToken);
            DeactivatePrices(otherActivePrices, userName);

            price.IsActive = true;
            price.ModifiedBy = userName;
            price.ModifiedDate = DateTime.UtcNow;
            price.Status = Status.Modified;

            await _repository.CommitAsync(cancellationToken);
            return true;
        }

        private static void DeactivatePrices(IEnumerable<StockCardPrice> prices, string userName)
        {
            foreach (var price in prices)
            {
                price.IsActive = false;
                price.ModifiedBy = userName;
                price.ModifiedDate = DateTime.UtcNow;
                price.Status = Status.Modified;
            }
        }

        private static ActivePriceDto MapToActivePriceDto(StockCardPrice price)
        {
            return new ActivePriceDto
            {
                Id = price.Id,
                StockCardId = price.StockCardId,
                StockCode = price.StockCard?.StockCode8 ?? string.Empty,
                Currency = price.Currency,
                UnitPrice = price.UnitPrice,
                TargetPrice = price.TargetPrice,
                PriceDate = price.PriceDate,
                ValidFrom = price.ValidFrom,
                ValidTo = price.ValidTo,
                SupplierId = price.SupplierId,
                SupplierName = price.SupplierName,
                Notes = price.Notes
            };
        }

        private static PriceDto MapToPriceDto(StockCardPrice price, string? stockCode = null)
        {
            return new PriceDto
            {
                Id = price.Id,
                StockCardId = price.StockCardId,
                StockCode = stockCode ?? price.StockCard?.StockCode8 ?? string.Empty,
                Currency = price.Currency,
                UnitPrice = price.UnitPrice,
                TargetPrice = price.TargetPrice,
                PriceDate = price.PriceDate,
                ValidFrom = price.ValidFrom,
                ValidTo = price.ValidTo,
                IsActive = price.IsActive,
                SupplierId = price.SupplierId,
                SupplierName = price.SupplierName,
                Notes = price.Notes,
                CreatedDate = price.CreatedDate,
                CreatedBy = price.CreatedBy
            };
        }
    }
}
