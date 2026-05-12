using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Mappers
{
    public static class EN13458CalculationVmMapper
    {
        public static EN13458DetailsVM MapDetailsVm(EN13458ResultDTO dto)
        {
            var vm = new EN13458DetailsVM();
            CopyResult(dto, vm);
            return vm;
        }

        public static EN13458CalculateVM MapCalculateVm(EN13458ResultDTO dto)
        {
            return new EN13458CalculateVM
            {
                Id = dto.Id,
                Name = dto.Name,
                OuterDiameter = dto.OuterDiameter,
                OuterTankDiameter = dto.OuterTankDiameter,
                ShellLength = dto.ShellLength,
                Pressure = dto.Pressure,
                StorageTypeId = dto.StorageTypeId,
                LiquidDensity = dto.LiquidDensity,
                TankOrientation = dto.TankOrientation,
                IsColdStretchApplied = dto.IsColdStretchApplied,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                StiffenerSpacing = 750
            };
        }

        public static EN13458ResultVM MapResultVm(EN13458ResultDTO dto)
        {
            var vm = new EN13458ResultVM();
            CopyResult(dto, vm);
            return vm;
        }

        private static void CopyResult(EN13458ResultDTO dto, EN13458ResultVM vm)
        {
            vm.Id = dto.Id;
            vm.Name = dto.Name;
            vm.OuterDiameter = dto.OuterDiameter;
            vm.OuterTankDiameter = dto.OuterTankDiameter;
            vm.ShellLength = dto.ShellLength;
            vm.Pressure = dto.Pressure;
            vm.StorageTypeId = dto.StorageTypeId;
            vm.LiquidDensity = dto.LiquidDensity;
            vm.TankOrientation = dto.TankOrientation;
            vm.IsColdStretchApplied = dto.IsColdStretchApplied;
            vm.DesignTemperature = dto.DesignTemperature;
            vm.WeldLength1500 = dto.WeldLength1500;
            vm.WeldLength2000 = dto.WeldLength2000;
            vm.WeldLength2500 = dto.WeldLength2500;
            vm.WeldLength3000 = dto.WeldLength3000;
            vm.InnerShellMaterialId = dto.InnerShellMaterialId;
            vm.InnerShellMaterialFormId = dto.InnerShellMaterialFormId;
            vm.InnerHeadMaterialId = dto.InnerHeadMaterialId;
            vm.InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId;
            vm.OuterShellMaterialId = dto.OuterShellMaterialId;
            vm.OuterShellMaterialFormId = dto.OuterShellMaterialFormId;
            vm.OuterHeadMaterialId = dto.OuterHeadMaterialId;
            vm.OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId;
            vm.InnerShellMaterialStrength = dto.InnerShellMaterialStrength;
            vm.InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength;
            vm.OuterShellMaterialStrength = dto.OuterShellMaterialStrength;
            vm.OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength;
            vm.InnerShellMaterialDensity = dto.InnerShellMaterialDensity;
            vm.InnerHeadMaterialDensity = dto.InnerHeadMaterialDensity;
            vm.OuterShellMaterialDensity = dto.OuterShellMaterialDensity;
            vm.OuterHeadMaterialDensity = dto.OuterHeadMaterialDensity;
            vm.InnerShellThickness = dto.InnerShellThickness;
            vm.InnerHeadThickness = dto.InnerHeadThickness;
            vm.OuterShellThickness = dto.OuterShellThickness;
            vm.OuterHeadThickness = dto.OuterHeadThickness;
            vm.RoundedInnerShellThickness = dto.RoundedInnerShellThickness;
            vm.RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness;
            vm.RoundedOuterShellThickness = dto.RoundedOuterShellThickness;
            vm.RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness;
            vm.DesignPressure = dto.DesignPressure;
            vm.TestPressure = dto.TestPressure;
            vm.StaticPressure = dto.StaticPressure;
            vm.InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter;
            vm.OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter;
            vm.InnerTankHeadWeight = dto.InnerTankHeadWeight;
            vm.OuterTankHeadWeight = dto.OuterTankHeadWeight;
            vm.InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength;
            vm.InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength;
            vm.InnerTankShellWeldLength = dto.InnerTankShellWeldLength;
            vm.InnerTankBombeWeldLength = dto.InnerTankBombeWeldLength;
            vm.InnerTankTotalWeldLength = dto.InnerTankTotalWeldLength;
            vm.OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength;
            vm.OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength;
            vm.OuterTankShellWeldLength = dto.OuterTankShellWeldLength;
            vm.OuterTankBombeWeldLength = dto.OuterTankBombeWeldLength;
            vm.OuterTankTotalWeldLength = dto.OuterTankTotalWeldLength;
            vm.StiffenerRingWeldLength = dto.StiffenerRingWeldLength;
            vm.TotalWeldLength = dto.TotalWeldLength;
            vm.TotalFilmCost = dto.TotalFilmCost;
            vm.InnerTankTotalLength = dto.InnerTankTotalLength;
            vm.OuterTankTotalLength = dto.OuterTankTotalLength;
            vm.InnerVolume = dto.InnerVolume;
            vm.OuterVolume = dto.OuterVolume;
            vm.InnerSurfaceArea = dto.InnerSurfaceArea;
            vm.OuterSurfaceArea = dto.OuterSurfaceArea;
            vm.InnerTankWeight = dto.InnerTankWeight;
            vm.OuterTankWeight = dto.OuterTankWeight;
            vm.PerliteVolume = dto.PerliteVolume;
            vm.PerliteWeight = dto.PerliteWeight;
            vm.GasNitrogenVolume = dto.GasNitrogenVolume;
            vm.LiquidNitrogenVolume = dto.LiquidNitrogenVolume;
            vm.BucklingWaveNumber = dto.BucklingWaveNumber;
            vm.ElasticBucklingPressureP1 = dto.ElasticBucklingPressureP1;
            vm.PlasticCollapsePressureP2 = dto.PlasticCollapsePressureP2;
            vm.DesignExternalPressurePv = dto.DesignExternalPressurePv;
            vm.SupportRingRequired = dto.SupportRingRequired;
            vm.SupportRingCriticalPressurePe = dto.SupportRingCriticalPressurePe;
            vm.SupportRingStressX = dto.SupportRingStressX;
            vm.SupportRingAllowableStress = dto.SupportRingAllowableStress;
            vm.SupportRingAdequate = dto.SupportRingAdequate;
            vm.HeadCollapsePressure = dto.HeadCollapsePressure;
            vm.RequiredProfileCount = dto.RequiredProfileCount;
            vm.ProfileDevelopedLength = dto.ProfileDevelopedLength;
            vm.TotalProfileLength = dto.TotalProfileLength;
            vm.ProfileWeldLength = dto.ProfileWeldLength;
            vm.InnerDevelopedLength = dto.InnerDevelopedLength;
            vm.OuterDevelopedLength = dto.OuterDevelopedLength;
            vm.InnerSectorPlan1500 = dto.InnerSectorPlan1500;
            vm.InnerSectorPlan2000 = dto.InnerSectorPlan2000;
            vm.InnerSectorPlan2500 = dto.InnerSectorPlan2500;
            vm.InnerSectorPlan3000 = dto.InnerSectorPlan3000;
            vm.OuterSectorPlan1500 = dto.OuterSectorPlan1500;
            vm.OuterSectorPlan2000 = dto.OuterSectorPlan2000;
            vm.OuterSectorPlan2500 = dto.OuterSectorPlan2500;
            vm.OuterSectorPlan3000 = dto.OuterSectorPlan3000;
        }

        public static EN13458ResultDTO MapResultDto(EN13458ResultVM vm)
        {
            return new EN13458ResultDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
                OuterTankDiameter = vm.OuterTankDiameter,
                ShellLength = vm.ShellLength,
                Pressure = vm.Pressure,
                StorageTypeId = vm.StorageTypeId,
                LiquidDensity = vm.LiquidDensity,
                TankOrientation = vm.TankOrientation,
                IsColdStretchApplied = vm.IsColdStretchApplied,
                DesignTemperature = vm.DesignTemperature == 0d ? 20d : vm.DesignTemperature,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength2500 = vm.WeldLength2500,
                WeldLength3000 = vm.WeldLength3000,
                InnerShellMaterialId = vm.InnerShellMaterialId,
                InnerShellMaterialFormId = vm.InnerShellMaterialFormId,
                InnerHeadMaterialId = vm.InnerHeadMaterialId,
                InnerHeadMaterialFormId = vm.InnerHeadMaterialFormId,
                OuterShellMaterialId = vm.OuterShellMaterialId,
                OuterShellMaterialFormId = vm.OuterShellMaterialFormId,
                OuterHeadMaterialId = vm.OuterHeadMaterialId,
                OuterHeadMaterialFormId = vm.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = vm.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = vm.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = vm.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = vm.OuterHeadMaterialStrength,
                InnerShellMaterialDensity = vm.InnerShellMaterialDensity,
                InnerHeadMaterialDensity = vm.InnerHeadMaterialDensity,
                OuterShellMaterialDensity = vm.OuterShellMaterialDensity,
                OuterHeadMaterialDensity = vm.OuterHeadMaterialDensity,
                InnerShellThickness = vm.InnerShellThickness,
                InnerHeadThickness = vm.InnerHeadThickness,
                OuterShellThickness = vm.OuterShellThickness,
                OuterHeadThickness = vm.OuterHeadThickness,
                RoundedInnerShellThickness = vm.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = vm.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = vm.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = vm.RoundedOuterHeadThickness,
                DesignPressure = vm.DesignPressure,
                TestPressure = vm.TestPressure,
                StaticPressure = vm.StaticPressure,
                InnerTankHeadPulDiameter = vm.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = vm.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = vm.InnerTankHeadWeight,
                OuterTankHeadWeight = vm.OuterTankHeadWeight,
                InnerTankHeadWeldLength = vm.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = vm.InnerTankCircumferenceWeldLength,
                InnerTankShellWeldLength = vm.InnerTankShellWeldLength,
                InnerTankBombeWeldLength = vm.InnerTankBombeWeldLength,
                InnerTankTotalWeldLength = vm.InnerTankTotalWeldLength,
                OuterTankHeadWeldLength = vm.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = vm.OuterTankCircumferenceWeldLength,
                OuterTankShellWeldLength = vm.OuterTankShellWeldLength,
                OuterTankBombeWeldLength = vm.OuterTankBombeWeldLength,
                OuterTankTotalWeldLength = vm.OuterTankTotalWeldLength,
                StiffenerRingWeldLength = vm.StiffenerRingWeldLength,
                TotalWeldLength = vm.TotalWeldLength,
                TotalFilmCost = vm.TotalFilmCost,
                InnerTankTotalLength = vm.InnerTankTotalLength,
                OuterTankTotalLength = vm.OuterTankTotalLength,
                InnerVolume = vm.InnerVolume,
                OuterVolume = vm.OuterVolume,
                InnerSurfaceArea = vm.InnerSurfaceArea,
                OuterSurfaceArea = vm.OuterSurfaceArea,
                InnerTankWeight = vm.InnerTankWeight,
                OuterTankWeight = vm.OuterTankWeight,
                PerliteVolume = vm.PerliteVolume,
                PerliteWeight = vm.PerliteWeight,
                GasNitrogenVolume = vm.GasNitrogenVolume,
                LiquidNitrogenVolume = vm.LiquidNitrogenVolume,
                BucklingWaveNumber = vm.BucklingWaveNumber,
                ElasticBucklingPressureP1 = vm.ElasticBucklingPressureP1,
                PlasticCollapsePressureP2 = vm.PlasticCollapsePressureP2,
                DesignExternalPressurePv = vm.DesignExternalPressurePv,
                SupportRingRequired = vm.SupportRingRequired,
                SupportRingCriticalPressurePe = vm.SupportRingCriticalPressurePe,
                SupportRingStressX = vm.SupportRingStressX,
                SupportRingAllowableStress = vm.SupportRingAllowableStress,
                SupportRingAdequate = vm.SupportRingAdequate,
                HeadCollapsePressure = vm.HeadCollapsePressure,
                RequiredProfileCount = vm.RequiredProfileCount,
                ProfileDevelopedLength = vm.ProfileDevelopedLength,
                TotalProfileLength = vm.TotalProfileLength,
                ProfileWeldLength = vm.ProfileWeldLength,
                InnerDevelopedLength = vm.InnerDevelopedLength,
                OuterDevelopedLength = vm.OuterDevelopedLength,
                InnerSectorPlan1500 = vm.InnerSectorPlan1500,
                InnerSectorPlan2000 = vm.InnerSectorPlan2000,
                InnerSectorPlan2500 = vm.InnerSectorPlan2500,
                InnerSectorPlan3000 = vm.InnerSectorPlan3000,
                OuterSectorPlan1500 = vm.OuterSectorPlan1500,
                OuterSectorPlan2000 = vm.OuterSectorPlan2000,
                OuterSectorPlan2500 = vm.OuterSectorPlan2500,
                OuterSectorPlan3000 = vm.OuterSectorPlan3000
            };
        }

    }
}
