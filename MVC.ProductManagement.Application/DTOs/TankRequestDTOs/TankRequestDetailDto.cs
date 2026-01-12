using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.TankRequestDTOs
{
    public class TankRequestDetailDto
    {
        public Guid Id { get; set; }
        public Guid GasTypeId { get; set; }
        public Guid DesignStandardId { get; set; }
        public Guid? ProductCodeId { get; set; }
        public string GasTypeName { get; set; } = string.Empty;
        public string DesignStandardName { get; set; } = string.Empty;
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
        public string? ProductCode { get; set; }
        public string? Notes { get; set; }
    }
}
