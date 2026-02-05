using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    /// <summary>
    /// Tüm gruplar için ortak lookup servisi
    /// </summary>
    public interface IStockCodeLookupService
    {
        Task<IReadOnlyList<LookupDto>> GetAllFluidsAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default);
    }
}
