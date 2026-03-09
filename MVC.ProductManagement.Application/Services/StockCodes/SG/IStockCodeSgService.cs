using MVC.ProductManagement.Application.DTOs.StockCodes.SG;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SG
{
    public interface IStockCodeSgService
    {
        // Ürün listesi
        Task<List<SgProductDto>> GetSgProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SgStockCodeGenerateResultDto> GenerateSgAsync(SgStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeSgFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Liste
        Task<SGStockCardListResultDto> GetStockCardsAsync(SGStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SGStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SGStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}
