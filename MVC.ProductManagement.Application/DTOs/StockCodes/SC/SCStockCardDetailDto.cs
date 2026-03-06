using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SC
{
    public class SCStockCardDetailDto
    {
        public Guid Id { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Prefix4 { get; set; } = string.Empty;
        public int Serial4 { get; set; }
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public List<SCFeatureSelectionDto> FeatureSelections { get; set; } = new();
    }
}
