using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class Material : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;              // Örn: P355NH, SA-516 Gr.70
        public string MaterialNumber { get; set; } = string.Empty;    // EN için 1.4301, ASME için designation
        public MaterialStandard Standard { get; set; }                // EN, ASME, ASTM...
        public string Group { get; set; } = string.Empty;             // Carbon steel, Stainless steel...
        public double Density { get; set; }                           // kg/m³
        public string? Notes { get; set; }

        public virtual ICollection<MaterialForm> Forms { get; set; } = new List<MaterialForm>();
    }
}
