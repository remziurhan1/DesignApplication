using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    public class SFeature : AuditableEntity
    {
        /// <summary>
        /// Kısa kod: PN, DN, CONN, STD, THREAD...
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// Görünen ad: Basınç Sınıfı, Anma Çapı, Bağlantı Tipi...
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Ekranda ve OptionKey üretiminde sıralama için
        /// </summary>
        public int SortOrder { get; set; }

        // Navigation
        public virtual ICollection<SFeatureValue> Values { get; set; } = new List<SFeatureValue>();
        public virtual ICollection<SProductFeature> ProductFeatures { get; set; } = new List<SProductFeature>();
    }
}
