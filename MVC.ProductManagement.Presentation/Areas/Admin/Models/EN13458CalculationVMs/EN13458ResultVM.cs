using System;

using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458ResultVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double OuterDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public double LiquidDensity { get; set; }
        public double SectorWidth { get; set; }
        public TankOrientation TankOrientation { get; set; }
        public bool IsColdStretchApplied { get; set; }

        public Guid InnerShellMaterialId { get; set; }
        public Guid InnerShellMaterialFormId { get; set; }
        public Guid InnerHeadMaterialId { get; set; }
        public Guid InnerHeadMaterialFormId { get; set; }
        public Guid OuterShellMaterialId { get; set; }
        public Guid OuterShellMaterialFormId { get; set; }
        public Guid OuterHeadMaterialId { get; set; }
        public Guid OuterHeadMaterialFormId { get; set; }

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
        public double GasNitrogenVolume { get; set; }
        public double LiquidNitrogenVolume { get; set; }
    }
}
