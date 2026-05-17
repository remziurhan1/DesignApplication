using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.MaterialCatalog
{
    public class MaterialStandard : AuditableEntity
    {
        public string StandardCode { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid MaterialFamilyId { get; set; }
        public virtual MaterialFamily MaterialFamily { get; set; } = default!;

        public Guid MaterialFormId { get; set; }
        public virtual MaterialForm MaterialForm { get; set; } = default!;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
