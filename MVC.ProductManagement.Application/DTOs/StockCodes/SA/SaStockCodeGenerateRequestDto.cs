using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    public sealed class SaStockCodeGenerateRequestDto
    {
        public Guid FluidId { get; set; }          // ✅ seçilecek
        public Guid SProductGroupId { get; set; }  // A
        public Guid SProductId { get; set; }       // SAA0...
    }
}
