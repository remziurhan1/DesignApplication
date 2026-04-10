namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs
{
    public class MaterialListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? ColdStretchYieldStrength { get; set; }
        public double? ElasticModulus { get; set; }
        public double? YieldFactorK { get; set; }
    }
}
