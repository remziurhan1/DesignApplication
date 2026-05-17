using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.MaterialCatalog
{
    public class MaterialFamily : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<MaterialStandard> MaterialStandards { get; set; } = new List<MaterialStandard>();
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
