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
            input.DesignTemperature = input.DesignTemperature == 0d ? 20d : input.DesignTemperature;
            input.InnerShellMaterialDensity = await _strengthProvider.ResolveDensityAsync(input.InnerShellMaterialId);
            input.InnerHeadMaterialDensity = await _strengthProvider.ResolveDensityAsync(input.InnerHeadMaterialId);
            input.OuterShellMaterialDensity = await _strengthProvider.ResolveDensityAsync(input.OuterShellMaterialId);
            input.OuterHeadMaterialDensity = await _strengthProvider.ResolveDensityAsync(input.OuterHeadMaterialId);

            await ResolveMaterialStrengthsAsync(input, null);

            input.YieldFactorK = await _strengthProvider.ResolveYieldFactorKAsync(input.OuterShellMaterialFormId);
            input.ElasticModulus = await _strengthProvider.ResolveElasticModulusAsync(input.OuterShellMaterialFormId);

            var result = await _engine.CalculateAsync(input);
            var refined = await ResolveMaterialStrengthsAsync(input, result);
            if (refined)
            {
                result = await _engine.CalculateAsync(input);
            }

            ApplySectorOrientationOutputs(result, input);
            return result;
        }

        private async Task<bool> ResolveMaterialStrengthsAsync(EN13458CalculateDTO input, EN13458ResultDTO? previousResult)
        {
            var shellThickness = previousResult?.RoundedInnerShellThickness ?? 0d;
            var headThickness = previousResult?.RoundedInnerHeadThickness ?? 0d;
            var outerShellThickness = previousResult?.RoundedOuterShellThickness ?? 0d;
            var outerHeadThickness = previousResult?.RoundedOuterHeadThickness ?? 0d;

            var innerShell = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.InnerShellMaterialId, input.InnerShellMaterialFormId, input.IsColdStretchApplied, input.DesignTemperature, shellThickness);
            var innerHead = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.InnerHeadMaterialId, input.InnerHeadMaterialFormId, input.IsColdStretchApplied, input.DesignTemperature, headThickness);
            var outerShell = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.OuterShellMaterialId, input.OuterShellMaterialFormId, input.IsColdStretchApplied, input.DesignTemperature, outerShellThickness);
            var outerHead = await _strengthProvider.ResolveEffectiveYieldStrengthAsync(input.OuterHeadMaterialId, input.OuterHeadMaterialFormId, input.IsColdStretchApplied, input.DesignTemperature, outerHeadThickness);

            var changed = !AreClose(input.InnerShellMaterialStrength, innerShell)
                || !AreClose(input.InnerHeadMaterialStrength, innerHead)
                || !AreClose(input.OuterShellMaterialStrength, outerShell)
                || !AreClose(input.OuterHeadMaterialStrength, outerHead);

            input.InnerShellMaterialStrength = innerShell;
            input.InnerHeadMaterialStrength = innerHead;
            input.OuterShellMaterialStrength = outerShell;
            input.OuterHeadMaterialStrength = outerHead;
            return previousResult != null && changed;
        }

        private static bool AreClose(double? left, double right)
            => left.HasValue && Math.Abs(left.Value - right) < 0.0001d;

        public async Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System")
        {
            EN13458Calculation entity;
            if (result.Id != Guid.Empty)
            {
                entity = await _repository.GetByIdAsync(result.Id)
                    ?? throw new InvalidOperationException($"EN13458 calculation not found: {result.Id}");
                ApplyToEntity(entity, result, createdBy);
                await _repository.UpdateAsync(entity);
            }
            else
            {
                entity = ToEntity(result, createdBy);
                await _repository.AddAsync(entity);
                result.Id = entity.Id;
            }

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
            Pressure = dto.Pressure, ProductTypeId = dto.StorageTypeId, LiquidDensity = dto.LiquidDensity, DesignTemperature = dto.DesignTemperature,
            InnerShellMaterialId = dto.InnerShellMaterialId, InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
            InnerHeadMaterialId = dto.InnerHeadMaterialId, InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
            OuterShellMaterialId = dto.OuterShellMaterialId, OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
            OuterHeadMaterialId = dto.OuterHeadMaterialId, OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
            InnerShellMaterialStrength = dto.InnerShellMaterialStrength, InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
            OuterShellMaterialStrength = dto.OuterShellMaterialStrength, OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
            InnerShellMaterialDensity = dto.InnerShellMaterialDensity, InnerHeadMaterialDensity = dto.InnerHeadMaterialDensity,
            OuterShellMaterialDensity = dto.OuterShellMaterialDensity, OuterHeadMaterialDensity = dto.OuterHeadMaterialDensity,
            InnerShellThickness = dto.InnerShellThickness, InnerHeadThickness = dto.InnerHeadThickness,
            OuterShellThickness = dto.OuterShellThickness, OuterHeadThickness = dto.OuterHeadThickness,
            RoundedInnerShellThickness = dto.RoundedInnerShellThickness, RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
            RoundedOuterShellThickness = dto.RoundedOuterShellThickness, RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
            DesignPressure = dto.DesignPressure, TestPressure = dto.TestPressure, StaticPressure = dto.StaticPressure,
            InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
            OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
            InnerTankHeadWeight = dto.InnerTankHeadWeight,
            OuterTankHeadWeight = dto.OuterTankHeadWeight,
            InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
            InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
            InnerTankShellWeldLength = dto.InnerTankShellWeldLength,
            InnerTankBombeWeldLength = dto.InnerTankBombeWeldLength,
            InnerTankTotalWeldLength = dto.InnerTankTotalWeldLength,
            OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
            OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
            OuterTankShellWeldLength = dto.OuterTankShellWeldLength,
            OuterTankBombeWeldLength = dto.OuterTankBombeWeldLength,
            OuterTankTotalWeldLength = dto.OuterTankTotalWeldLength,
            StiffenerRingWeldLength = dto.StiffenerRingWeldLength,
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
            BucklingWaveNumber = dto.BucklingWaveNumber,
            ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1,
            PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2,
            DesignExternalPressurePv = dto.DesignExternalPressurePv,
            SupportRingRequired = dto.SupportRingRequired,
            SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe,
            SupportRingStressX = dto.SupportRingStressX,
            SupportRingAllowableStress = dto.SupportRingAllowableStress,
            SupportRingAdequate = dto.SupportRingAdequate,
            HeadCollapsePressure = dto.HeadCollapsePressure,
            RequiredProfileCount = dto.RequiredProfileCount,
            ProfileDevelopedLength = dto.ProfileDevelopedLength,
            TotalProfileLength = dto.TotalProfileLength,
            ProfileWeldLength = dto.ProfileWeldLength,

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

        private static void ApplyToEntity(EN13458Calculation entity, EN13458ResultDTO dto, string modifiedBy)
        {
            entity.Name = dto.Name;
            entity.OuterDiameter = dto.OuterDiameter;
            entity.OuterTankDiameter = dto.OuterTankDiameter;
            entity.ShellLength = dto.ShellLength;
            entity.Pressure = dto.Pressure;
            entity.ProductTypeId = dto.StorageTypeId;
            entity.LiquidDensity = dto.LiquidDensity;
            entity.DesignTemperature = dto.DesignTemperature;
            entity.InnerShellMaterialId = dto.InnerShellMaterialId;
            entity.InnerShellMaterialFormId = dto.InnerShellMaterialFormId;
            entity.InnerHeadMaterialId = dto.InnerHeadMaterialId;
            entity.InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId;
            entity.OuterShellMaterialId = dto.OuterShellMaterialId;
            entity.OuterShellMaterialFormId = dto.OuterShellMaterialFormId;
            entity.OuterHeadMaterialId = dto.OuterHeadMaterialId;
            entity.OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId;
            entity.InnerShellMaterialStrength = dto.InnerShellMaterialStrength;
            entity.InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength;
            entity.OuterShellMaterialStrength = dto.OuterShellMaterialStrength;
            entity.OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength;
            entity.InnerShellMaterialDensity = dto.InnerShellMaterialDensity;
            entity.InnerHeadMaterialDensity = dto.InnerHeadMaterialDensity;
            entity.OuterShellMaterialDensity = dto.OuterShellMaterialDensity;
            entity.OuterHeadMaterialDensity = dto.OuterHeadMaterialDensity;
            entity.InnerShellThickness = dto.InnerShellThickness;
            entity.InnerHeadThickness = dto.InnerHeadThickness;
            entity.OuterShellThickness = dto.OuterShellThickness;
            entity.OuterHeadThickness = dto.OuterHeadThickness;
            entity.RoundedInnerShellThickness = dto.RoundedInnerShellThickness;
            entity.RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness;
            entity.RoundedOuterShellThickness = dto.RoundedOuterShellThickness;
            entity.RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness;
            entity.DesignPressure = dto.DesignPressure;
            entity.TestPressure = dto.TestPressure;
            entity.StaticPressure = dto.StaticPressure;
            entity.InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter;
            entity.OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter;
            entity.InnerTankHeadWeight = dto.InnerTankHeadWeight;
            entity.OuterTankHeadWeight = dto.OuterTankHeadWeight;
            entity.InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength;
            entity.InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength;
            entity.InnerTankShellWeldLength = dto.InnerTankShellWeldLength;
            entity.InnerTankBombeWeldLength = dto.InnerTankBombeWeldLength;
            entity.InnerTankTotalWeldLength = dto.InnerTankTotalWeldLength;
            entity.OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength;
            entity.OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength;
            entity.OuterTankShellWeldLength = dto.OuterTankShellWeldLength;
            entity.OuterTankBombeWeldLength = dto.OuterTankBombeWeldLength;
            entity.OuterTankTotalWeldLength = dto.OuterTankTotalWeldLength;
            entity.StiffenerRingWeldLength = dto.StiffenerRingWeldLength;
            entity.TotalWeldLength = dto.TotalWeldLength;
            entity.TotalFilmCost = dto.TotalFilmCost;
            entity.InnerTankTotalLength = dto.InnerTankTotalLength;
            entity.OuterTankTotalLength = dto.OuterTankTotalLength;
            entity.PerliteVolume = dto.PerliteVolume;
            entity.PerliteWeight = dto.PerliteWeight;
            entity.InnerVolume = dto.InnerVolume;
            entity.OuterVolume = dto.OuterVolume;
            entity.InnerSurfaceArea = dto.InnerSurfaceArea;
            entity.OuterSurfaceArea = dto.OuterSurfaceArea;
            entity.InnerTankWeight = dto.InnerTankWeight;
            entity.OuterTankWeight = dto.OuterTankWeight;
            entity.WeldLength1500 = dto.WeldLength1500;
            entity.WeldLength2000 = dto.WeldLength2000;
            entity.WeldLength2500 = dto.WeldLength2500;
            entity.WeldLength3000 = dto.WeldLength3000;
            entity.GasNitrogenVolume = dto.GasNitrogenVolume;
            entity.LiquidNitrogenVolume = dto.LiquidNitrogenVolume;
            entity.BucklingWaveNumber = dto.BucklingWaveNumber;
            entity.ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1;
            entity.PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2;
            entity.DesignExternalPressurePv = dto.DesignExternalPressurePv;
            entity.SupportRingRequired = dto.SupportRingRequired;
            entity.SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe;
            entity.SupportRingStressX = dto.SupportRingStressX;
            entity.SupportRingAllowableStress = dto.SupportRingAllowableStress;
            entity.SupportRingAdequate = dto.SupportRingAdequate;
            entity.HeadCollapsePressure = dto.HeadCollapsePressure;
            entity.RequiredProfileCount = dto.RequiredProfileCount;
            entity.ProfileDevelopedLength = dto.ProfileDevelopedLength;
            entity.TotalProfileLength = dto.TotalProfileLength;
            entity.ProfileWeldLength = dto.ProfileWeldLength;
            entity.InnerDevelopedLength = dto.InnerDevelopedLength;
            entity.OuterDevelopedLength = dto.OuterDevelopedLength;
            entity.InnerSectorPlan1500 = dto.InnerSectorPlan1500;
            entity.InnerSectorPlan2000 = dto.InnerSectorPlan2000;
            entity.InnerSectorPlan2500 = dto.InnerSectorPlan2500;
            entity.InnerSectorPlan3000 = dto.InnerSectorPlan3000;
            entity.OuterSectorPlan1500 = dto.OuterSectorPlan1500;
            entity.OuterSectorPlan2000 = dto.OuterSectorPlan2000;
            entity.OuterSectorPlan2500 = dto.OuterSectorPlan2500;
            entity.OuterSectorPlan3000 = dto.OuterSectorPlan3000;
            entity.ModifiedBy = modifiedBy;
            entity.ModifiedDate = DateTime.UtcNow;
        }

        private static EN13458ResultDTO ToDto(EN13458Calculation entity) => new EN13458ResultDTO
        {
            Id = entity.Id, Name = entity.Name, OuterDiameter = entity.OuterDiameter, OuterTankDiameter = entity.OuterTankDiameter, ShellLength = entity.ShellLength,
            Pressure = entity.Pressure, StorageTypeId = entity.ProductTypeId, LiquidDensity = entity.LiquidDensity, DesignTemperature = entity.DesignTemperature,
            IsColdStretchApplied = false, TankOrientation = MVC.ProductManagement.Domain.Enums.TankOrientation.Horizontal,
            InnerShellMaterialId = entity.InnerShellMaterialId, InnerShellMaterialFormId = entity.InnerShellMaterialFormId,
            InnerHeadMaterialId = entity.InnerHeadMaterialId, InnerHeadMaterialFormId = entity.InnerHeadMaterialFormId,
            OuterShellMaterialId = entity.OuterShellMaterialId, OuterShellMaterialFormId = entity.OuterShellMaterialFormId,
            OuterHeadMaterialId = entity.OuterHeadMaterialId, OuterHeadMaterialFormId = entity.OuterHeadMaterialFormId,
            InnerShellMaterialStrength = entity.InnerShellMaterialStrength, InnerHeadMaterialStrength = entity.InnerHeadMaterialStrength,
            OuterShellMaterialStrength = entity.OuterShellMaterialStrength, OuterHeadMaterialStrength = entity.OuterHeadMaterialStrength,
            InnerShellMaterialDensity = entity.InnerShellMaterialDensity, InnerHeadMaterialDensity = entity.InnerHeadMaterialDensity,
            OuterShellMaterialDensity = entity.OuterShellMaterialDensity, OuterHeadMaterialDensity = entity.OuterHeadMaterialDensity,
            InnerShellThickness = entity.InnerShellThickness, InnerHeadThickness = entity.InnerHeadThickness,
            OuterShellThickness = entity.OuterShellThickness, OuterHeadThickness = entity.OuterHeadThickness,
            RoundedInnerShellThickness = entity.RoundedInnerShellThickness, RoundedInnerHeadThickness = entity.RoundedInnerHeadThickness,
            RoundedOuterShellThickness = entity.RoundedOuterShellThickness, RoundedOuterHeadThickness = entity.RoundedOuterHeadThickness,
            DesignPressure = entity.DesignPressure, TestPressure = entity.TestPressure, StaticPressure = entity.StaticPressure,
            InnerTankHeadPulDiameter = entity.InnerTankHeadPulDiameter,
            OuterTankHeadPulDiameter = entity.OuterTankHeadPulDiameter,
            InnerTankHeadWeight = entity.InnerTankHeadWeight,
            OuterTankHeadWeight = entity.OuterTankHeadWeight,
            InnerTankHeadWeldLength = entity.InnerTankHeadWeldLength,
            InnerTankCircumferenceWeldLength = entity.InnerTankCircumferenceWeldLength,
            InnerTankShellWeldLength = entity.InnerTankShellWeldLength,
            InnerTankBombeWeldLength = entity.InnerTankBombeWeldLength,
            InnerTankTotalWeldLength = entity.InnerTankTotalWeldLength,
            OuterTankHeadWeldLength = entity.OuterTankHeadWeldLength,
            OuterTankCircumferenceWeldLength = entity.OuterTankCircumferenceWeldLength,
            OuterTankShellWeldLength = entity.OuterTankShellWeldLength,
            OuterTankBombeWeldLength = entity.OuterTankBombeWeldLength,
            OuterTankTotalWeldLength = entity.OuterTankTotalWeldLength,
            StiffenerRingWeldLength = entity.StiffenerRingWeldLength,
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
            BucklingWaveNumber = entity.BucklingWaveNumber,
            ElasticBucklingPressureP1 = entity.ElasticBucklingPressureP1,
            PlasticCollapsePressureP2 = entity.PlasticCollapsePressureP2,
            DesignExternalPressurePv = entity.DesignExternalPressurePv,
            SupportRingRequired = entity.SupportRingRequired,
            SupportRingCriticalPressurePe = entity.SupportRingCriticalPressurePe,
            SupportRingStressX = entity.SupportRingStressX,
            SupportRingAllowableStress = entity.SupportRingAllowableStress,
            SupportRingAdequate = entity.SupportRingAdequate,
            HeadCollapsePressure = entity.HeadCollapsePressure,
            RequiredProfileCount = entity.RequiredProfileCount,
            ProfileDevelopedLength = entity.ProfileDevelopedLength,
            TotalProfileLength = entity.TotalProfileLength,
            ProfileWeldLength = entity.ProfileWeldLength,

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
