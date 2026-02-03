using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.TankRequestVMs
{
    public class TankRequestCreateViewModel
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
        // DropDown için listeler
        public List<SelectListItem>? GasTypes { get; set; }
        public List<SelectListItem>? DesignStandards { get; set; }
        public List<SelectListItem>? ProductCodes { get; set; }
    }
}
