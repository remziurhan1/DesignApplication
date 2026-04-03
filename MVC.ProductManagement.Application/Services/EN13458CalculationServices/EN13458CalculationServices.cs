using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.CostingDTOs;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.Costing;
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
        private readonly IEN13458FilmQuantityService _filmQuantityService;
        private readonly AppDbContext _context;

        private const string GasNitrogenStockCode = "ZA001871";
        private const string LiquidNitrogenStockCode = "ZA000216";
        private const string PerliteStockCode = "ZA000464";
        private const string ProfileWeldStockCode = "";
        private const double DefaultWeldConsumableUnitPriceEuro = 30d;
        private const double FilmSourceLength = 1500d;
        private const double HeadPulDiameterCoefficient = 1.17d;
        private const double HeadWeldDivisor = 1.15d;
        private const string DefaultAnalysisName = "Maliyet Analizi";
        private const string CalculatedSourceType = "Calculated";
        private const string ManualSourceType = "Manual";
        private const string ManualGroupSourceType = "ManualGroup";
        private const string PreviewRevisionCode = "PREVIEW";
        private const string ManualStockCostGroupCode = "EK-STK";
        private const string ManualStockCostGroupName = "Ek Stok Kodları";
        private const string ManualGroupCostGroupCode = "EK-GRP";
        private const string ManualGroupCostGroupName = "Ek Stok Grupları";
        private const string BombeLaborCostGroupCode = "BOMBE";
        private const string BombeLaborCostGroupName = "Bombe İşçilik";
        private const string FinanceOverheadType = "Finance";
        private const string GeneralManagementOverheadType = "GeneralManagement";

        public EN13458CalculationServices(
            IMaterialRepository materialRepository,
            IMaterialFormRepository materialFormRepository,
            IEN13458CalculationManager calculationManager,
            IEN13458FilmQuantityService filmQuantityService,
            AppDbContext context)
        {
            _materialRepository = materialRepository;
            _materialFormRepository = materialFormRepository;
            _calculationManager = calculationManager;
            _filmQuantityService = filmQuantityService;
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
                .Where(x => x.EN13458CalculationId == calculationId);

            EN13458CostAnalysis? analysis;
            if (costAnalysisId.HasValue && costAnalysisId.Value != Guid.Empty)
            {
                analysis = await query
                    .Include(x => x.Items)
                    .Include(x => x.SalesPrices)
                    .FirstOrDefaultAsync(x => x.Id == costAnalysisId.Value);
            }
            else
            {
                analysis = await query
                    .OrderByDescending(x => x.RevisionNo)
                    .Include(x => x.Items)
                    .Include(x => x.SalesPrices)
                    .FirstOrDefaultAsync();
            }

            if (analysis == null)
            {
                return null;
            }

            var result = await GetRequiredResultAsync(calculationId);
            await EnsureWeldAndFilmRowsAsync(analysis, result);

            var rows = analysis.Items
                .Where(x => x.Status != Status.Deleted)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.ItemName)
                .Select(ToRowDto)
                .ToList();

            return BuildCostTableFromItems(analysis, rows, analysis.SalesPrices.FirstOrDefault(x => x.Status != Status.Deleted));
        }

        public async Task<EN13458MaterialCostTableDTO> CreateCostAnalysisAsync(Guid calculationId, string analysisName, string notes = "", string createdBy = "System")
        {
            await EnsureCalculationExistsAsync(calculationId);

            var calculation = await GetRequiredCalculationAsync(calculationId);
            var result = await GetRequiredResultAsync(calculationId);
            var latest = await GetLatestCostAnalysisAsync(calculationId);
            var revisionNo = (latest?.RevisionNo ?? -1) + 1;
            var rows = await BuildMaterialCostRowsAsync(result, latest);

            var analysis = new EN13458CostAnalysis
            {
                EN13458CalculationId = calculationId,
                RevisionNo = revisionNo,
                RevisionCode = FormatRevisionCode(revisionNo),
                Name = string.IsNullOrWhiteSpace(analysisName) ? DefaultAnalysisName : analysisName.Trim(),
                Notes = notes?.Trim() ?? string.Empty,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                InnerHeadBombeLaborRateId = latest?.InnerHeadBombeLaborRateId,
                OuterHeadBombeLaborRateId = latest?.OuterHeadBombeLaborRateId,
                Items = rows.Select(row => ToEntity(row, createdBy)).ToList()
            };

            _context.EN13458CostAnalyses.Add(analysis);
            await _context.SaveChangesAsync();

            if (latest != null)
            {
                var latestSalesPrice = await _context.EN13458SalesPrices
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EN13458CalculationId == calculationId && x.EN13458CostAnalysisId == latest.Id && x.Status != Status.Deleted);

                await CloneSalesPriceAsync(calculationId, analysis.Id, latestSalesPrice, rows.Sum(x => x.ItemCost), createdBy);
            }

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
            var rows = await BuildMaterialCostRowsAsync(result, source);

            var analysis = new EN13458CostAnalysis
            {
                EN13458CalculationId = calculationId,
                RevisionNo = revisionNo,
                RevisionCode = FormatRevisionCode(revisionNo),
                Name = string.IsNullOrWhiteSpace(analysisName) ? source.Name : analysisName.Trim(),
                Notes = string.IsNullOrWhiteSpace(notes) ? source.Notes : notes.Trim(),
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                InnerHeadBombeLaborRateId = source.InnerHeadBombeLaborRateId,
                OuterHeadBombeLaborRateId = source.OuterHeadBombeLaborRateId,
                Items = rows.Select(row => ToEntity(row, createdBy)).ToList()
            };

            _context.EN13458CostAnalyses.Add(analysis);
            await _context.SaveChangesAsync();

            var sourceSalesPrice = await _context.EN13458SalesPrices
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EN13458CalculationId == calculationId && x.EN13458CostAnalysisId == source.Id && x.Status != Status.Deleted);

            await CloneSalesPriceAsync(calculationId, analysis.Id, sourceSalesPrice, rows.Sum(x => x.ItemCost), createdBy);

            return await GetCostAnalysisAsync(calculationId, analysis.Id) ?? BuildCostTableFromItems(analysis, rows);
        }

        public async Task UpdateCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId, Guid? generatedStockCodeId, double? quantity, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy = "System")
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

            await ApplyCostAnalysisItemUpdateAsync(item, generatedStockCodeId, quantity, useManualUnitPrice, manualUnitPrice, modifiedBy);
            await RefreshSalesPriceFromLatestCostAsync(calculationId, costAnalysisId, modifiedBy);
            await _context.SaveChangesAsync();
        }

        public async Task BulkUpdateCostAnalysisItemsAsync(Guid calculationId, Guid costAnalysisId, IReadOnlyCollection<(Guid CostAnalysisItemId, Guid? GeneratedStockCodeId, double? Quantity, bool UseManualUnitPrice, double? ManualUnitPrice)> items, string modifiedBy = "System")
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
        

            var analysisItemMap = analysisItems.ToDictionary(x => x.Id);
            foreach (var request in items.Where(x => x.CostAnalysisItemId != Guid.Empty))
            {
                if (!analysisItemMap.TryGetValue(request.CostAnalysisItemId, out var item))
                {
                    throw new InvalidOperationException("Güncellenecek maliyet kalemi bulunamadı.");
                }

                await ApplyCostAnalysisItemUpdateAsync(item, request.GeneratedStockCodeId, request.Quantity, request.UseManualUnitPrice, request.ManualUnitPrice, modifiedBy);
            }

            await RefreshSalesPriceFromLatestCostAsync(calculationId, costAnalysisId, modifiedBy);
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

            await RefreshSalesPriceFromLatestCostAsync(calculationId, costAnalysisId, createdBy);
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
            await RefreshSalesPriceFromLatestCostAsync(calculationId, costAnalysisId, createdBy);
            await _context.SaveChangesAsync();
        }

        private async Task ApplyCostAnalysisItemUpdateAsync(EN13458CostAnalysisItem item, Guid? generatedStockCodeId, double? quantity, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy)
        {
            if (quantity.HasValue && IsManualSource(item))
            {
                item.Quantity = NormalizeManualQuantity(quantity.Value);
            }

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
            await RefreshSalesPriceFromLatestCostAsync(calculationId, costAnalysisId, "System");
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBombeLaborAsync(Guid calculationId, Guid costAnalysisId, Guid? innerHeadBombeLaborRateId, Guid? outerHeadBombeLaborRateId, string modifiedBy = "System")
        {
            var analysis = await _context.EN13458CostAnalyses
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == costAnalysisId && x.EN13458CalculationId == calculationId);

            if (analysis == null)
            {
                throw new InvalidOperationException("Seçilen maliyet analizi bulunamadı.");
            }

            analysis.InnerHeadBombeLaborRateId = innerHeadBombeLaborRateId;
            analysis.OuterHeadBombeLaborRateId = outerHeadBombeLaborRateId;
            analysis.ModifiedBy = modifiedBy;
            analysis.ModifiedDate = DateTime.UtcNow;

            var result = await GetRequiredResultAsync(calculationId);
            var rebuiltRows = await BuildMaterialCostRowsAsync(result, analysis);
            var rebuiltMap = rebuiltRows.ToDictionary(x => x.ItemKey, StringComparer.OrdinalIgnoreCase);

            foreach (var item in analysis.Items.Where(x => x.Status != Status.Deleted && rebuiltMap.ContainsKey(x.ItemKey)))
            {
                var row = rebuiltMap[item.ItemKey];
                item.MaterialName = row.MaterialName;
                item.FormType = row.FormType;
                item.Quantity = row.Quantity;
                item.Unit = row.Unit;
                item.StockCode = row.StockCode;
                item.StockCodeName = row.StockCodeName;
                item.StockUnitPrice = row.StockUnitPrice;
                item.UnitPrice = row.UnitPrice;
                item.ItemCost = row.ItemCost;
                item.ModifiedBy = modifiedBy;
                item.ModifiedDate = DateTime.UtcNow;
            }

            await RefreshSalesPriceFromLatestCostAsync(calculationId, costAnalysisId, modifiedBy);
            await _context.SaveChangesAsync();
        }

        public async Task<EN13458SalesPriceDTO?> GetSalesPriceAsync(Guid calculationId, Guid costAnalysisId)
        {
            var salesPrice = await _context.EN13458SalesPrices
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EN13458CalculationId == calculationId && x.EN13458CostAnalysisId == costAnalysisId && x.Status != Status.Deleted);

            return salesPrice == null ? null : MapSalesPrice(salesPrice);
        }

        public async Task<EN13458SalesPriceDTO> UpsertSalesPriceAsync(Guid calculationId, Guid costAnalysisId, Guid laborRateId, double laborHours, Guid gugHourlyRateId, Guid financeOverheadRateId, Guid generalManagementOverheadRateId, double profitPercentage, string modifiedBy = "System")
        {
            if (laborHours < 0)
            {
                throw new InvalidOperationException("İşçilik saati negatif olamaz.");
            }

            var costTable = await GetCostAnalysisAsync(calculationId, costAnalysisId)
                ?? throw new InvalidOperationException("Satış fiyatı için maliyet analizi bulunamadı.");

            var laborRate = await _context.LaborRates.FirstOrDefaultAsync(x => x.Id == laborRateId && x.Status != Status.Deleted)
                ?? throw new InvalidOperationException("İşçilik tarifesi bulunamadı.");
            var gugRate = await _context.GugHourlyRates.FirstOrDefaultAsync(x => x.Id == gugHourlyRateId && x.Status != Status.Deleted)
                ?? throw new InvalidOperationException("GÜG saatlik değeri bulunamadı.");
            var financeRate = await _context.OverheadRates.FirstOrDefaultAsync(x => x.Id == financeOverheadRateId && x.Status != Status.Deleted)
                ?? throw new InvalidOperationException("Finans gideri bulunamadı.");
            var generalManagementRate = await _context.OverheadRates.FirstOrDefaultAsync(x => x.Id == generalManagementOverheadRateId && x.Status != Status.Deleted)
                ?? throw new InvalidOperationException("Genel yönetim gideri bulunamadı.");

            var calculation = CalculateSalesPrice(costTable.GrandTotalCost, laborHours, laborRate.HourlyRate, gugRate.HourlyRate, financeRate.Percentage, generalManagementRate.Percentage, profitPercentage);

            var entity = await _context.EN13458SalesPrices
                .FirstOrDefaultAsync(x => x.EN13458CalculationId == calculationId && x.EN13458CostAnalysisId == costAnalysisId && x.Status != Status.Deleted);

            if (entity == null)
            {
                entity = new EN13458SalesPrice
                {
                    EN13458CalculationId = calculationId,
                    EN13458CostAnalysisId = costAnalysisId,
                    CreatedBy = modifiedBy,
                    CreatedDate = DateTime.UtcNow
                };
                _context.EN13458SalesPrices.Add(entity);
            }
            else
            {
                entity.ModifiedBy = modifiedBy;
                entity.ModifiedDate = DateTime.UtcNow;
            }

            entity.LaborRateId = laborRateId;
            entity.GugHourlyRateId = gugHourlyRateId;
            entity.FinanceOverheadRateId = financeOverheadRateId;
            entity.GeneralManagementOverheadRateId = generalManagementOverheadRateId;
            entity.LaborHours = laborHours;
            entity.ProfitPercentage = profitPercentage;
            entity.LaborCost = calculation.LaborCost;
            entity.GugCost = calculation.GugCost;
            entity.ImmCost = calculation.ImmCost;
            entity.AraToplam1 = calculation.AraToplam1;
            entity.FinanceCost = calculation.FinanceCost;
            entity.GeneralManagementCost = calculation.GeneralManagementCost;
            entity.AraToplam2 = calculation.AraToplam2;
            entity.MinimumSalesPrice = calculation.MinimumSalesPrice;
            entity.SalesPrice = calculation.SalesPrice;

            await _context.SaveChangesAsync();
            return MapSalesPrice(entity, laborRate.HourlyRate, gugRate.HourlyRate, financeRate.Percentage, generalManagementRate.Percentage);
        }

        public async Task<EN13458MaterialCostTableDTO> BuildMaterialCostTableAsync(EN13458ResultDTO result)
        {
            var rows = await BuildMaterialCostRowsAsync(result, previousAnalysis: null);
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

        private async Task CloneSalesPriceAsync(Guid calculationId, Guid targetCostAnalysisId, EN13458SalesPrice? sourceSalesPrice, double immCost, string modifiedBy)
        {
            if (sourceSalesPrice == null)
            {
                return;
            }

            var laborRate = await _context.LaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.LaborRateId && x.Status != Status.Deleted);
            var gugRate = await _context.GugHourlyRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.GugHourlyRateId && x.Status != Status.Deleted);
            var financeRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.FinanceOverheadRateId && x.Status != Status.Deleted);
            var generalManagementRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.GeneralManagementOverheadRateId && x.Status != Status.Deleted);

            if (laborRate == null || gugRate == null || financeRate == null || generalManagementRate == null)
            {
                return;
            }

            var calculation = CalculateSalesPrice(
                immCost,
                sourceSalesPrice.LaborHours,
                laborRate.HourlyRate,
                gugRate.HourlyRate,
                financeRate.Percentage,
                generalManagementRate.Percentage,
                sourceSalesPrice.ProfitPercentage);

            _context.EN13458SalesPrices.Add(new EN13458SalesPrice
            {
                EN13458CalculationId = calculationId,
                EN13458CostAnalysisId = targetCostAnalysisId,
                LaborRateId = laborRate.Id,
                GugHourlyRateId = gugRate.Id,
                FinanceOverheadRateId = financeRate.Id,
                GeneralManagementOverheadRateId = generalManagementRate.Id,
                LaborHours = sourceSalesPrice.LaborHours,
                ProfitPercentage = sourceSalesPrice.ProfitPercentage,
                LaborCost = calculation.LaborCost,
                GugCost = calculation.GugCost,
                ImmCost = calculation.ImmCost,
                AraToplam1 = calculation.AraToplam1,
                FinanceCost = calculation.FinanceCost,
                GeneralManagementCost = calculation.GeneralManagementCost,
                AraToplam2 = calculation.AraToplam2,
                MinimumSalesPrice = calculation.MinimumSalesPrice,
                SalesPrice = calculation.SalesPrice,
                CreatedBy = modifiedBy,
                CreatedDate = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        private async Task RefreshSalesPriceFromLatestCostAsync(Guid calculationId, Guid costAnalysisId, string modifiedBy)
        {
            var salesPrice = await _context.EN13458SalesPrices
                .FirstOrDefaultAsync(x => x.EN13458CalculationId == calculationId && x.EN13458CostAnalysisId == costAnalysisId && x.Status != Status.Deleted);
            if (salesPrice == null)
            {
                return;
            }

            var laborRate = await _context.LaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == salesPrice.LaborRateId && x.Status != Status.Deleted);
            var gugRate = await _context.GugHourlyRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == salesPrice.GugHourlyRateId && x.Status != Status.Deleted);
            var financeRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == salesPrice.FinanceOverheadRateId && x.Status != Status.Deleted);
            var generalManagementRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == salesPrice.GeneralManagementOverheadRateId && x.Status != Status.Deleted);
            if (laborRate == null || gugRate == null || financeRate == null || generalManagementRate == null)
            {
                return;
            }

            var immCost = await _context.EN13458CostAnalysisItems
                .Where(x => x.EN13458CostAnalysisId == costAnalysisId && x.Status != Status.Deleted)
                .SumAsync(x => (double?)x.ItemCost) ?? 0d;
            var calculation = CalculateSalesPrice(immCost, salesPrice.LaborHours, laborRate.HourlyRate, gugRate.HourlyRate, financeRate.Percentage, generalManagementRate.Percentage, salesPrice.ProfitPercentage);

            salesPrice.LaborCost = calculation.LaborCost;
            salesPrice.GugCost = calculation.GugCost;
            salesPrice.ImmCost = calculation.ImmCost;
            salesPrice.AraToplam1 = calculation.AraToplam1;
            salesPrice.FinanceCost = calculation.FinanceCost;
            salesPrice.GeneralManagementCost = calculation.GeneralManagementCost;
            salesPrice.AraToplam2 = calculation.AraToplam2;
            salesPrice.MinimumSalesPrice = calculation.MinimumSalesPrice;
            salesPrice.SalesPrice = calculation.SalesPrice;
            salesPrice.ModifiedBy = modifiedBy;
            salesPrice.ModifiedDate = DateTime.UtcNow;
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

        private async Task<List<EN13458MaterialCostRowDTO>> BuildMaterialCostRowsAsync(EN13458ResultDTO result, EN13458CostAnalysis? previousAnalysis)
        {
            var rows = new List<EN13458MaterialCostRowDTO>();
            var previousItems = previousAnalysis?.Items?.Where(x => x.Status != Status.Deleted).ToList();
            var previousCalculatedItems = previousItems?
                .Where(x => string.Equals(x.ItemSourceType, CalculatedSourceType, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.ItemKey, StringComparer.OrdinalIgnoreCase)
                ?? new Dictionary<string, EN13458CostAnalysisItem>(StringComparer.OrdinalIgnoreCase);

            rows.Add(await BuildMaterialRowAsync("INNER-SHELL", 10, "SAC", "Sac Maliyeti", "İç Gövde", result.InnerShellMaterialId, result.InnerShellMaterialFormId, result.InnerShellThickness, result.RoundedInnerShellThickness, result.OuterDiameter, result.ShellLength, isHead: false, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("INNER-HEAD", 20, "SAC", "Sac Maliyeti", "İç Bombe", result.InnerHeadMaterialId, result.InnerHeadMaterialFormId, result.InnerHeadThickness, result.RoundedInnerHeadThickness, result.OuterDiameter, result.ShellLength, isHead: true, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("OUTER-SHELL", 30, "SAC", "Sac Maliyeti", "Dış Gövde", result.OuterShellMaterialId, result.OuterShellMaterialFormId, result.OuterShellThickness, result.RoundedOuterShellThickness, result.OuterTankDiameter, result.OuterTankTotalLength, isHead: false, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("OUTER-HEAD", 40, "SAC", "Sac Maliyeti", "Dış Bombe", result.OuterHeadMaterialId, result.OuterHeadMaterialFormId, result.OuterHeadThickness, result.RoundedOuterHeadThickness, result.OuterTankDiameter, result.OuterTankTotalLength, isHead: true, previousCalculatedItems));
            rows.Add(await BuildBombeLaborRowAsync("BOMBE-LABOR-INNER", 25, "İç Bombe İşçilik", result.InnerHeadMaterialId, result.InnerTankHeadWeight * 2d, previousAnalysis?.InnerHeadBombeLaborRateId, previousCalculatedItems.GetValueOrDefault("BOMBE-LABOR-INNER")));
            rows.Add(await BuildBombeLaborRowAsync("BOMBE-LABOR-OUTER", 45, "Dış Bombe İşçilik", result.OuterHeadMaterialId, result.OuterTankHeadWeight * 2d, previousAnalysis?.OuterHeadBombeLaborRateId, previousCalculatedItems.GetValueOrDefault("BOMBE-LABOR-OUTER")));
            rows = rows.Where(x => x != null).ToList();

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

            if (result.TotalWeldLength > 0)
            {
                rows.Add(BuildWeldConsumableRow(result.TotalWeldLength, previousCalculatedItems.GetValueOrDefault("WELD-CONSUMABLE")));
            }

            var profileRow = await BuildProfileCostRowAsync(result, previousCalculatedItems.GetValueOrDefault("PROFILE"));
            if (profileRow is not null)
            {
                rows.Add(profileRow);
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
                ? GetTwoHeadsAreaApproximation(diameter)
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

        private async Task<EN13458MaterialCostRowDTO> BuildBombeLaborRowAsync(string itemKey, int sortOrder, string itemName, Guid materialId, double quantity, Guid? selectedRateId, EN13458CostAnalysisItem? previous)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);
            var selectedRate = selectedRateId.HasValue
                ? await _context.BombeLaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == selectedRateId.Value)
                : null;

            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = sortOrder,
                ItemKey = itemKey,
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = BombeLaborCostGroupCode,
                CostGroupName = BombeLaborCostGroupName,
                ItemName = itemName,
                MaterialId = materialId,
                MaterialName = material?.Name ?? itemName,
                FormType = selectedRate == null ? "Bombe işçilik seçilmedi" : $"{selectedRate.MaterialType} / {selectedRate.Name}",
                Quantity = quantity,
                Unit = "kg",
                StockCode = string.Empty,
                StockCodeName = selectedRate?.Name ?? string.Empty,
                StockUnitPrice = selectedRate?.RatePerKg ?? 0,
                UnitPrice = selectedRate?.RatePerKg ?? 0,
                ItemCost = quantity * (selectedRate?.RatePerKg ?? 0)
            };

            if (previous != null)
            {
                row.StockUnitPrice = selectedRate?.RatePerKg ?? previous.StockUnitPrice;
                row.UnitPrice = selectedRate?.RatePerKg ?? previous.UnitPrice;
                row.ItemCost = row.Quantity * row.UnitPrice;
            }

            return row;
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

        private async Task<EN13458MaterialCostRowDTO?> BuildFilmCountCostRowAsync(EN13458ResultDTO result, EN13458CostAnalysisItem? previous)
        {
            var weldLengthForFilmCount = result.TotalWeldLength > 0
                ? result.TotalWeldLength
                : CalculateInnerTankWeldLength1500(result);
            var filmCalculation = _filmQuantityService.Calculate(weldLengthForFilmCount);
            var totalFilmCount = filmCalculation.FilmQuantity;
            if (totalFilmCount <= 0)
            {
                return null;
            }

            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = 100,
                ItemKey = "FILM-COUNT",
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = "FILM",
                CostGroupName = "Film Maliyeti",
                ItemName = $"Toplam Film Sayısı (Toplam Kaynak / {filmCalculation.Divisor:0})",
                StockCode = ProfileWeldStockCode,
                MaterialName = "Film",
                FormType = "Hizmet",
                Quantity = totalFilmCount,
                Unit = "adet"
            };

            return await ApplyPreviousPricingAsync(row, previous, fallbackUnitPrice: await ResolveUnitPriceAsync(ProfileWeldStockCode, null));
        }

        private EN13458MaterialCostRowDTO BuildWeldConsumableRow(double totalWeldLengthMm, EN13458CostAnalysisItem? previous)
        {
            var weldLengthM = Math.Round(totalWeldLengthMm / 1000d, 2);

            var row = new EN13458MaterialCostRowDTO
            {
                SortOrder = 80,
                ItemKey = "WELD-CONSUMABLE",
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = "WELD",
                CostGroupName = "Kaynak Sarf Maliyeti",
                ItemName = "Toplam Kaynak Miktarı",
                MaterialName = "Kaynak Teli",
                FormType = "Hizmet",
                Quantity = weldLengthM,
                Unit = "m",
                StockUnitPrice = DefaultWeldConsumableUnitPriceEuro,
                UnitPrice = DefaultWeldConsumableUnitPriceEuro,
                ItemCost = weldLengthM * DefaultWeldConsumableUnitPriceEuro
            };

            if (previous != null)
            {
                row.UseManualUnitPrice = previous.UseManualUnitPrice;
                row.ManualUnitPrice = previous.ManualUnitPrice;
                row.UnitPrice = ResolveEffectiveUnitPrice(row.StockUnitPrice, row.UseManualUnitPrice, row.ManualUnitPrice);
                row.ItemCost = row.Quantity * row.UnitPrice;
            }

            return row;
        }

        private static double CalculateInnerTankWeldLength1500(EN13458ResultDTO result)
        {
            if (result.ShellLength <= 0 || result.OuterDiameter <= 0)
            {
                return 0d;
            }

            var sectionCount = result.ShellLength / FilmSourceLength;
            var circumferenceWeld = (sectionCount * result.OuterDiameter * Math.PI) + (Math.PI * result.OuterDiameter);
            var headPulDiameter = HeadPulDiameterCoefficient * result.OuterDiameter;
            var headWeld = ((headPulDiameter / FilmSourceLength) * (headPulDiameter / HeadWeldDivisor) * 2d);

            return circumferenceWeld + headWeld;
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

        private async Task EnsureWeldAndFilmRowsAsync(EN13458CostAnalysis analysis, EN13458ResultDTO result)
        {
            var activeItems = analysis.Items.Where(x => x.Status != Status.Deleted).ToList();
            var hasWeldRow = activeItems.Any(x => string.Equals(x.ItemKey, "WELD-CONSUMABLE", StringComparison.OrdinalIgnoreCase));
            var hasFilmRow = activeItems.Any(x => string.Equals(x.ItemKey, "FILM-COUNT", StringComparison.OrdinalIgnoreCase));

            if (hasWeldRow && hasFilmRow)
            {
                return;
            }

            var hasChanges = false;

            if (!hasWeldRow && result.TotalWeldLength > 0)
            {
                var weldRow = BuildWeldConsumableRow(result.TotalWeldLength, previous: null);
                var weldEntity = ToEntity(weldRow, "System");
                weldEntity.EN13458CostAnalysisId = analysis.Id;
                analysis.Items.Add(weldEntity);
                hasChanges = true;
            }

            if (!hasFilmRow)
            {
                var filmRow = await BuildFilmCountCostRowAsync(result, previous: null);
                if (filmRow != null)
                {
                    var filmEntity = ToEntity(filmRow, "System");
                    filmEntity.EN13458CostAnalysisId = analysis.Id;
                    analysis.Items.Add(filmEntity);
                    hasChanges = true;
                }
            }

            if (hasChanges)
            {
                await _context.SaveChangesAsync();
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

        private static EN13458MaterialCostTableDTO BuildCostTableFromItems(EN13458CostAnalysis analysis, List<EN13458MaterialCostRowDTO> items, EN13458SalesPrice? salesPrice = null)
        {
            return new EN13458MaterialCostTableDTO
            {
                CostAnalysisId = analysis.Id,
                EN13458CalculationId = analysis.EN13458CalculationId,
                RevisionNo = analysis.RevisionNo,
                RevisionCode = analysis.RevisionCode,
                AnalysisName = analysis.Name,
                CreatedDate = analysis.CreatedDate,
                InnerHeadBombeLaborRateId = analysis.InnerHeadBombeLaborRateId,
                OuterHeadBombeLaborRateId = analysis.OuterHeadBombeLaborRateId,
                Items = items.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList(),
                TotalMaterialCost = items.Sum(x => x.ItemCost),
                TotalFilmCost = items.Where(x => x.CostGroupCode == "FILM").Sum(x => x.ItemCost),
                GrandTotalCost = items.Sum(x => x.ItemCost),
                SalesPrice = salesPrice == null ? null : MapSalesPrice(salesPrice),
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


        private static EN13458SalesPriceDTO MapSalesPrice(EN13458SalesPrice salesPrice, double? laborHourlyRate = null, double? gugHourlyRate = null, double? financePercentage = null, double? generalManagementPercentage = null)
        {
            return new EN13458SalesPriceDTO
            {
                Id = salesPrice.Id,
                EN13458CalculationId = salesPrice.EN13458CalculationId,
                EN13458CostAnalysisId = salesPrice.EN13458CostAnalysisId,
                LaborRateId = salesPrice.LaborRateId,
                GugHourlyRateId = salesPrice.GugHourlyRateId,
                FinanceOverheadRateId = salesPrice.FinanceOverheadRateId,
                GeneralManagementOverheadRateId = salesPrice.GeneralManagementOverheadRateId,
                LaborHours = salesPrice.LaborHours,
                ProfitPercentage = salesPrice.ProfitPercentage,
                LaborHourlyRate = laborHourlyRate ?? 0,
                GugHourlyRateValue = gugHourlyRate ?? 0,
                FinancePercentage = financePercentage ?? 0,
                GeneralManagementPercentage = generalManagementPercentage ?? 0,
                LaborCost = salesPrice.LaborCost,
                GugCost = salesPrice.GugCost,
                ImmCost = salesPrice.ImmCost,
                AraToplam1 = salesPrice.AraToplam1,
                FinanceCost = salesPrice.FinanceCost,
                GeneralManagementCost = salesPrice.GeneralManagementCost,
                AraToplam2 = salesPrice.AraToplam2,
                MinimumSalesPrice = salesPrice.MinimumSalesPrice,
                SalesPrice = salesPrice.SalesPrice
            };
        }

        private static EN13458SalesPriceDTO CalculateSalesPrice(double immCost, double laborHours, double laborHourlyRate, double gugHourlyRate, double financePercentage, double generalManagementPercentage, double profitPercentage)
        {
            var laborCost = laborHours * laborHourlyRate;
            var gugCost = laborHours * gugHourlyRate;
            var araToplam1 = immCost + laborCost + gugCost;
            var financeCost = araToplam1 * financePercentage / 100d;
            var generalManagementCost = araToplam1 * generalManagementPercentage / 100d;
            var araToplam2 = araToplam1 + financeCost + generalManagementCost;
            var salesPrice = araToplam2 * (1 + (profitPercentage / 100d));

            return new EN13458SalesPriceDTO
            {
                LaborHours = laborHours,
                ProfitPercentage = profitPercentage,
                LaborHourlyRate = laborHourlyRate,
                GugHourlyRateValue = gugHourlyRate,
                FinancePercentage = financePercentage,
                GeneralManagementPercentage = generalManagementPercentage,
                LaborCost = laborCost,
                GugCost = gugCost,
                ImmCost = immCost,
                AraToplam1 = araToplam1,
                FinanceCost = financeCost,
                GeneralManagementCost = generalManagementCost,
                AraToplam2 = araToplam2,
                MinimumSalesPrice = immCost,
                SalesPrice = salesPrice
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

        private static bool IsManualSource(EN13458CostAnalysisItem item)
        {
            return string.Equals(item.ItemSourceType, ManualSourceType, StringComparison.OrdinalIgnoreCase)
                || string.Equals(item.ItemSourceType, ManualGroupSourceType, StringComparison.OrdinalIgnoreCase);
        }

        private static double NormalizeManualQuantity(double quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Manuel maliyet kalemi miktarı sıfırdan büyük olmalıdır.");
            }

            return quantity;
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

        private static double GetTwoHeadsAreaApproximation(double diameter) => GetSingleHeadAreaApproximation(diameter) * 2d;
    }
}
