using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    /// <summary>
    /// Aktif Fiyat DTO
    /// </summary>
    public class ActivePriceDto
    {
        /// <summary>
        /// Fiyat ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Stok Kartı ID
        /// </summary>
        public Guid StockCardId { get; set; }

        /// <summary>
        /// Stok Kodu
        /// </summary>
        public string StockCode { get; set; }

        /// <summary>
        /// Para Birimi (TRY, USD, EUR)
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Birim Fiyat (KDV Hariç)
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// KDV Oranı (%)
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// KDV Dahil Fiyat
        /// </summary>
        public decimal PriceWithVat { get; set; }

        /// <summary>
        /// Geçerlilik Başlangıç Tarihi
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Geçerlilik Bitiş Tarihi (null ise süresiz)
        /// </summary>
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// Notlar
        /// </summary>
        public string Notes { get; set; }
    }
}
