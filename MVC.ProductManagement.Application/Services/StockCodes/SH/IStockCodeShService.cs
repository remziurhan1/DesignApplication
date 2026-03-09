using MVC.ProductManagement.Application.DTOs.StockCodes.SH;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SH
{
    public interface IStockCodeShService
    {
        // Ürün listesi
        Task<List<ShProductDto>> GetShProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<ShStockCodeGenerateResultDto> GenerateShAsync(ShStockCodeGenerateRequestDto request, CancellationToken ct = default);

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
