using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;

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
        public double WeldLength1500 { get; set; }
        public double WeldLength2000 { get; set; }
        public double WeldLength3000 { get; set; }
        public double WeldLength4000 { get; set; }
        public double SurfaceArea { get; set; }

        public virtual ICollection<AD2000CostAnalysis> CostAnalyses { get; set; } = new List<AD2000CostAnalysis>();
        public virtual ICollection<Costing.AD2000SalesPrice> SalesPrices { get; set; } = new List<Costing.AD2000SalesPrice>();
    }
}
