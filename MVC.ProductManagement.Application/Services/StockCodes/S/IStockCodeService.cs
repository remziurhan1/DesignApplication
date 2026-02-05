using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S
{
    public interface IStockCodeService
    {
        Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default);

        // ✅ Group seçilince: Fluid listesi
        Task<IReadOnlyList<LookupDto>> GetFluidsByGroupAsync(Guid sProductGroupId, CancellationToken cancellationToken = default);

        // ✅ Group + Fluid seçilince: Product listesi
        Task<IReadOnlyList<LookupDto>> GetSProductsAsync(Guid sProductGroupId, Guid fluidId, CancellationToken cancellationToken = default);

        Task<SStockCodeGenerateResultDto> GenerateSAsync(
    SStockCodeGenerateRequestDto request,
    CancellationToken cancellationToken = default);


        Task<IReadOnlyList<StockCardListItemDto>> ListSStockCardsAsync(
            int take = 200,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<LookupDto>> GetAllFluidsAsync(CancellationToken cancellationToken = default);

    }
}
