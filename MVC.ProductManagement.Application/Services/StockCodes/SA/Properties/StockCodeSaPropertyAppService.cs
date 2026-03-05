using MVC.ProductManagement.Application.DTOs.StockCodes.SA.Properties;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA.Properties
{
    public class StockCodeSaPropertyAppService : IStockCodeSaPropertyAppService
    {
        private readonly IStockCodeSaPropertyRepository _repository;

        public StockCodeSaPropertyAppService(IStockCodeSaPropertyRepository repository)
        {
            _repository = repository;
        }

        public Task<IReadOnlyList<SaStockCodePropertyListDto>> GetAllAsync(CancellationToken cancellationToken = default)
            => _repository.GetAllAsync(cancellationToken);

        public Task<IReadOnlyList<SaStockCodePropertyListDto>> GetByProductAsync(Guid productId, CancellationToken cancellationToken = default)
            => _repository.GetByProductAsync(productId, cancellationToken);

        public Task<SaStockCodePropertyUpdateDto> GetForEditAsync(Guid id, CancellationToken cancellationToken = default)
            => _repository.GetForEditAsync(id, cancellationToken);

        public async Task<Guid> AddAsync(SaStockCodePropertyCreateDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.ProductId == Guid.Empty) throw new InvalidOperationException("Ürün seçimi zorunludur.");
            if (dto.FeatureId == Guid.Empty) throw new InvalidOperationException("Feature seçimi zorunludur.");
            if (dto.IsFixed && !dto.FixedValueId.HasValue) throw new InvalidOperationException("Sabit feature için değer seçimi zorunludur.");

            return await _repository.AddAsync(dto, cancellationToken);
        }

        public async Task<bool> UpdateAsync(SaStockCodePropertyUpdateDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.Id == Guid.Empty) throw new InvalidOperationException("Kural kaydı seçimi zorunludur.");
            if (dto.ProductId == Guid.Empty) throw new InvalidOperationException("Ürün seçimi zorunludur.");
            if (dto.FeatureId == Guid.Empty) throw new InvalidOperationException("Feature seçimi zorunludur.");
            if (dto.IsFixed && !dto.FixedValueId.HasValue) throw new InvalidOperationException("Sabit feature için değer seçimi zorunludur.");

            return await _repository.UpdateAsync(dto, cancellationToken);
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty) throw new InvalidOperationException("Silinecek kayıt seçilmedi.");
            return _repository.DeleteAsync(id, cancellationToken);
        }
    }
}
