using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SB
{
    public interface IStockCodeSbService
    {
        // Ürün listesi
        Task<List<SbProductDto>> GetSbProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SbStockCodeGenerateResultDto> GenerateSbAsync(SbStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeSbFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Liste
        Task<SBStockCardListResultDto> GetStockCardsAsync(SBStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SBStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SBStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}