using System;
using System.ComponentModel.DataAnnotations;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458CalculateVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, double.MaxValue)]
        public double OuterDiameter { get; set; }

        [Range(1, double.MaxValue)]
        public double ShellLength { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Pressure { get; set; }

        [Range(1, double.MaxValue)]
        public double LiquidDensity { get; set; }

        [Range(1, double.MaxValue)]
        public double SectorWidth { get; set; }

        [Required]
        public TankOrientation TankOrientation { get; set; } = TankOrientation.Horizontal;

        [Required] public Guid InnerShellMaterialId { get; set; }
        [Required] public Guid InnerShellMaterialFormId { get; set; }
        [Required] public Guid InnerHeadMaterialId { get; set; }
        [Required] public Guid InnerHeadMaterialFormId { get; set; }
        [Required] public Guid OuterShellMaterialId { get; set; }
        [Required] public Guid OuterShellMaterialFormId { get; set; }
        [Required] public Guid OuterHeadMaterialId { get; set; }
        [Required] public Guid OuterHeadMaterialFormId { get; set; }
    }
}
