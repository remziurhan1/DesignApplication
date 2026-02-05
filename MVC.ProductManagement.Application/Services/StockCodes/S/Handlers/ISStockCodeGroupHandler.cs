using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Handlers
{
    public interface ISStockCodeGroupHandler
    {
        string GroupCode { get; }

        // ✅ Bu grup için akışkan gerekli mi?
        bool RequiresFluid { get; }

        Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetFluidsAsync(Guid groupId);

        // ✅ fluidId artık opsiyonel
        Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetProductsAsync(Guid groupId, Guid? fluidId);

        // ✅ NEW: Feature seçimleri eklendi
        Task<StockCodeGenerateResultDto> GenerateAsync(
            Guid groupId,
            Guid? fluidId,
            Guid productId,
            Dictionary<Guid, Guid>? selectedFeatureValues = null,
            CancellationToken cancellationToken = default);
    }
}
