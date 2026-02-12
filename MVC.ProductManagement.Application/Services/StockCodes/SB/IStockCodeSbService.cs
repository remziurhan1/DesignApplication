using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;

namespace MVC.ProductManagement.Application.Services.StockCodes.SB
{
    public interface IStockCodeSbService
    {
        /// <summary>
        /// Tüm SB ürünlerini getirir (SBA0, SBA1...)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSbProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Seçilen ürüne göre feature'ları getirir
        /// </summary>
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// SB stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SbStockCodeGenerateResultDto> GenerateSbAsync(
            SbStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}