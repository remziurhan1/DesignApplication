using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class StockMainCodeGroupService : IStockMainCodeGroupService
    {
        private readonly IStockMainCodeGroupRepository _repository;

        public StockMainCodeGroupService(IStockMainCodeGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockMainCodeGroupListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync(tracking: false);
            return entities
                .OrderBy(x => x.Code)
                .Select(x => new StockMainCodeGroupListDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsEnabled = x.IsEnabled
                }).ToList();
        }

        public async Task<StockMainCodeGroupDetailDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, tracking: false);
            if (entity == null) return null;

            return new StockMainCodeGroupDetailDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                IsEnabled = entity.IsEnabled
            };
        }

        public async Task<StockMainCodeGroupDetailDto> CreateAsync(StockMainCodeGroupCreateDto dto)
        {
            var entity = new StockMainCodeGroup
            {
                Code = dto.Code.Trim().ToUpperInvariant(),
                Name = dto.Name.Trim(),
                IsEnabled = dto.IsEnabled
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Main group create failed");
        }

        public async Task<StockMainCodeGroupDetailDto> UpdateAsync(StockMainCodeGroupUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("Main group not found");
            entity.Code = dto.Code.Trim().ToUpperInvariant();
            entity.Name = dto.Name.Trim();
            entity.IsEnabled = dto.IsEnabled;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangeAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Main group update failed");
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Main group not found");
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangeAsync();
        }
    }
}
