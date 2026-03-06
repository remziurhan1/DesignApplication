using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Rules
{
    public interface IRuleCatalogSyncService
    {
        Task SyncAsync(CancellationToken cancellationToken = default);
    }
}
