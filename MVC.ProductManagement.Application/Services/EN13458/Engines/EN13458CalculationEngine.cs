using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.Engines
{
    public class EN13458CalculationEngine : ICryogenicsCalculationEngine
    {
        private readonly IEnumerable<IEN13458CalculationStep> _steps;

        public EN13458CalculationEngine(IEnumerable<IEN13458CalculationStep> steps)
        {
            _steps = steps;
        }

        public Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO input)
        {
            var result = new EN13458ResultDTO
            {
                Name = input.Name,
                OuterDiameter = input.OuterDiameter,
                ShellLength = input.ShellLength,
                Pressure = input.Pressure,
                LiquidDensity = input.LiquidDensity,
                SectorWidth = input.SectorWidth,
                TankOrientation = input.TankOrientation,
                IsColdStretchApplied = input.IsColdStretchApplied,
                InnerShellMaterialId = input.InnerShellMaterialId,
                InnerShellMaterialFormId = input.InnerShellMaterialFormId,
                InnerHeadMaterialId = input.InnerHeadMaterialId,
                InnerHeadMaterialFormId = input.InnerHeadMaterialFormId,
                OuterShellMaterialId = input.OuterShellMaterialId,
                OuterShellMaterialFormId = input.OuterShellMaterialFormId,
                OuterHeadMaterialId = input.OuterHeadMaterialId,
                OuterHeadMaterialFormId = input.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = input.InnerShellMaterialStrength ?? 0d,
                InnerHeadMaterialStrength = input.InnerHeadMaterialStrength ?? 0d,
                OuterShellMaterialStrength = input.OuterShellMaterialStrength ?? 0d,
                OuterHeadMaterialStrength = input.OuterHeadMaterialStrength ?? 0d
            };

            var context = new EN13458DesignContext { Input = input, Result = result };
            foreach (var step in _steps)
            {
                step.Execute(context);
            }

            return Task.FromResult(result);
        }
    }
}
