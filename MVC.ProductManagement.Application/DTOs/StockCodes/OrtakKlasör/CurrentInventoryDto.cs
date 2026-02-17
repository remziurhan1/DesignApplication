using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class CurrentInventoryDto
    {
        public Guid StockCardId { get; set; }
        public string StockCode { get; set; }
        public int CurrentStock { get; set; }
        public DateTime? LastMovementDate { get; set; }
        public List<InventoryByLocationDto> ByLocation { get; set; } = new();
    }

}
