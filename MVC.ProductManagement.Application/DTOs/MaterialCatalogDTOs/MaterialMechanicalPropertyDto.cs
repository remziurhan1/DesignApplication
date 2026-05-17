namespace MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs
{
    public class MaterialMechanicalPropertyDto
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public string Grade { get; set; } = string.Empty;
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public double Temperature { get; set; }
        public double? YieldStrength { get; set; }
        public double? TensileStrengthMin { get; set; }
        public double? TensileStrengthMax { get; set; }
        public double? Elongation { get; set; }
        public double? AllowableStress { get; set; }
        public string? SourceNote { get; set; }
    }
}
