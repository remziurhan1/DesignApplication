using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.MaterialFormVms
{
    public class MaterialFormDetailVm
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public string? MaterialName { get; set; } // ilişkili Material’den gösterim kolaylığı
        public MaterialFormType FormType { get; set; }
        public string MaterialClass { get; set; } = string.Empty;
        public string Norm { get; set; } = string.Empty;
        public string? SymbolicName { get; set; }
        public string? StockCode { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public string ProductStandard { get; set; } = string.Empty;
        public double? WeldingFactor { get; set; }
        public string? Notes { get; set; }
        public double UnitPrice { get; set; }
        public double? TargetPrice { get; set; }
        public double? ColdStretchYieldStrength { get; set; }

    }
}
