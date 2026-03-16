using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    /// <summary>
    /// Stok kartı fiyat geçmişi
    /// </summary>
    public class StockCardPrice : AuditableEntity
    {
        public Guid StockCardId { get; set; }
        public virtual StockCard StockCard { get; set; }

        /// <summary>
        /// Para birimi (TRY, USD, EUR)
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Birim fiyat
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Hedef fiyat (opsiyonel)
        /// </summary>
        public decimal? TargetPrice { get; set; }

        /// <summary>
        /// Geçerlilik başlangıç tarihi
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Geçerlilik bitiş tarihi (null ise süresiz)
        /// </summary>
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Notlar
        /// </summary>
        public string Notes { get; set; }

        // ✅ Mevcut property'lerin ALTINA EKLE
        public virtual ICollection<StockCardDatasheet> Datasheets { get; set; }
        public virtual ICollection<StockCardPrice> Prices { get; set; }
        public virtual ICollection<StockCardInventory> InventoryMovements { get; set; }
    }
}
