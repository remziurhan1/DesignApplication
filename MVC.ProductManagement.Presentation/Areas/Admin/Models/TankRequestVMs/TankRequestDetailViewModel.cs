namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.TankRequestVMs
{
    public class TankRequestDetailViewModel
    {
        public Guid Id { get; set; }
        public string GasTypeName { get; set; } = string.Empty;
        public string DesignStandardName { get; set; } = string.Empty;
        public string UsageType { get; set; } = string.Empty;
        public string Orientation { get; set; } = string.Empty;
        public string Placement { get; set; } = string.Empty;
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
