using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    /// <summary>
    /// Feature değerleri arası bağımlılık kuralları
    /// Örnek: MATERIAL = 304 → STRENGTH sadece A2-70, A4-80
    /// Örnek: MATERIAL = 304 → COATING sadece "-"
    /// Örnek: STRENGTH = 12.9 → COATING sadece SIYAH OKSIT
    /// </summary>
    public class SFeatureValueDependency : AuditableEntity
    {
        /// <summary>
        /// Hangi ürün (SAA6, SAB2, vs.) - opsiyonel (null ise tüm ürünler için geçerli)
        /// </summary>
        public Guid? SProductId { get; set; }
        public virtual SProduct? SProduct { get; set; }

        /// <summary>
        /// Kaynak Feature (MATERIAL, STRENGTH, vs.)
        /// </summary>
        public Guid SourceFeatureId { get; set; }
        public virtual SFeature SourceFeature { get; set; } = default!;

        /// <summary>
        /// Kaynak Değer (304, 12.9, vs.)
        /// </summary>
        public Guid SourceValueId { get; set; }
        public virtual SFeatureValue SourceValue { get; set; } = default!;

        /// <summary>
        /// Hedef Feature (STRENGTH, COATING, vs.)
        /// </summary>
        public Guid TargetFeatureId { get; set; }
        public virtual SFeature TargetFeature { get; set; } = default!;

        /// <summary>
        /// Hedef Değer (A2-70, "-", SIYAH OKSIT, vs.)
        /// </summary>
        public Guid TargetValueId { get; set; }
        public virtual SFeatureValue TargetValue { get; set; } = default!;

        /// <summary>
        /// Zorunluluk tipi
        /// REQUIRED: Bu değer seçilmek ZORUNDA
        /// ALLOWED: Bu değer seçilebilir
        /// FORBIDDEN: Bu değer YASAK
        /// </summary>
        public DependencyType Type { get; set; }
    }

    public enum DependencyType
    {
        /// <summary>
        /// Zorunlu: Kaynak seçilince hedef de seçilmek ZORUNDA
        /// Örnek: MATERIAL=304 → COATING="-" (REQUIRED)
        /// </summary>
        REQUIRED = 1,

        /// <summary>
        /// İzinli: Kaynak seçilince hedef seçilebilir
        /// Örnek: MATERIAL=KARBON → COATING=CINKO (ALLOWED)
        /// </summary>
        ALLOWED = 2,

        /// <summary>
        /// Yasak: Kaynak seçilince hedef SEÇİLEMEZ
        /// Örnek: MATERIAL=304 → STRENGTH=12.9 (FORBIDDEN)
        /// </summary>
        FORBIDDEN = 3
    }
}