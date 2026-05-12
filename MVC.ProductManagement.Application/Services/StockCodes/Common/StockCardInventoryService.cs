using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

namespace MVC.ProductManagement.Infrastructure.Services.StockCards
{
    public class StockCardInventoryService : IStockCardInventoryService
    {
        private readonly IStockCardInventoryRepository _repository;

        public StockCardInventoryService(IStockCardInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CurrentInventoryDto> GetCurrentInventoryAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var stockCard = await _repository.GetStockCardAsync(stockCardId, tracking: false, cancellationToken);
            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            var lastMovement = await _repository.GetLastMovementAsync(stockCardId, cancellationToken);
            var byLocation = await _repository.GetLocationBalancesAsync(stockCardId, cancellationToken);

            return new CurrentInventoryDto
            {
                StockCardId = stockCardId,
                StockCode = stockCard.StockCode8,
                CurrentStock = lastMovement?.StockAfter ?? 0,
                LastMovementDate = lastMovement?.MovementDate,
                ByLocation = byLocation.Select(l => new InventoryByLocationDto
                {
                    Location = l.Location,
                    Quantity = l.StockAfter,
                    LastUpdate = l.MovementDate == default ? null : l.MovementDate
                }).ToList()
            };
        }

        public async Task<IReadOnlyList<InventoryDto>> GetInventoryMovementsAsync(
            Guid stockCardId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            CancellationToken cancellationToken = default)
        {
            var movements = await _repository.GetMovementsAsync(stockCardId, startDate, endDate, cancellationToken);
            return movements.Select(x => MapToDto(x)).ToList();
        }

        public async Task<InventoryDto> CreateMovementAsync(
            InventoryMovementCreateDto createDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var stockCard = await _repository.GetStockCardAsync(createDto.StockCardId, tracking: true, cancellationToken);
            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            var currentInventory = await GetCurrentInventoryAsync(createDto.StockCardId, cancellationToken);
            var stockBefore = currentInventory.CurrentStock;

            int stockAfter;
            switch (createDto.MovementType)
            {
                case InventoryMovementType.In:
                case InventoryMovementType.InitialStock:
                    stockAfter = stockBefore + createDto.Quantity;
                    break;
                case InventoryMovementType.Out:
                    if (stockBefore < createDto.Quantity)
                        throw new InvalidOperationException($"Yetersiz stok! Mevcut: {stockBefore}, İstenen: {createDto.Quantity}");
                    stockAfter = stockBefore - createDto.Quantity;
                    break;
                case InventoryMovementType.Adjustment:
                    stockAfter = createDto.Quantity;
                    createDto.Quantity = stockAfter - stockBefore;
                    break;
                default:
                    throw new InvalidOperationException("Geçersiz hareket tipi.");
            }

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
                Status = Status.Added
            };

            await _repository.AddAsync(movement, cancellationToken);
            await _repository.CommitAsync(cancellationToken);

            return MapToDto(movement, stockCard.StockCode8);
        }

        public async Task<InventoryDto> InitialStockAsync(
            Guid stockCardId,
            int quantity,
            string location,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var hasMovements = await _repository.HasMovementsAsync(stockCardId, cancellationToken);
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

        private static InventoryDto MapToDto(StockCardInventory movement, string? stockCode = null)
        {
            return new InventoryDto
            {
                Id = movement.Id,
                StockCardId = movement.StockCardId,
                StockCode = stockCode ?? movement.StockCard?.StockCode8 ?? string.Empty,
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
    }
}
