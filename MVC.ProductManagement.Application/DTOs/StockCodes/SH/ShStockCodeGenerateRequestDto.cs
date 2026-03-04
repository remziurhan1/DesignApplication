namespace MVC.ProductManagement.Application.DTOs.StockCodes.SH
{
    public class ShStockCodeGenerateRequestDto
    {
        /// <summary>
        /// Seçilen ürün (SHA0, SHA1, SHA2...)
        /// </summary>
        public Guid SProductId { get; set; }

        /// <summary>
        /// Feature seçimleri (Malzeme, Standart, Çap, Boy, Kaplama)
        /// Key: SFeatureId, Value: SFeatureValueId
        /// </summary>
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
    }
}