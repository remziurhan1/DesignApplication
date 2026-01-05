using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs
{
    public class MaterialUpdateVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public MaterialStandard Standard { get; set; }
        public string Group { get; set; } = string.Empty;
        public double Density { get; set; }
        public string? Notes { get; set; }
    }
}
