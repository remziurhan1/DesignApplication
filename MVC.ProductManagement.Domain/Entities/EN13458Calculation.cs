using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.Costing;
using System;
using System.Collections.Generic;

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
        public double DesignTemperature { get; set; } = 20d;
        public double WeldLength1500 { get; set; }
        public double WeldLength2000 { get; set; }
        public double WeldLength2500 { get; set; }
        public double WeldLength3000 { get; set; }

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
        public double InnerShellMaterialDensity { get; set; }
        public double InnerHeadMaterialDensity { get; set; }
        public double OuterShellMaterialDensity { get; set; }
        public double OuterHeadMaterialDensity { get; set; }

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

        public double InnerTankHeadPulDiameter { get; set; }
        public double OuterTankHeadPulDiameter { get; set; }
        public double InnerTankHeadWeight { get; set; }
        public double OuterTankHeadWeight { get; set; }
        public double InnerTankHeadWeldLength { get; set; }
        public double InnerTankCircumferenceWeldLength { get; set; }
        public double InnerTankShellWeldLength { get; set; }
        public double InnerTankBombeWeldLength { get; set; }
        public double InnerTankTotalWeldLength { get; set; }
        public double OuterTankHeadWeldLength { get; set; }
        public double OuterTankCircumferenceWeldLength { get; set; }
        public double OuterTankShellWeldLength { get; set; }
        public double OuterTankBombeWeldLength { get; set; }
        public double OuterTankTotalWeldLength { get; set; }
        public double StiffenerRingWeldLength { get; set; }
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

        // === DIŞ TANK ELASTİK-PLASTİK BURKULMA ===
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


        public virtual ICollection<EN13458CostDetail> CostDetails { get; set; } = new List<EN13458CostDetail>();
        public virtual ICollection<EN13458CostAnalysis> CostAnalyses { get; set; } = new List<EN13458CostAnalysis>();
        public virtual ICollection<EN13458SalesPrice> SalesPrices { get; set; } = new List<EN13458SalesPrice>();
        public Guid ProductTypeId { get; set; } // İlgili ProductType ID
        public virtual StorageType StorageService { get; set; } // İlgili ProductType
    }
}
