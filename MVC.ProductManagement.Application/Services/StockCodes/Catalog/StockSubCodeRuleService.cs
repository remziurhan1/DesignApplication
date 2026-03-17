using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class StockSubCodeRuleService : IStockSubCodeRuleService
    {
        private readonly IStockSubCodeRuleRepository _repository;
        private readonly IStockSubCodeGroupRepository _subGroupRepository;

        public StockSubCodeRuleService(IStockSubCodeRuleRepository repository, IStockSubCodeGroupRepository subGroupRepository)
        {
            _repository = repository;
            _subGroupRepository = subGroupRepository;
        }

        public async Task<List<StockSubCodeRuleListDto>> GetAllAsync(Guid? subGroupId = null)
        {
            var entities = subGroupId.HasValue
                ? await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId.Value, tracking: false)
                : await _repository.GetAllAsync(tracking: false);

            return entities
                .OrderBy(x => x.StockSubCodeGroup.StockMainCodeGroup.Code)
                .ThenBy(x => x.StockSubCodeGroup.Code)
                .ThenBy(x => x.RuleCode)
                .Select(x => new StockSubCodeRuleListDto
                {
                    Id = x.Id,
                    StockSubCodeGroupId = x.StockSubCodeGroupId,
                    MainGroupCode = x.StockSubCodeGroup.StockMainCodeGroup.Code,
                    MainGroupName = x.StockSubCodeGroup.StockMainCodeGroup.Name,
                    SubGroupCode = x.StockSubCodeGroup.Code,
                    SubGroupName = x.StockSubCodeGroup.Name,
                    RuleCode = x.RuleCode,
                    RuleName = x.RuleName,
                    Description = x.Description,
                    IsEnabled = x.IsEnabled
                }).ToList();
        }

        public async Task<StockSubCodeRuleDetailDto?> GetByIdAsync(Guid id)
        {
            var x = await _repository.GetByIdAsync(id, tracking: false);
            if (x == null) return null;

            return new StockSubCodeRuleDetailDto
            {
                Id = x.Id,
                StockSubCodeGroupId = x.StockSubCodeGroupId,
                MainGroupCode = x.StockSubCodeGroup.StockMainCodeGroup.Code,
                MainGroupName = x.StockSubCodeGroup.StockMainCodeGroup.Name,
                SubGroupCode = x.StockSubCodeGroup.Code,
                SubGroupName = x.StockSubCodeGroup.Name,
                RuleCode = x.RuleCode,
                RuleName = x.RuleName,
                Description = x.Description,
                IsEnabled = x.IsEnabled
            };
        }

        public async Task<StockSubCodeRuleDetailDto> CreateAsync(StockSubCodeRuleCreateDto dto)
        {
            var subGroupExists = await _subGroupRepository.AnyAsync(x => x.Id == dto.StockSubCodeGroupId);
            if (!subGroupExists) throw new Exception("Sub group not found");

            var entity = new StockSubCodeRule
            {
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                RuleCode = dto.RuleCode.Trim().ToUpperInvariant(),
                RuleName = dto.RuleName.Trim(),
                Description = dto.Description?.Trim(),
                IsEnabled = dto.IsEnabled
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Rule create failed");
        }

        public async Task<StockSubCodeRuleDetailDto> UpdateAsync(StockSubCodeRuleUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("Rule not found");
            var subGroupExists = await _subGroupRepository.AnyAsync(x => x.Id == dto.StockSubCodeGroupId);
            if (!subGroupExists) throw new Exception("Sub group not found");

            entity.StockSubCodeGroupId = dto.StockSubCodeGroupId;
            entity.RuleCode = dto.RuleCode.Trim().ToUpperInvariant();
            entity.RuleName = dto.RuleName.Trim();
            entity.Description = dto.Description?.Trim();
            entity.IsEnabled = dto.IsEnabled;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangeAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Rule update failed");
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Rule not found");
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangeAsync();
        }
    }
}
