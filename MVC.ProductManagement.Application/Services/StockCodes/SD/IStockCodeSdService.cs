using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SD
{
    public interface IStockCodeSdService
    {
        /// <summary>
        /// Tüm SD ürünlerini getirir (SDA0, SDB1, SDC2...)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSdProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Seçilen ürüne göre feature'ları getirir
        /// </summary>
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// SD stok kodu üretir (akışkan yok, feature'larla)
        /// </summary>
        Task<SdStockCodeGenerateResultDto> GenerateSdAsync(
            SdStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}
