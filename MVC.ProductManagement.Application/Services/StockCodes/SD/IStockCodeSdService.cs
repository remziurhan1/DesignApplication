using MVC.ProductManagement.Application.DTOs.StockCodes.SD;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SD
{
    public interface IStockCodeSdService
    {
        // Ürün listesi
        Task<List<SdProductDto>> GetSdProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<SdStockCodeGenerateResultDto> GenerateSdAsync(SdStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeSdFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Liste
        Task<SDStockCardListResultDto> GetStockCardsAsync(SDStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SDStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SDStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}