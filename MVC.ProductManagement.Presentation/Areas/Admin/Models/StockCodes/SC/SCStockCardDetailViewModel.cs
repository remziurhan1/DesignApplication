using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.DTOs.StockCodes.SC;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SC
{
    public class SCStockCardDetailViewModel
    {
        public SCStockCardDetailDto StockCard { get; set; } = default!;
        public List<DatasheetDto> Datasheets { get; set; } = new();
        public List<PriceDto> PriceHistory { get; set; } = new();
        public ActivePriceDto? ActivePrice { get; set; }
        public CurrentInventoryDto? CurrentInventory { get; set; }
        public List<InventoryDto> InventoryMovements { get; set; } = new();
    }
}
