using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    /// <summary>
    /// Kapasite Seçeneği (3, 6, 10, 15, 20, 22 m³)
    /// </summary>
    public class CapacityOption : AuditableEntity
    {
        /// <summary>
        /// Kapasite grubu ID
        /// </summary>
        public Guid CapacityGroupId { get; set; }

        /// <summary>
        /// Kapasite değeri (m³)
        /// </summary>
        public double CapacityValue { get; set; }

        /// <summary>
        /// Görünen isim (örn: "10 m³")
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Varsayılan gövde boyu (mm) - STD tanklar için
        /// </summary>
        public double? DefaultShellLength { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Sıralama
        /// </summary>
        public int DisplayOrder { get; set; }

        // Navigation Property
        public virtual CapacityGroup CapacityGroup { get; set; } = null!;
    }
}
