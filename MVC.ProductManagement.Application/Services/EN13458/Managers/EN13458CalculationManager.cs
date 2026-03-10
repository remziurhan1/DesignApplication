using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.Repositories.EN13458Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.Managers
{
    public class EN13458CalculationManager : IEN13458CalculationManager
    {
        private readonly ICryogenicsCalculationEngine _engine;
        private readonly IEN13458MaterialStrengthProvider _strengthProvider;
        private readonly IEN13458Repository _repository;

        public EN13458CalculationManager(ICryogenicsCalculationEngine engine, IEN13458MaterialStrengthProvider strengthProvider, IEN13458Repository repository)
        {
            _engine = engine;
            _strengthProvider = strengthProvider;
            _repository = repository;
        }

        public async Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO input)
        {
            input.InnerShellMaterialStrength = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.InnerShellMaterialId, input.InnerShellMaterialFormId, input.IsColdStretchApplied);
            input.InnerHeadMaterialStrength = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.InnerHeadMaterialId, input.InnerHeadMaterialFormId, input.IsColdStretchApplied);
            input.OuterShellMaterialStrength = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.OuterShellMaterialId, input.OuterShellMaterialFormId, input.IsColdStretchApplied);
            input.OuterHeadMaterialStrength = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.OuterHeadMaterialId, input.OuterHeadMaterialFormId, input.IsColdStretchApplied);
            return await _engine.CalculateAsync(input);
        }

        public async Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System")
        {
            var entity = ToEntity(result, createdBy);
            await _repository.AddAsync(entity);
            await _repository.SaveChangeAsync();
            result.Id = entity.Id;
            return result;
        }

        public async Task<EN13458ResultDTO?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, tracking: false);
            return entity == null ? null : ToDto(entity);
        }

        public async Task<List<EN13458ResultDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync(tracking: false);
            return list.Select(ToDto).ToList();
        }

        private static EN13458Calculation ToEntity(EN13458ResultDTO dto, string createdBy) => new EN13458Calculation
        {
            Id = Guid.NewGuid(), Name = dto.Name, OuterDiameter = dto.OuterDiameter, ShellLength = dto.ShellLength,
            Pressure = dto.Pressure, LiquidDensity = dto.LiquidDensity, SectorWidth = dto.SectorWidth,
            InnerShellMaterialId = dto.InnerShellMaterialId, InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
            InnerHeadMaterialId = dto.InnerHeadMaterialId, InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
            OuterShellMaterialId = dto.OuterShellMaterialId, OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
            OuterHeadMaterialId = dto.OuterHeadMaterialId, OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
            InnerShellMaterialStrength = dto.InnerShellMaterialStrength, InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
            OuterShellMaterialStrength = dto.OuterShellMaterialStrength, OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
            InnerShellThickness = dto.InnerShellThickness, InnerHeadThickness = dto.InnerHeadThickness,
            OuterShellThickness = dto.OuterShellThickness, OuterHeadThickness = dto.OuterHeadThickness,
            RoundedInnerShellThickness = dto.RoundedInnerShellThickness, RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
            RoundedOuterShellThickness = dto.RoundedOuterShellThickness, RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
            DesignPressure = dto.DesignPressure, TestPressure = dto.TestPressure, StaticPressure = dto.StaticPressure,
            TotalWeldLength = dto.TotalWeldLength, TotalFilmCost = dto.TotalFilmCost,
            InnerTankTotalLength = dto.InnerTankTotalLength, OuterTankTotalLength = dto.OuterTankTotalLength,
            CreatedBy = createdBy, CreatedDate = DateTime.UtcNow
        };

        private static EN13458ResultDTO ToDto(EN13458Calculation entity) => new EN13458ResultDTO
        {
            Id = entity.Id, Name = entity.Name, OuterDiameter = entity.OuterDiameter, ShellLength = entity.ShellLength,
            Pressure = entity.Pressure, LiquidDensity = entity.LiquidDensity, SectorWidth = entity.SectorWidth,
            IsColdStretchApplied = false, TankOrientation = MVC.ProductManagement.Domain.Enums.TankOrientation.Horizontal,
            InnerShellMaterialId = entity.InnerShellMaterialId, InnerShellMaterialFormId = entity.InnerShellMaterialFormId,
            InnerHeadMaterialId = entity.InnerHeadMaterialId, InnerHeadMaterialFormId = entity.InnerHeadMaterialFormId,
            OuterShellMaterialId = entity.OuterShellMaterialId, OuterShellMaterialFormId = entity.OuterShellMaterialFormId,
            OuterHeadMaterialId = entity.OuterHeadMaterialId, OuterHeadMaterialFormId = entity.OuterHeadMaterialFormId,
            InnerShellMaterialStrength = entity.InnerShellMaterialStrength, InnerHeadMaterialStrength = entity.InnerHeadMaterialStrength,
            OuterShellMaterialStrength = entity.OuterShellMaterialStrength, OuterHeadMaterialStrength = entity.OuterHeadMaterialStrength,
            InnerShellThickness = entity.InnerShellThickness, InnerHeadThickness = entity.InnerHeadThickness,
            OuterShellThickness = entity.OuterShellThickness, OuterHeadThickness = entity.OuterHeadThickness,
            RoundedInnerShellThickness = entity.RoundedInnerShellThickness, RoundedInnerHeadThickness = entity.RoundedInnerHeadThickness,
            RoundedOuterShellThickness = entity.RoundedOuterShellThickness, RoundedOuterHeadThickness = entity.RoundedOuterHeadThickness,
            DesignPressure = entity.DesignPressure, TestPressure = entity.TestPressure, StaticPressure = entity.StaticPressure,
            TotalWeldLength = entity.TotalWeldLength, TotalFilmCost = entity.TotalFilmCost,
            InnerTankTotalLength = entity.InnerTankTotalLength, OuterTankTotalLength = entity.OuterTankTotalLength
        };
    }
}
