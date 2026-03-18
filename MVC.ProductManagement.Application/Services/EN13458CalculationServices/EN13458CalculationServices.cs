using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices
{
    public class EN13458CalculationServices : IEN13458CalculationServices
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialFormRepository _materialFormRepository;
        private readonly IEN13458CalculationManager _calculationManager;
        private readonly AppDbContext _context;

        private const string GasNitrogenStockCode = "ZA001871";
        private const string LiquidNitrogenStockCode = "ZA000216";
        private const string PerliteStockCode = "ZA000464";
        private const string ProfileWeldStockCode = "";
        private const string DefaultAnalysisName = "Maliyet Analizi";
        private const string CalculatedSourceType = "Calculated";
        private const string ManualSourceType = "Manual";
        private const string ManualGroupSourceType = "ManualGroup";
        private const string PreviewRevisionCode = "PREVIEW";
        private const string ManualStockCostGroupCode = "EK-STK";
        private const string ManualStockCostGroupName = "Ek Stok Kodları";
        private const string ManualGroupCostGroupCode = "EK-GRP";
        private const string ManualGroupCostGroupName = "Ek Stok Grupları";

        public EN13458CalculationServices(
            IMaterialRepository materialRepository,
            IMaterialFormRepository materialFormRepository,
            IEN13458CalculationManager calculationManager,
            AppDbContext context)
        {
            _materialRepository = materialRepository;
            _materialFormRepository = materialFormRepository;
            _calculationManager = calculationManager;
            _context = context;
        }

        public Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO dto)
            => _calculationManager.CalculateAsync(dto);

        public Task<EN13458ResultDTO?> GetByIdAsync(Guid id)
            => _calculationManager.GetByIdAsync(id);

        public Task<List<EN13458ResultDTO>> GetAllAsync()
            => _calculationManager.GetAllAsync();

        public Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System")
            => _calculationManager.SaveAsync(result, createdBy);

        public async Task<List<EN13458CostAnalysisSummaryDTO>> GetCostAnalysesAsync(Guid calculationId)
        {
            return await _context.EN13458CostAnalyses
                .AsNoTracking()
                .Where(x => x.EN13458CalculationId == calculationId)
                .OrderByDescending(x => x.RevisionNo)
                .Select(x => new EN13458CostAnalysisSummaryDTO
                {
                    Id = x.Id,
                    EN13458CalculationId = x.EN13458CalculationId,
                    RevisionNo = x.RevisionNo,
                    RevisionCode = x.RevisionCode,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    GrandTotalCost = x.Items.Where(i => i.Status != Status.Deleted).Sum(i => i.ItemCost)
                })
                .ToListAsync();
        }

        public async Task<EN13458MaterialCostTableDTO?> GetCostAnalysisAsync(Guid calculationId, Guid? costAnalysisId = null)
        {
            var query = _context.EN13458CostAnalyses
                .AsNoTracking()
                .Where(x => x.EN13458CalculationId == calculationId);

            EN13458CostAnalysis? analysis;
            if (costAnalysisId.HasValue && costAnalysisId.Value != Guid.Empty)
            {
                analysis = await query
                    .Include(x => x.Items)
                    .FirstOrDefaultAsync(x => x.Id == costAnalysisId.Value);
            }
            else
            {
                analysis = await query
                    .OrderByDescending(x => x.RevisionNo)
                    .Include(x => x.Items)
                    .FirstOrDefaultAsync();
            }

            return analysis == null ? null : BuildCostTableFromItems(analysis, analysis.Items.Where(x => x.Status != Status.Deleted).OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).Select(ToRowDto).ToList());
        }

        public async Task<EN13458MaterialCostTableDTO> CreateCostAnalysisAsync(Guid calculationId, string analysisName, string notes = "", string createdBy = "System")
        {
            await EnsureCalculationExistsAsync(calculationId);

            var calculation = await GetRequiredCalculationAsync(calculationId);
            var result = await GetRequiredResultAsync(calculationId);
            var latest = await GetLatestCostAnalysisAsync(calculationId);
            var revisionNo = (latest?.RevisionNo ?? -1) + 1;
            var rows = await BuildMaterialCostRowsAsync(result, latest?.Items.Where(x => x.Status != Status.Deleted).ToList());

            var analysis = new EN13458CostAnalysis
            {
                EN13458CalculationId = calculationId,
                RevisionNo = revisionNo,
                RevisionCode = FormatRevisionCode(revisionNo),
                Name = string.IsNullOrWhiteSpace(analysisName) ? DefaultAnalysisName : analysisName.Trim(),
                Notes = notes?.Trim() ?? string.Empty,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                Items = rows.Select(row => ToEntity(row, createdBy)).ToList()
            };

            _context.EN13458CostAnalyses.Add(analysis);
            await _context.SaveChangesAsync();

            return await GetCostAnalysisAsync(calculation.Id, analysis.Id) ?? BuildCostTableFromItems(analysis, rows);
        }

        public async Task<EN13458MaterialCostTableDTO> CreateCostAnalysisRevisionAsync(Guid calculationId, Guid sourceCostAnalysisId, string analysisName, string notes = "", string createdBy = "System")
        {
            await EnsureCalculationExistsAsync(calculationId);

            var source = await _context.EN13458CostAnalyses
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == sourceCostAnalysisId && x.EN13458CalculationId == calculationId);

            if (source == null)
            {
                throw new InvalidOperationException("Revizyon oluşturmak için kaynak maliyet analizi bulunamadı.");
            }

            var result = await GetRequiredResultAsync(calculationId);
            var latest = await GetLatestCostAnalysisAsync(calculationId);
            var revisionNo = (latest?.RevisionNo ?? -1) + 1;
            var rows = await BuildMaterialCostRowsAsync(result, source.Items.Where(x => x.Status != Status.Deleted).ToList());

            var analysis = new EN13458CostAnalysis
            {
                EN13458CalculationId = calculationId,
                RevisionNo = revisionNo,
                RevisionCode = FormatRevisionCode(revisionNo),
                Name = string.IsNullOrWhiteSpace(analysisName) ? source.Name : analysisName.Trim(),
                Notes = string.IsNullOrWhiteSpace(notes) ? source.Notes : notes.Trim(),
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                Items = rows.Select(row => ToEntity(row, createdBy)).ToList()
            };

            _context.EN13458CostAnalyses.Add(analysis);
            await _context.SaveChangesAsync();

            return await GetCostAnalysisAsync(calculationId, analysis.Id) ?? BuildCostTableFromItems(analysis, rows);
        }

        public async Task UpdateCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId, Guid? generatedStockCodeId, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy = "System")
        {
            var item = await _context.EN13458CostAnalysisItems
                .Include(x => x.EN13458CostAnalysis)
                .FirstOrDefaultAsync(x => x.Id == costAnalysisItemId
                    && x.EN13458CostAnalysisId == costAnalysisId
                    && x.EN13458CostAnalysis.EN13458CalculationId == calculationId);

            if (item == null)
            {
                throw new InvalidOperationException("Güncellenecek maliyet kalemi bulunamadı.");
            }

            await ApplyCostAnalysisItemUpdateAsync(item, generatedStockCodeId, useManualUnitPrice, manualUnitPrice, modifiedBy);

            await _context.SaveChangesAsync();
        }

        public async Task BulkUpdateCostAnalysisItemsAsync(Guid calculationId, Guid costAnalysisId, IReadOnlyCollection<(Guid CostAnalysisItemId, Guid? GeneratedStockCodeId, bool UseManualUnitPrice, double? ManualUnitPrice)> items, string modifiedBy = "System")
        {
            var itemIds = items
                .Where(x => x.CostAnalysisItemId != Guid.Empty)
                .Select(x => x.CostAnalysisItemId)
                .Distinct()
                .ToList();

            if (itemIds.Count == 0)
            {
                return;
            }

            var analysisItems = await _context.EN13458CostAnalysisItems
                .Include(x => x.EN13458CostAnalysis)
                .Where(x => x.EN13458CostAnalysisId == costAnalysisId
                    && x.EN13458CostAnalysis.EN13458CalculationId == calculationId
                    && itemIds.Contains(x.Id))
                .ToListAsync();
        }

            var analysisItemMap = analysisItems.ToDictionary(x => x.Id);
            foreach (var request in items.Where(x => x.CostAnalysisItemId != Guid.Empty))
            {
                if (!analysisItemMap.TryGetValue(request.CostAnalysisItemId, out var item))
                {
                    throw new InvalidOperationException("Güncellenecek maliyet kalemi bulunamadı.");
                }

                await ApplyCostAnalysisItemUpdateAsync(item, request.GeneratedStockCodeId, request.UseManualUnitPrice, request.ManualUnitPrice, modifiedBy);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddManualStockCodeCostAsync(Guid calculationId, Guid costAnalysisId, Guid generatedStockCodeId, double quantity, bool useManualUnitPrice, double? manualUnitPrice, string createdBy = "System")
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Stok kodu miktarı sıfırdan büyük olmalıdır.");
            }

            var analysis = await GetRequiredCostAnalysisAsync(calculationId, costAnalysisId);
            var generatedCode = await _context.GeneratedStockCodes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == generatedStockCodeId);

            if (generatedCode == null)
            {
                throw new InvalidOperationException("Seçilen stok kodu bulunamadı.");
            }

            var stockUnitPrice = Convert.ToDouble(generatedCode.UnitPrice ?? 0m);
            var effectiveUnitPrice = ResolveEffectiveUnitPrice(stockUnitPrice, useManualUnitPrice, manualUnitPrice);
            var itemName = string.IsNullOrWhiteSpace(generatedCode.Description)
                ? generatedCode.GeneratedCode
                : generatedCode.Description!;

            var nextSortOrder = await GetNextSortOrderAsync(costAnalysisId);
            _context.EN13458CostAnalysisItems.Add(new EN13458CostAnalysisItem
            {
                EN13458CostAnalysisId = costAnalysisId,
                SortOrder = nextSortOrder,
                ItemKey = $"MANUAL-STOCK-{Guid.NewGuid():N}",
                ItemSourceType = ManualSourceType,
                CostGroupCode = ManualStockCostGroupCode,
                CostGroupName = ManualStockCostGroupName,
                ItemName = itemName,
                GeneratedStockCodeId = generatedCode.Id,
                StockCode = generatedCode.GeneratedCode,
                StockCodeName = BuildStockDisplayName(generatedCode.GeneratedCode, generatedCode.Description, generatedCode.RuleName),
                MaterialName = string.IsNullOrWhiteSpace(generatedCode.RuleName) ? "Stok Kodu" : generatedCode.RuleName,
                FormType = "Stok Kodu",
                Quantity = quantity,
                Unit = "adet",
                StockUnitPrice = stockUnitPrice,
                UseManualUnitPrice = useManualUnitPrice,
                ManualUnitPrice = useManualUnitPrice ? NormalizeNullablePrice(manualUnitPrice) : null,
                UnitPrice = effectiveUnitPrice,
                ItemCost = quantity * effectiveUnitPrice,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddManualStockGroupCostAsync(Guid calculationId, Guid costAnalysisId, Guid stockProductGroupId, double multiplier, string createdBy = "System")
        {
            if (multiplier <= 0)
            {
                throw new InvalidOperationException("Grup çarpanı sıfırdan büyük olmalıdır.");
            }

            await GetRequiredCostAnalysisAsync(calculationId, costAnalysisId);

            var group = await _context.StockProductGroups
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == stockProductGroupId);

            if (group == null)
            {
                throw new InvalidOperationException("Seçilen stok grubu bulunamadı.");
            }

            var groupItems = await _context.StockProductGroupItems
                .AsNoTracking()
                .Where(x => x.StockProductGroupId == stockProductGroupId)
                .Join(
                    _context.GeneratedStockCodes.AsNoTracking(),
                    item => item.GeneratedStockCodeId,
                    code => code.Id,
                    (item, code) => new { Item = item, Code = code })
                .OrderBy(x => x.Code.GeneratedCode)
                .ThenBy(x => x.Code.Id)
                .ToListAsync();

            if (groupItems.Count == 0)
            {
                throw new InvalidOperationException("Seçilen stok grubunda eklenebilir kalem bulunamadı.");
            }

            var nextSortOrder = await GetNextSortOrderAsync(costAnalysisId);
            var details = groupItems.Select((x, index) =>
            {
                var quantity = x.Item.Quantity * multiplier;
                var stockUnitPrice = Convert.ToDouble(x.Item.UnitPrice > 0 ? x.Item.UnitPrice : (x.Code.UnitPrice ?? 0m));
                var itemName = string.IsNullOrWhiteSpace(x.Code.Description)
                    ? x.Code.GeneratedCode
                    : x.Code.Description!;

                return new EN13458CostAnalysisItem
                {
                    EN13458CostAnalysisId = costAnalysisId,
                    SortOrder = nextSortOrder + index,
                    ItemKey = BuildManualGroupItemKey(group.Id, x.Code.Id, index),
                    ItemSourceType = ManualGroupSourceType,
                    CostGroupCode = ManualGroupCostGroupCode,
                    CostGroupName = ManualGroupCostGroupName,
                    ItemName = $"{group.Name} / {itemName}",
                    GeneratedStockCodeId = x.Code.Id,
                    StockCode = x.Code.GeneratedCode,
                    StockCodeName = BuildStockDisplayName(x.Code.GeneratedCode, x.Code.Description, x.Code.RuleName),
                    MaterialName = string.IsNullOrWhiteSpace(x.Code.RuleName) ? group.Name : x.Code.RuleName,
                    FormType = group.Name,
                    Quantity = quantity,
                    Unit = "adet",
                    StockUnitPrice = stockUnitPrice,
                    UnitPrice = stockUnitPrice,
                    ItemCost = quantity * stockUnitPrice,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.UtcNow
                };
            }).ToList();

            _context.EN13458CostAnalysisItems.AddRange(details);
            await _context.SaveChangesAsync();
        }

        private async Task ApplyCostAnalysisItemUpdateAsync(EN13458CostAnalysisItem item, Guid? generatedStockCodeId, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy)
        {
            var stockInfo = await ResolveGeneratedStockCodeAsync(generatedStockCodeId, item.StockCode);
            item.GeneratedStockCodeId = stockInfo?.Id;
            item.StockCode = stockInfo?.GeneratedCode ?? string.Empty;
            item.StockCodeName = stockInfo == null
                ? string.Empty
                : BuildStockDisplayName(stockInfo.GeneratedCode, stockInfo.Description, stockInfo.RuleName);
            item.StockUnitPrice = stockInfo == null ? 0 : Convert.ToDouble(stockInfo.UnitPrice ?? 0m);
            item.UseManualUnitPrice = useManualUnitPrice;
            item.ManualUnitPrice = useManualUnitPrice ? NormalizeNullablePrice(manualUnitPrice) : null;
            item.UnitPrice = ResolveEffectiveUnitPrice(item.StockUnitPrice, item.UseManualUnitPrice, item.ManualUnitPrice);
            item.ItemCost = item.Quantity * item.UnitPrice;
            item.ModifiedBy = modifiedBy;
            item.ModifiedDate = DateTime.UtcNow;
        }

        public async Task RemoveCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId)
        {
            var item = await _context.EN13458CostAnalysisItems
                .Include(x => x.EN13458CostAnalysis)
                .FirstOrDefaultAsync(x => x.Id == costAnalysisItemId
                    && x.EN13458CostAnalysisId == costAnalysisId
                    && x.EN13458CostAnalysis.EN13458CalculationId == calculationId);

            if (item == null)
            {
                throw new InvalidOperationException("Silinecek maliyet kalemi bulunamadı.");
            }

            _context.EN13458CostAnalysisItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<EN13458MaterialCostTableDTO> BuildMaterialCostTableAsync(EN13458ResultDTO result)
        {
            var rows = await BuildMaterialCostRowsAsync(result, previousItems: null);
            return new EN13458MaterialCostTableDTO
            {
                EN13458CalculationId = result.Id == Guid.Empty ? null : result.Id,
                RevisionCode = PreviewRevisionCode,
                AnalysisName = DefaultAnalysisName,
                IsPreview = true,
                CreatedDate = DateTime.UtcNow,
                Items = rows.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList(),
                GroupTotals = rows.GroupBy(x => new { x.CostGroupCode, x.CostGroupName })
                    .Select(g => new EN13458CostGroupSummaryDTO
                    {
                        CostGroupCode = g.Key.CostGroupCode,
                        CostGroupName = g.Key.CostGroupName,
                        TotalCost = g.Sum(i => i.ItemCost)
                    })
                    .OrderBy(x => x.CostGroupCode)
                    .ToList(),
                TotalMaterialCost = rows.Sum(x => x.ItemCost),
                TotalFilmCost = rows.Where(x => x.CostGroupCode == "FILM").Sum(x => x.ItemCost),
                GrandTotalCost = rows.Sum(x => x.ItemCost)
            };
        }

        private async Task<EN13458Calculation> GetRequiredCalculationAsync(Guid calculationId)
        {
            return await _context.EN13458Calculations
                .AsNoTracking()
                .FirstAsync(x => x.Id == calculationId);
        }

        private async Task<EN13458ResultDTO> GetRequiredResultAsync(Guid calculationId)
        {
            return await _calculationManager.GetByIdAsync(calculationId)
                ?? throw new InvalidOperationException("EN13458 kaydı bulunamadı.");
        }

        private async Task<EN13458CostAnalysis?> GetLatestCostAnalysisAsync(Guid calculationId)
        {
            return await _context.EN13458CostAnalyses
                .Include(x => x.Items)
                .Where(x => x.EN13458CalculationId == calculationId)
                .OrderByDescending(x => x.RevisionNo)
                .FirstOrDefaultAsync();
        }

        private async Task<EN13458CostAnalysis> GetRequiredCostAnalysisAsync(Guid calculationId, Guid costAnalysisId)
        {
            var analysis = await _context.EN13458CostAnalyses
                .FirstOrDefaultAsync(x => x.Id == costAnalysisId && x.EN13458CalculationId == calculationId);

            if (analysis == null)
            {
                throw new InvalidOperationException("Seçilen maliyet analizi bulunamadı.");
            }

            return analysis;
        }

        private async Task<List<EN13458MaterialCostRowDTO>> BuildMaterialCostRowsAsync(EN13458ResultDTO result, List<EN13458CostAnalysisItem>? previousItems)
        {
            var rows = new List<EN13458MaterialCostRowDTO>();
            var previousCalculatedItems = previousItems?
                .Where(x => x.Status != Status.Deleted)
                .Where(x => string.Equals(x.ItemSourceType, CalculatedSourceType, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.ItemKey, StringComparer.OrdinalIgnoreCase)
                ?? new Dictionary<string, EN13458CostAnalysisItem>(StringComparer.OrdinalIgnoreCase);

            rows.Add(await BuildMaterialRowAsync("INNER-SHELL", 10, "SAC", "Sac Maliyeti", "İç Gövde", result.InnerShellMaterialId, result.InnerShellMaterialFormId, result.InnerShellThickness, result.RoundedInnerShellThickness, result.OuterDiameter, result.ShellLength, isHead: false, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("INNER-HEAD", 20, "SAC", "Sac Maliyeti", "İç Bombe", result.InnerHeadMaterialId, result.InnerHeadMaterialFormId, result.InnerHeadThickness, result.RoundedInnerHeadThickness, result.OuterDiameter, result.ShellLength, isHead: true, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("OUTER-SHELL", 30, "SAC", "Sac Maliyeti", "Dış Gövde", result.OuterShellMaterialId, result.OuterShellMaterialFormId, result.OuterShellThickness, result.RoundedOuterShellThickness, result.OuterTankDiameter, result.OuterTankTotalLength, isHead: false, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("OUTER-HEAD", 40, "SAC", "Sac Maliyeti", "Dış Bombe", result.OuterHeadMaterialId, result.OuterHeadMaterialFormId, result.OuterHeadThickness, result.RoundedOuterHeadThickness, result.OuterTankDiameter, result.OuterTankTotalLength, isHead: true, previousCalculatedItems));

            if (result.GasNitrogenVolume > 0)
            {
                rows.Add(await BuildServiceRowAsync("GAS-NITROGEN", 50, "SARF", "Sarf Malzemeleri", "Gaz Azot", GasNitrogenStockCode, result.GasNitrogenVolume, "Nm³", previousCalculatedItems));
            }

            if (result.LiquidNitrogenVolume > 0)
            {
                rows.Add(await BuildServiceRowAsync("LIQUID-NITROGEN", 60, "SARF", "Sarf Malzemeleri", "Sıvı Azot", LiquidNitrogenStockCode, result.LiquidNitrogenVolume, "kg", previousCalculatedItems));
            }

            if (result.PerliteWeight > 0)
            {
                rows.Add(await BuildServiceRowAsync("PERLITE", 70, "SARF", "Sarf Malzemeleri", "Perlit", PerliteStockCode, result.PerliteWeight, "kg", previousCalculatedItems));
            }

            if (result.TotalFilmCost > 0)
            {
                rows.Add(ApplyPreviousSelection(new EN13458MaterialCostRowDTO
                {
                    SortOrder = 80,
                    ItemKey = "FILM",
                    ItemSourceType = CalculatedSourceType,
                    CostGroupCode = "FILM",
                    CostGroupName = "Film ve İzolasyon",
                    ItemName = "Film Maliyeti",
                    MaterialName = "Film/İzolasyon",
                    FormType = "Hizmet",
                    Quantity = 1,
                    Unit = "lot",
                    StockUnitPrice = result.TotalFilmCost,
                    UnitPrice = result.TotalFilmCost,
                    ItemCost = result.TotalFilmCost
                }, previousCalculatedItems.GetValueOrDefault("FILM")));
            }

            var profileRow = await BuildProfileCostRowAsync(result, previousCalculatedItems.GetValueOrDefault("PROFILE"));
            if (profileRow is not null)
            {
                rows.Add(profileRow);
            }

            var profileWeldRow = await BuildProfileWeldCostRowAsync(result, previousCalculatedItems.GetValueOrDefault("PROFILE-WELD"));
            if (profileWeldRow is not null)
            {
                rows.Add(profileWeldRow);
            }

            if (previousItems != null)
            {
                rows.AddRange(previousItems
                    .Where(x => x.Status != Status.Deleted)
                    .Where(x => !string.Equals(x.ItemSourceType, CalculatedSourceType, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.SortOrder)
                    .ThenBy(x => x.ItemName)
                    .Select(ToRowDto));
            }

            return rows.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList();
        }

        private async Task<EN13458MaterialCostRowDTO> BuildMaterialRowAsync(
            string itemKey,
            int sortOrder,
            string costGroupCode,
            string costGroupName,
            string itemName,
            Guid materialId,
            Guid materialFormId,
            double calculatedThickness,
            double usedThickness,
            double diameter,
            double shellLength,
            bool isHead,
            IReadOnlyDictionary<string, EN13458CostAnalysisItem> previousItems)
        {
            var material = await _materialRepository.GetByIdAsync(materialId)
                ?? throw new InvalidOperationException($"Material not found: {materialId}");

            var form = await _materialFormRepository.GetByIdAsync(materialFormId)
                ?? throw new InvalidOperationException($"MaterialForm not found: {materialFormId}");

            var area = isHead
                ? GetSingleHeadAreaApproximation(diameter)
                : Math.PI * diameter * shellLength;

            var volumeMm3 = area * usedThickness;
            var weightKg = volumeMm3 * 1e-9 * material.Density;
            previousItems.TryGetValue(itemKey, out var previous);

            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = sortOrder,
                ItemKey = itemKey,
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = costGroupCode,
                CostGroupName = costGroupName,
                ItemName = itemName,
                MaterialId = material.Id,
                MaterialName = material.Name,
                MaterialFormId = form.Id,
                FormType = form.FormType.ToString(),
                Quantity = weightKg,
                Unit = "kg",
                CalculatedThickness = calculatedThickness,
                UsedThickness = usedThickness,
                Density = material.Density,
                TheoreticalWeight = weightKg,
                StockUnitPrice = 0,
                UnitPrice = 0,
                ItemCost = 0
            };

            return await ApplyPreviousPricingAsync(row, previous, fallbackUnitPrice: 0);
        }

        private async Task<EN13458MaterialCostRowDTO> BuildServiceRowAsync(string itemKey, int sortOrder, string costGroupCode, string costGroupName, string itemName, string defaultStockCode, double quantity, string unit, IReadOnlyDictionary<string, EN13458CostAnalysisItem> previousItems)
        {
            previousItems.TryGetValue(itemKey, out var previous);
            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = sortOrder,
                ItemKey = itemKey,
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = costGroupCode,
                CostGroupName = costGroupName,
                ItemName = itemName,
                MaterialName = itemName,
                FormType = "Sarf",
                Quantity = quantity,
                Unit = unit,
                StockCode = defaultStockCode,
                StockCodeName = string.IsNullOrWhiteSpace(defaultStockCode) ? string.Empty : defaultStockCode
            };

            return await ApplyPreviousPricingAsync(row, previous, fallbackUnitPrice: await ResolveUnitPriceAsync(defaultStockCode, null));
        }

        private async Task<EN13458MaterialCostRowDTO?> BuildProfileCostRowAsync(EN13458ResultDTO result, EN13458CostAnalysisItem? previous)
        {
            if (result.RequiredProfileCount <= 0 || result.ProfileDevelopedLength <= 0)
            {
                return null;
            }

            var material = await _materialRepository.GetByIdAsync(result.OuterShellMaterialId);
            var form = await _materialFormRepository.GetByIdAsync(result.OuterShellMaterialFormId);

            if (material == null || form == null)
            {
                return null;
            }

            const double defaultProfileAreaMm2 = 444d;
            var totalLengthMm = result.TotalProfileLength > 0 ? result.TotalProfileLength : (result.RequiredProfileCount * result.ProfileDevelopedLength);
            var totalLengthM = totalLengthMm / 1000d;
            var volumeMm3 = defaultProfileAreaMm2 * totalLengthMm;
            var weightKg = volumeMm3 * 1e-9 * material.Density;

            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = 90,
                ItemKey = "PROFILE",
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = "PROF",
                CostGroupName = "Profil Maliyeti",
                ItemName = "Dış Tank Stifner Profili (40x40x3)",
                MaterialId = material.Id,
                MaterialName = material.Name,
                MaterialFormId = form.Id,
                FormType = form.FormType.ToString(),
                Quantity = Math.Round(totalLengthM, 2),
                Unit = "m",
                Density = material.Density,
                TheoreticalWeight = Math.Round(weightKg, 2)
            };

            return await ApplyPreviousPricingAsync(row, previous, fallbackUnitPrice: 0);
        }

        private async Task<EN13458MaterialCostRowDTO?> BuildProfileWeldCostRowAsync(EN13458ResultDTO result, EN13458CostAnalysisItem? previous)
        {
            if (result.ProfileWeldLength <= 0)
            {
                return null;
            }

            var quantityMeters = result.ProfileWeldLength / 1000d;
            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = 100,
                ItemKey = "PROFILE-WELD",
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = "WELD",
                CostGroupName = "Kaynak Maliyeti",
                ItemName = "Profil Kaynak Metrajı",
                StockCode = ProfileWeldStockCode,
                MaterialName = "Profil Kaynağı",
                FormType = "Hizmet",
                Quantity = Math.Round(quantityMeters, 2),
                Unit = "m"
            };

            return await ApplyPreviousPricingAsync(row, previous, fallbackUnitPrice: await ResolveUnitPriceAsync(ProfileWeldStockCode, null));
        }

        private async Task<EN13458MaterialCostRowDTO> ApplyPreviousPricingAsync(EN13458MaterialCostRowDTO row, EN13458CostAnalysisItem? previous, double fallbackUnitPrice)
        {
            row.GeneratedStockCodeId = previous?.GeneratedStockCodeId;
            row.StockCode = previous?.StockCode ?? row.StockCode;
            row.StockCodeName = previous?.StockCodeName ?? row.StockCodeName;
            row.UseManualUnitPrice = previous?.UseManualUnitPrice ?? false;
            row.ManualUnitPrice = previous?.UseManualUnitPrice == true ? NormalizeNullablePrice(previous.ManualUnitPrice) : null;

            GeneratedStockCode? selectedCode = null;
            if (row.GeneratedStockCodeId.HasValue)
            {
                selectedCode = await ResolveGeneratedStockCodeAsync(row.GeneratedStockCodeId, row.StockCode);
            }
            else if (!string.IsNullOrWhiteSpace(row.StockCode))
            {
                selectedCode = await ResolveGeneratedStockCodeAsync(null, row.StockCode);
            }

            if (selectedCode != null)
            {
                row.GeneratedStockCodeId = selectedCode.Id;
                row.StockCode = selectedCode.GeneratedCode;
                row.StockCodeName = BuildStockDisplayName(selectedCode.GeneratedCode, selectedCode.Description, selectedCode.RuleName);
                row.StockUnitPrice = Convert.ToDouble(selectedCode.UnitPrice ?? 0m);
            }
            else
            {
                row.StockUnitPrice = fallbackUnitPrice;
            }

            row.UnitPrice = ResolveEffectiveUnitPrice(row.StockUnitPrice, row.UseManualUnitPrice, row.ManualUnitPrice);
            row.ItemCost = row.Quantity * row.UnitPrice;
            return row;
        }

        private static EN13458MaterialCostRowDTO ApplyPreviousSelection(EN13458MaterialCostRowDTO row, EN13458CostAnalysisItem? previous)
        {
            if (previous == null)
            {
                return row;
            }

            row.GeneratedStockCodeId = previous.GeneratedStockCodeId;
            row.StockCode = previous.StockCode;
            row.StockCodeName = previous.StockCodeName;
            row.StockUnitPrice = previous.StockUnitPrice;
            row.UseManualUnitPrice = previous.UseManualUnitPrice;
            row.ManualUnitPrice = previous.UseManualUnitPrice ? NormalizeNullablePrice(previous.ManualUnitPrice) : null;
            row.UnitPrice = ResolveEffectiveUnitPrice(row.StockUnitPrice, row.UseManualUnitPrice, row.ManualUnitPrice);
            row.ItemCost = row.Quantity * row.UnitPrice;
            return row;
        }

        private async Task<GeneratedStockCode?> ResolveGeneratedStockCodeAsync(Guid? generatedStockCodeId, string? stockCode)
        {
            if (generatedStockCodeId.HasValue && generatedStockCodeId.Value != Guid.Empty)
            {
                return await _context.GeneratedStockCodes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == generatedStockCodeId.Value);
            }

            if (string.IsNullOrWhiteSpace(stockCode))
            {
                return null;
            }

            return await _context.GeneratedStockCodes.AsNoTracking().FirstOrDefaultAsync(x => x.GeneratedCode == stockCode);
        }

        private async Task<double> ResolveUnitPriceAsync(string stockCode, Guid? generatedStockCodeId)
        {
            var generatedCode = await ResolveGeneratedStockCodeAsync(generatedStockCodeId, stockCode);
            if (generatedCode?.UnitPrice != null)
            {
                return Convert.ToDouble(generatedCode.UnitPrice.Value);
            }

            if (string.IsNullOrWhiteSpace(stockCode))
            {
                return 0;
            }

            var today = DateTime.UtcNow.Date;
            var unitPrice = await _context.StockCardPrices
                .AsNoTracking()
                .Where(p => p.StockCard.StockCode8 == stockCode
                    && p.IsActive
                    && p.Status != Status.Deleted
                    && p.ValidFrom.Date <= today
                    && (p.ValidTo == null || p.ValidTo.Value.Date >= today))
                .OrderByDescending(p => p.ValidFrom)
                .Select(p => (double?)p.UnitPrice)
                .FirstOrDefaultAsync();

            return unitPrice ?? 0;
        }

        private async Task<int> GetNextSortOrderAsync(Guid costAnalysisId)
        {
            var maxSortOrder = await _context.EN13458CostAnalysisItems
                .AsNoTracking()
                .Where(x => x.EN13458CostAnalysisId == costAnalysisId)
                .Select(x => (int?)x.SortOrder)
                .MaxAsync();

            return (maxSortOrder ?? 0) + 10;
        }

        private async Task EnsureCalculationExistsAsync(Guid calculationId)
        {
            var exists = await _context.EN13458Calculations
                .AsNoTracking()
                .AnyAsync(x => x.Id == calculationId);

            if (!exists)
            {
                throw new InvalidOperationException("EN13458 kaydı bulunamadı.");
            }
        }

        private EN13458CostAnalysisItem ToEntity(EN13458MaterialCostRowDTO item, string createdBy)
        {
            return new EN13458CostAnalysisItem
            {
                SortOrder = item.SortOrder,
                ItemKey = item.ItemKey,
                ItemSourceType = item.ItemSourceType,
                CostGroupCode = item.CostGroupCode,
                CostGroupName = item.CostGroupName,
                ItemName = item.ItemName,
                MaterialId = item.MaterialId,
                MaterialName = item.MaterialName,
                MaterialFormId = item.MaterialFormId,
                FormType = item.FormType,
                GeneratedStockCodeId = item.GeneratedStockCodeId,
                StockCode = item.StockCode,
                StockCodeName = item.StockCodeName,
                Quantity = item.Quantity,
                Unit = item.Unit,
                CalculatedThickness = item.CalculatedThickness,
                UsedThickness = item.UsedThickness,
                Density = item.Density,
                TheoreticalWeight = item.TheoreticalWeight,
                UseManualUnitPrice = item.UseManualUnitPrice,
                ManualUnitPrice = item.UseManualUnitPrice ? NormalizeNullablePrice(item.ManualUnitPrice) : null,
                StockUnitPrice = item.StockUnitPrice,
                UnitPrice = item.UnitPrice,
                ItemCost = item.ItemCost,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow
            };
        }

        private static EN13458MaterialCostRowDTO ToRowDto(EN13458CostAnalysisItem item)
        {
            return new EN13458MaterialCostRowDTO
            {
                CostAnalysisItemId = item.Id,
                CostAnalysisId = item.EN13458CostAnalysisId,
                SortOrder = item.SortOrder,
                ItemKey = item.ItemKey,
                ItemSourceType = item.ItemSourceType,
                CostGroupCode = item.CostGroupCode,
                CostGroupName = item.CostGroupName,
                ItemName = item.ItemName,
                StockCode = item.StockCode,
                StockCodeName = item.StockCodeName,
                GeneratedStockCodeId = item.GeneratedStockCodeId,
                MaterialId = item.MaterialId,
                MaterialName = item.MaterialName,
                MaterialFormId = item.MaterialFormId,
                FormType = item.FormType,
                Quantity = item.Quantity,
                Unit = item.Unit,
                CalculatedThickness = item.CalculatedThickness,
                UsedThickness = item.UsedThickness,
                Density = item.Density,
                StockUnitPrice = item.StockUnitPrice,
                UseManualUnitPrice = item.UseManualUnitPrice,
                ManualUnitPrice = item.UseManualUnitPrice ? NormalizeNullablePrice(item.ManualUnitPrice) : null,
                UnitPrice = item.UnitPrice,
                TheoreticalWeight = item.TheoreticalWeight,
                ItemCost = item.ItemCost
            };
        }

        private static EN13458MaterialCostTableDTO BuildCostTableFromItems(EN13458CostAnalysis analysis, List<EN13458MaterialCostRowDTO> items)
        {
            return new EN13458MaterialCostTableDTO
            {
                CostAnalysisId = analysis.Id,
                EN13458CalculationId = analysis.EN13458CalculationId,
                RevisionNo = analysis.RevisionNo,
                RevisionCode = analysis.RevisionCode,
                AnalysisName = analysis.Name,
                CreatedDate = analysis.CreatedDate,
                Items = items.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList(),
                TotalMaterialCost = items.Sum(x => x.ItemCost),
                TotalFilmCost = items.Where(x => x.CostGroupCode == "FILM").Sum(x => x.ItemCost),
                GrandTotalCost = items.Sum(x => x.ItemCost),
                GroupTotals = items
                    .GroupBy(x => new { x.CostGroupCode, x.CostGroupName })
                    .Select(g => new EN13458CostGroupSummaryDTO
                    {
                        CostGroupCode = g.Key.CostGroupCode,
                        CostGroupName = g.Key.CostGroupName,
                        TotalCost = g.Sum(i => i.ItemCost)
                    })
                    .OrderBy(x => x.CostGroupCode)
                    .ToList()
            };
        }


        private static string BuildManualGroupItemKey(Guid groupId, Guid codeId, int index)
        {
            var groupToken = groupId.ToString("N")[..8];
            var codeToken = codeId.ToString("N")[..8];
            return $"MG-{groupToken}-{codeToken}-{index:000}";
        }

        private static string FormatRevisionCode(int revisionNo) => $"REV{revisionNo:00}";

        private static string BuildStockDisplayName(string stockCode, string? description, string ruleName)
        {
            var tail = !string.IsNullOrWhiteSpace(description) ? description : ruleName;
            return string.IsNullOrWhiteSpace(tail) ? stockCode : $"{stockCode} - {tail}";
        }

        private static double ResolveEffectiveUnitPrice(double stockUnitPrice, bool useManualUnitPrice, double? manualUnitPrice)
        {
            if (useManualUnitPrice)
            {
                return NormalizeNullablePrice(manualUnitPrice) ?? 0;
            }

            return stockUnitPrice;
        }

        private static double? NormalizeNullablePrice(double? value)
        {
            if (!value.HasValue)
            {
                return null;
            }

            return value.Value < 0 ? 0 : value.Value;
        }

        private static double GetSingleHeadAreaApproximation(double diameter)
        {
            var circleArea = Math.PI * Math.Pow(diameter, 2) / 4d;
            return circleArea * 1.1d;
        }
    }
}
