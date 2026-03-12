using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
   public class EN13458ResultDTO
    {
        public Guid Id { get; set; }

        // === GİRİŞ PARAMETRELERİ ===
        public string Name { get; set; }
        public double OuterDiameter { get; set; }
        public double OuterTankDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public Guid StorageTypeId { get; set; }
        public double LiquidDensity { get; set; }
        public TankOrientation TankOrientation { get; set; }
        public bool IsColdStretchApplied { get; set; }

        public double WeldLength1500 { get; set; }
        public double WeldLength2000 { get; set; }
        public double WeldLength2500 { get; set; }
        public double WeldLength3000 { get; set; }

        // Outer vessel external pressure inputs
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
        // Malzeme ve Form Id'leri
        public Guid InnerShellMaterialId { get; set; }
        public Guid InnerShellMaterialFormId { get; set; }
        public Guid InnerHeadMaterialId { get; set; }
        public Guid InnerHeadMaterialFormId { get; set; }
        public Guid OuterShellMaterialId { get; set; }
        public Guid OuterShellMaterialFormId { get; set; }
        public Guid OuterHeadMaterialId { get; set; }
        public Guid OuterHeadMaterialFormId { get; set; }
        public MaterialForm InnerShellMaterialForm { get; set; }
        public MaterialForm InnerHeadMaterialForm { get; set; }

        // === MALZEME DAYANIMLARI ===
        public double InnerShellMaterialStrength { get; set; }
        public double InnerHeadMaterialStrength { get; set; }
        public double OuterShellMaterialStrength { get; set; }
        public double OuterHeadMaterialStrength { get; set; }

        // === KALINLIK SONUÇLARI ===
        public double InnerShellThickness { get; set; }
        public double InnerHeadThickness { get; set; }
        public double OuterShellThickness { get; set; }
        public double OuterHeadThickness { get; set; }

        // Yuvarlanmış kalınlıklar
        public double RoundedInnerShellThickness { get; set; }
        public double RoundedInnerHeadThickness { get; set; }
        public double RoundedOuterShellThickness { get; set; }
        public double RoundedOuterHeadThickness { get; set; }

        // === BASINÇ VE STATİK DEĞERLER ===
        public double DesignPressure { get; set; }
        public double TestPressure { get; set; }
        public double StaticPressure { get; set; }

        // Outer vessel external pressure results
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

        // === BOY, MALİYET, UZUNLUK ===
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

        // === HACİM / AĞIRLIK / YÜZEY ===
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

        // Sac oryantasyonu / açınım çıktıları
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
