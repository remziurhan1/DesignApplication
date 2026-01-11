using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    /// <summary>
    /// Kapasite Grubu (Çap-Kapasite eşleştirmesi)
    /// </summary>
    public class CapacityGroup : AuditableEntity
    {
        /// <summary>
        /// Grup adı (örn: "Grup 1 - 1675mm")
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// İç tank çapı (mm)
        /// </summary>
        public double InnerDiameter { get; set; }

        /// <summary>
        /// Minimum kapasite (m³)
        /// </summary>
        public double MinCapacity { get; set; }

        /// <summary>
        /// Maximum kapasite (m³)
        /// </summary>
        public double MaxCapacity { get; set; }

        /// <summary>
        /// Açıklama
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Sıralama
        /// </summary>
        public int DisplayOrder { get; set; }

        // Navigation Properties
        public virtual ICollection<CapacityOption> CapacityOptions { get; set; } = new List<CapacityOption>();
    }
}
