using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.Costing
{
    public class OverheadRate : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string OverheadType { get; set; } = string.Empty;
        public double Percentage { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
