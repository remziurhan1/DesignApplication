using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    namespace MVC.ProductManagement.Domain.Entities
    {
        /// <summary>
        /// Gaz tipine ait basınç seçenekleri
        /// </summary>
        public class GasTypePressure : AuditableEntity
        {
            /// <summary>
            /// Gaz tipi ID
            /// </summary>
            public Guid GasTypeId { get; set; }

            /// <summary>
            /// Basınç değeri (bar)
            /// </summary>
            public double PressureValue { get; set; }

            /// <summary>
            /// Görünen isim (örn: "17 bar", "37 bar")
            /// </summary>
            public string DisplayName { get; set; } = string.Empty;

            /// <summary>
            /// Aktif mi?
            /// </summary>
            public bool IsActive { get; set; } = true;

            /// <summary>
            /// Sıralama
            /// </summary>
            public int DisplayOrder { get; set; }

            // Navigation Property
            public virtual GasType GasType { get; set; } = null!;
        }
    }
}
