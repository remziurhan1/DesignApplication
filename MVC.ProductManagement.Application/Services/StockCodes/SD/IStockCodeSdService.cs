using MVC.ProductManagement.Application.DTOs.StockCodes.SD;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SD
{
    public interface IStockCodeSdService
    {
        // Ürün listesi
        Task<List<SdProductDto>> GetSdProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SdStockCodeGenerateResultDto> GenerateSdAsync(SdStockCodeGenerateRequestDto request, CancellationToken ct = default);

        /// <summary>
        /// SD stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SdStockCodeGenerateResultDto> GenerateSdAsync(
            SdStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        Task<GenericStockCodeFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<GenericStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);
    }
}