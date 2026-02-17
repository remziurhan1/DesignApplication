using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class PriceUpdateDto
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}
