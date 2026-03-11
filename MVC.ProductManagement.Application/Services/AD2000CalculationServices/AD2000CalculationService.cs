using System;
using System.Threading.Tasks;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;

namespace MVC.ProductManagement.Application.Services.AD2000CalculationServices
{
    public class AD2000CalculationService : IAD2000CalculationService
    {
        public Task<AD2000ResultDTO> CalculateAsync(AD2000CalculateDTO dto)
        {
            var p = dto.DesignPressure;
            var d = dto.Diameter;
            var sigma = dto.AllowableStress;
            var z = dto.WeldJointFactor <= 0 ? 1.0 : dto.WeldJointFactor;
            var beta = dto.Beta <= 0 ? 1.0 : dto.Beta;
            var ca = Math.Max(0, dto.CorrosionAllowance);

            // AD2000 tek cidar yaklaşımı için pratik başlangıç formülleri
            var shellThickness = ((p * d) / ((2 * sigma * z) - p)) * beta + ca;
            var headThickness = ((p * d) / ((4 * sigma * z) - p)) * beta + ca;

            var roundedShell = RoundUpToHalf(shellThickness);
            var roundedHead = RoundUpToHalf(headThickness);

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
                Beta = dto.Beta,
                ShellMaterialId = dto.ShellMaterialId,
                ShellMaterialFormId = dto.ShellMaterialFormId,
                HeadMaterialId = dto.HeadMaterialId,
                HeadMaterialFormId = dto.HeadMaterialFormId,
                ShellThickness = shellThickness,
                HeadThickness = headThickness,
                RoundedShellThickness = roundedShell,
                RoundedHeadThickness = roundedHead,
                TestPressure = dto.DesignPressure * 1.3
            });
        }

        private static double RoundUpToHalf(double value) => Math.Ceiling(value * 2.0) / 2.0;
    }
}
