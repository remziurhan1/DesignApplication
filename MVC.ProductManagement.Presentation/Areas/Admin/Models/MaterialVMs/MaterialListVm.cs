namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs
{
    public class MaterialListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public double Density { get; set; }
        public string? Notes { get; set; }
    }
}
