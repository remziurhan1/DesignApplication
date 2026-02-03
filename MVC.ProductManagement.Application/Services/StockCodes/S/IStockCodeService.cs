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
        // Dropdown kaynakları
        Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<LookupDto>> GetSProductsAsync(Guid sProductGroupId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<LookupDto>> GetPrefixRulesAsync(
    Guid fluidId,
    Guid sProductGroupId,
    Guid sProductId,
    CancellationToken cancellationToken = default);


        // Asıl iş: kod üret / varsa getir
        Task<SStockCodeGenerateResultDto> GenerateSAsync(
            SStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        // Listeleme (opsiyonel ama pratik)
        Task<IReadOnlyList<StockCardListItemDto>> ListSStockCardsAsync(
            int take = 200,
            CancellationToken cancellationToken = default);
    }
}
