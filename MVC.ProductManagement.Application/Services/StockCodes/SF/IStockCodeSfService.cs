using MVC.ProductManagement.Application.DTOs.StockCodes.Common;

namespace MVC.ProductManagement.Application.Services.StockCodes.SF
{
    public interface IStockCodeSfService
    {
        /// <summary>
        /// Tüm SF ürünlerini getirir (SFA0, SFA1, SFC0...)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSfProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// SF stok kodu üretir (akışkan yok, feature'larla - SA mantığı)
        /// </summary>
        Task<SfStockCodeGenerateResultDto> GenerateSfAsync(
            SfStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}