using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Domain.Entities;
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

        public async Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System")
        {
            var saved = await _calculationManager.SaveAsync(result, createdBy);
            var costTable = await BuildMaterialCostTableAsync(saved);

            var details = costTable.Items.Select(item => new EN13458CostDetail
            {
                EN13458CalculationId = saved.Id,
                CostGroupCode = item.CostGroupCode,
                CostGroupName = item.CostGroupName,
                ItemName = item.ItemName,
                StockCode = item.StockCode,
                MaterialId = item.MaterialId,
                MaterialName = item.MaterialName,
                MaterialFormId = item.MaterialFormId,
                FormType = item.FormType,
                Quantity = item.Quantity,
                Unit = item.Unit,
                CalculatedThickness = item.CalculatedThickness,
                UsedThickness = item.UsedThickness,
                Density = item.Density,
                UnitPrice = item.UnitPrice,
                TheoreticalWeight = item.TheoreticalWeight,
                ItemCost = item.ItemCost,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow
            }).ToList();

            _context.EN13458CostDetails.AddRange(details);
            await _context.SaveChangesAsync();

            return saved;
        }

        public Task<EN13458ResultDTO?> GetByIdAsync(Guid id)
            => _calculationManager.GetByIdAsync(id);

        public Task<List<EN13458ResultDTO>> GetAllAsync()
            => _calculationManager.GetAllAsync();

        public async Task<EN13458MaterialCostTableDTO?> GetSavedMaterialCostTableAsync(Guid calculationId)
        {
            var items = await _context.EN13458CostDetails
                .AsNoTracking()
                .Where(x => x.EN13458CalculationId == calculationId)
                .OrderBy(x => x.CostGroupCode)
                .ThenBy(x => x.ItemName)
                .Select(x => new EN13458MaterialCostRowDTO
                {
                    CostGroupCode = x.CostGroupCode,
                    CostGroupName = x.CostGroupName,
                    ItemName = x.ItemName,
                    StockCode = x.StockCode,
                    MaterialId = x.MaterialId,
                    MaterialName = x.MaterialName,
                    MaterialFormId = x.MaterialFormId,
                    FormType = x.FormType,
                    Quantity = x.Quantity,
                    Unit = x.Unit,
                    CalculatedThickness = x.CalculatedThickness,
                    UsedThickness = x.UsedThickness,
                    Density = x.Density,
                    UnitPrice = x.UnitPrice,
                    TheoreticalWeight = x.TheoreticalWeight,
                    ItemCost = x.ItemCost
                })
                .ToListAsync();

            if (items.Count == 0)
            {
                return null;
            }

            var table = new EN13458MaterialCostTableDTO
            {
                Items = items,
                TotalMaterialCost = items.Sum(x => x.ItemCost),
                GrandTotalCost = items.Sum(x => x.ItemCost)
            };

            table.TotalFilmCost = items
                .Where(x => x.CostGroupCode == "FILM")
                .Sum(x => x.ItemCost);

            table.GroupTotals = items
                .GroupBy(x => new { x.CostGroupCode, x.CostGroupName })
                .Select(g => new EN13458CostGroupSummaryDTO
                {
                    CostGroupCode = g.Key.CostGroupCode,
                    CostGroupName = g.Key.CostGroupName,
                    TotalCost = g.Sum(i => i.ItemCost)
                })
                .OrderBy(x => x.CostGroupCode)
                .ToList();

            return table;
        }

        public async Task<EN13458MaterialCostTableDTO> BuildMaterialCostTableAsync(EN13458ResultDTO result)
        {
            var table = new EN13458MaterialCostTableDTO();

            table.Items.Add(await BuildRowAsync("SAC", "Sac Maliyeti", "İç Gövde", result.InnerShellMaterialId, result.InnerShellMaterialFormId, result.InnerShellThickness, result.RoundedInnerShellThickness, result.OuterDiameter, result.ShellLength, isHead: false));
            table.Items.Add(await BuildRowAsync("SAC", "Sac Maliyeti", "İç Bombe", result.InnerHeadMaterialId, result.InnerHeadMaterialFormId, result.InnerHeadThickness, result.RoundedInnerHeadThickness, result.OuterDiameter, result.ShellLength, isHead: true));
            table.Items.Add(await BuildRowAsync("SAC", "Sac Maliyeti", "Dış Gövde", result.OuterShellMaterialId, result.OuterShellMaterialFormId, result.OuterShellThickness, result.RoundedOuterShellThickness, result.OuterTankDiameter, result.OuterTankTotalLength, isHead: false));
            table.Items.Add(await BuildRowAsync("SAC", "Sac Maliyeti", "Dış Bombe", result.OuterHeadMaterialId, result.OuterHeadMaterialFormId, result.OuterHeadThickness, result.RoundedOuterHeadThickness, result.OuterTankDiameter, result.OuterTankTotalLength, isHead: true));

            if (result.GasNitrogenVolume > 0)
            {
                table.Items.Add(await BuildServiceRowAsync("SARF", "Sarf Malzemeleri", "Gaz Azot", GasNitrogenStockCode, result.GasNitrogenVolume, "Nm³"));
            }

            if (result.LiquidNitrogenVolume > 0)
            {
                table.Items.Add(await BuildServiceRowAsync("SARF", "Sarf Malzemeleri", "Sıvı Azot", LiquidNitrogenStockCode, result.LiquidNitrogenVolume, "kg"));
            }

            if (result.PerliteWeight > 0)
            {
                table.Items.Add(await BuildServiceRowAsync("SARF", "Sarf Malzemeleri", "Perlit", PerliteStockCode, result.PerliteWeight, "kg"));
            }

            if (result.TotalFilmCost > 0)
            {
                table.Items.Add(new EN13458MaterialCostRowDTO
                {
                    CostGroupCode = "FILM",
                    CostGroupName = "Film ve İzolasyon",
                    ItemName = "Film Maliyeti",
                    StockCode = "",
                    MaterialName = "Film/İzolasyon",
                    FormType = "Hizmet",
                    Quantity = 1,
                    Unit = "lot",
                    ItemCost = result.TotalFilmCost
                });
            }

            var profileRow = await BuildProfileCostRowAsync(result);
            if (profileRow is not null)
            {
                table.Items.Add(profileRow);
            }

            var profileWeldRow = await BuildProfileWeldCostRowAsync(result);
            if (profileWeldRow is not null)
            {
                table.Items.Add(profileWeldRow);
            }

            var groupRows = await BuildGroupCostRowsAsync(result.SelectedStockCardGroupIds);
            table.Items.AddRange(groupRows);

            table.TotalMaterialCost = table.Items.Sum(x => x.ItemCost);
            table.TotalFilmCost = result.TotalFilmCost;
            table.GrandTotalCost = table.TotalMaterialCost;

            table.GroupTotals = table.Items
                .GroupBy(x => new { x.CostGroupCode, x.CostGroupName })
                .Select(g => new EN13458CostGroupSummaryDTO
                {
                    CostGroupCode = g.Key.CostGroupCode,
                    CostGroupName = g.Key.CostGroupName,
                    TotalCost = g.Sum(i => i.ItemCost)
                })
                .OrderBy(x => x.CostGroupCode)
                .ToList();

            return table;
        }

        private async Task<EN13458MaterialCostRowDTO> BuildRowAsync(
            string costGroupCode,
            string costGroupName,
            string itemName,
            Guid materialId,
            Guid materialFormId,
            double calculatedThickness,
            double usedThickness,
            double diameter,
            double shellLength,
            bool isHead)
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
            var itemCost = weightKg * form.UnitPrice;

            return new EN13458MaterialCostRowDTO
            {
                CostGroupCode = costGroupCode,
                CostGroupName = costGroupName,
                ItemName = itemName,
                StockCode = string.Empty,
                MaterialId = material.Id,
                MaterialName = material.Name,
                MaterialFormId = form.Id,
                FormType = form.FormType.ToString(),
                Quantity = weightKg,
                Unit = "kg",
                CalculatedThickness = calculatedThickness,
                UsedThickness = usedThickness,
                Density = material.Density,
                UnitPrice = form.UnitPrice,
                TheoreticalWeight = weightKg,
                ItemCost = itemCost
            };
        }

        private async Task<EN13458MaterialCostRowDTO> BuildServiceRowAsync(string costGroupCode, string costGroupName, string itemName, string stockCode, double quantity, string unit)
        {
            var unitPrice = await ResolveActiveUnitPriceByStockCodeAsync(stockCode);
            var itemCost = quantity * unitPrice;

            return new EN13458MaterialCostRowDTO
            {
                CostGroupCode = costGroupCode,
                CostGroupName = costGroupName,
                ItemName = itemName,
                StockCode = stockCode,
                MaterialName = itemName,
                FormType = "Sarf",
                Quantity = quantity,
                Unit = unit,
                UnitPrice = unitPrice,
                ItemCost = itemCost
            };
        }

        private async Task<EN13458MaterialCostRowDTO?> BuildProfileCostRowAsync(EN13458ResultDTO result)
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

            const double defaultProfileAreaMm2 = 444d; // 40x40x3 profil
            var totalLengthMm = result.TotalProfileLength > 0 ? result.TotalProfileLength : (result.RequiredProfileCount * result.ProfileDevelopedLength);
            var totalLengthM = totalLengthMm / 1000d;
            var volumeMm3 = defaultProfileAreaMm2 * totalLengthMm;
            var weightKg = volumeMm3 * 1e-9 * material.Density;
            var itemCost = weightKg * form.UnitPrice;

            return new EN13458MaterialCostRowDTO
            {
                CostGroupCode = "PROF",
                CostGroupName = "Profil Maliyeti",
                ItemName = "Dış Tank Stifner Profili (40x40x3)",
                StockCode = string.Empty,
                MaterialId = material.Id,
                MaterialName = material.Name,
                MaterialFormId = form.Id,
                FormType = form.FormType.ToString(),
                Quantity = Math.Round(totalLengthM, 2),
                Unit = "m",
                UnitPrice = form.UnitPrice,
                Density = material.Density,
                TheoreticalWeight = Math.Round(weightKg, 2),
                ItemCost = itemCost
            };
        }

        private async Task<EN13458MaterialCostRowDTO?> BuildProfileWeldCostRowAsync(EN13458ResultDTO result)
        {
            if (result.ProfileWeldLength <= 0)
            {
                return null;
            }

            var quantityMeters = result.ProfileWeldLength / 1000d;
            var unitPrice = await ResolveActiveUnitPriceByStockCodeAsync(ProfileWeldStockCode);
            var itemCost = quantityMeters * unitPrice;

            return new EN13458MaterialCostRowDTO
            {
                CostGroupCode = "WELD",
                CostGroupName = "Kaynak Maliyeti",
                ItemName = "Profil Kaynak Metrajı",
                StockCode = ProfileWeldStockCode,
                MaterialName = "Profil Kaynağı",
                FormType = "Hizmet",
                Quantity = Math.Round(quantityMeters, 2),
                Unit = "m",
                UnitPrice = unitPrice,
                ItemCost = itemCost
            };
        }

        private async Task<List<EN13458MaterialCostRowDTO>> BuildGroupCostRowsAsync(IEnumerable<Guid>? selectedGroupIds)
        {
            var groupIds = selectedGroupIds?
                .Where(x => x != Guid.Empty)
                .Distinct()
                .ToList() ?? new List<Guid>();

            if (groupIds.Count == 0)
            {
                return new List<EN13458MaterialCostRowDTO>();
            }

            var groups = await _context.StockCardGroups
                .AsNoTracking()
                .Where(g => groupIds.Contains(g.Id) && g.Status != Status.Deleted)
                .OrderBy(g => g.GroupCode)
                .Select(g => new
                {
                    g.GroupCode,
                    g.Name,
                    g.TotalAmount
                })
                .ToListAsync();

            return groups.Select(group => new EN13458MaterialCostRowDTO
            {
                CostGroupCode = group.GroupCode,
                CostGroupName = group.Name,
                ItemName = $"{group.GroupCode} Grup Maliyeti",
                MaterialName = "Grup Toplamı",
                FormType = "Grup",
                Quantity = 1,
                Unit = "lot",
                UnitPrice = (double)group.TotalAmount,
                ItemCost = (double)group.TotalAmount
            }).ToList();
        }

        private async Task<double> ResolveActiveUnitPriceByStockCodeAsync(string stockCode)
        {
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

        private static double GetSingleHeadAreaApproximation(double diameter)
        {
            var circleArea = Math.PI * Math.Pow(diameter, 2) / 4d;
            return circleArea * 1.1d;
        }
    }
}
