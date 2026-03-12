using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.Repositories.AD2000Repositories;

namespace MVC.ProductManagement.Application.Services.AD2000CalculationServices
{
    public class AD2000CalculationService : IAD2000CalculationService
    {
        private readonly IAD2000Repository _repository;

        public AD2000CalculationService(IAD2000Repository repository)
        {
            _repository = repository;
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

            var roundedShell = RoundUpToHalf(shellThickness);
            var roundedHead = RoundUpToHalf(headThickness);
            var weldLength1500 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 1500d);
            var weldLength2000 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 2000d);
            var weldLength3000 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 3000d);
            var weldLength4000 = CalculateWeldLengthForSectorWidth(d, dto.ShellLength, 4000d);
            var surfaceArea = CalculateSurfaceArea(d, dto.ShellLength);

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
                RoundedShellThickness = roundedShell,
                RoundedHeadThickness = roundedHead,
                TestPressure = effectivePressure * 1.3,
                WeldLength1500 = weldLength1500,
                WeldLength2000 = weldLength2000,
                WeldLength3000 = weldLength3000,
                WeldLength4000 = weldLength4000,
                SurfaceArea = surfaceArea
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

            var effectiveHeightMm = orientation == TankOrientation.Vertical
                ? shellLengthMm + diameterMm
                : diameterMm;

            const double gravity = 9.81;
            return (density * gravity * (effectiveHeightMm / 1000d)) / 100000d;
        }

        private static double RoundUpToHalf(double value) => Math.Ceiling(value * 2.0) / 2.0;
    }
}
