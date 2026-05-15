using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Domain.Enums;
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

        public async Task<double> ResolveDensityAsync(Guid materialId)
        {
            var material = await _materialService.GetByIdAsync(materialId)
                ?? throw new InvalidOperationException($"Material not found: {materialId}");

            if (material.Density <= 0d)
                throw new InvalidOperationException($"Material density is not defined: {materialId}");

            return material.Density;
        }

        public async Task<double> ResolveElasticModulusAsync(Guid materialFormId)
        {
            var form = await _materialFormService.GetByIdAsync(materialFormId)
                ?? throw new InvalidOperationException($"Material form not found: {materialFormId}");

            if (form.ElasticModulus.HasValue && form.ElasticModulus.Value > 0d)
                return form.ElasticModulus.Value;

            return 210000d;
        }

        public async Task<double> ResolveYieldFactorKAsync(Guid materialFormId)
        {
            var form = await _materialFormService.GetByIdAsync(materialFormId)
                ?? throw new InvalidOperationException($"Material form not found: {materialFormId}");

            if (form.YieldFactorK.HasValue && form.YieldFactorK.Value > 0d)
                return form.YieldFactorK.Value;

            if (form.ColdStretchYieldStrength.HasValue && form.ColdStretchYieldStrength.Value > 0d)
                return form.ColdStretchYieldStrength.Value;

            return 235d;
        }

        public Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId, bool isColdStretchApplied)
            => ResolveEffectiveYieldStrengthAsync(materialId, materialFormId, isColdStretchApplied, DefaultTemperature, 0d);

        public async Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId, bool isColdStretchApplied, double temperature, double thickness)
        {
            var form = await _materialFormService.GetByIdAsync(materialFormId)
                ?? throw new InvalidOperationException($"Material form not found: {materialFormId}");

            var material = await _materialService.GetByIdAsync(materialId)
                ?? throw new InvalidOperationException($"Material not found: {materialId}");

            var normalizedThickness = thickness > 0d
                ? thickness
                : form.ThicknessMin > 0d ? form.ThicknessMin : 10d;
            var normalizedTemperature = double.IsNaN(temperature) ? DefaultTemperature : temperature;

            var interpolated = await _yieldStrengthService.GetByConditionsAsync(materialFormId, normalizedTemperature, normalizedThickness);
            var normalYield = interpolated?.Rp02;

            var coldStretchAllowed = form.MaterialFamily == MaterialFamily.StainlessSteel
                && form.FormType == MaterialFormType.Plate;
            var coldStretchYield = coldStretchAllowed
                ? form.ColdStretchYieldStrength
                : null;
            var effectiveYield = isColdStretchApplied
                ? (coldStretchYield ?? normalYield)
                : normalYield;

            if (!effectiveYield.HasValue)
            {
                throw new InvalidOperationException(
                    $"Yield strength data not found for material={materialId}, form={materialFormId}, temperature={normalizedTemperature}, thickness={normalizedThickness}.");
            }

            return effectiveYield.Value;
        }
    }
}
