using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    public class SProductFeature : AuditableEntity
    {
        public Guid SProductId { get; set; }
        public virtual SProduct SProduct { get; set; } = default!;

        public Guid SFeatureId { get; set; }
        public virtual SFeature SFeature { get; set; } = default!;

        public bool IsRequired { get; set; }

        /// <summary>
        /// Ürün bazlı sıralama (UI + OptionKey). Null ise SFeature.SortOrder kullanılır.
        /// </summary>
        public int? SortOrder { get; set; }
    }
}
