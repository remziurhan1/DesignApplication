using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.S
{
    public sealed class SStockCodeGenerateRequestDto
    {
        public Guid FluidId { get; set; }          // LPG/LNG...
        public Guid SProductGroupId { get; set; }  // Tablo-5 (A..H,Z)
        public Guid SProductId { get; set; }       // Ürün (Küresel/Emniyet...)
        public Guid PrefixRuleId { get; set; }

    }
}
