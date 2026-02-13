using MVC.ProductManagement.Application.DTOs;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA
{
    public interface IStockCodeSaService
    {
        /// <summary>
        /// 1. SA Ürün listesi
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 2. Ürüne göre feature'ları getir
        /// </summary>
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 3. Kod üretimi
        /// </summary>
        Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 4. Liste (filtreleme + pagination)
        /// </summary>
        Task<SAStockCardListResultDto> GetStockCardsAsync(
            SAStockCardFilterDto filter,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 5. Detay görüntüleme
        /// </summary>
        Task<SAStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 6. Düzenleme için veri getir
        /// </summary>
        Task<SAStockCardUpdateDto> GetStockCardForEditAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 7. Güncelleme
        /// </summary>
        Task<bool> UpdateStockCardAsync(
            SAStockCardUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 8. Silme (soft delete)
        /// </summary>
        Task<bool> DeleteStockCardAsync(
            Guid stockCardId,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 9. Feature değerleri getir
        /// </summary>
        Task<List<FeatureValueDto>> GetFeatureValuesAsync(Guid featureId);
    }
}