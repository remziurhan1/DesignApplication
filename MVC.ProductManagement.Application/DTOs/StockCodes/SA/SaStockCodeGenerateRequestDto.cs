using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    public class SaStockCodeGenerateRequestDto
    {
        public Guid SProductId { get; set; } // SAA0, SAB1, SAC2...
    }
}
