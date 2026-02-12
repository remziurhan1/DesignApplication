using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SG;

namespace MVC.ProductManagement.Application.Services.StockCodes.SG
{
    public interface IStockCodeSgService
    {
        /// <summary>
        /// Tüm SG ürünlerini getirir (SGA0, SGA1, SGA2...)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSgProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Seçilen ürüne göre feature'ları getirir
        /// </summary>
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// SG stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SgStockCodeGenerateResultDto> GenerateSgAsync(
            SgStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}