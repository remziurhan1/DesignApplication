using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{
    public class StockCodeGenerateResultDto
    {
        public string StockCode8 { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool AlreadyExists { get; set; }
    }
}
