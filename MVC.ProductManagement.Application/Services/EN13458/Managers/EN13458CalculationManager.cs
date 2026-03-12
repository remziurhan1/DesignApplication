using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Application.Services.EN13458.CalculationSteps;
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

            input.YieldFactorK = input.OuterShellMaterialStrength ?? input.YieldFactorK;
            input.ElasticModulus = await _strengthProvider.ResolveElasticModulusAsync(input.OuterShellMaterialId);

            var result = await _engine.CalculateAsync(input);
            ApplySectorOrientationOutputs(result, input);
            return result;
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
            Id = Guid.NewGuid(), Name = dto.Name, OuterDiameter = dto.OuterDiameter, OuterTankDiameter = dto.OuterTankDiameter, ShellLength = dto.ShellLength,
            Pressure = dto.Pressure, ProductTypeId = dto.StorageTypeId, LiquidDensity = dto.LiquidDensity,
            CorrosionAllowance = dto.CorrosionAllowance, BucklingLength = dto.BucklingLength, ElasticModulus = dto.ElasticModulus,
            PoissonRatio = dto.PoissonRatio, RoundnessErrorPercent = dto.RoundnessErrorPercent, YieldFactorK = dto.YieldFactorK,
            UseGeneralElasticFormula = dto.UseGeneralElasticFormula, HasStiffener = dto.HasStiffener,
            UseManualStiffenerValues = dto.UseManualStiffenerValues,
            StiffenerMaterialId = dto.StiffenerMaterialId,
            StiffenerMaterialFormId = dto.StiffenerMaterialFormId,
            StiffenerInertia = dto.StiffenerInertia, StiffenerArea = dto.StiffenerArea,
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
            EffectiveOuterThickness = dto.EffectiveOuterThickness, DOverT = dto.DOverT, LOverD = dto.LOverD, DaOverLb = dto.DaOverLb,
            ElasticBucklingPressure = dto.ElasticBucklingPressure, PlasticDeformationPressure = dto.PlasticDeformationPressure,
            AllowableExternalPressure = dto.AllowableExternalPressure, ExternalDesignPressure = dto.ExternalDesignPressure,
            ExternalPressureDesignOk = dto.ExternalPressureDesignOk, RequiredStiffenerInertia = dto.RequiredStiffenerInertia,
            FixedOutOfRoundnessPercent = dto.FixedOutOfRoundnessPercent, FixedPoissonRatio = dto.FixedPoissonRatio, FixedWeldCoefficient = dto.FixedWeldCoefficient,
            RequiredStiffenerArea = dto.RequiredStiffenerArea, StiffenerInertiaOk = dto.StiffenerInertiaOk, StiffenerAreaOk = dto.StiffenerAreaOk,
            InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
            OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
            InnerTankHeadWeight = dto.InnerTankHeadWeight,
            OuterTankHeadWeight = dto.OuterTankHeadWeight,
            InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
            InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
            OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
            OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
            TotalWeldLength = dto.TotalWeldLength, TotalFilmCost = dto.TotalFilmCost,
            InnerTankTotalLength = dto.InnerTankTotalLength, OuterTankTotalLength = dto.OuterTankTotalLength,
            PerliteVolume = dto.PerliteVolume, PerliteWeight = dto.PerliteWeight,
            InnerVolume = dto.InnerVolume, OuterVolume = dto.OuterVolume,
            InnerSurfaceArea = dto.InnerSurfaceArea, OuterSurfaceArea = dto.OuterSurfaceArea,
            InnerTankWeight = dto.InnerTankWeight, OuterTankWeight = dto.OuterTankWeight,
            WeldLength1500 = dto.WeldLength1500,
            WeldLength2000 = dto.WeldLength2000,
            WeldLength2500 = dto.WeldLength2500,
            WeldLength3000 = dto.WeldLength3000,
            GasNitrogenVolume = dto.GasNitrogenVolume, LiquidNitrogenVolume = dto.LiquidNitrogenVolume,

            InnerDevelopedLength = dto.InnerDevelopedLength,
            OuterDevelopedLength = dto.OuterDevelopedLength,
            InnerSectorPlan1500 = dto.InnerSectorPlan1500,
            InnerSectorPlan2000 = dto.InnerSectorPlan2000,
            InnerSectorPlan2500 = dto.InnerSectorPlan2500,
            InnerSectorPlan3000 = dto.InnerSectorPlan3000,
            OuterSectorPlan1500 = dto.OuterSectorPlan1500,
            OuterSectorPlan2000 = dto.OuterSectorPlan2000,
            OuterSectorPlan2500 = dto.OuterSectorPlan2500,
            OuterSectorPlan3000 = dto.OuterSectorPlan3000,

            CreatedBy = createdBy, CreatedDate = DateTime.UtcNow
        };

        private static EN13458ResultDTO ToDto(EN13458Calculation entity) => new EN13458ResultDTO
        {
            Id = entity.Id, Name = entity.Name, OuterDiameter = entity.OuterDiameter, OuterTankDiameter = entity.OuterTankDiameter, ShellLength = entity.ShellLength,
            Pressure = entity.Pressure, StorageTypeId = entity.ProductTypeId, LiquidDensity = entity.LiquidDensity,
            CorrosionAllowance = entity.CorrosionAllowance, BucklingLength = entity.BucklingLength, ElasticModulus = entity.ElasticModulus,
            PoissonRatio = entity.PoissonRatio, RoundnessErrorPercent = entity.RoundnessErrorPercent, YieldFactorK = entity.YieldFactorK,
            UseGeneralElasticFormula = entity.UseGeneralElasticFormula, HasStiffener = entity.HasStiffener,
            UseManualStiffenerValues = entity.UseManualStiffenerValues,
            StiffenerMaterialId = entity.StiffenerMaterialId,
            StiffenerMaterialFormId = entity.StiffenerMaterialFormId,
            StiffenerInertia = entity.StiffenerInertia, StiffenerArea = entity.StiffenerArea,
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
            EffectiveOuterThickness = entity.EffectiveOuterThickness, DOverT = entity.DOverT, LOverD = entity.LOverD, DaOverLb = entity.DaOverLb,
            ElasticBucklingPressure = entity.ElasticBucklingPressure, PlasticDeformationPressure = entity.PlasticDeformationPressure,
            AllowableExternalPressure = entity.AllowableExternalPressure, ExternalDesignPressure = entity.ExternalDesignPressure,
            ExternalPressureDesignOk = entity.ExternalPressureDesignOk, RequiredStiffenerInertia = entity.RequiredStiffenerInertia,
            FixedOutOfRoundnessPercent = entity.FixedOutOfRoundnessPercent, FixedPoissonRatio = entity.FixedPoissonRatio, FixedWeldCoefficient = entity.FixedWeldCoefficient,
            RequiredStiffenerArea = entity.RequiredStiffenerArea, StiffenerInertiaOk = entity.StiffenerInertiaOk, StiffenerAreaOk = entity.StiffenerAreaOk,
            InnerTankHeadPulDiameter = entity.InnerTankHeadPulDiameter,
            OuterTankHeadPulDiameter = entity.OuterTankHeadPulDiameter,
            InnerTankHeadWeight = entity.InnerTankHeadWeight,
            OuterTankHeadWeight = entity.OuterTankHeadWeight,
            InnerTankHeadWeldLength = entity.InnerTankHeadWeldLength,
            InnerTankCircumferenceWeldLength = entity.InnerTankCircumferenceWeldLength,
            OuterTankHeadWeldLength = entity.OuterTankHeadWeldLength,
            OuterTankCircumferenceWeldLength = entity.OuterTankCircumferenceWeldLength,
            TotalWeldLength = entity.TotalWeldLength, TotalFilmCost = entity.TotalFilmCost,
            InnerTankTotalLength = entity.InnerTankTotalLength, OuterTankTotalLength = entity.OuterTankTotalLength,
            PerliteVolume = entity.PerliteVolume, PerliteWeight = entity.PerliteWeight,
            InnerVolume = entity.InnerVolume, OuterVolume = entity.OuterVolume,
            InnerSurfaceArea = entity.InnerSurfaceArea, OuterSurfaceArea = entity.OuterSurfaceArea,
            InnerTankWeight = entity.InnerTankWeight, OuterTankWeight = entity.OuterTankWeight,
            WeldLength1500 = entity.WeldLength1500,
            WeldLength2000 = entity.WeldLength2000,
            WeldLength2500 = entity.WeldLength2500,
            WeldLength3000 = entity.WeldLength3000,
            GasNitrogenVolume = entity.GasNitrogenVolume, LiquidNitrogenVolume = entity.LiquidNitrogenVolume,

            InnerDevelopedLength = entity.InnerDevelopedLength,
            OuterDevelopedLength = entity.OuterDevelopedLength,
            InnerSectorPlan1500 = entity.InnerSectorPlan1500,
            InnerSectorPlan2000 = entity.InnerSectorPlan2000,
            InnerSectorPlan2500 = entity.InnerSectorPlan2500,
            InnerSectorPlan3000 = entity.InnerSectorPlan3000,
            OuterSectorPlan1500 = entity.OuterSectorPlan1500,
            OuterSectorPlan2000 = entity.OuterSectorPlan2000,
            OuterSectorPlan2500 = entity.OuterSectorPlan2500,
            OuterSectorPlan3000 = entity.OuterSectorPlan3000
        };

        private static void ApplySectorOrientationOutputs(EN13458ResultDTO result, EN13458CalculateDTO input)
        {
            var innerDiameter = input.OuterDiameter;
            var outerDiameter = result.OuterTankDiameter;
            var innerShellLength = input.ShellLength;
            var outerShellLength = EN13458OuterTankRules.GetOuterShellLength(input.OuterDiameter, input.ShellLength);

            result.InnerDevelopedLength = Math.Round(Math.PI * innerDiameter, 2);
            result.OuterDevelopedLength = Math.Round(Math.PI * outerDiameter, 2);

            result.InnerSectorPlan1500 = BuildSectorCutList(innerShellLength, 1500d, result.RoundedInnerShellThickness, result.InnerDevelopedLength);
            result.InnerSectorPlan2000 = BuildSectorCutList(innerShellLength, 2000d, result.RoundedInnerShellThickness, result.InnerDevelopedLength);
            result.InnerSectorPlan2500 = BuildSectorCutList(innerShellLength, 2500d, result.RoundedInnerShellThickness, result.InnerDevelopedLength);
            result.InnerSectorPlan3000 = BuildSectorCutList(innerShellLength, 3000d, result.RoundedInnerShellThickness, result.InnerDevelopedLength);

            result.OuterSectorPlan1500 = BuildSectorCutList(outerShellLength, 1500d, result.RoundedOuterShellThickness, result.OuterDevelopedLength);
            result.OuterSectorPlan2000 = BuildSectorCutList(outerShellLength, 2000d, result.RoundedOuterShellThickness, result.OuterDevelopedLength);
            result.OuterSectorPlan2500 = BuildSectorCutList(outerShellLength, 2500d, result.RoundedOuterShellThickness, result.OuterDevelopedLength);
            result.OuterSectorPlan3000 = BuildSectorCutList(outerShellLength, 3000d, result.RoundedOuterShellThickness, result.OuterDevelopedLength);
        }

        private static string BuildSectorCutList(double shellLength, double sectorWidth, double thickness, double developedLength)
        {
            if (shellLength <= 0 || sectorWidth <= 0)
            {
                return string.Empty;
            }

            var pieceCount = (int)Math.Ceiling(shellLength / sectorWidth);
            var items = new List<string>(pieceCount);

            for (var i = 0; i < pieceCount; i++)
            {
                var remaining = shellLength - (i * sectorWidth);
                var width = Math.Round(Math.Min(sectorWidth, Math.Max(0, remaining)), 2);
                items.Add($"{thickness:0.##} x {width:0.##} x {developedLength:0.##}");
            }

            return string.Join(" + ", items);
        }
    }
}
