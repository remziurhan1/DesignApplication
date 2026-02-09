namespace MVC.ProductManagement.Application.DTOs.StockCodes.SB
{
    public class SbStockCodeGenerateRequestDto
    {
        /// <summary>
        /// Seçilen ürün (SBA0, SBA1...)
        /// </summary>
        public Guid SProductId { get; set; }

        /// <summary>
        /// Feature seçimleri (Somun Tipi, Mukavemet, Standart, Ölçü, Yüzey İşlemi)
        /// Key: SFeatureId, Value: SFeatureValueId
        /// </summary>
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
    }
}