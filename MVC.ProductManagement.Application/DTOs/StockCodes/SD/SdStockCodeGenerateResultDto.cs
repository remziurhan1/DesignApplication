using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SD
{
    public class SdStockCodeGenerateResultDto
    {
        public bool AlreadyExists { get; set; }
        public Guid StockCardId { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Prefix4 { get; set; } = string.Empty;
        public int Serial4 { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
