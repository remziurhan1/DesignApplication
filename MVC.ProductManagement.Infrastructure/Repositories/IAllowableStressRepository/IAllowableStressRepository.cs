using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.IAllowableStressRepository
{
    public interface IAllowableStressRepository :
        IAsyncRepository,
        IAsyncFindableRepository<AllowableStress>,
        IAsyncInsertableRepository<AllowableStress>,
        IAsyncQueryableRepository<AllowableStress>,
        IAsyncUpdatebleRepository<AllowableStress>,
        IAsyncDeletableRepository<AllowableStress>
    {
        Task<AllowableStress?> GetByConditionsAsync(Guid materialFormId, double temperature);
        Task<List<AllowableStress>> GetByMaterialFormIdAsync(Guid materialFormId);
    }
}
