using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities
{
    public class EN13458Calculation : AuditableEntity
    {
        // === GİRİŞ VERİLERİ ===
        public string Name { get; set; }
        public double OuterDiameter { get; set; }            // mm
        public double ShellLength { get; set; }              // mm
        public double Pressure { get; set; }                 // bar
        public double LiquidDensity { get; set; }            // kg/m³
        public double SectorWidth { get; set; }              // mm (1500, 2000, 2500)

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

        public double TotalWeldLength { get; set; }
        public double TotalFilmCost { get; set; }

        public double InnerTankTotalLength { get; set; }
        public double OuterTankTotalLength { get; set; }

        public Guid ProductTypeId { get; set; } // İlgili ProductType ID
        public virtual StorageType StorageService { get; set; } // İlgili ProductType
    }
}
