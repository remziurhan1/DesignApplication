using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SF
{
    public interface IStockCodeSfService
    {
        // Ürün listesi
        Task<List<SfProductDto>> GetSfProductsAsync(CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeSfFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Kod üretme
        Task<SfStockCodeGenerateResultDto> GenerateSfAsync(SfStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Liste
        Task<SFStockCardListResultDto> GetStockCardsAsync(SFStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SFStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SFStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}