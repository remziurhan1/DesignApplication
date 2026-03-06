using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SF
{
    public class SFStockCardDetailViewModel
    {
        public SFStockCardDetailDto StockCard { get; set; } = default!;
        public List<DatasheetDto> Datasheets { get; set; } = new();
        public List<PriceDto> PriceHistory { get; set; } = new();
        public ActivePriceDto? ActivePrice { get; set; }
        public CurrentInventoryDto? CurrentInventory { get; set; }
        public List<InventoryDto> InventoryMovements { get; set; } = new();
    }
}
