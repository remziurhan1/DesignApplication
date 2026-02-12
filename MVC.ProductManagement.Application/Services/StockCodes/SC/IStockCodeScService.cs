using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SC
{
    public interface IStockCodeScService
    {
        Task<IReadOnlyList<LookupDto>> GetScProductsAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<ScStockCodeGenerateResultDto> GenerateScAsync(
            ScStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}
