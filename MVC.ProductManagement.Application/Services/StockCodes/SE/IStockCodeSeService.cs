using MVC.ProductManagement.Application.DTOs.StockCodes.SE;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SE
{
    public interface IStockCodeSeService
    {
        // Ürün listesi
        Task<List<SeProductDto>> GetSeProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SeStockCodeGenerateResultDto> GenerateSeAsync(SeStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeSeFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Liste
        Task<SEStockCardListResultDto> GetStockCardsAsync(SEStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SEStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SEStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}