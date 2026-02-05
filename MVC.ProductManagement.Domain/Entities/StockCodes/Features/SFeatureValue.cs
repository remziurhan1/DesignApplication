using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    public class SFeatureValue : AuditableEntity
    {
        public Guid SFeatureId { get; set; }
        public virtual SFeature SFeature { get; set; } = default!;

        /// <summary>
        /// Sistem kodu: PN40, DN50, EN1092, ASME_B16_5, G, NPT, RF...
        /// OptionKey burada kullanılan değer
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// Kullanıcıya gösterilecek isim
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Aynı feature altındaki sıralama
        /// </summary>
        public int SortOrder { get; set; }
    }
}
