using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    /// <summary>
    /// Prefix + Feature bazında izinli değerler
    /// Örnek: SAA0 + MATERIAL → KARBON, ALAŞIMLI (sadece bunlar gösterilir)
    /// Örnek: SAA6 + MATERIAL → 304, 316 (sadece bunlar gösterilir)
    /// </summary>
    public class SFeatureValueRule : AuditableEntity
    {
        /// <summary>
        /// Hangi ürün (SAA0, SAB1, vs.)
        /// </summary>
        public Guid SProductId { get; set; }
        public virtual SProduct SProduct { get; set; } = default!;

        /// <summary>
        /// Hangi feature (MATERIAL, COATING, vs.)
        /// </summary>
        public Guid SFeatureId { get; set; }
        public virtual SFeature SFeature { get; set; } = default!;

        /// <summary>
        /// İzinli değer (KARBON, 304, CINKO, vs.)
        /// </summary>
        public Guid SFeatureValueId { get; set; }
        public virtual SFeatureValue SFeatureValue { get; set; } = default!;

        /// <summary>
        /// Sıralama (dropdown'da gösterim sırası)
        /// </summary>
        public int SortOrder { get; set; }
    }
}