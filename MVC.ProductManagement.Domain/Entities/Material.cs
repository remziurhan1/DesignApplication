using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class Material : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;              // Legacy display name (Örn: P355NH, SA-516 Gr.70)
        public string Grade { get; set; } = string.Empty;             // Yeni katalog grade alanı (P355GH, A516 Gr.70 vb.)
        public string MaterialNumber { get; set; } = string.Empty;    // EN için 1.4301, ASME için designation
        public string? Description { get; set; }
        public double Density { get; set; }                           // kg/m³

        public Guid? MaterialFamilyId { get; set; }
        public virtual MaterialCatalog.MaterialFamily? MaterialFamily { get; set; }

        public Guid? MaterialFormId { get; set; }
        public virtual MaterialForm? MaterialForm { get; set; }

        public Guid? MaterialStandardId { get; set; }
        public virtual MaterialCatalog.MaterialStandard? MaterialStandard { get; set; }

        public string? Notes { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<MaterialForm> Forms { get; set; } = new List<MaterialForm>();
        public virtual ICollection<MaterialCatalog.MaterialMechanicalProperty> MechanicalProperties { get; set; } = new List<MaterialCatalog.MaterialMechanicalProperty>();
        public virtual ICollection<StockCodes.Common.StockCard> StockCards { get; set; } = new List<StockCodes.Common.StockCard>();
    }
}
