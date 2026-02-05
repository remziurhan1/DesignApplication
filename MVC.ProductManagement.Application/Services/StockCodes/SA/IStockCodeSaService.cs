using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA
{
    public interface IStockCodeSaService
    {
        Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default);

        Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}
