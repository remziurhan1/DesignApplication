using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.MaterialCatalog
{
    public class MaterialMechanicalProperty : AuditableEntity
    {
        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; } = default!;

        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public double Temperature { get; set; }
        public double? YieldStrength { get; set; }
        public double? TensileStrengthMin { get; set; }
        public double? TensileStrengthMax { get; set; }
        public double? Elongation { get; set; }
        public double? AllowableStress { get; set; }
        public string? SourceNote { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
