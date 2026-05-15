
namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs
{
    public class MaterialCreateVm
    {
        public string Name { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public double Density { get; set; }
        public string? Notes { get; set; }


    }
}
