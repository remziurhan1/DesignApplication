using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SC
{
    public interface IStockCodeScService
    {
        // Ürün listesi
        Task<List<ScProductDto>> GetScProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<ScStockCodeGenerateResultDto> GenerateScAsync(ScStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeScFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Liste
        Task<SCStockCardListResultDto> GetStockCardsAsync(SCStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SCStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SCStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}