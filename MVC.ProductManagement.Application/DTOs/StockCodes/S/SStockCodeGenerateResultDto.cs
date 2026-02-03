using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.S
{
    public sealed class SStockCodeGenerateResultDto
    {
        public bool AlreadyExists { get; set; }
        public Guid StockCardId { get; set; }

        public string StockCode8 { get; set; } = default!; // SFA01000
        public string Prefix4 { get; set; } = default!;    // SFA0
        public int Serial4 { get; set; }                   // 1000..9999

        public string Description { get; set; } = default!;

        // UI geri gösterim (opsiyonel)
        public Guid FluidId { get; set; }
        public Guid SProductGroupId { get; set; }
        public Guid SProductId { get; set; }
        public Guid PrefixRuleId { get; set; }
    }

}
