using MVC.ProductManagement.Application.DTOs.StockCodes.SG;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SG
{
    public interface IStockCodeSgService
    {
        // Ürün listesi
        Task<List<SgProductDto>> GetSgProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SgStockCodeGenerateResultDto> GenerateSgAsync(SgStockCodeGenerateRequestDto request, CancellationToken ct = default);

        /// <summary>
        /// SG stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SgStockCodeGenerateResultDto> GenerateSgAsync(
            SgStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        Task<GenericStockCodeFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<GenericStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);
    }
}
