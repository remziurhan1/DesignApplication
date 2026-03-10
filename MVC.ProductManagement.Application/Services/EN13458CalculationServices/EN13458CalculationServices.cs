using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices
{
    public class EN13458CalculationServices : IEN13458CalculationServices
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialFormRepository _materialFormRepository;
        private readonly IEN13458CalculationManager _calculationManager;

        public EN13458CalculationServices(
            IMaterialRepository materialRepository,
            IMaterialFormRepository materialFormRepository,
            IEN13458CalculationManager calculationManager)
        {
            _materialRepository = materialRepository;
            _materialFormRepository = materialFormRepository;
            _calculationManager = calculationManager;
        }


        public Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO dto)
            => _calculationManager.CalculateAsync(dto);

        public Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System")
            => _calculationManager.SaveAsync(result, createdBy);

        public Task<EN13458ResultDTO?> GetByIdAsync(Guid id)
            => _calculationManager.GetByIdAsync(id);

        public Task<List<EN13458ResultDTO>> GetAllAsync()
            => _calculationManager.GetAllAsync();

        public async Task<EN13458MaterialCostTableDTO> BuildMaterialCostTableAsync(EN13458ResultDTO result)
        {
            var table = new EN13458MaterialCostTableDTO
            {
                TotalFilmCost = result.TotalFilmCost
            };

            table.Items.Add(await BuildRowAsync("İç Gövde", result.InnerShellMaterialId, result.InnerShellMaterialFormId, result.InnerShellThickness, result.RoundedInnerShellThickness, result.OuterDiameter, result.ShellLength, isHead: false));
            table.Items.Add(await BuildRowAsync("İç Bombe", result.InnerHeadMaterialId, result.InnerHeadMaterialFormId, result.InnerHeadThickness, result.RoundedInnerHeadThickness, result.OuterDiameter, result.ShellLength, isHead: true));
            table.Items.Add(await BuildRowAsync("Dış Gövde", result.OuterShellMaterialId, result.OuterShellMaterialFormId, result.OuterShellThickness, result.RoundedOuterShellThickness, result.OuterDiameter, result.ShellLength, isHead: false));
            table.Items.Add(await BuildRowAsync("Dış Bombe", result.OuterHeadMaterialId, result.OuterHeadMaterialFormId, result.OuterHeadThickness, result.RoundedOuterHeadThickness, result.OuterDiameter, result.ShellLength, isHead: true));

            table.TotalMaterialCost = 0;
            foreach (var item in table.Items)
            {
                table.TotalMaterialCost += item.ItemCost;
            }

            table.GrandTotalCost = table.TotalMaterialCost + table.TotalFilmCost;
            return table;
        }

        private async Task<EN13458MaterialCostRowDTO> BuildRowAsync(
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
                ItemName = itemName,
                MaterialId = material.Id,
                MaterialName = material.Name,
                MaterialFormId = form.Id,
                FormType = form.FormType.ToString(),
                CalculatedThickness = calculatedThickness,
                UsedThickness = usedThickness,
                Density = material.Density,
                UnitPrice = form.UnitPrice,
                TheoreticalWeight = weightKg,
                ItemCost = itemCost
            };
        }

        private static double GetSingleHeadAreaApproximation(double diameter)
        {
            var circleArea = Math.PI * Math.Pow(diameter, 2) / 4d;
            return circleArea * 1.1d;
        }
    }
}
