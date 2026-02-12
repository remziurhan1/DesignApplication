using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SE;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SE
{
    public interface IStockCodeSeService
    {
        /// <summary>
        /// Tüm SE ürünlerini getirir (SEA0, SEB1, SEC2...)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSeProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Seçilen ürüne göre feature'ları getirir
        /// </summary>
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// SE stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SeStockCodeGenerateResultDto> GenerateSeAsync(
            SeStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}
