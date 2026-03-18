using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.Costing
{
    public class BombeLaborRate : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string MaterialType { get; set; } = string.Empty;
        public double RatePerKg { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
