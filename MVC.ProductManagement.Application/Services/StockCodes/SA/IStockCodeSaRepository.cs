using MVC.ProductManagement.Application.DTOs;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA
{
    public interface IStockCodeSaRepository
    {
        Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);

        Task<SAStockCardListResultDto> GetStockCardsAsync(
            SAStockCardFilterDto filter,
            CancellationToken cancellationToken = default);

        Task<SAStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        Task<SAStockCardUpdateDto> GetStockCardForEditAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        Task<bool> UpdateStockCardAsync(
            SAStockCardUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteStockCardAsync(
            Guid stockCardId,
            string userName,
            CancellationToken cancellationToken = default);

        Task<List<FeatureValueDto>> GetFeatureValuesAsync(Guid featureId);

        Task<IReadOnlyList<FeatureDto>> GetAllFeaturesAsync(CancellationToken cancellationToken = default);

        Task<StockCodeSaFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default);
    }
}
