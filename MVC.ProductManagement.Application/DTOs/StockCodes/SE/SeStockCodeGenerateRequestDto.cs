using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SE
{
    public class SeStockCodeGenerateRequestDto
    {
        /// <summary>
        /// Seçilen ürün (SEA0, SEB1, SEC2...)
        /// </summary>
        public Guid SProductId { get; set; }

        /// <summary>
        /// Feature seçimleri (Ürün Kategorisi, Malzeme, Kesit/Kapasite, Voltaj, Standart, Renk/Tip)
        /// Key: SFeatureId, Value: SFeatureValueId
        /// </summary>
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
    }
}
