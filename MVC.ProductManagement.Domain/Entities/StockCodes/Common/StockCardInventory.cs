using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    /// <summary>
    /// Stok kartı envanter hareketleri
    /// </summary>
    public class StockCardInventory : AuditableEntity
    {
        public Guid StockCardId { get; set; }
        public virtual StockCard StockCard { get; set; }

        /// <summary>
        /// Hareket tipi (Giriş/Çıkış)
        /// </summary>
        public InventoryMovementType MovementType { get; set; }

        /// <summary>
        /// Miktar
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Hareket öncesi stok
        /// </summary>
        public int StockBefore { get; set; }

        /// <summary>
        /// Hareket sonrası stok
        /// </summary>
        public int StockAfter { get; set; }

        /// <summary>
        /// Hareket tarihi
        /// </summary>
        public DateTime MovementDate { get; set; }

        /// <summary>
        /// Depo/Lokasyon
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Referans belge (İrsaliye, Fatura, vb.)
        /// </summary>
        public string ReferenceDocument { get; set; }

        /// <summary>
        /// Açıklama
        /// </summary>
        public string Description { get; set; }
    }
}