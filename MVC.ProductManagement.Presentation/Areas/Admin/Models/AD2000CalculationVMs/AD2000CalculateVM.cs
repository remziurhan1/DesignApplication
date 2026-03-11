using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.AD2000CalculationVMs
{
    public class AD2000CalculateVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, double.MaxValue)]
        public double Diameter { get; set; }

        [Range(1, double.MaxValue)]
        public double ShellLength { get; set; }

        [Range(0.01, double.MaxValue)]
        public double DesignPressure { get; set; }

        [Display(Name = "Dizayn Sıcaklığı Min (°C)")]
        public double DesignTemperatureMin { get; set; }

        [Display(Name = "Dizayn Sıcaklığı Max (°C)")]
        public double DesignTemperatureMax { get; set; }

        [Range(0, double.MaxValue)]
        public double CorrosionAllowance { get; set; }

        [Range(0.1, 1)]
        public double WeldJointFactor { get; set; } = 1.0;

        [Range(1, double.MaxValue)]
        public double AllowableStress { get; set; }

        [Range(0.1, 5)]
        public double Beta { get; set; } = 1.0;

        [Required] public Guid ShellMaterialId { get; set; }
        [Required] public Guid ShellMaterialFormId { get; set; }
        [Required] public Guid HeadMaterialId { get; set; }
        [Required] public Guid HeadMaterialFormId { get; set; }
    }
}
