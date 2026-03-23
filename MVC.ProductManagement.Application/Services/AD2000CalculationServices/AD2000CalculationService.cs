using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.Costing;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.AD2000Repositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.AD2000CalculationServices
{
    public class AD2000CalculationService : IAD2000CalculationService
    {
        private readonly IAD2000Repository _repository;
        private readonly AppDbContext _context;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialFormRepository _materialFormRepository;

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
        private const double FilmLengthDivisor = 450d;

        public AD2000CalculationService(
            IAD2000Repository repository,
            AppDbContext context,
            IMaterialRepository materialRepository,
            IMaterialFormRepository materialFormRepository)
        {
            _repository = repository;
            _context = context;
            _materialRepository = materialRepository;
            _materialFormRepository = materialFormRepository;
        }

        public Task<AD2000ResultDTO> CalculateAsync(AD2000CalculateDTO dto)
        {
            var pDesign = dto.DesignPressure;
            var d = dto.Diameter;
            var shellSigma = dto.ShellAllowableStress > 0 ? dto.ShellAllowableStress : dto.AllowableStress;
            var headSigma = dto.HeadAllowableStress > 0 ? dto.HeadAllowableStress : dto.AllowableStress;
            var z = dto.WeldJointFactor <= 0 ? 1.0 : dto.WeldJointFactor;
            var beta = dto.Beta <= 0 ? 1.0 : dto.Beta;
            var ca = Math.Max(0, dto.CorrosionAllowance);

            var staticPressure = dto.StaticPressure > 0
                ? dto.StaticPressure
                : CalculateStaticPressureBar(dto.LiquidDensity, dto.TankOrientation, dto.ShellLength, dto.Diameter);

            var effectivePressure = pDesign + staticPressure;
            var shellThickness = ((effectivePressure * d) / ((20 * (shellSigma / 1.5) * z) + effectivePressure)) + ca;
            var headThickness = ((effectivePressure * d * beta) / ((40 * (headSigma / 1.5) * z) - effectivePressure)) + ca;

            return Task.FromResult(new AD2000ResultDTO
            {
                Name = dto.Name,
                Diameter = dto.Diameter,
                ShellLength = dto.ShellLength,
                DesignPressure = dto.DesignPressure,
                DesignTemperatureMin = dto.DesignTemperatureMin,
                DesignTemperatureMax = dto.DesignTemperatureMax,
                CorrosionAllowance = dto.CorrosionAllowance,
                WeldJointFactor = dto.WeldJointFactor,
                AllowableStress = dto.AllowableStress,
                ShellAllowableStress = dto.ShellAllowableStress,
                HeadAllowableStress = dto.HeadAllowableStress,
                EstimatedShellThickness = dto.EstimatedShellThickness,
                EstimatedHeadThickness = dto.EstimatedHeadThickness,
                Beta = dto.Beta,
                TankOrientation = dto.TankOrientation,
                StorageTypeId = dto.StorageTypeId,
                IsManualDensity = dto.IsManualDensity,
                LiquidDensity = dto.LiquidDensity,
                StaticPressure = staticPressure,
                ShellMaterialId = dto.ShellMaterialId,
                ShellMaterialFormId = dto.ShellMaterialFormId,
                HeadMaterialId = dto.HeadMaterialId,
                HeadMaterialFormId = dto.HeadMaterialFormId,
                ShellThickness = shellThickness,
                HeadThickness = headThickness,
                RoundedShellThickness = RoundUpToHalf(shellThickness),
                RoundedHeadThickness = RoundUpToHalf(headThickness),
                TestPressure = effectivePressure * 1.3,
                WeldLength1500 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 1500d),
                WeldLength2000 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 2000d),
                WeldLength3000 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 3000d),
                WeldLength4000 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 4000d),
                SurfaceArea = CalculateSurfaceArea(d, dto.ShellLength)
            });
        }

        public async Task<AD2000ResultDTO> SaveAsync(AD2000ResultDTO result, string createdBy = "System")
        {
            var entity = ToEntity(result, createdBy);
            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();
            result.Id = entity.Id;
            return result;
        }

        public async Task<AD2000ResultDTO?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, tracking: false);
            return entity == null ? null : ToDto(entity);
        }

        public async Task<List<AD2000ResultDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync(tracking: false);
            return list.Select(ToDto).ToList();
        }

        public async Task<List<AD2000CostAnalysisSummaryDTO>> GetCostAnalysesAsync(Guid calculationId)
        {
            return await _context.Set<AD2000CostAnalysis>()
                .AsNoTracking()
                .Where(x => x.AD2000CalculationId == calculationId)
                .OrderByDescending(x => x.RevisionNo)
                .Select(x => new AD2000CostAnalysisSummaryDTO
                {
                    Id = x.Id,
                    AD2000CalculationId = x.AD2000CalculationId,
                    RevisionNo = x.RevisionNo,
                    RevisionCode = x.RevisionCode,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    GrandTotalCost = x.Items.Where(i => i.Status != Status.Deleted).Sum(i => i.ItemCost)
                })
                .ToListAsync();
        }

        public async Task<AD2000MaterialCostTableDTO?> GetCostAnalysisAsync(Guid calculationId, Guid? costAnalysisId = null)
        {
            var query = _context.Set<AD2000CostAnalysis>().AsNoTracking().Where(x => x.AD2000CalculationId == calculationId);
            AD2000CostAnalysis? analysis;
            if (costAnalysisId.HasValue && costAnalysisId.Value != Guid.Empty)
            {
                analysis = await query.Include(x => x.Items).Include(x => x.SalesPrices).FirstOrDefaultAsync(x => x.Id == costAnalysisId.Value);
            }
            else
            {
                analysis = await query.OrderByDescending(x => x.RevisionNo).Include(x => x.Items).Include(x => x.SalesPrices).FirstOrDefaultAsync();
            }

            return analysis == null ? null : BuildCostTableFromItems(analysis, analysis.Items.Where(x => x.Status != Status.Deleted).OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).Select(ToRowDto).ToList(), analysis.SalesPrices.FirstOrDefault(x => x.Status != Status.Deleted));
        }

        public async Task<AD2000MaterialCostTableDTO> CreateCostAnalysisAsync(Guid calculationId, string analysisName, string notes = "", string createdBy = "System")
        {
            await EnsureCalculationExistsAsync(calculationId);
            var result = await GetRequiredResultAsync(calculationId);
            var latest = await GetLatestCostAnalysisAsync(calculationId);
            var revisionNo = (latest?.RevisionNo ?? -1) + 1;
            var rows = await BuildMaterialCostRowsAsync(result, latest);

            var analysis = new AD2000CostAnalysis
            {
                AD2000CalculationId = calculationId,
                RevisionNo = revisionNo,
                RevisionCode = FormatRevisionCode(revisionNo),
                Name = string.IsNullOrWhiteSpace(analysisName) ? DefaultAnalysisName : analysisName.Trim(),
                Notes = notes?.Trim() ?? string.Empty,
                HeadBombeLaborRateId = latest?.HeadBombeLaborRateId,
                Items = rows.Select(x => ToEntity(x, createdBy)).ToList(),
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow
            };

            _context.Add(analysis);
            await _context.SaveChangesAsync();

            if (latest != null)
            {
                var latestSalesPrice = await _context.Set<AD2000SalesPrice>().AsNoTracking().FirstOrDefaultAsync(x => x.AD2000CalculationId == calculationId && x.AD2000CostAnalysisId == latest.Id && x.Status != Status.Deleted);
                await CloneSalesPriceAsync(calculationId, analysis.Id, latestSalesPrice, rows.Sum(x => x.ItemCost), createdBy);
            }

            return await GetCostAnalysisAsync(calculationId, analysis.Id) ?? BuildPreviewCostTable(result.Id, rows);
        }

        public async Task<AD2000MaterialCostTableDTO> CreateCostAnalysisRevisionAsync(Guid calculationId, Guid sourceCostAnalysisId, string analysisName, string notes = "", string createdBy = "System")
        {
            await EnsureCalculationExistsAsync(calculationId);
            var source = await _context.Set<AD2000CostAnalysis>().Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == sourceCostAnalysisId && x.AD2000CalculationId == calculationId);
            if (source == null)
            {
                throw new InvalidOperationException("Revizyon oluşturmak için kaynak maliyet analizi bulunamadı.");
            }

            var result = await GetRequiredResultAsync(calculationId);
            var latest = await GetLatestCostAnalysisAsync(calculationId);
            var revisionNo = (latest?.RevisionNo ?? -1) + 1;
            var rows = await BuildMaterialCostRowsAsync(result, source);

            var analysis = new AD2000CostAnalysis
            {
                AD2000CalculationId = calculationId,
                RevisionNo = revisionNo,
                RevisionCode = FormatRevisionCode(revisionNo),
                Name = string.IsNullOrWhiteSpace(analysisName) ? source.Name : analysisName.Trim(),
                Notes = string.IsNullOrWhiteSpace(notes) ? source.Notes : notes.Trim(),
                HeadBombeLaborRateId = source.HeadBombeLaborRateId,
                Items = rows.Select(x => ToEntity(x, createdBy)).ToList(),
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow
            };

            _context.Add(analysis);
            await _context.SaveChangesAsync();

            var sourceSalesPrice = await _context.Set<AD2000SalesPrice>().AsNoTracking().FirstOrDefaultAsync(x => x.AD2000CalculationId == calculationId && x.AD2000CostAnalysisId == source.Id && x.Status != Status.Deleted);
            await CloneSalesPriceAsync(calculationId, analysis.Id, sourceSalesPrice, rows.Sum(x => x.ItemCost), createdBy);

            return await GetCostAnalysisAsync(calculationId, analysis.Id) ?? BuildPreviewCostTable(result.Id, rows);
        }

        public async Task UpdateCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId, Guid? generatedStockCodeId, double? quantity, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy = "System")
        {
            var item = await _context.Set<AD2000CostAnalysisItem>()
                .Include(x => x.AD2000CostAnalysis)
                .FirstOrDefaultAsync(x => x.Id == costAnalysisItemId && x.AD2000CostAnalysisId == costAnalysisId && x.AD2000CostAnalysis.AD2000CalculationId == calculationId);

            if (item == null)
            {
                throw new InvalidOperationException("Güncellenecek maliyet kalemi bulunamadı.");
            }

            await ApplyCostAnalysisItemUpdateAsync(item, generatedStockCodeId, quantity, useManualUnitPrice, manualUnitPrice, modifiedBy);
            await _context.SaveChangesAsync();
        }

        public async Task BulkUpdateCostAnalysisItemsAsync(Guid calculationId, Guid costAnalysisId, IReadOnlyCollection<(Guid CostAnalysisItemId, Guid? GeneratedStockCodeId, double? Quantity, bool UseManualUnitPrice, double? ManualUnitPrice)> items, string modifiedBy = "System")
        {
            var itemIds = items.Where(x => x.CostAnalysisItemId != Guid.Empty).Select(x => x.CostAnalysisItemId).Distinct().ToList();
            if (itemIds.Count == 0)
            {
                return;
            }

            var analysisItems = await _context.Set<AD2000CostAnalysisItem>()
                .Include(x => x.AD2000CostAnalysis)
                .Where(x => x.AD2000CostAnalysisId == costAnalysisId && x.AD2000CostAnalysis.AD2000CalculationId == calculationId && itemIds.Contains(x.Id))
                .ToListAsync();

            var map = analysisItems.ToDictionary(x => x.Id);
            foreach (var request in items.Where(x => x.CostAnalysisItemId != Guid.Empty))
            {
                if (!map.TryGetValue(request.CostAnalysisItemId, out var item))
                {
                    throw new InvalidOperationException("Güncellenecek maliyet kalemi bulunamadı.");
                }

                await ApplyCostAnalysisItemUpdateAsync(item, request.GeneratedStockCodeId, request.Quantity, request.UseManualUnitPrice, request.ManualUnitPrice, modifiedBy);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddManualStockCodeCostAsync(Guid calculationId, Guid costAnalysisId, Guid generatedStockCodeId, double quantity, bool useManualUnitPrice, double? manualUnitPrice, string createdBy = "System")
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Stok kodu miktarı sıfırdan büyük olmalıdır.");
            }

            await GetRequiredCostAnalysisAsync(calculationId, costAnalysisId);
            var generatedCode = await _context.GeneratedStockCodes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == generatedStockCodeId);
            if (generatedCode == null)
            {
                throw new InvalidOperationException("Seçilen stok kodu bulunamadı.");
            }

            var stockUnitPrice = Convert.ToDouble(generatedCode.UnitPrice ?? 0m);
            var effectiveUnitPrice = ResolveEffectiveUnitPrice(stockUnitPrice, useManualUnitPrice, manualUnitPrice);
            var nextSortOrder = await GetNextSortOrderAsync(costAnalysisId);

            _context.Add(new AD2000CostAnalysisItem
            {
                AD2000CostAnalysisId = costAnalysisId,
                SortOrder = nextSortOrder,
                ItemKey = $"MANUAL-STOCK-{Guid.NewGuid():N}",
                ItemSourceType = ManualSourceType,
                CostGroupCode = ManualStockCostGroupCode,
                CostGroupName = ManualStockCostGroupName,
                ItemName = string.IsNullOrWhiteSpace(generatedCode.Description) ? generatedCode.GeneratedCode : generatedCode.Description!,
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
            var group = await _context.StockProductGroups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == stockProductGroupId);
            if (group == null)
            {
                throw new InvalidOperationException("Seçilen stok grubu bulunamadı.");
            }

            var groupItems = await _context.StockProductGroupItems.AsNoTracking()
                .Where(x => x.StockProductGroupId == stockProductGroupId)
                .Join(_context.GeneratedStockCodes.AsNoTracking(), item => item.GeneratedStockCodeId, code => code.Id, (item, code) => new { Item = item, Code = code })
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
                var qty = x.Item.Quantity * multiplier;
                var stockUnitPrice = Convert.ToDouble(x.Item.UnitPrice > 0 ? x.Item.UnitPrice : (x.Code.UnitPrice ?? 0m));
                return new AD2000CostAnalysisItem
                {
                    AD2000CostAnalysisId = costAnalysisId,
                    SortOrder = nextSortOrder + index,
                    ItemKey = BuildManualGroupItemKey(group.Id, x.Code.Id, index),
                    ItemSourceType = ManualGroupSourceType,
                    CostGroupCode = ManualGroupCostGroupCode,
                    CostGroupName = ManualGroupCostGroupName,
                    ItemName = $"{group.Name} / {(string.IsNullOrWhiteSpace(x.Code.Description) ? x.Code.GeneratedCode : x.Code.Description!)}",
                    GeneratedStockCodeId = x.Code.Id,
                    StockCode = x.Code.GeneratedCode,
                    StockCodeName = BuildStockDisplayName(x.Code.GeneratedCode, x.Code.Description, x.Code.RuleName),
                    MaterialName = string.IsNullOrWhiteSpace(x.Code.RuleName) ? group.Name : x.Code.RuleName,
                    FormType = group.Name,
                    Quantity = qty,
                    Unit = "adet",
                    StockUnitPrice = stockUnitPrice,
                    UnitPrice = stockUnitPrice,
                    ItemCost = qty * stockUnitPrice,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.UtcNow
                };
            }).ToList();

            _context.AddRange(details);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId)
        {
            var item = await _context.Set<AD2000CostAnalysisItem>()
                .Include(x => x.AD2000CostAnalysis)
                .FirstOrDefaultAsync(x => x.Id == costAnalysisItemId && x.AD2000CostAnalysisId == costAnalysisId && x.AD2000CostAnalysis.AD2000CalculationId == calculationId);

            if (item == null)
            {
                throw new InvalidOperationException("Silinecek maliyet kalemi bulunamadı.");
            }

            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBombeLaborAsync(Guid calculationId, Guid costAnalysisId, Guid? headBombeLaborRateId, string modifiedBy = "System")
        {
            var analysis = await _context.Set<AD2000CostAnalysis>()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == costAnalysisId && x.AD2000CalculationId == calculationId);

            if (analysis == null)
            {
                throw new InvalidOperationException("Seçilen maliyet analizi bulunamadı.");
            }

            analysis.HeadBombeLaborRateId = headBombeLaborRateId;
            analysis.ModifiedBy = modifiedBy;
            analysis.ModifiedDate = DateTime.UtcNow;

            var bombeRow = analysis.Items.FirstOrDefault(x => x.ItemKey == "BOMBE-LABOR-HEAD" && x.Status != Status.Deleted);
            if (bombeRow != null)
            {
                var rate = headBombeLaborRateId.HasValue
                    ? await _context.BombeLaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == headBombeLaborRateId.Value && x.Status != Status.Deleted)
                    : null;
                bombeRow.StockUnitPrice = rate?.RatePerKg ?? 0;
                bombeRow.UnitPrice = bombeRow.StockUnitPrice;
                bombeRow.ItemCost = bombeRow.Quantity * bombeRow.UnitPrice;
                bombeRow.StockCodeName = rate?.Name ?? string.Empty;
                bombeRow.FormType = rate == null ? "Bombe işçilik seçilmedi" : $"{rate.MaterialType} / {rate.Name}";
                bombeRow.ModifiedBy = modifiedBy;
                bombeRow.ModifiedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<AD2000SalesPriceDTO?> GetSalesPriceAsync(Guid calculationId, Guid costAnalysisId)
        {
            var salesPrice = await _context.Set<AD2000SalesPrice>().AsNoTracking().FirstOrDefaultAsync(x => x.AD2000CalculationId == calculationId && x.AD2000CostAnalysisId == costAnalysisId && x.Status != Status.Deleted);
            return salesPrice == null ? null : MapSalesPrice(salesPrice);
        }

        public async Task<AD2000SalesPriceDTO> UpsertSalesPriceAsync(Guid calculationId, Guid costAnalysisId, Guid laborRateId, double laborHours, Guid gugHourlyRateId, Guid financeOverheadRateId, Guid generalManagementOverheadRateId, double profitPercentage, string modifiedBy = "System")
        {
            await GetRequiredCostAnalysisAsync(calculationId, costAnalysisId);
            var costTable = await GetCostAnalysisAsync(calculationId, costAnalysisId) ?? throw new InvalidOperationException("Maliyet analizi bulunamadı.");
            var laborRate = await _context.LaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == laborRateId && x.Status != Status.Deleted) ?? throw new InvalidOperationException("İşçilik tarifesi bulunamadı.");
            var gugRate = await _context.GugHourlyRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == gugHourlyRateId && x.Status != Status.Deleted) ?? throw new InvalidOperationException("GÜG tarifesi bulunamadı.");
            var financeRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == financeOverheadRateId && x.Status != Status.Deleted) ?? throw new InvalidOperationException("Finans gider oranı bulunamadı.");
            var generalManagementRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == generalManagementOverheadRateId && x.Status != Status.Deleted) ?? throw new InvalidOperationException("Genel yönetim gider oranı bulunamadı.");

            var calculation = CalculateSalesPrice(costTable.GrandTotalCost, laborHours, laborRate.HourlyRate, gugRate.HourlyRate, financeRate.Percentage, generalManagementRate.Percentage, profitPercentage);
            var entity = await _context.Set<AD2000SalesPrice>().FirstOrDefaultAsync(x => x.AD2000CalculationId == calculationId && x.AD2000CostAnalysisId == costAnalysisId && x.Status != Status.Deleted);
            if (entity == null)
            {
                entity = new AD2000SalesPrice { AD2000CalculationId = calculationId, AD2000CostAnalysisId = costAnalysisId };
                _context.Add(entity);
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
            entity.ModifiedBy = modifiedBy;
            entity.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return MapSalesPrice(entity, laborRate.HourlyRate, gugRate.HourlyRate, financeRate.Percentage, generalManagementRate.Percentage);
        }

        public async Task<AD2000MaterialCostTableDTO> BuildMaterialCostTableAsync(AD2000ResultDTO result)
        {
            var rows = await BuildMaterialCostRowsAsync(result, null);
            return BuildPreviewCostTable(result.Id, rows);
        }

        private AD2000MaterialCostTableDTO BuildPreviewCostTable(Guid id, List<AD2000MaterialCostRowDTO> rows)
        {
            return new AD2000MaterialCostTableDTO
            {
                AD2000CalculationId = id == Guid.Empty ? null : id,
                RevisionCode = PreviewRevisionCode,
                AnalysisName = DefaultAnalysisName,
                IsPreview = true,
                CreatedDate = DateTime.UtcNow,
                Items = rows.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList(),
                GroupTotals = BuildGroupTotals(rows),
                TotalMaterialCost = rows.Sum(x => x.ItemCost),
                GrandTotalCost = rows.Sum(x => x.ItemCost)
            };
        }

        private async Task<List<AD2000MaterialCostRowDTO>> BuildMaterialCostRowsAsync(AD2000ResultDTO result, AD2000CostAnalysis? previousAnalysis)
        {
            var rows = new List<AD2000MaterialCostRowDTO>();
            var previousItems = previousAnalysis?.Items?.Where(x => x.Status != Status.Deleted).ToList();
            var previousCalculatedItems = previousItems?
                .Where(x => string.Equals(x.ItemSourceType, CalculatedSourceType, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.ItemKey, StringComparer.OrdinalIgnoreCase)
                ?? new Dictionary<string, AD2000CostAnalysisItem>(StringComparer.OrdinalIgnoreCase);

            rows.Add(await BuildMaterialRowAsync("SHELL", 10, "SAC", "Sac Maliyeti", "Gövde Sacı", result.ShellMaterialId, result.ShellMaterialFormId, result.ShellThickness, result.RoundedShellThickness, result.Diameter, result.ShellLength, false, previousCalculatedItems));
            rows.Add(await BuildMaterialRowAsync("HEAD", 20, "SAC", "Sac Maliyeti", "Bombe Sacı", result.HeadMaterialId, result.HeadMaterialFormId, result.HeadThickness, result.RoundedHeadThickness, result.Diameter, result.ShellLength, true, previousCalculatedItems));
            rows.Add(await BuildBombeLaborRowAsync(result, previousAnalysis?.HeadBombeLaborRateId, previousCalculatedItems.GetValueOrDefault("BOMBE-LABOR-HEAD")));

            var filmCountRow = await BuildFilmCountRowAsync(result.WeldLength1500, previousCalculatedItems.GetValueOrDefault("FILM-COUNT"));
            if (filmCountRow is not null)
            {
                rows.Add(filmCountRow);
            }

            rows.Add(await BuildServiceRowAsync("SURFACE", 70, "YUZ", "Yüzey / Boya", "Yüzey Alanı", string.Empty, result.SurfaceArea, "m²", previousCalculatedItems));

            if (previousItems != null)
            {
                rows.AddRange(previousItems
                    .Where(x => !string.Equals(x.ItemSourceType, CalculatedSourceType, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.SortOrder)
                    .ThenBy(x => x.ItemName)
                    .Select(ToRowDto));
            }

            return rows.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList();
        }

        private async Task<AD2000MaterialCostRowDTO> BuildMaterialRowAsync(string itemKey, int sortOrder, string costGroupCode, string costGroupName, string itemName, Guid materialId, Guid materialFormId, double calculatedThickness, double usedThickness, double diameter, double shellLength, bool isHead, IReadOnlyDictionary<string, AD2000CostAnalysisItem> previousItems)
        {
            var material = await _materialRepository.GetByIdAsync(materialId) ?? throw new InvalidOperationException($"Material not found: {materialId}");
            var form = await _materialFormRepository.GetByIdAsync(materialFormId) ?? throw new InvalidOperationException($"MaterialForm not found: {materialFormId}");
            previousItems.TryGetValue(itemKey, out var previous);

            var area = isHead ? GetTwoHeadsAreaApproximation(diameter) : Math.PI * diameter * shellLength;
            var volumeMm3 = area * usedThickness;
            var weightKg = volumeMm3 * 1e-9 * material.Density;

            var row = new AD2000MaterialCostRowDTO
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
                Quantity = Math.Round(weightKg, 2),
                Unit = "kg",
                CalculatedThickness = calculatedThickness,
                UsedThickness = usedThickness,
                Density = material.Density,
                TheoreticalWeight = Math.Round(weightKg, 2)
            };

            return await ApplyPreviousPricingAsync(row, previous, 0);
        }

        private async Task<AD2000MaterialCostRowDTO?> BuildFilmCountRowAsync(double weldLength1500, AD2000CostAnalysisItem? previous)
        {
            var totalFilmCount = CalculateFilmCount(weldLength1500);
            if (totalFilmCount <= 0)
            {
                return null;
            }

            var row = new AD2000MaterialCostRowDTO
            {
                SortOrder = 30,
                ItemKey = "FILM-COUNT",
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = "FILM",
                CostGroupName = "Film Maliyeti",
                ItemName = "Toplam Film Sayısı (1500 Kaynak)",
                MaterialName = "Film",
                FormType = "Hizmet",
                Quantity = totalFilmCount,
                Unit = "adet"
            };

            return await ApplyPreviousPricingAsync(row, previous, 0);
        }

        private static double CalculateFilmCount(double weldLength1500)
        {
            if (weldLength1500 <= 0)
            {
                return 0d;
            }

            return Math.Ceiling(weldLength1500 / FilmLengthDivisor);
        }

        private async Task<AD2000MaterialCostRowDTO> BuildBombeLaborRowAsync(AD2000ResultDTO result, Guid? selectedRateId, AD2000CostAnalysisItem? previous)
        {
            var totalHeadWeight = await CalculateHeadWeightAsync(result);
            var material = await _materialRepository.GetByIdAsync(result.HeadMaterialId);
            var selectedRate = selectedRateId.HasValue ? await _context.BombeLaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == selectedRateId.Value && x.Status != Status.Deleted) : null;

            var row = new AD2000MaterialCostRowDTO
            {
                SortOrder = 25,
                ItemKey = "BOMBE-LABOR-HEAD",
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = BombeLaborCostGroupCode,
                CostGroupName = BombeLaborCostGroupName,
                ItemName = "Bombe İşçilik",
                MaterialId = result.HeadMaterialId,
                MaterialName = material?.Name ?? "Bombe İşçilik",
                FormType = selectedRate == null ? "Bombe işçilik seçilmedi" : $"{selectedRate.MaterialType} / {selectedRate.Name}",
                Quantity = totalHeadWeight,
                Unit = "kg",
                StockCodeName = selectedRate?.Name ?? string.Empty,
                StockUnitPrice = selectedRate?.RatePerKg ?? 0,
                UnitPrice = selectedRate?.RatePerKg ?? 0,
                ItemCost = totalHeadWeight * (selectedRate?.RatePerKg ?? 0)
            };

            if (previous != null && selectedRate == null)
            {
                row.StockUnitPrice = previous.StockUnitPrice;
                row.UnitPrice = previous.UnitPrice;
                row.ItemCost = row.Quantity * row.UnitPrice;
                row.StockCodeName = previous.StockCodeName;
                row.FormType = previous.FormType;
            }

            return row;
        }

        private async Task<AD2000MaterialCostRowDTO> BuildServiceRowAsync(string itemKey, int sortOrder, string costGroupCode, string costGroupName, string itemName, string stockCode, double quantity, string unit, IReadOnlyDictionary<string, AD2000CostAnalysisItem> previousItems)
        {
            previousItems.TryGetValue(itemKey, out var previous);
            var row = new AD2000MaterialCostRowDTO
            {
                SortOrder = sortOrder,
                ItemKey = itemKey,
                ItemSourceType = CalculatedSourceType,
                CostGroupCode = costGroupCode,
                CostGroupName = costGroupName,
                ItemName = itemName,
                MaterialName = itemName,
                FormType = "Hizmet",
                Quantity = Math.Round(quantity, 2),
                Unit = unit,
                StockCode = stockCode,
                StockCodeName = stockCode
            };

            return await ApplyPreviousPricingAsync(row, previous, await ResolveUnitPriceAsync(stockCode, null));
        }

        private async Task<AD2000MaterialCostRowDTO> ApplyPreviousPricingAsync(AD2000MaterialCostRowDTO row, AD2000CostAnalysisItem? previous, double fallbackUnitPrice)
        {
            row.GeneratedStockCodeId = previous?.GeneratedStockCodeId;
            row.StockCode = previous?.StockCode ?? row.StockCode;
            row.StockCodeName = previous?.StockCodeName ?? row.StockCodeName;
            row.UseManualUnitPrice = previous?.UseManualUnitPrice ?? false;
            row.ManualUnitPrice = previous?.UseManualUnitPrice == true ? NormalizeNullablePrice(previous.ManualUnitPrice) : null;

            var selectedCode = row.GeneratedStockCodeId.HasValue
                ? await ResolveGeneratedStockCodeAsync(row.GeneratedStockCodeId, row.StockCode)
                : await ResolveGeneratedStockCodeAsync(null, row.StockCode);

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

        private async Task ApplyCostAnalysisItemUpdateAsync(AD2000CostAnalysisItem item, Guid? generatedStockCodeId, double? quantity, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy)
        {
            if (quantity.HasValue && IsManualSource(item))
            {
                item.Quantity = NormalizeManualQuantity(quantity.Value);
            }

            var stockInfo = await ResolveGeneratedStockCodeAsync(generatedStockCodeId, item.StockCode);
            item.GeneratedStockCodeId = stockInfo?.Id;
            item.StockCode = stockInfo?.GeneratedCode ?? string.Empty;
            item.StockCodeName = stockInfo == null ? string.Empty : BuildStockDisplayName(stockInfo.GeneratedCode, stockInfo.Description, stockInfo.RuleName);
            item.StockUnitPrice = stockInfo == null ? 0 : Convert.ToDouble(stockInfo.UnitPrice ?? 0m);
            item.UseManualUnitPrice = useManualUnitPrice;
            item.ManualUnitPrice = useManualUnitPrice ? NormalizeNullablePrice(manualUnitPrice) : null;
            item.UnitPrice = ResolveEffectiveUnitPrice(item.StockUnitPrice, item.UseManualUnitPrice, item.ManualUnitPrice);
            item.ItemCost = item.Quantity * item.UnitPrice;
            item.ModifiedBy = modifiedBy;
            item.ModifiedDate = DateTime.UtcNow;
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
            var unitPrice = await _context.StockCardPrices.AsNoTracking()
                .Where(p => p.StockCard.StockCode8 == stockCode && p.IsActive && p.Status != Status.Deleted && p.ValidFrom.Date <= today && (p.ValidTo == null || p.ValidTo.Value.Date >= today))
                .OrderByDescending(p => p.ValidFrom)
                .Select(p => (double?)p.UnitPrice)
                .FirstOrDefaultAsync();

            return unitPrice ?? 0;
        }

        private async Task<AD2000CostAnalysis?> GetLatestCostAnalysisAsync(Guid calculationId)
        {
            return await _context.Set<AD2000CostAnalysis>()
                .Include(x => x.Items)
                .Where(x => x.AD2000CalculationId == calculationId)
                .OrderByDescending(x => x.RevisionNo)
                .FirstOrDefaultAsync();
        }

        private async Task<AD2000CostAnalysis> GetRequiredCostAnalysisAsync(Guid calculationId, Guid costAnalysisId)
        {
            var analysis = await _context.Set<AD2000CostAnalysis>().FirstOrDefaultAsync(x => x.Id == costAnalysisId && x.AD2000CalculationId == calculationId);
            if (analysis == null)
            {
                throw new InvalidOperationException("Seçilen maliyet analizi bulunamadı.");
            }

            return analysis;
        }

        private async Task<AD2000ResultDTO> GetRequiredResultAsync(Guid calculationId)
            => await GetByIdAsync(calculationId) ?? throw new InvalidOperationException("AD2000 kaydı bulunamadı.");

        private async Task EnsureCalculationExistsAsync(Guid calculationId)
        {
            var exists = await _context.AD2000Calculations.AsNoTracking().AnyAsync(x => x.Id == calculationId);
            if (!exists)
            {
                throw new InvalidOperationException("AD2000 kaydı bulunamadı.");
            }
        }

        private async Task<int> GetNextSortOrderAsync(Guid costAnalysisId)
        {
            var maxSortOrder = await _context.Set<AD2000CostAnalysisItem>().AsNoTracking().Where(x => x.AD2000CostAnalysisId == costAnalysisId).Select(x => (int?)x.SortOrder).MaxAsync();
            return (maxSortOrder ?? 0) + 10;
        }

        private async Task<double> CalculateHeadWeightAsync(AD2000ResultDTO result)
        {
            var material = await _materialRepository.GetByIdAsync(result.HeadMaterialId) ?? throw new InvalidOperationException("Bombe malzemesi bulunamadı.");
            var area = GetTwoHeadsAreaApproximation(result.Diameter);
            var volumeMm3 = area * result.RoundedHeadThickness;
            return Math.Round(volumeMm3 * 1e-9 * material.Density, 2);
        }

        private async Task CloneSalesPriceAsync(Guid calculationId, Guid targetCostAnalysisId, AD2000SalesPrice? sourceSalesPrice, double immCost, string modifiedBy)
        {
            if (sourceSalesPrice == null)
            {
                return;
            }

            var laborRate = await _context.LaborRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.LaborRateId && x.Status != Status.Deleted);
            var gugRate = await _context.GugHourlyRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.GugHourlyRateId && x.Status != Status.Deleted);
            var financeRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.FinanceOverheadRateId && x.Status != Status.Deleted);
            var gmRate = await _context.OverheadRates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sourceSalesPrice.GeneralManagementOverheadRateId && x.Status != Status.Deleted);
            if (laborRate == null || gugRate == null || financeRate == null || gmRate == null)
            {
                return;
            }

            var calculation = CalculateSalesPrice(immCost, sourceSalesPrice.LaborHours, laborRate.HourlyRate, gugRate.HourlyRate, financeRate.Percentage, gmRate.Percentage, sourceSalesPrice.ProfitPercentage);
            _context.Add(new AD2000SalesPrice
            {
                AD2000CalculationId = calculationId,
                AD2000CostAnalysisId = targetCostAnalysisId,
                LaborRateId = laborRate.Id,
                GugHourlyRateId = gugRate.Id,
                FinanceOverheadRateId = financeRate.Id,
                GeneralManagementOverheadRateId = gmRate.Id,
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

        private AD2000CostAnalysisItem ToEntity(AD2000MaterialCostRowDTO item, string createdBy)
        {
            return new AD2000CostAnalysisItem
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

        private static AD2000MaterialCostRowDTO ToRowDto(AD2000CostAnalysisItem item)
        {
            return new AD2000MaterialCostRowDTO
            {
                CostAnalysisItemId = item.Id,
                CostAnalysisId = item.AD2000CostAnalysisId,
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

        private static AD2000MaterialCostTableDTO BuildCostTableFromItems(AD2000CostAnalysis analysis, List<AD2000MaterialCostRowDTO> items, AD2000SalesPrice? salesPrice = null)
        {
            return new AD2000MaterialCostTableDTO
            {
                CostAnalysisId = analysis.Id,
                AD2000CalculationId = analysis.AD2000CalculationId,
                RevisionNo = analysis.RevisionNo,
                RevisionCode = analysis.RevisionCode,
                AnalysisName = analysis.Name,
                CreatedDate = analysis.CreatedDate,
                HeadBombeLaborRateId = analysis.HeadBombeLaborRateId,
                Items = items.OrderBy(x => x.SortOrder).ThenBy(x => x.ItemName).ToList(),
                GroupTotals = BuildGroupTotals(items),
                TotalMaterialCost = items.Sum(x => x.ItemCost),
                GrandTotalCost = items.Sum(x => x.ItemCost),
                SalesPrice = salesPrice == null ? null : MapSalesPrice(salesPrice)
            };
        }

        private static List<AD2000CostGroupSummaryDTO> BuildGroupTotals(List<AD2000MaterialCostRowDTO> items)
            => items.GroupBy(x => new { x.CostGroupCode, x.CostGroupName })
                .Select(g => new AD2000CostGroupSummaryDTO { CostGroupCode = g.Key.CostGroupCode, CostGroupName = g.Key.CostGroupName, TotalCost = g.Sum(i => i.ItemCost) })
                .OrderBy(x => x.CostGroupCode)
                .ToList();

        private static AD2000SalesPriceDTO MapSalesPrice(AD2000SalesPrice salesPrice, double? laborHourlyRate = null, double? gugHourlyRate = null, double? financePercentage = null, double? gmPercentage = null)
        {
            return new AD2000SalesPriceDTO
            {
                Id = salesPrice.Id,
                AD2000CalculationId = salesPrice.AD2000CalculationId,
                AD2000CostAnalysisId = salesPrice.AD2000CostAnalysisId,
                LaborRateId = salesPrice.LaborRateId,
                GugHourlyRateId = salesPrice.GugHourlyRateId,
                FinanceOverheadRateId = salesPrice.FinanceOverheadRateId,
                GeneralManagementOverheadRateId = salesPrice.GeneralManagementOverheadRateId,
                LaborHours = salesPrice.LaborHours,
                ProfitPercentage = salesPrice.ProfitPercentage,
                LaborHourlyRate = laborHourlyRate ?? 0,
                GugHourlyRateValue = gugHourlyRate ?? 0,
                FinancePercentage = financePercentage ?? 0,
                GeneralManagementPercentage = gmPercentage ?? 0,
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

        private static AD2000SalesPriceDTO CalculateSalesPrice(double immCost, double laborHours, double laborHourlyRate, double gugHourlyRate, double financePercentage, double generalManagementPercentage, double profitPercentage)
        {
            var laborCost = laborHours * laborHourlyRate;
            var gugCost = laborHours * gugHourlyRate;
            var araToplam1 = immCost + laborCost + gugCost;
            var financeCost = araToplam1 * financePercentage / 100d;
            var generalManagementCost = araToplam1 * generalManagementPercentage / 100d;
            var araToplam2 = araToplam1 + financeCost + generalManagementCost;
            var salesPrice = araToplam2 * (1 + profitPercentage / 100d);

            return new AD2000SalesPriceDTO
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

        private static AD2000Calculation ToEntity(AD2000ResultDTO dto, string createdBy) => new AD2000Calculation
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Diameter = dto.Diameter,
            ShellLength = dto.ShellLength,
            DesignPressure = dto.DesignPressure,
            DesignTemperatureMin = dto.DesignTemperatureMin,
            DesignTemperatureMax = dto.DesignTemperatureMax,
            CorrosionAllowance = dto.CorrosionAllowance,
            WeldJointFactor = dto.WeldJointFactor,
            AllowableStress = dto.AllowableStress,
            ShellAllowableStress = dto.ShellAllowableStress,
            HeadAllowableStress = dto.HeadAllowableStress,
            EstimatedShellThickness = dto.EstimatedShellThickness,
            EstimatedHeadThickness = dto.EstimatedHeadThickness,
            Beta = dto.Beta,
            TankOrientation = dto.TankOrientation,
            StorageTypeId = dto.StorageTypeId,
            IsManualDensity = dto.IsManualDensity,
            LiquidDensity = dto.LiquidDensity,
            StaticPressure = dto.StaticPressure,
            ShellMaterialId = dto.ShellMaterialId,
            ShellMaterialFormId = dto.ShellMaterialFormId,
            HeadMaterialId = dto.HeadMaterialId,
            HeadMaterialFormId = dto.HeadMaterialFormId,
            ShellThickness = dto.ShellThickness,
            HeadThickness = dto.HeadThickness,
            RoundedShellThickness = dto.RoundedShellThickness,
            RoundedHeadThickness = dto.RoundedHeadThickness,
            TestPressure = dto.TestPressure,
            WeldLength1500 = dto.WeldLength1500,
            WeldLength2000 = dto.WeldLength2000,
            WeldLength3000 = dto.WeldLength3000,
            WeldLength4000 = dto.WeldLength4000,
            SurfaceArea = dto.SurfaceArea,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow
        };

        private static AD2000ResultDTO ToDto(AD2000Calculation entity) => new AD2000ResultDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Diameter = entity.Diameter,
            ShellLength = entity.ShellLength,
            DesignPressure = entity.DesignPressure,
            DesignTemperatureMin = entity.DesignTemperatureMin,
            DesignTemperatureMax = entity.DesignTemperatureMax,
            CorrosionAllowance = entity.CorrosionAllowance,
            WeldJointFactor = entity.WeldJointFactor,
            AllowableStress = entity.AllowableStress,
            ShellAllowableStress = entity.ShellAllowableStress > 0 ? entity.ShellAllowableStress : entity.AllowableStress,
            HeadAllowableStress = entity.HeadAllowableStress > 0 ? entity.HeadAllowableStress : entity.AllowableStress,
            EstimatedShellThickness = entity.EstimatedShellThickness,
            EstimatedHeadThickness = entity.EstimatedHeadThickness,
            Beta = entity.Beta,
            TankOrientation = entity.TankOrientation,
            StorageTypeId = entity.StorageTypeId,
            IsManualDensity = entity.IsManualDensity,
            LiquidDensity = entity.LiquidDensity,
            StaticPressure = entity.StaticPressure,
            ShellMaterialId = entity.ShellMaterialId,
            ShellMaterialFormId = entity.ShellMaterialFormId,
            HeadMaterialId = entity.HeadMaterialId,
            HeadMaterialFormId = entity.HeadMaterialFormId,
            ShellThickness = entity.ShellThickness,
            HeadThickness = entity.HeadThickness,
            RoundedShellThickness = entity.RoundedShellThickness,
            RoundedHeadThickness = entity.RoundedHeadThickness,
            TestPressure = entity.TestPressure,
            WeldLength1500 = entity.WeldLength1500,
            WeldLength2000 = entity.WeldLength2000,
            WeldLength3000 = entity.WeldLength3000,
            WeldLength4000 = entity.WeldLength4000,
            SurfaceArea = entity.SurfaceArea
        };

        private static double CalculateSurfaceArea(double diameterMm, double shellLengthMm)
        {
            var diameterM = diameterMm / 1000d;
            var shellLengthM = shellLengthMm / 1000d;
            var shellArea = Math.PI * diameterM * shellLengthM;
            var headArea = 2d * Math.PI * Math.Pow(diameterM / 2d, 2);
            return Math.Round(shellArea + headArea, 2);
        }

        private static double CalculateWeldLengthForSectorWidth(double diameter, double shellLength, double sectorWidth)
        {
            var sectorCount = shellLength / sectorWidth;
            var shellWeldLength = sectorCount * diameter * Math.PI;
            var circularWeldLength = Math.PI * diameter;
            var headPulDiameter = 1.17d * diameter;
            var headWeldLength = Math.Round((headPulDiameter / sectorWidth) * (headPulDiameter / 1.15d) * 2d, 2);
            return Math.Round(shellWeldLength + circularWeldLength + headWeldLength, 2);
        }

        private static double CalculateStaticPressureBar(double density, TankOrientation orientation, double shellLengthMm, double diameterMm)
        {
            if (density <= 0)
            {
                return 0;
            }

            var effectiveHeightMm = orientation == TankOrientation.Vertical ? shellLengthMm + diameterMm : diameterMm;
            return (density * 9.81 * (effectiveHeightMm / 1000d)) / 100000d;
        }

        private static double RoundUpToHalf(double value) => Math.Ceiling(value * 2.0) / 2.0;
        private static double GetTwoHeadsAreaApproximation(double diameter) => (Math.PI * Math.Pow(diameter, 2) / 4d) * 1.1d * 2d;
        private static string FormatRevisionCode(int revisionNo) => $"REV{revisionNo:00}";
        private static string BuildManualGroupItemKey(Guid groupId, Guid codeId, int index) => $"MG-{groupId.ToString("N")[..8]}-{codeId.ToString("N")[..8]}-{index:000}";
        private static string BuildStockDisplayName(string stockCode, string? description, string ruleName) => string.IsNullOrWhiteSpace(description) && string.IsNullOrWhiteSpace(ruleName) ? stockCode : $"{stockCode} - {(string.IsNullOrWhiteSpace(description) ? ruleName : description)}";
        private static double ResolveEffectiveUnitPrice(double stockUnitPrice, bool useManualUnitPrice, double? manualUnitPrice) => useManualUnitPrice ? NormalizeNullablePrice(manualUnitPrice) ?? 0 : stockUnitPrice;
        private static bool IsManualSource(AD2000CostAnalysisItem item) => string.Equals(item.ItemSourceType, ManualSourceType, StringComparison.OrdinalIgnoreCase) || string.Equals(item.ItemSourceType, ManualGroupSourceType, StringComparison.OrdinalIgnoreCase);
        private static double NormalizeManualQuantity(double quantity) => quantity <= 0 ? throw new InvalidOperationException("Manuel maliyet kalemi miktarı sıfırdan büyük olmalıdır.") : quantity;
        private static double? NormalizeNullablePrice(double? value) => !value.HasValue ? null : value.Value < 0 ? 0 : value.Value;
    }
}
