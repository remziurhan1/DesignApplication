using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SC
{
    // ===== UPDATE =====
    public class SCStockCardUpdateDto
    {
        public Guid StockCardId { get; set; }
        public Dictionary<Guid, Guid> FeatureSelections { get; set; } = new();
    }
}
