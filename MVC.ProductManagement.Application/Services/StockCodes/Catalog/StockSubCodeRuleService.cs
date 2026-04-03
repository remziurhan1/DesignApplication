using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;
namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class StockSubCodeRuleService : IStockSubCodeRuleService
    {
        private readonly IStockSubCodeRuleRepository _repository;
        private readonly IStockSubCodeGroupRepository _subGroupRepository;
        private readonly IStockMainCodeGroupRepository _mainGroupRepository;
        private readonly IGeneratedStockCodeService _generatedStockCodeService;

        public StockSubCodeRuleService(
            IStockSubCodeRuleRepository repository,
            IStockSubCodeGroupRepository subGroupRepository,
            IStockMainCodeGroupRepository mainGroupRepository,
            IGeneratedStockCodeService generatedStockCodeService)
        {
            _repository = repository;
            _subGroupRepository = subGroupRepository;
            _mainGroupRepository = mainGroupRepository;
            _generatedStockCodeService = generatedStockCodeService;
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
                .ThenBy(x => x.SortOrder ?? int.MaxValue)
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
                        SortOrder = x.SortOrder,
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
                SortOrder = entity.SortOrder,
                IsEnabled = entity.IsEnabled
            };
        }



        public async Task<StockSubCodeRuleDetailDto?> FindBySubGroupAndDescriptionAsync(Guid subGroupId, string? description)
        {
            var normalizedDescription = NormalizeDescription(description);
            if (string.IsNullOrEmpty(normalizedDescription))
            {
                return null;
            }

            var entities = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false);
            var matched = entities.FirstOrDefault(x => NormalizeDescription(x.Description) == normalizedDescription);
            if (matched == null)
            {
                return null;
            }

            return await GetByIdAsync(matched.Id);
        }

        public async Task<StockSubCodeRuleDetailDto> CreateAsync(StockSubCodeRuleCreateDto dto)
        {
            _ = await _subGroupRepository.GetByIdAsync(dto.StockSubCodeGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var normalizedDescription = NormalizeDescription(dto.Description);
            if (!string.IsNullOrEmpty(normalizedDescription))
            {
                var existingRule = await FindBySubGroupAndDescriptionAsync(dto.StockSubCodeGroupId, normalizedDescription);
                if (existingRule != null)
                {
                    return existingRule;
                }
            }

            var normalizedRuleCode = string.IsNullOrWhiteSpace(dto.RuleCode)
                ? await GetRuleCodeAsync(dto.StockSubCodeGroupId, dto.RuleName)
                : dto.RuleCode.Trim().ToUpperInvariant();

            var entity = new StockSubCodeRule
            {
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                RuleCode = normalizedRuleCode,
                RuleName = dto.RuleName.Trim(),
                Description = dto.Description?.Trim(),
                SortOrder = dto.SortOrder,
                IsEnabled = dto.IsEnabled
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();
            await _generatedStockCodeService.RefreshDerivedFieldsBySubGroupAsync(dto.StockSubCodeGroupId);
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Rule create failed");
        }

        public async Task<StockSubCodeRuleDetailDto> UpdateAsync(StockSubCodeRuleUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("Rule not found");
            var subGroupExists = await _subGroupRepository.AnyAsync(x => x.Id == dto.StockSubCodeGroupId);
            if (!subGroupExists) throw new Exception("Sub group not found");

            entity.StockSubCodeGroupId = dto.StockSubCodeGroupId;
            entity.RuleCode = string.IsNullOrWhiteSpace(dto.RuleCode)
                ? await GetRuleCodeAsync(dto.StockSubCodeGroupId, dto.RuleName)
                : dto.RuleCode.Trim().ToUpperInvariant();
            entity.RuleName = dto.RuleName.Trim();
            entity.Description = dto.Description?.Trim();
            entity.SortOrder = dto.SortOrder;
            entity.IsEnabled = dto.IsEnabled;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangeAsync();
            await _generatedStockCodeService.RefreshDerivedFieldsBySubGroupAsync(dto.StockSubCodeGroupId);
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Rule update failed");
        }

        public async Task<string> GetNextStockCodeBySubGroupAsync(Guid subGroupId)
        {
            var existingCodes = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false);
            var usedCodes = existingCodes
                .Select(x => x.RuleCode?.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var random = new Random();
            string code;
            do
            {
                code = random.Next(0, 1_000_000).ToString("D6");
            } while (usedCodes.Contains(code));

            return code;
        }

        private async Task<string> GetRuleCodeAsync(Guid subGroupId, string ruleName)
        {
            var normalizedRuleName = ruleName.Trim();
            var existingForGroup = (await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false))
                .FirstOrDefault(x => string.Equals(x.RuleName.Trim(), normalizedRuleName, StringComparison.OrdinalIgnoreCase)
                                  && !string.IsNullOrWhiteSpace(x.RuleCode));

            if (existingForGroup != null)
            {
                return existingForGroup.RuleCode.Trim().ToUpperInvariant();
            }

            return await GetNextStockCodeBySubGroupAsync(subGroupId);
        }


        private static string? NormalizeDescription(string? description)
        {
            var normalized = description?.Trim();
            return string.IsNullOrWhiteSpace(normalized) ? null : normalized.ToUpperInvariant();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Rule not found");
            var subGroupId = entity.StockSubCodeGroupId;
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangeAsync();
            await _generatedStockCodeService.RefreshDerivedFieldsBySubGroupAsync(subGroupId);
        }
    }
}
