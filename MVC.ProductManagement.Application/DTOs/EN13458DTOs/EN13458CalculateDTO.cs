using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
   public class EN13458CalculateDTO
    {
        public string Name { get; set; }
        public double OuterDiameter { get; set; }
        public double? OuterTankDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public Guid StorageTypeId { get; set; }
        public double LiquidDensity { get; set; }
        public TankOrientation TankOrientation { get; set; } = TankOrientation.Horizontal;
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

        // Malzeme seçimleri
        public Guid InnerShellMaterialId { get; set; }
        public Guid InnerShellMaterialFormId { get; set; }

        public Guid InnerHeadMaterialId { get; set; }
        public Guid InnerHeadMaterialFormId { get; set; }

        public Guid OuterShellMaterialId { get; set; }
        public Guid OuterShellMaterialFormId { get; set; }

        public Guid OuterHeadMaterialId { get; set; }
        public Guid OuterHeadMaterialFormId { get; set; }

        // Opsiyonel normalize edilmiş dayanım değerleri (adapter tarafından set edilebilir)
        public double? InnerShellMaterialStrength { get; set; }
        public double? InnerHeadMaterialStrength { get; set; }
        public double? OuterShellMaterialStrength { get; set; }
        public double? OuterHeadMaterialStrength { get; set; }
    }
}
