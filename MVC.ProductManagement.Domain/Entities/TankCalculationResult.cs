using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class TankCalculationResult : AuditableEntity
    {
        public Guid TankRequestId { get; set; }
        public string CalculationStandard { get; set; } = string.Empty;
        public double? ShellThickness { get; set; }
        public double? HeadThickness { get; set; }
        public double? InnerVolume { get; set; }
        public double? OuterVolume { get; set; }
        public double? SurfaceArea { get; set; }
        public double? PerliteVolume { get; set; }
        public double? InnerTankLength { get; set; }
        public double? OuterTankLength { get; set; }
        public double? TotalWeight { get; set; }
        public string? Notes { get; set; }

        public virtual TankRequest TankRequest { get; set; } = null!;
    }
}
