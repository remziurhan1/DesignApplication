using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SC
{
    public class ScStockCodeGenerateRequestDto
    {
        public Guid SProductId { get; set; }
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
    }
}
