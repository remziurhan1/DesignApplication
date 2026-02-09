using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SD
{
    public class SdStockCodeGenerateRequestDto
    {
        /// <summary>
        /// Seçilen ürün (SDA0, SDB1, SDC2...)
        /// </summary>
        public Guid SProductId { get; set; }

        /// <summary>
        /// Feature seçimleri (Bağlantı Tipi, Malzeme, Standart, Ölçü, Açı, Yüzey İşlemi)
        /// Key: SFeatureId, Value: SFeatureValueId
        /// </summary>
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
    }
}
