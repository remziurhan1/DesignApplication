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
            var normalizedName = Normalize(ruleName);
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
            var composedDescription = await ComposeDescriptionAsync(subGroupId, selectedRuleIds, null);

            return new GeneratedStockCodeResolveDto
            {
                Code = nextCode,
                RuleName = ruleName?.Trim() ?? string.Empty,
                Description = composedDescription,
                IsExisting = false
            };
        }

        public async Task<GeneratedStockCodeListDto> CreateAsync(GeneratedStockCodeCreateDto dto)
        {
            var normalizedName = Normalize(dto.RuleName);
            var existing = (await _repository.GetAllAsync(x => x.StockSubCodeGroupId == dto.StockSubCodeGroupId, tracking: false))
                .FirstOrDefault(x => Normalize(x.RuleName) == normalizedName);

            if (existing != null)
            {
                return (await GetAllAsync(dto.StockSubCodeGroupId)).First(x => x.Id == existing.Id);
            }

            var generatedCode = string.IsNullOrWhiteSpace(dto.GeneratedCode)
                ? await GetNextCodeBySubGroupAsync(dto.StockSubCodeGroupId)
                : dto.GeneratedCode.Trim().ToUpperInvariant();

            var description = await ComposeDescriptionAsync(dto.StockSubCodeGroupId, dto.SelectedRuleIds, dto.Description);

            var entity = new GeneratedStockCode
            {
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                StockSubCodeRuleId = dto.StockSubCodeRuleId,
                GeneratedCode = generatedCode,
                RuleName = dto.RuleName.Trim(),
                Description = description,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();

            return (await GetAllAsync(entity.StockSubCodeGroupId)).First(x => x.Id == entity.Id);
        }

        private async Task<string> GetNextCodeBySubGroupAsync(Guid subGroupId)
        {
            var subGroup = await _subGroupRepository.GetByIdAsync(subGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var subGroupCode = subGroup.Code.Trim().ToUpperInvariant();
            var existingCodes = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false);

            var regex = new Regex($"^{Regex.Escape(subGroupCode)}(\\d{{5}})$", RegexOptions.CultureInvariant);
            var maxNumber = existingCodes
                .Select(x => regex.Match(x.GeneratedCode))
                .Where(m => m.Success)
                .Select(m => int.Parse(m.Groups[1].Value))
                .DefaultIfEmpty(0)
                .Max();

            return $"{subGroupCode}{maxNumber + 1:D5}";
        }

        private async Task<string?> ComposeDescriptionAsync(Guid subGroupId, List<Guid>? selectedRuleIds, string? manualDescription)
        {
            var descriptionParts = new List<string>();

            if (selectedRuleIds?.Any() == true)
            {
                var ruleIdSet = selectedRuleIds.Distinct().ToList();
                var rules = await _ruleRepository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId && ruleIdSet.Contains(x.Id), tracking: false);
                descriptionParts.AddRange(rules
                    .Select(x => x.Description?.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct()!);
            }

            var extra = manualDescription?.Trim();
            if (!string.IsNullOrWhiteSpace(extra))
            {
                descriptionParts.Add(extra);
            }

            return descriptionParts.Any() ? string.Join(" | ", descriptionParts.Distinct()) : null;
        }

        private static string? Normalize(string? text)
        {
            var normalized = text?.Trim();
            return string.IsNullOrWhiteSpace(normalized) ? null : normalized.ToUpperInvariant();
        }
    }
}
