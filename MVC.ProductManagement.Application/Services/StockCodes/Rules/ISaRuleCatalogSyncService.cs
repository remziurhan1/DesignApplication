using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Rules
{
    public interface ISaRuleCatalogSyncService
    {
        Task SyncAsync(CancellationToken cancellationToken = default);
    }
}
