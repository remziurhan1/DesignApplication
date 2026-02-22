using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SF
{
    public class SFStockCardFilterDto
    {
        public string? SearchTerm { get; set; }
        public Guid? ProductId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}
