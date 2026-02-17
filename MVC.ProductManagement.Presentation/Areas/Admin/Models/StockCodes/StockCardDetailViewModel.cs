using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{
    /// <summary>
    /// Stok Kartı Detay sayfası için tüm modülleri içeren ViewModel
    /// SA, SB, SC, SD, SE, SF, SG için ortak kullanılır
    /// </summary>
    /// <typeparam name="TStockCardDetail">Stok kartı detay DTO tipi (SAStockCardDetailDto, SBStockCardDetailDto, vb.)</typeparam>
    public class StockCardDetailViewModel<TStockCardDetail> where TStockCardDetail : class
    {
        /// <summary>
        /// Stok kartı genel bilgileri
        /// </summary>
        public TStockCardDetail StockCard { get; set; }

        /// <summary>
        /// Mevcut stok durumu
        /// </summary>
        public CurrentInventoryDto CurrentInventory { get; set; }

        /// <summary>
        /// Stok hareketleri geçmişi
        /// </summary>
        public IReadOnlyList<InventoryDto> InventoryMovements { get; set; } = new List<InventoryDto>();

        /// <summary>
        /// Teknik dökümanlar (Datasheets)
        /// </summary>
        public IReadOnlyList<DatasheetDto> Datasheets { get; set; } = new List<DatasheetDto>();

        /// <summary>
        /// Fiyat geçmişi
        /// </summary>
        public IReadOnlyList<PriceDto> PriceHistory { get; set; } = new List<PriceDto>();

        /// <summary>
        /// Aktif fiyat bilgisi
        /// </summary>
        public ActivePriceDto ActivePrice { get; set; }
    }
}