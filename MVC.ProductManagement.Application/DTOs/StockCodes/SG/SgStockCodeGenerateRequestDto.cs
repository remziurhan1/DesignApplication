namespace MVC.ProductManagement.Application.DTOs.StockCodes.SG
{
    public class SgStockCodeGenerateRequestDto
    {
        /// <summary>
        /// Seçilen ürün (SGA0, SGA1, SGA2...)
        /// </summary>
        public Guid SProductId { get; set; }

        /// <summary>
        /// Feature seçimleri (Malzeme, Standart, Çap, Boy, Kaplama)
        /// Key: SFeatureId, Value: SFeatureValueId
        /// </summary>
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
    }
}