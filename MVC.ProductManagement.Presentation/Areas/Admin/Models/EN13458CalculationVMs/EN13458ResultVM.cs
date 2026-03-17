using System;
using System.Collections.Generic;

using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458ResultVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double OuterDiameter { get; set; }
        public double OuterTankDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public Guid StorageTypeId { get; set; }
        public string StorageTypeName { get; set; } = string.Empty;
        public double LiquidDensity { get; set; }
        public TankOrientation TankOrientation { get; set; }
        public bool IsColdStretchApplied { get; set; }

        public double WeldLength1500 { get; set; }
        public double WeldLength2000 { get; set; }
        public double WeldLength2500 { get; set; }
        public double WeldLength3000 { get; set; }
        public Guid InnerShellMaterialId { get; set; }
        public string InnerShellMaterialName { get; set; } = string.Empty;
        public Guid InnerShellMaterialFormId { get; set; }
        public string InnerShellMaterialFormName { get; set; } = string.Empty;
        public Guid InnerHeadMaterialId { get; set; }
        public string InnerHeadMaterialName { get; set; } = string.Empty;
        public Guid InnerHeadMaterialFormId { get; set; }
        public string InnerHeadMaterialFormName { get; set; } = string.Empty;
        public Guid OuterShellMaterialId { get; set; }
        public string OuterShellMaterialName { get; set; } = string.Empty;
        public Guid OuterShellMaterialFormId { get; set; }
        public string OuterShellMaterialFormName { get; set; } = string.Empty;
        public Guid OuterHeadMaterialId { get; set; }
        public string OuterHeadMaterialName { get; set; } = string.Empty;
        public Guid OuterHeadMaterialFormId { get; set; }
        public string OuterHeadMaterialFormName { get; set; } = string.Empty;

        public double InnerShellMaterialStrength { get; set; }
        public double InnerHeadMaterialStrength { get; set; }
        public double OuterShellMaterialStrength { get; set; }
        public double OuterHeadMaterialStrength { get; set; }

        public double InnerShellThickness { get; set; }
        public double InnerHeadThickness { get; set; }
        public double OuterShellThickness { get; set; }
        public double OuterHeadThickness { get; set; }
        public double RoundedInnerShellThickness { get; set; }
        public double RoundedInnerHeadThickness { get; set; }
        public double RoundedOuterShellThickness { get; set; }
        public double RoundedOuterHeadThickness { get; set; }

        public double DesignPressure { get; set; }
        public double TestPressure { get; set; }
        public double StaticPressure { get; set; }
        public double InnerTankHeadPulDiameter { get; set; }
        public double OuterTankHeadPulDiameter { get; set; }
        public double InnerTankHeadWeight { get; set; }
        public double OuterTankHeadWeight { get; set; }
        public double InnerTankHeadWeldLength { get; set; }
        public double InnerTankCircumferenceWeldLength { get; set; }
        public double OuterTankHeadWeldLength { get; set; }
        public double OuterTankCircumferenceWeldLength { get; set; }
        public double TotalWeldLength { get; set; }
        public double TotalFilmCost { get; set; }
        public double InnerTankTotalLength { get; set; }
        public double OuterTankTotalLength { get; set; }

        public double InnerVolume { get; set; }
        public double OuterVolume { get; set; }
        public double InnerSurfaceArea { get; set; }
        public double OuterSurfaceArea { get; set; }
        public double InnerTankWeight { get; set; }
        public double OuterTankWeight { get; set; }
        public double PerliteVolume { get; set; }
        public double PerliteWeight { get; set; }
        public double GasNitrogenVolume { get; set; }
        public double LiquidNitrogenVolume { get; set; }

        public double BucklingWaveNumber { get; set; }
        public double ElasticBucklingPressureP1 { get; set; }
        public double PlasticCollapsePressureP2 { get; set; }
        public double DesignExternalPressurePv { get; set; }
        public bool SupportRingRequired { get; set; }
        public double SupportRingCriticalPressurePe { get; set; }
        public double SupportRingStressX { get; set; }
        public double SupportRingAllowableStress { get; set; }
        public bool SupportRingAdequate { get; set; }
        public double HeadCollapsePressure { get; set; }
        public int RequiredProfileCount { get; set; }
        public double ProfileDevelopedLength { get; set; }
        public double TotalProfileLength { get; set; }
        public double ProfileWeldLength { get; set; }

        public double InnerDevelopedLength { get; set; }
        public double OuterDevelopedLength { get; set; }
        public string InnerSectorPlan1500 { get; set; } = string.Empty;
        public string InnerSectorPlan2000 { get; set; } = string.Empty;
        public string InnerSectorPlan2500 { get; set; } = string.Empty;
        public string InnerSectorPlan3000 { get; set; } = string.Empty;
        public string OuterSectorPlan1500 { get; set; } = string.Empty;
        public string OuterSectorPlan2000 { get; set; } = string.Empty;
        public string OuterSectorPlan2500 { get; set; } = string.Empty;
        public string OuterSectorPlan3000 { get; set; } = string.Empty;

    }
}
