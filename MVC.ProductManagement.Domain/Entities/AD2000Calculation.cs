using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities
{
    public class AD2000Calculation : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public double Diameter { get; set; }
        public double ShellLength { get; set; }
        public double DesignPressure { get; set; }
        public double DesignTemperatureMin { get; set; }
        public double DesignTemperatureMax { get; set; }
        public double CorrosionAllowance { get; set; }
        public double WeldJointFactor { get; set; }
        public double AllowableStress { get; set; }
        public double Beta { get; set; }

        public Guid ShellMaterialId { get; set; }
        public virtual Material ShellMaterial { get; set; } = null!;
        public Guid ShellMaterialFormId { get; set; }
        public virtual MaterialForm ShellMaterialForm { get; set; } = null!;

        public Guid HeadMaterialId { get; set; }
        public virtual Material HeadMaterial { get; set; } = null!;
        public Guid HeadMaterialFormId { get; set; }
        public virtual MaterialForm HeadMaterialForm { get; set; } = null!;

        public double ShellThickness { get; set; }
        public double HeadThickness { get; set; }
        public double RoundedShellThickness { get; set; }
        public double RoundedHeadThickness { get; set; }
        public double TestPressure { get; set; }
    }
}
