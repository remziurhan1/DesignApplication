using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class TankRequest : AuditableEntity
    {
        public Guid GasTypeId { get; set; }
        public Guid DesignStandardId { get; set; }
        public UsageType UsageType { get; set; }
        public TankOrientation Orientation { get; set; }
        public PlacementType Placement { get; set; }
        public string? TransportType { get; set; }
        public double CapacityValue { get; set; }
        public double OperatingPressure { get; set; }
        public double? DesignPressure { get; set; }
        public double InnerDiameter { get; set; }
        public bool IsInnerTankStainless { get; set; }
        public string TankCode { get; set; } = string.Empty;
        public Guid? ProductCodeId { get; set; }
        public string? Notes { get; set; }

        public virtual GasType GasType { get; set; } = null!;
        public virtual DesignStandard DesignStandard { get; set; } = null!;
        public virtual ProductCode? ProductCode { get; set; }
        public virtual TankCalculationResult? CalculationResult { get; set; }
        public virtual Quote? Quote { get; set; }
    }
}
