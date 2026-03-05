using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes
{
    /// <summary>
    /// Stok Kartı detay sayfasında kullanılan ortak ViewModel.
    /// </summary>
    public class StockCardDetailViewModel<TStockCardDetail> where TStockCardDetail : class
    {
        public TStockCardDetail StockCard { get; set; } = default!;
        public CurrentInventoryDto? CurrentInventory { get; set; }
        public IReadOnlyList<InventoryDto> InventoryMovements { get; set; } = new List<InventoryDto>();
        public IReadOnlyList<DatasheetDto> Datasheets { get; set; } = new List<DatasheetDto>();
        public IReadOnlyList<PriceDto> PriceHistory { get; set; } = new List<PriceDto>();
        public ActivePriceDto? ActivePrice { get; set; }
    }
}
