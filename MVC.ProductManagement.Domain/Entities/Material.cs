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
        public string? SymbolicName { get; set; }                     // Örn: P355GH, X2CrNi18-9
        public string MaterialNumber { get; set; } = string.Empty;    // EN için 1.4301, ASME için designation
        public MaterialStandard Standard { get; set; }                // EN, ASME, ASTM...
        public string Origin { get; set; } = string.Empty;            // Plate, Forging, Welded Tube...
        public string Group { get; set; } = string.Empty;             // Carbon steel, Stainless steel...
        public string Norm { get; set; } = string.Empty;              // ASME II, ASTM, EN10028-2...
        public string? StockCode { get; set; }                        // Harici stok kod referansı (nullable)
        public double Density { get; set; }                           // kg/m³
        public double? ColdStretchYieldStrength { get; set; }         // MPa (örn: 400)
        public double? ElasticModulus { get; set; }                   // MPa (Young modülü, EN dış basınç hesabı)
        public double? YieldFactorK { get; set; }                     // MPa (dış basınç plastisite katsayısı)
        public string? Notes { get; set; }

        public virtual ICollection<MaterialForm> Forms { get; set; } = new List<MaterialForm>();
    }
}
