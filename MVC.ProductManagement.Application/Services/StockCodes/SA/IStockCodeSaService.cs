using MVC.ProductManagement.Application.DTOs.Common;
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
        /// 1. Prefix listesi getir (SAA0, SAA1, SAB0, vs.)
        /// </summary>
        Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 2. ✅ YENİ: Prefix seçildiğinde kural bazlı form verilerini getir
        /// (sabit feature'lar otomatik doldurulmuş + izinli değerler)
        /// </summary>
        Task<StockCodeSaFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 3. ✅ YENİ: Kullanıcı bir feature seçtiğinde, bağımlılıklara göre filtrelenmiş değerleri getir
        /// (AJAX için)
        /// </summary>
        Task<List<FeatureValueDto>> GetFilteredValuesAsync(
            Guid productId,
            Guid featureId,
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 4. ✅ ESKİ METOD - KALDIRILIYOR (artık GetFormDataAsync kullanılıyor)
        /// </summary>
        [Obsolete("GetFormDataAsync kullanın")]
        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 5. Stok kodu oluştur (validasyon + kural kontrolü + kayıt)
        /// </summary>
        Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 6. ✅ YENİ: SA Stok Kartlarını listele ve filtrele
        /// </summary>
        Task<PagedResult<SAStockCardListDto>> GetStockCardsAsync(
            SAStockCardFilterDto filter,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 7. ✅ YENİ: SA Stok Kartı detayını getir
        /// </summary>
        Task<SAStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);
    }
}