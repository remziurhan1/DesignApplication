using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities
{
    public class EN13458Calculation : AuditableEntity
    {
        // === GİRİŞ VERİLERİ ===
        public string Name { get; set; }
        public double OuterDiameter { get; set; }            // mm
        public double OuterTankDiameter { get; set; }        // mm
        public double ShellLength { get; set; }              // mm
        public double Pressure { get; set; }                 // bar
        public double LiquidDensity { get; set; }            // kg/m³
        public double WeldLength1500 { get; set; }
        public double WeldLength2000 { get; set; }
        public double WeldLength2500 { get; set; }
        public double WeldLength3000 { get; set; }

        public double CorrosionAllowance { get; set; }
        public double BucklingLength { get; set; }
        public double ElasticModulus { get; set; }
        public double PoissonRatio { get; set; }
        public double RoundnessErrorPercent { get; set; }
        public double YieldFactorK { get; set; }
        public bool UseGeneralElasticFormula { get; set; }
        public bool HasStiffener { get; set; }
        public bool UseManualStiffenerValues { get; set; }
        public Guid? StiffenerMaterialId { get; set; }
        public Guid? StiffenerMaterialFormId { get; set; }
        public double? StiffenerInertia { get; set; }
        public double? StiffenerArea { get; set; }

        // === MALZEME BAĞLANTILARI ===
        // İç Gövde
        public Guid InnerShellMaterialId { get; set; }
        public virtual Material InnerShellMaterial { get; set; }
        public Guid InnerShellMaterialFormId { get; set; }
        public virtual MaterialForm InnerShellMaterialForm { get; set; }

        // İç Bombe
        public Guid InnerHeadMaterialId { get; set; }
        public virtual Material InnerHeadMaterial { get; set; }
        public Guid InnerHeadMaterialFormId { get; set; }
        public virtual MaterialForm InnerHeadMaterialForm { get; set; }

        // Dış Gövde
        public Guid OuterShellMaterialId { get; set; }
        public virtual Material OuterShellMaterial { get; set; }
        public Guid OuterShellMaterialFormId { get; set; }
        public virtual MaterialForm OuterShellMaterialForm { get; set; }

        // Dış Bombe
        public Guid OuterHeadMaterialId { get; set; }
        public virtual Material OuterHeadMaterial { get; set; }
        public Guid OuterHeadMaterialFormId { get; set; }
        public virtual MaterialForm OuterHeadMaterialForm { get; set; }

        // === MALZEME DAYANIMLARI ===
        public double InnerShellMaterialStrength { get; set; }   // Rp0.2 (MPa)
        public double InnerHeadMaterialStrength { get; set; }    // Rp0.2 (MPa)
        public double OuterShellMaterialStrength { get; set; }   // Rp0.2 (MPa)
        public double OuterHeadMaterialStrength { get; set; }    // Rp0.2 (MPa)

        // === HESAPLANAN DEĞERLER ===
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

        public double EffectiveOuterThickness { get; set; }
        public double DOverT { get; set; }
        public double LOverD { get; set; }
        public double DaOverLb { get; set; }
        public double ElasticBucklingPressure { get; set; }
        public double PlasticDeformationPressure { get; set; }
        public double AllowableExternalPressure { get; set; }
        public double ExternalDesignPressure { get; set; }
        public bool ExternalPressureDesignOk { get; set; }
        public double FixedOutOfRoundnessPercent { get; set; }
        public double FixedPoissonRatio { get; set; }
        public double FixedWeldCoefficient { get; set; }
        public double? RequiredStiffenerInertia { get; set; }
        public double? RequiredStiffenerArea { get; set; }
        public bool? StiffenerInertiaOk { get; set; }
        public bool? StiffenerAreaOk { get; set; }

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


        // === SAC ORYANTASYONU / AÇINIM ÇIKTILARI ===
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

        public Guid ProductTypeId { get; set; } // İlgili ProductType ID
        public virtual StorageType StorageService { get; set; } // İlgili ProductType
    }
}
