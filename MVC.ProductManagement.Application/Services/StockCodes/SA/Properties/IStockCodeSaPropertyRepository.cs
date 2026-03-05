using MVC.ProductManagement.Application.DTOs.StockCodes.SA.Properties;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA.Properties
{
    public interface IStockCodeSaPropertyRepository
    {
        Task<IReadOnlyList<SaStockCodePropertyListDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<SaStockCodePropertyListDto>> GetByProductAsync(Guid productId, CancellationToken cancellationToken = default);
        Task<SaStockCodePropertyUpdateDto> GetForEditAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> AddAsync(SaStockCodePropertyCreateDto dto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(SaStockCodePropertyUpdateDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
