namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.TankRequestVMs
{
    public class TankRequestListViewModel
    {
        public Guid Id { get; set; }
        public string GasTypeName { get; set; } = string.Empty;
        public string DesignStandardName { get; set; } = string.Empty;
        public string UsageType { get; set; } = string.Empty;
        public string Orientation { get; set; } = string.Empty;
        public string Placement { get; set; } = string.Empty;
        public double CapacityValue { get; set; }
        public double OperatingPressure { get; set; }
        public string TankCode { get; set; } = string.Empty;
    }
}
