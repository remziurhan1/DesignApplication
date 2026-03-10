using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using System;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.MaterialAdapter
{
    public class EN13458MaterialStrengthProvider : IEN13458MaterialStrengthProvider
    {
        private const double DefaultTemperature = 20d;
        private const double DefaultThickness = 10d;

        private readonly IMaterialService _materialService;
        private readonly IMaterialFormService _materialFormService;
        private readonly IYieldStrengthService _yieldStrengthService;

        public EN13458MaterialStrengthProvider(
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IYieldStrengthService yieldStrengthService)
        {
            _materialService = materialService;
            _materialFormService = materialFormService;
            _yieldStrengthService = yieldStrengthService;
        }

        public async Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId, bool isColdStretchApplied)
        {
            var form = await _materialFormService.GetByIdAsync(materialFormId)
                ?? throw new InvalidOperationException($"Material form not found: {materialFormId}");

            var material = await _materialService.GetByIdAsync(materialId)
                ?? throw new InvalidOperationException($"Material not found: {materialId}");

            var interpolated = await _yieldStrengthService.GetByConditionsAsync(materialFormId, DefaultTemperature, DefaultThickness);

            var effectiveYield = isColdStretchApplied
                ? (form.ColdStretchYieldStrength ?? material.ColdStretchYieldStrength ?? interpolated?.Rp02)
                : interpolated?.Rp02;

            if (!effectiveYield.HasValue)
            {
                throw new InvalidOperationException(
                    $"Yield strength data not found for material={materialId}, form={materialFormId}.");
            }

            return effectiveYield.Value;
        }
    }
}
