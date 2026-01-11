using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    /// <summary>
    /// Tasarım Standardı (ASME, EN 13458, AD2000, GOST...)
    /// </summary>
    public class DesignStandard : AuditableEntity
    {
        /// <summary>
        /// Standart adı (örn: "ASME Section VIII Div. 1")
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Kısa kod (örn: "ASME-VIII-1", "EN-13458")
        /// </summary>
        public string Code { get; set; } = string.Empty;

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
        public virtual ICollection<GasTypeDesignStandard> GasTypes { get; set; } = new List<GasTypeDesignStandard>();
    }
}
