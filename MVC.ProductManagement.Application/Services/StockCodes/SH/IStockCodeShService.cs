using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SH;

namespace MVC.ProductManagement.Application.Services.StockCodes.SH
{
    public interface IStockCodeShService
    {
        /// <summary>
        /// Tüm SH ürünlerini getirir (SHA0, SHA1, SHA2...)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetShProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Seçilen ürüne göre feature'ları getirir
        /// </summary>
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// SH stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<ShStockCodeGenerateResultDto> GenerateShAsync(
            ShStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        Task<GenericStockCodeFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<GenericStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);
    }
}
