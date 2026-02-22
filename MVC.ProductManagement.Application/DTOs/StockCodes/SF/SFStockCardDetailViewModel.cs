using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SF
{
    // ===== DETAY VIEW MODEL =====
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
