using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class PriceDto
    {
        public Guid Id { get; set; }
        public Guid StockCardId { get; set; }
        public string StockCode { get; set; }
        public string Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal PriceWithVat { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
