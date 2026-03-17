using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;
using System.Text.RegularExpressions;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class GeneratedStockCodeService : IGeneratedStockCodeService
    {
        private readonly IGeneratedStockCodeRepository _repository;
        private readonly IStockSubCodeGroupRepository _subGroupRepository;
        private readonly IStockMainCodeGroupRepository _mainGroupRepository;
        private readonly IStockSubCodeRuleRepository _ruleRepository;

        public GeneratedStockCodeService(
            IGeneratedStockCodeRepository repository,
            IStockSubCodeGroupRepository subGroupRepository,
            IStockMainCodeGroupRepository mainGroupRepository,
            IStockSubCodeRuleRepository ruleRepository)
        {
            _repository = repository;
            _subGroupRepository = subGroupRepository;
            _mainGroupRepository = mainGroupRepository;
            _ruleRepository = ruleRepository;
        }

        public async Task<List<GeneratedStockCodeListDto>> GetAllAsync(Guid? subGroupId = null)
        {
            var entities = subGroupId.HasValue
                ? await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId.Value, tracking: false)
                : await _repository.GetAllAsync(tracking: false);

            var subGroupIds = entities.Select(x => x.StockSubCodeGroupId).Distinct().ToList();
            var subGroups = await _subGroupRepository.GetAllAsync(x => subGroupIds.Contains(x.Id), tracking: false);
            var subGroupsById = subGroups.ToDictionary(x => x.Id);

            var mainGroupIds = subGroups.Select(x => x.StockMainCodeGroupId).Distinct().ToList();
            var mainGroups = await _mainGroupRepository.GetAllAsync(x => mainGroupIds.Contains(x.Id), tracking: false);
            var mainGroupsById = mainGroups.ToDictionary(x => x.Id);

            return entities
                .OrderByDescending(x => x.CreatedDate)
                .Select(x =>
                {
                    subGroupsById.TryGetValue(x.StockSubCodeGroupId, out var subGroup);
                    var mainGroup = subGroup != null && mainGroupsById.TryGetValue(subGroup.StockMainCodeGroupId, out var mg) ? mg : null;

                    return new GeneratedStockCodeListDto
                    {
                        Id = x.Id,
                        StockSubCodeGroupId = x.StockSubCodeGroupId,
                        StockSubCodeRuleId = x.StockSubCodeRuleId,
                        MainGroupCode = mainGroup?.Code ?? string.Empty,
                        SubGroupCode = subGroup?.Code ?? string.Empty,
                        SubGroupName = subGroup?.Name ?? string.Empty,
                        GeneratedCode = x.GeneratedCode,
                        RuleName = x.RuleName,
                        Description = x.Description,
                        UnitPrice = x.UnitPrice,
                        TargetPrice = x.TargetPrice
                    };
                })
                .ToList();
        }

        public async Task<GeneratedStockCodeResolveDto> ResolveCodeAsync(Guid subGroupId, string? ruleName, List<Guid>? selectedRuleIds = null)
        {
            var fallbackName = await ComposeRuleNameAsync(subGroupId, selectedRuleIds);
            var effectiveRuleName = !string.IsNullOrWhiteSpace(ruleName) ? ruleName.Trim() : fallbackName;
            var normalizedName = Normalize(effectiveRuleName);

            if (!string.IsNullOrWhiteSpace(normalizedName))
            {
                var existing = (await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false))
                    .FirstOrDefault(x => Normalize(x.RuleName) == normalizedName);

                if (existing != null)
                {
                    return new GeneratedStockCodeResolveDto
                    {
                        Code = existing.GeneratedCode,
                        RuleName = existing.RuleName,
                        Description = existing.Description,
                        UnitPrice = existing.UnitPrice,
                        TargetPrice = existing.TargetPrice,
                        IsExisting = true
                    };
                }
            }

            var nextCode = await GetNextCodeBySubGroupAsync(subGroupId);
            var codeWithRules = await ComposeCodeWithRulesAsync(subGroupId, nextCode, selectedRuleIds);
            var composedDescription = await ComposeDescriptionAsync(subGroupId, codeWithRules, selectedRuleIds, null);

            return new GeneratedStockCodeResolveDto
            {
                Code = codeWithRules,
                RuleName = effectiveRuleName,
                Description = composedDescription,
                IsExisting = false
            };
        }

        public async Task<GeneratedStockCodeListDto> CreateAsync(GeneratedStockCodeCreateDto dto)
        {
            var generatedCode = string.IsNullOrWhiteSpace(dto.GeneratedCode)
                ? await GetNextCodeBySubGroupAsync(dto.StockSubCodeGroupId)
                : dto.GeneratedCode.Trim().ToUpperInvariant();

            var baseCode = generatedCode.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? generatedCode;
            var codeWithRules = await ComposeCodeWithRulesAsync(dto.StockSubCodeGroupId, baseCode, dto.SelectedRuleIds);

            var existingByCode = (await _repository.GetAllAsync(x => x.StockSubCodeGroupId == dto.StockSubCodeGroupId, tracking: false))
                .FirstOrDefault(x => Normalize(x.GeneratedCode) == Normalize(codeWithRules));
            if (existingByCode != null)
            {
                return (await GetAllAsync(dto.StockSubCodeGroupId)).First(x => x.Id == existingByCode.Id);
            }

            var fallbackName = await ComposeRuleNameAsync(dto.StockSubCodeGroupId, dto.SelectedRuleIds);
            var effectiveRuleName = !string.IsNullOrWhiteSpace(dto.RuleName) ? dto.RuleName.Trim() : fallbackName;
            var normalizedName = Normalize(effectiveRuleName);

            if (!string.IsNullOrWhiteSpace(normalizedName))
            {
                var existingByName = (await _repository.GetAllAsync(x => x.StockSubCodeGroupId == dto.StockSubCodeGroupId, tracking: false))
                    .FirstOrDefault(x => Normalize(x.RuleName) == normalizedName);

                if (existingByName != null)
                {
                    return (await GetAllAsync(dto.StockSubCodeGroupId)).First(x => x.Id == existingByName.Id);
                }
            }

            var description = await ComposeDescriptionAsync(dto.StockSubCodeGroupId, codeWithRules, dto.SelectedRuleIds, dto.Description);

            var entity = new GeneratedStockCode
            {
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                StockSubCodeRuleId = dto.StockSubCodeRuleId,
                GeneratedCode = codeWithRules,
                RuleName = effectiveRuleName,
                Description = description,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();

            return (await GetAllAsync(entity.StockSubCodeGroupId)).First(x => x.Id == entity.Id);
        }

        private async Task<string> ComposeRuleNameAsync(Guid subGroupId, List<Guid>? selectedRuleIds)
        {
            if (selectedRuleIds?.Any() != true)
            {
                return string.Empty;
            }

            var ruleIdSet = selectedRuleIds.Distinct().ToList();
            var rules = await _ruleRepository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId && ruleIdSet.Contains(x.Id), tracking: false);
            var orderedRules = rules
                .OrderBy(x => x.SortOrder ?? int.MaxValue)
                .ThenBy(x => x.CreatedDate)
                .ThenBy(x => x.RuleCode)
                .ToList();

            var parts = orderedRules
                .Select(x => x.Description?.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .Distinct()
                .ToList();

            return string.Join("-", parts);
        }

        private async Task<string> GetNextCodeBySubGroupAsync(Guid subGroupId)
        {
            var subGroup = await _subGroupRepository.GetByIdAsync(subGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var subGroupCode = subGroup.Code.Trim().ToUpperInvariant();
            var existingCodes = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false);

            var regex = new Regex($"^{Regex.Escape(subGroupCode)}(\\d{{5}})(?:/.+)?$", RegexOptions.CultureInvariant);
            var maxNumber = existingCodes
                .Select(x => regex.Match(x.GeneratedCode))
                .Where(m => m.Success)
                .Select(m => int.Parse(m.Groups[1].Value))
                .DefaultIfEmpty(0)
                .Max();

            return $"{subGroupCode}{maxNumber + 1:D5}";
        }

        private async Task<string> ComposeCodeWithRulesAsync(Guid subGroupId, string baseCode, List<Guid>? selectedRuleIds)
        {
            var ruleParts = await GetOrderedRuleDescriptionsAsync(subGroupId, selectedRuleIds);
            if (!ruleParts.Any())
            {
                return baseCode;
            }

            return $"{baseCode}/{string.Join("/", ruleParts)}";
        }

        private async Task<string?> ComposeDescriptionAsync(Guid subGroupId, string codeWithRules, List<Guid>? selectedRuleIds, string? manualDescription)
        {
            var subGroup = await _subGroupRepository.GetByIdAsync(subGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var descriptionParts = new List<string> { codeWithRules, subGroup.Name.Trim() };
            descriptionParts.AddRange(await GetOrderedRuleDescriptionsAsync(subGroupId, selectedRuleIds));

            var normalizedParts = descriptionParts
                .Select(x => x?.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .Distinct()
                .ToList();

            var extra = manualDescription?.Trim();
            if (!string.IsNullOrWhiteSpace(extra))
            {
                normalizedParts.Add(extra);
            }

            return normalizedParts.Any() ? string.Join(" - ", normalizedParts) : null;
        }

        private async Task<List<string>> GetOrderedRuleDescriptionsAsync(Guid subGroupId, List<Guid>? selectedRuleIds)
        {
            var descriptions = new List<string>();

            if (selectedRuleIds?.Any() != true)
            {
                return descriptions;
            }

            var ruleIdSet = selectedRuleIds.Distinct().ToList();
            var rules = await _ruleRepository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId && ruleIdSet.Contains(x.Id), tracking: false);
            var orderedRules = rules
                .OrderBy(x => x.SortOrder ?? int.MaxValue)
                .ThenBy(x => x.CreatedDate)
                .ThenBy(x => x.RuleCode)
                .ToList();

            foreach (var description in orderedRules.Select(x => x.Description?.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                if (!descriptions.Contains(description!))
                {
                    descriptions.Add(description!);
                }
            }

            return descriptions;
        }

        private static string? Normalize(string? text)
        {
            var normalized = text?.Trim();
            return string.IsNullOrWhiteSpace(normalized) ? null : normalized.ToUpperInvariant();
        }
    }
}
