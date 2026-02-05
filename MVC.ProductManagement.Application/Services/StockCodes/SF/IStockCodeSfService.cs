using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SF
{
    public interface IStockCodeSfService
    {
        Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<LookupDto>> GetSfProductsAsync(
            Guid fluidId,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<SfStockCodeGenerateResultDto> GenerateSfAsync(
            SfStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}
