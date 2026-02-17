using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    /// <summary>
    /// Stok kartı datasheeti (PDF/Döküman)
    /// </summary>
    public class StockCardDatasheet : AuditableEntity
    {
        public Guid StockCardId { get; set; }
        public virtual StockCard StockCard { get; set; }

        /// <summary>
        /// Dosya adı
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Dosya yolu (fiziksel)
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Dosya boyutu (byte)
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// MIME type (application/pdf, image/png, vb.)
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Versiyon numarası
        /// </summary>
        public int Version { get; set; } = 1;

        /// <summary>
        /// Açıklama
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}