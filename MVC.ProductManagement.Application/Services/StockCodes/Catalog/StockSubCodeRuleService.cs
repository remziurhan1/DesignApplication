using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;
using System.Text.RegularExpressions;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class StockSubCodeRuleService : IStockSubCodeRuleService
    {
        private readonly IStockSubCodeRuleRepository _repository;
        private readonly IStockSubCodeGroupRepository _subGroupRepository;
        private readonly IStockMainCodeGroupRepository _mainGroupRepository;

        public StockSubCodeRuleService(
            IStockSubCodeRuleRepository repository,
            IStockSubCodeGroupRepository subGroupRepository,
            IStockMainCodeGroupRepository mainGroupRepository)
        {
            _repository = repository;
            _subGroupRepository = subGroupRepository;
            _mainGroupRepository = mainGroupRepository;
        }

        public async Task<List<StockSubCodeRuleListDto>> GetAllAsync(Guid? subGroupId = null)
        {
            var entities = subGroupId.HasValue
                ? await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId.Value, tracking: false)
                : await _repository.GetAllAsync(tracking: false);

            var subGroupIds = entities
                .Select(x => x.StockSubCodeGroupId)
                .Distinct()
                .ToList();

            var subGroups = await _subGroupRepository.GetAllAsync(x => subGroupIds.Contains(x.Id), tracking: false);
            var subGroupsById = subGroups.ToDictionary(x => x.Id);

            var mainGroupIds = subGroups
                .Select(x => x.StockMainCodeGroupId)
                .Distinct()
                .ToList();

            var mainGroups = await _mainGroupRepository.GetAllAsync(x => mainGroupIds.Contains(x.Id), tracking: false);
            var mainGroupsById = mainGroups.ToDictionary(x => x.Id);

            return entities
                .OrderBy(x =>
                {
                    if (!subGroupsById.TryGetValue(x.StockSubCodeGroupId, out var subGroup)) return string.Empty;
                    return mainGroupsById.TryGetValue(subGroup.StockMainCodeGroupId, out var mainGroup) ? mainGroup.Code : string.Empty;
                })
                .ThenBy(x => subGroupsById.TryGetValue(x.StockSubCodeGroupId, out var subGroup) ? subGroup.Code : string.Empty)
                .ThenBy(x => x.RuleCode)
                .Select(x =>
                {
                    subGroupsById.TryGetValue(x.StockSubCodeGroupId, out var subGroup);
                    var mainGroup = subGroup != null && mainGroupsById.TryGetValue(subGroup.StockMainCodeGroupId, out var group)
                        ? group
                        : null;

                    return new StockSubCodeRuleListDto
                    {
                        Id = x.Id,
                        StockSubCodeGroupId = x.StockSubCodeGroupId,
                        MainGroupCode = mainGroup?.Code ?? string.Empty,
                        MainGroupName = mainGroup?.Name ?? string.Empty,
                        SubGroupCode = subGroup?.Code ?? string.Empty,
                        SubGroupName = subGroup?.Name ?? string.Empty,
                        RuleCode = x.RuleCode,
                        RuleName = x.RuleName,
                        Description = x.Description,
                        IsEnabled = x.IsEnabled
                    };
                })
                .ToList();
        }

        public async Task<StockSubCodeRuleDetailDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, tracking: false);
            if (entity == null) return null;

            var subGroup = await _subGroupRepository.GetByIdAsync(entity.StockSubCodeGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var mainGroup = await _mainGroupRepository.GetByIdAsync(subGroup.StockMainCodeGroupId, tracking: false)
                ?? throw new Exception("Main group not found");

            return new StockSubCodeRuleDetailDto
            {
                Id = entity.Id,
                StockSubCodeGroupId = entity.StockSubCodeGroupId,
                MainGroupCode = mainGroup.Code,
                MainGroupName = mainGroup.Name,
                SubGroupCode = subGroup.Code,
                SubGroupName = subGroup.Name,
                RuleCode = entity.RuleCode,
                RuleName = entity.RuleName,
                Description = entity.Description,
                IsEnabled = entity.IsEnabled
            };
        }

        public async Task<StockSubCodeRuleDetailDto> CreateAsync(StockSubCodeRuleCreateDto dto)
        {
            _ = await _subGroupRepository.GetByIdAsync(dto.StockSubCodeGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var normalizedRuleCode = string.IsNullOrWhiteSpace(dto.RuleCode)
                ? await GetNextStockCodeBySubGroupAsync(dto.StockSubCodeGroupId)
                : dto.RuleCode.Trim().ToUpperInvariant();

            var entity = new StockSubCodeRule
            {
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                RuleCode = normalizedRuleCode,
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

        public async Task<string> GetNextStockCodeBySubGroupAsync(Guid subGroupId)
        {
            var subGroup = await _subGroupRepository.GetByIdAsync(subGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var subGroupCode = subGroup.Code.Trim().ToUpperInvariant();
            var existingCodes = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false);

            var regex = new Regex($"^{Regex.Escape(subGroupCode)}(\\d{{5}})$", RegexOptions.CultureInvariant);
            var maxNumber = existingCodes
                .Select(x => regex.Match(x.RuleCode))
                .Where(m => m.Success)
                .Select(m => int.Parse(m.Groups[1].Value))
                .DefaultIfEmpty(0)
                .Max();

            var nextNumber = maxNumber + 1;
            return $"{subGroupCode}{nextNumber:D5}";
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Rule not found");
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangeAsync();
        }
    }
}
