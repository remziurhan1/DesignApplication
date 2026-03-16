using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class MaterialForm : AuditableEntity
    {
        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public MaterialFormType FormType { get; set; }                // Plate, Pipe, Forging, Bar
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public string ProductStandard { get; set; } = string.Empty;   // EN 10028-3, ASME II-D...
        public double? WeldingFactor { get; set; }                    // ASME’de E faktörü, EN’de boş olabilir
        public string? Notes { get; set; }
        public double UnitPrice { get; set; }
        public double? TargetPrice { get; set; }
        public double? ColdStretchYieldStrength { get; set; }         // MPa (sadece plate/paslanmaz senaryoları için)
        public double? SectionArea { get; set; }                      // mm² (profil kesit alanı)
        public double? MomentOfInertia { get; set; }                  // mm4 (atalet momenti)
        public double? SectionModulus { get; set; }                   // mm3 (mukavemet momenti)

        public virtual ICollection<YieldStrength> YieldStrengths { get; set; } = new List<YieldStrength>();
        public virtual ICollection<AllowableStress> AllowableStresses { get; set; } = new List<AllowableStress>();
    }
}
