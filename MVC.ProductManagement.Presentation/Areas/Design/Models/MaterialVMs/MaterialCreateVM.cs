using MVC.ProductManagement.Presentation.Areas.Design.Models.MaterialFormVms;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.MaterialVMs
{
    public class MaterialCreateVm
    {
        public string Name { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public double Density { get; set; }
        public double? ColdStretchYieldStrength { get; set; }
        public double? ElasticModulus { get; set; }
        public double? YieldFactorK { get; set; }
        public string? Notes { get; set; }

        public List<MaterialFormCreateVm> Forms { get; set; } = new();

    }
}
