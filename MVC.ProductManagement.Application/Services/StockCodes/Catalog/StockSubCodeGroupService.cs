using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class StockSubCodeGroupService : IStockSubCodeGroupService
    {
        private readonly IStockSubCodeGroupRepository _repository;
        private readonly IStockMainCodeGroupRepository _mainGroupRepository;

        public StockSubCodeGroupService(IStockSubCodeGroupRepository repository, IStockMainCodeGroupRepository mainGroupRepository)
        {
            _repository = repository;
            _mainGroupRepository = mainGroupRepository;
        }

        public async Task<List<StockSubCodeGroupListDto>> GetAllAsync(Guid? mainGroupId = null)
        {
            var entities = mainGroupId.HasValue
                ? await _repository.GetAllAsync(x => x.StockMainCodeGroupId == mainGroupId.Value, tracking: false)
                : await _repository.GetAllAsync(tracking: false);

            return entities
                .OrderBy(x => x.StockMainCodeGroup.Code)
                .ThenBy(x => x.Code)
                .Select(x => new StockSubCodeGroupListDto
                {
                    Id = x.Id,
                    StockMainCodeGroupId = x.StockMainCodeGroupId,
                    MainGroupCode = x.StockMainCodeGroup.Code,
                    MainGroupName = x.StockMainCodeGroup.Name,
                    Code = x.Code,
                    Name = x.Name,
                    IsEnabled = x.IsEnabled
                }).ToList();
        }

        public async Task<StockSubCodeGroupDetailDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, tracking: false);
            if (entity == null) return null;

            return new StockSubCodeGroupDetailDto
            {
                Id = entity.Id,
                StockMainCodeGroupId = entity.StockMainCodeGroupId,
                MainGroupCode = entity.StockMainCodeGroup.Code,
                MainGroupName = entity.StockMainCodeGroup.Name,
                Code = entity.Code,
                Name = entity.Name,
                IsEnabled = entity.IsEnabled
            };
        }

        public async Task<StockSubCodeGroupDetailDto> CreateAsync(StockSubCodeGroupCreateDto dto)
        {
            var mainGroupExists = await _mainGroupRepository.AnyAsync(x => x.Id == dto.StockMainCodeGroupId);
            if (!mainGroupExists) throw new Exception("Main group not found");

            var entity = new StockSubCodeGroup
            {
                StockMainCodeGroupId = dto.StockMainCodeGroupId,
                Code = dto.Code.Trim().ToUpperInvariant(),
                Name = dto.Name.Trim(),
                IsEnabled = dto.IsEnabled
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Sub group create failed");
        }

        public async Task<StockSubCodeGroupDetailDto> UpdateAsync(StockSubCodeGroupUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("Sub group not found");
            var mainGroupExists = await _mainGroupRepository.AnyAsync(x => x.Id == dto.StockMainCodeGroupId);
            if (!mainGroupExists) throw new Exception("Main group not found");

            entity.StockMainCodeGroupId = dto.StockMainCodeGroupId;
            entity.Code = dto.Code.Trim().ToUpperInvariant();
            entity.Name = dto.Name.Trim();
            entity.IsEnabled = dto.IsEnabled;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangeAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Sub group update failed");
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Sub group not found");
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangeAsync();
        }
    }
}
