using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class InventoryByLocationDto
    {
        public string Location { get; set; }
        public int Quantity { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
