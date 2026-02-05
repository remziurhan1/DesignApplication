using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SB
{
    public class SbStockCodeGenerateRequestDto
    {
        public Guid FluidId { get; set; }
        public Guid SProductId { get; set; } // SBA0, SBB3...
    }
}
