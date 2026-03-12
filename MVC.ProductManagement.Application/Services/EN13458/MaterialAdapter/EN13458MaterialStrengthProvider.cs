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


        public async Task<double> ResolveElasticModulusAsync(Guid materialId)
        {
            var material = await _materialService.GetByIdAsync(materialId)
                ?? throw new InvalidOperationException($"Material not found: {materialId}");

            var group = material.Group?.ToLowerInvariant() ?? string.Empty;

            if (group.Contains("stainless") || group.Contains("paslan"))
                return 193000d;

            if (group.Contains("aluminum") || group.Contains("alümin") || group.Contains("aluminy"))
                return 70000d;

            return 210000d;
        }

        public async Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId, bool isColdStretchApplied)
        {
            var form = await _materialFormService.GetByIdAsync(materialFormId)
                ?? throw new InvalidOperationException($"Material form not found: {materialFormId}");

            var material = await _materialService.GetByIdAsync(materialId)
                ?? throw new InvalidOperationException($"Material not found: {materialId}");

            var normalYieldSourceThickness = form.ThicknessMin > 0d ? form.ThicknessMin : 10d;
            var interpolated = await _yieldStrengthService.GetByConditionsAsync(materialFormId, DefaultTemperature, normalYieldSourceThickness);
            var normalYield = interpolated?.Rp02;

            var coldStretchYield = form.ColdStretchYieldStrength ?? material.ColdStretchYieldStrength;
            var effectiveYield = isColdStretchApplied
                ? (coldStretchYield ?? normalYield)
                : normalYield;

            if (!effectiveYield.HasValue)
            {
                throw new InvalidOperationException(
                    $"Yield strength data not found for material={materialId}, form={materialFormId}.");
            }

            return effectiveYield.Value;
        }
    }
}
