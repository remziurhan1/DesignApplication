using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SF
{
    // ===== LİSTE DTO (Excel export) =====
    public class SFStockCardListDto
    {
        public Guid Id { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
