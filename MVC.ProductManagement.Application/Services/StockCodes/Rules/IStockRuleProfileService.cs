using System.Threading;
using System.Threading.Tasks;
using MVC.ProductManagement.Application.DTOs.StockCodes.Rules;

namespace MVC.ProductManagement.Application.Services.StockCodes.Rules
{
    public interface IStockRuleProfileService
    {
        Task<StockRuleProfileDto> GetProfileAsync(string groupCode, CancellationToken cancellationToken = default);
    }
}
