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
        public string Name { get; set; } = string.Empty;              // Örn: P355NH, SA-516 Gr.70
        public string MaterialNumber { get; set; } = string.Empty;    // EN için 1.4301, ASME için designation
        public double Density { get; set; }                           // kg/m³
        public double? ColdStretchYieldStrength { get; set; }         // MPa (örn: 400)
        public double? ElasticModulus { get; set; }                   // MPa (Young modülü, EN dış basınç hesabı)
        public double? YieldFactorK { get; set; }                     // MPa (dış basınç plastisite katsayısı)
        public string? Notes { get; set; }

        public virtual ICollection<MaterialForm> Forms { get; set; } = new List<MaterialForm>();
    }
}
