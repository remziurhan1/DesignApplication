using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class StockProductGroupService : IStockProductGroupService
    {
        private readonly IStockProductGroupRepository _groupRepository;
        private readonly IStockProductGroupItemRepository _itemRepository;
        private readonly IGeneratedStockCodeRepository _generatedCodeRepository;

        public StockProductGroupService(
            IStockProductGroupRepository groupRepository,
            IStockProductGroupItemRepository itemRepository,
            IGeneratedStockCodeRepository generatedCodeRepository)
        {
            _groupRepository = groupRepository;
            _itemRepository = itemRepository;
            _generatedCodeRepository = generatedCodeRepository;
        }

        public async Task<List<StockProductGroupListDto>> GetAllAsync()
        {
            var groups = await _groupRepository.GetAllAsync(tracking: false);
            var items = await _itemRepository.GetAllAsync(tracking: false);

            var itemCounts = items
                .GroupBy(x => x.StockProductGroupId)
                .ToDictionary(x => x.Key, x => x.Count());

            return groups
                .OrderBy(x => x.Name)
                .Select(x => new StockProductGroupListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    TotalQuantity = x.TotalQuantity,
                    TotalCost = x.TotalCost,
                    AverageUnitCost = x.TotalQuantity > 0 ? x.TotalCost / x.TotalQuantity : 0,
                    ItemCount = itemCounts.TryGetValue(x.Id, out var count) ? count : 0
                })
                .ToList();
        }

        public async Task<StockProductGroupDetailDto?> GetByIdAsync(Guid id)
        {
            var group = await _groupRepository.GetByIdAsync(id, tracking: false);
            if (group == null)
            {
                return null;
            }

            var items = (await _itemRepository.GetAllAsync(x => x.StockProductGroupId == id, tracking: false)).ToList();
            var generatedCodeIds = items.Select(x => x.GeneratedStockCodeId).Distinct().ToList();
            var generatedCodes = (await _generatedCodeRepository.GetAllAsync(x => generatedCodeIds.Contains(x.Id), tracking: false))
                .ToDictionary(x => x.Id);

            return new StockProductGroupDetailDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                TotalQuantity = group.TotalQuantity,
                TotalCost = group.TotalCost,
                AverageUnitCost = group.TotalQuantity > 0 ? group.TotalCost / group.TotalQuantity : 0,
                ItemCount = items.Count,
                Items = items
                    .OrderBy(x => generatedCodes.TryGetValue(x.GeneratedStockCodeId, out var code) ? code.GeneratedCode : string.Empty)
                    .Select(x =>
                    {
                        generatedCodes.TryGetValue(x.GeneratedStockCodeId, out var code);
                        return new StockProductGroupItemDto
                        {
                            GeneratedStockCodeId = x.GeneratedStockCodeId,
                            GeneratedCode = code?.GeneratedCode ?? string.Empty,
                            Description = code?.Description ?? string.Empty,
                            UnitPrice = x.UnitPrice,
                            Quantity = x.Quantity,
                            TotalCost = x.TotalCost
                        };
                    })
                    .ToList()
            };
        }

        public async Task<StockProductGroupDetailDto> CreateAsync(StockProductGroupCreateDto dto)
        {
            var group = new StockProductGroup
            {
                Name = dto.Name.Trim(),
                Description = dto.Description?.Trim()
            };

            var preparedItems = await PrepareItemsAsync(group.Id, dto.Items);
            group.TotalQuantity = preparedItems.TotalQuantity;
            group.TotalCost = preparedItems.TotalCost;

            await _groupRepository.AddAsync(group);
            await _itemRepository.AddRangeAsync(preparedItems.Items);
            await _groupRepository.SaveChangeAsync();

            return await GetByIdAsync(group.Id) ?? throw new Exception("Product group create failed");
        }

        public async Task<StockProductGroupDetailDto> UpdateAsync(StockProductGroupUpdateDto dto)
        {
            var group = await _groupRepository.GetByIdAsync(dto.Id) ?? throw new Exception("Product group not found");

            group.Name = dto.Name.Trim();
            group.Description = dto.Description?.Trim();

            var existingItems = (await _itemRepository.GetAllAsync(x => x.StockProductGroupId == dto.Id)).ToList();
            if (existingItems.Any())
            {
                await _itemRepository.DeleteRangeAsync(existingItems);
            }

            var preparedItems = await PrepareItemsAsync(group.Id, dto.Items);
            group.TotalQuantity = preparedItems.TotalQuantity;
            group.TotalCost = preparedItems.TotalCost;

            await _groupRepository.UpdateAsync(group);
            await _itemRepository.AddRangeAsync(preparedItems.Items);
            await _groupRepository.SaveChangeAsync();

            return await GetByIdAsync(group.Id) ?? throw new Exception("Product group update failed");
        }

        public async Task DeleteAsync(Guid id)
        {
            var group = await _groupRepository.GetByIdAsync(id) ?? throw new Exception("Product group not found");
            var items = (await _itemRepository.GetAllAsync(x => x.StockProductGroupId == id)).ToList();
            if (items.Any())
            {
                await _itemRepository.DeleteRangeAsync(items);
            }

            await _groupRepository.DeleteAsync(group);
            await _groupRepository.SaveChangeAsync();
        }

        private async Task<(List<StockProductGroupItem> Items, int TotalQuantity, decimal TotalCost)> PrepareItemsAsync(Guid stockProductGroupId, List<StockProductGroupItemCreateDto> itemDtos)
        {
            if (itemDtos == null || itemDtos.Count == 0)
            {
                throw new Exception("At least one stock code row is required.");
            }

            var normalizedItems = itemDtos
                .Where(x => x.GeneratedStockCodeId != Guid.Empty && x.Quantity > 0)
                .ToList();

            if (!normalizedItems.Any())
            {
                throw new Exception("At least one valid stock code row is required.");
            }

            var generatedCodeIds = normalizedItems.Select(x => x.GeneratedStockCodeId).Distinct().ToList();
            var generatedCodes = (await _generatedCodeRepository.GetAllAsync(x => generatedCodeIds.Contains(x.Id))).ToDictionary(x => x.Id);

            var items = new List<StockProductGroupItem>();
            var totalQuantity = 0;
            var totalCost = 0m;

            foreach (var itemDto in normalizedItems)
            {
                if (!generatedCodes.TryGetValue(itemDto.GeneratedStockCodeId, out var generatedCode))
                {
                    throw new Exception("Generated stock code not found.");
                }

                var unitPrice = generatedCode.UnitPrice ?? 0;
                var itemTotalCost = unitPrice * itemDto.Quantity;

                items.Add(new StockProductGroupItem
                {
                    StockProductGroupId = stockProductGroupId,
                    GeneratedStockCodeId = generatedCode.Id,
                    Quantity = itemDto.Quantity,
                    UnitPrice = unitPrice,
                    TotalCost = itemTotalCost
                });

                totalQuantity += itemDto.Quantity;
                totalCost += itemTotalCost;
            }

            return (items, totalQuantity, totalCost);
        }
    }
}
