using System;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000CalculateDTO
    {
        public string Name { get; set; } = string.Empty;
        public double Diameter { get; set; }
        public double ShellLength { get; set; }
        public double DesignPressure { get; set; }
        public double DesignTemperatureMin { get; set; }
        public double DesignTemperatureMax { get; set; }
        public double CorrosionAllowance { get; set; }
        public double WeldJointFactor { get; set; } = 1.0;
        public double AllowableStress { get; set; }
        public double ShellAllowableStress { get; set; }
        public double HeadAllowableStress { get; set; }
        public double EstimatedShellThickness { get; set; }
        public double EstimatedHeadThickness { get; set; }
        public double Beta { get; set; }
        public TankOrientation TankOrientation { get; set; } = TankOrientation.Horizontal;
        public Guid? StorageTypeId { get; set; }
        public bool IsManualDensity { get; set; }
        public double LiquidDensity { get; set; }
        public double StaticPressure { get; set; }

        public Guid ShellMaterialId { get; set; }
        public Guid ShellMaterialFormId { get; set; }
        public Guid HeadMaterialId { get; set; }
        public Guid HeadMaterialFormId { get; set; }

        public double TotalWeldLength { get; set; }
    }
}
