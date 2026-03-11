using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using MVC.ProductManagement.Domain.Entities;
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
            var p = dto.DesignPressure;
            var d = dto.Diameter;
            var sigma = dto.AllowableStress;
            var z = dto.WeldJointFactor <= 0 ? 1.0 : dto.WeldJointFactor;
            var beta = dto.Beta <= 0 ? 1.0 : dto.Beta;
            var ca = Math.Max(0, dto.CorrosionAllowance);

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
            Beta = dto.Beta,
            ShellMaterialId = dto.ShellMaterialId,
            ShellMaterialFormId = dto.ShellMaterialFormId,
            HeadMaterialId = dto.HeadMaterialId,
            HeadMaterialFormId = dto.HeadMaterialFormId,
            ShellThickness = dto.ShellThickness,
            HeadThickness = dto.HeadThickness,
            RoundedShellThickness = dto.RoundedShellThickness,
            RoundedHeadThickness = dto.RoundedHeadThickness,
            TestPressure = dto.TestPressure,
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
            Beta = entity.Beta,
            ShellMaterialId = entity.ShellMaterialId,
            ShellMaterialFormId = entity.ShellMaterialFormId,
            HeadMaterialId = entity.HeadMaterialId,
            HeadMaterialFormId = entity.HeadMaterialFormId,
            ShellThickness = entity.ShellThickness,
            HeadThickness = entity.HeadThickness,
            RoundedShellThickness = entity.RoundedShellThickness,
            RoundedHeadThickness = entity.RoundedHeadThickness,
            TestPressure = entity.TestPressure
        };

        private static double RoundUpToHalf(double value) => Math.Ceiling(value * 2.0) / 2.0;
    }
}
