using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialFormVms
{
    public class MaterialFormCreateVm
    {
        public Guid MaterialId { get; set; }
        public MaterialFormType FormType { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public string ProductStandard { get; set; } = string.Empty;
        public double? WeldingFactor { get; set; }
        public string? Notes { get; set; }
        public double UnitPrice { get; set; }



    }
}
