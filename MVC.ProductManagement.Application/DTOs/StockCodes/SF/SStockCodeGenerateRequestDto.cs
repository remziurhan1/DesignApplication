using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.S
{
    public class SfStockCodeGenerateRequestDto
    {
        public Guid FluidId { get; set; }
        public Guid SProductId { get; set; } // F0, F1, F2...
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
        // Key: FeatureId (PN, DN, SURFACE)
        // Value: FeatureValueId (PN40, DN50, RF)
    }
}
