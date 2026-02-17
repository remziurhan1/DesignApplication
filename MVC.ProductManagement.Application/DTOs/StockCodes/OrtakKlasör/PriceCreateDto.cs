using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class PriceCreateDto
    {
        public Guid StockCardId { get; set; }
        public string Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; } = 20;
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Notes { get; set; }
    }
}
