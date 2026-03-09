using MVC.ProductManagement.Application.DTOs.StockCodes.SH;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SH
{
    public interface IStockCodeShService
    {
        // Ürün listesi
        Task<List<ShProductDto>> GetShProductsAsync(CancellationToken ct = default);

        // Kod üretme
        Task<ShStockCodeGenerateResultDto> GenerateShAsync(ShStockCodeGenerateRequestDto request, CancellationToken ct = default);

        // Form data (rule-based)
        Task<StockCodeShFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default);

        // Liste
        Task<SHStockCardListResultDto> GetStockCardsAsync(SHStockCardFilterDto filter, CancellationToken ct = default);

        // Detay
        Task<SHStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken ct = default);

        // Güncelleme
        Task UpdateStockCardAsync(SHStockCardUpdateDto dto, string updatedBy, CancellationToken ct = default);

        // Silme
        Task DeleteStockCardAsync(Guid stockCardId, string deletedBy, CancellationToken ct = default);
    }
}
