using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.Costing
{
    public class LaborRate : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public double HourlyRate { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
