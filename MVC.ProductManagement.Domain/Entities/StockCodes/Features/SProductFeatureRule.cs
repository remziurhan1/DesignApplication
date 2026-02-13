using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    /// <summary>
    /// Prefix bazlı feature kuralları
    /// Örnek: SAA0 için STRENGTH = 8.8 (sabit)
    /// Örnek: SAA1 için THREAD = METRIK (sabit)
    /// </summary>
    public class SProductFeatureRule : AuditableEntity
    {
        /// <summary>
        /// Hangi ürün (SAA0, SAB1, vs.)
        /// </summary>
        public Guid SProductId { get; set; }
        public virtual SProduct SProduct { get; set; } = default!;

        /// <summary>
        /// Hangi feature (STANDARD, THREAD, STRENGTH, vs.)
        /// </summary>
        public Guid SFeatureId { get; set; }
        public virtual SFeature SFeature { get; set; } = default!;

        /// <summary>
        /// Sabit mi? (true ise kullanıcı değiştiremez, otomatik atanır)
        /// Örnek: SAA0 için STRENGTH = 8.8 (sabit)
        /// </summary>
        public bool IsFixed { get; set; }

        /// <summary>
        /// Eğer IsFixed = true ise, sabit değer
        /// Örnek: SAA0 için STRENGTH = 8.8 → FixedValueId = SFeatureValue:STRENGTH:8.8
        /// </summary>
        public Guid? FixedValueId { get; set; }
        public virtual SFeatureValue? FixedValue { get; set; }
    }
}