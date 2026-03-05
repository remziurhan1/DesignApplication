using MVC.ProductManagement.Application.DTOs;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA
{
    public class StockCodeSaAppService : IStockCodeSaAppService
    {
        private readonly IStockCodeSaRepository _repository;

        public StockCodeSaAppService(IStockCodeSaRepository repository)
        {
            _repository = repository;
        }

        public Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default)
            => _repository.GetSaProductsAsync(cancellationToken);

        public Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(Guid productId, CancellationToken cancellationToken = default)
            => _repository.GetFeaturesByProductAsync(productId, cancellationToken);

        public Task<SaStockCodeGenerateResultDto> GenerateSaAsync(SaStockCodeGenerateRequestDto request, CancellationToken cancellationToken = default)
            => _repository.GenerateSaAsync(request, cancellationToken);

        public Task<SAStockCardListResultDto> GetStockCardsAsync(SAStockCardFilterDto filter, CancellationToken cancellationToken = default)
            => _repository.GetStockCardsAsync(filter, cancellationToken);

        public Task<SAStockCardDetailDto> GetStockCardDetailAsync(Guid stockCardId, CancellationToken cancellationToken = default)
            => _repository.GetStockCardDetailAsync(stockCardId, cancellationToken);

        public Task<SAStockCardUpdateDto> GetStockCardForEditAsync(Guid stockCardId, CancellationToken cancellationToken = default)
            => _repository.GetStockCardForEditAsync(stockCardId, cancellationToken);

        public Task<bool> UpdateStockCardAsync(SAStockCardUpdateDto updateDto, string userName, CancellationToken cancellationToken = default)
            => _repository.UpdateStockCardAsync(updateDto, userName, cancellationToken);

        public Task<bool> DeleteStockCardAsync(Guid stockCardId, string userName, CancellationToken cancellationToken = default)
            => _repository.DeleteStockCardAsync(stockCardId, userName, cancellationToken);

        public Task<List<FeatureValueDto>> GetFeatureValuesAsync(Guid featureId)
            => _repository.GetFeatureValuesAsync(featureId);

        public Task<IReadOnlyList<FeatureDto>> GetAllFeaturesAsync(CancellationToken cancellationToken = default)
            => _repository.GetAllFeaturesAsync(cancellationToken);

        public Task<StockCodeSaFormDto> GetFormDataAsync(Guid productId, CancellationToken cancellationToken = default)
            => _repository.GetFormDataAsync(productId, cancellationToken);
    }
}
