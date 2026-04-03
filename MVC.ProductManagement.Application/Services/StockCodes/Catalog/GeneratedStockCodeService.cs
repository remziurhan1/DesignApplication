using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public class GeneratedStockCodeService : IGeneratedStockCodeService
    {
        private const int GeneratedCodePrefixLength = 4;
        private const int GeneratedCodeNumericLength = 4;
        private const int GeneratedCodeLength = GeneratedCodePrefixLength + GeneratedCodeNumericLength;

        private readonly IGeneratedStockCodeRepository _repository;
        private readonly IStockSubCodeGroupRepository _subGroupRepository;
        private readonly IStockMainCodeGroupRepository _mainGroupRepository;
        private readonly IStockSubCodeRuleRepository _ruleRepository;
        private readonly AppDbContext _context;

        public GeneratedStockCodeService(
            IGeneratedStockCodeRepository repository,
            IStockSubCodeGroupRepository subGroupRepository,
            IStockMainCodeGroupRepository mainGroupRepository,
            IStockSubCodeRuleRepository ruleRepository,
            AppDbContext context)
        {
            _repository = repository;
            _subGroupRepository = subGroupRepository;
            _mainGroupRepository = mainGroupRepository;
            _ruleRepository = ruleRepository;
            _context = context;
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
                        TargetPrice = x.TargetPrice,
                        PrimaryUnitType = x.PrimaryUnitType,
                        KgEquivalentPerPrimaryUnit = x.KgEquivalentPerPrimaryUnit
                    };
                })
                .ToList();
        }

        public async Task<GeneratedStockCodeDetailDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, tracking: false);
            if (entity == null)
            {
                return null;
            }

            var item = (await GetAllAsync(entity.StockSubCodeGroupId)).FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return null;
            }

            return new GeneratedStockCodeDetailDto
            {
                Id = item.Id,
                StockSubCodeGroupId = item.StockSubCodeGroupId,
                StockSubCodeRuleId = item.StockSubCodeRuleId,
                MainGroupCode = item.MainGroupCode,
                SubGroupCode = item.SubGroupCode,
                SubGroupName = item.SubGroupName,
                GeneratedCode = item.GeneratedCode,
                RuleName = item.RuleName,
                Description = item.Description,
                UnitPrice = item.UnitPrice,
                TargetPrice = item.TargetPrice,
                PrimaryUnitType = item.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = item.KgEquivalentPerPrimaryUnit
            };
        }

        public async Task<GeneratedStockCodeResolveDto> ResolveCodeAsync(Guid subGroupId, List<Guid>? selectedRuleIds = null)
        {
            var nextCode = await GetNextCodeBySubGroupAsync(subGroupId);
            var composedRuleName = await ComposeRuleNameAsync(subGroupId, selectedRuleIds);
            var composedDescription = await ComposeDescriptionAsync(subGroupId, selectedRuleIds, null);

            return new GeneratedStockCodeResolveDto
            {
                Code = nextCode,
                RuleName = composedRuleName,
                Description = composedDescription,
                IsExisting = false
            };
        }

        public async Task<GeneratedStockCodeListDto> CreateAsync(GeneratedStockCodeCreateDto dto)
        {
            var subGroup = await _subGroupRepository.GetByIdAsync(dto.StockSubCodeGroupId, tracking: false)
                ?? throw new Exception("Sub group not found");

            var stockCodePrefix = GetStockCodePrefix(subGroup.Code);
            var generatedCode = string.IsNullOrWhiteSpace(dto.GeneratedCode)
                ? await GetNextCodeBySubGroupAsync(dto.StockSubCodeGroupId)
                : NormalizeGeneratedCode(dto.GeneratedCode, stockCodePrefix);

            var existingByCode = (await _repository.GetAllAsync(x => x.StockSubCodeGroupId == dto.StockSubCodeGroupId, tracking: false))
                .FirstOrDefault(x => Normalize(x.GeneratedCode) == Normalize(generatedCode));
            if (existingByCode != null)
            {
                return (await GetAllAsync(dto.StockSubCodeGroupId)).First(x => x.Id == existingByCode.Id);
            }

            var effectiveRuleName = await ComposeRuleNameAsync(dto.StockSubCodeGroupId, dto.SelectedRuleIds);
            var description = string.IsNullOrWhiteSpace(dto.Description)
                ? await ComposeDescriptionAsync(dto.StockSubCodeGroupId, dto.SelectedRuleIds, null)
                : dto.Description.Trim();

            var entity = new GeneratedStockCode
            {
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                StockSubCodeRuleId = dto.StockSubCodeRuleId,
                GeneratedCode = generatedCode,
                RuleName = effectiveRuleName,
                Description = description,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                PrimaryUnitType = dto.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = dto.KgEquivalentPerPrimaryUnit
            };

            await _repository.AddAsync(entity);
            await SaveRuleSelectionsAsync(entity.Id, dto.SelectedRuleIds);
            await _repository.SaveChangeAsync();

            return (await GetAllAsync(entity.StockSubCodeGroupId)).First(x => x.Id == entity.Id);
        }

        public async Task<GeneratedStockCodeDetailDto> UpdateAsync(GeneratedStockCodeUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception("Generated stock code not found");

            entity.StockSubCodeRuleId = dto.StockSubCodeRuleId;
            entity.RuleName = await ComposeRuleNameAsync(entity.StockSubCodeGroupId, dto.SelectedRuleIds);
            entity.Description = string.IsNullOrWhiteSpace(dto.Description)
                ? await ComposeDescriptionAsync(entity.StockSubCodeGroupId, dto.SelectedRuleIds, null)
                : dto.Description.Trim();
            entity.UnitPrice = dto.UnitPrice;
            entity.TargetPrice = dto.TargetPrice;
            entity.PrimaryUnitType = dto.PrimaryUnitType;
            entity.KgEquivalentPerPrimaryUnit = dto.KgEquivalentPerPrimaryUnit;

            await _repository.UpdateAsync(entity);
            await SaveRuleSelectionsAsync(entity.Id, dto.SelectedRuleIds);
            await _repository.SaveChangeAsync();

            return await GetByIdAsync(entity.Id) ?? throw new Exception("Generated stock code update failed");
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
                .Select(x => x.RuleName?.Trim())
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

            var stockCodePrefix = GetStockCodePrefix(subGroup.Code);
            var existingCodes = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId, tracking: false);

            var regex = new Regex($"^{Regex.Escape(stockCodePrefix)}(\\d{{{GeneratedCodeNumericLength}}})$", RegexOptions.CultureInvariant);
            var maxNumber = existingCodes
                .Select(x => regex.Match(x.GeneratedCode))
                .Where(m => m.Success)
                .Select(m => int.Parse(m.Groups[1].Value))
                .DefaultIfEmpty(-1)
                .Max();

            return $"{stockCodePrefix}{maxNumber + 1:D4}";
        }

        private async Task<string?> ComposeDescriptionAsync(Guid subGroupId, List<Guid>? selectedRuleIds, string? manualDescription)
        {
            var normalizedParts = (await GetOrderedRuleDescriptionsAsync(subGroupId, selectedRuleIds))
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

        public async Task RefreshDerivedFieldsBySubGroupAsync(Guid subGroupId)
        {
            var entities = await _repository.GetAllAsync(x => x.StockSubCodeGroupId == subGroupId);
            foreach (var entity in entities)
            {
                var selectedRuleIds = await _context.GeneratedStockCodeRuleSelections
                    .AsNoTracking()
                    .Where(x => x.GeneratedStockCodeId == entity.Id)
                    .Select(x => x.StockSubCodeRuleId)
                    .ToListAsync();

                if (!selectedRuleIds.Any() && entity.StockSubCodeRuleId.HasValue)
                {
                    selectedRuleIds.Add(entity.StockSubCodeRuleId.Value);
                }

                entity.RuleName = await ComposeRuleNameAsync(subGroupId, selectedRuleIds);
                entity.Description = await ComposeDescriptionAsync(subGroupId, selectedRuleIds, null);
                await _repository.UpdateAsync(entity);
            }

            await _repository.SaveChangeAsync();
        }

        private async Task SaveRuleSelectionsAsync(Guid generatedStockCodeId, List<Guid>? selectedRuleIds)
        {
            var normalizedIds = (selectedRuleIds ?? new List<Guid>())
                .Where(x => x != Guid.Empty)
                .Distinct()
                .ToList();

            var existing = _context.GeneratedStockCodeRuleSelections
                .Where(x => x.GeneratedStockCodeId == generatedStockCodeId)
                .ToList();

            if (existing.Any())
            {
                _context.GeneratedStockCodeRuleSelections.RemoveRange(existing);
            }

            if (normalizedIds.Any())
            {
                var rows = normalizedIds.Select(ruleId => new GeneratedStockCodeRuleSelection
                {
                    GeneratedStockCodeId = generatedStockCodeId,
                    StockSubCodeRuleId = ruleId
                });
                await _context.GeneratedStockCodeRuleSelections.AddRangeAsync(rows);
            }
        }

        private static string? Normalize(string? text)
        {
            var normalized = text?.Trim();
            return string.IsNullOrWhiteSpace(normalized) ? null : normalized.ToUpperInvariant();
        }

        private static string GetStockCodePrefix(string subGroupCode)
        {
            var normalized = subGroupCode.Trim().ToUpperInvariant();
            if (normalized.Length >= GeneratedCodePrefixLength)
            {
                return normalized[..GeneratedCodePrefixLength];
            }

            return normalized.PadRight(GeneratedCodePrefixLength, '0');
        }

        private static string NormalizeGeneratedCode(string generatedCode, string stockCodePrefix)
        {
            var normalized = generatedCode.Trim().ToUpperInvariant();
            if (normalized.Length != GeneratedCodeLength)
            {
                throw new Exception($"Generated stock code must be exactly {GeneratedCodeLength} characters.");
            }

            if (!normalized.StartsWith(stockCodePrefix, StringComparison.Ordinal))
            {
                throw new Exception($"Generated stock code must start with subgroup prefix {stockCodePrefix}.");
            }

            var numericPart = normalized[GeneratedCodePrefixLength..];
            if (numericPart.Length != GeneratedCodeNumericLength || !numericPart.All(char.IsDigit))
            {
                throw new Exception($"Generated stock code must end with {GeneratedCodeNumericLength} digits.");
            }

            return normalized;
        }
    }
}
