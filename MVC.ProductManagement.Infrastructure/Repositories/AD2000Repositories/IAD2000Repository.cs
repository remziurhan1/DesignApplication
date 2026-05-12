using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.AD2000Repositories
{
    public interface IAD2000Repository : IAsyncRepository,
        IAsyncFindableRepository<AD2000Calculation>,
        IAsyncInsertableRepository<AD2000Calculation>,
        IAsyncQueryableRepository<AD2000Calculation>,
        IAsyncUpdatebleRepository<AD2000Calculation>,
        IAsyncDeletableRepository<AD2000Calculation>
    {
        Task<bool> DeleteCalculationGraphAsync(Guid calculationId, CancellationToken cancellationToken = default);
    }
}
