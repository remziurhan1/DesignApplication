using MVC.ProductManagement.Application.DTOs.StockCodes.SE;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SE
{
    public interface IStockCodeSeService
    {
        // Ürün listesi
        Task<List<SeProductDto>> GetSeProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SeStockCodeGenerateResultDto> GenerateSeAsync(SeStockCodeGenerateRequestDto request, CancellationToken ct = default);

        /// <summary>
        /// SE stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SeStockCodeGenerateResultDto> GenerateSeAsync(
            SeStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        Task<GenericStockCodeFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<GenericStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);
    }
}