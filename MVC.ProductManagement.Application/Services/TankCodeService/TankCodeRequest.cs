using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.TankCodeService
{
    public class TankCodeRequest
    {
        public string GasCode { get; set; } = string.Empty;
        public UsageType UsageType { get; set; }
        public string? TransportType { get; set; }
        public double CapacityValue { get; set; }
        public TankOrientation Orientation { get; set; }
        public PlacementType Placement { get; set; }
        public double OperatingPressure { get; set; }
        public double InnerDiameter { get; set; }
    }
}
