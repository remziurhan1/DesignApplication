using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialFormVms;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs
{
    public class MaterialCreateVm
    {
        public string Name { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public MaterialStandard Standard { get; set; }
        public string Group { get; set; } = string.Empty;
        public double Density { get; set; }
        public string? Notes { get; set; }

        public List<MaterialFormCreateVm> Forms { get; set; } = new();

    }
}
