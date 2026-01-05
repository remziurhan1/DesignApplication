using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.YieldStrengthRepositories
{
    public interface IYieldStrengthRepository :
       IAsyncRepository,
       IAsyncFindableRepository<YieldStrength>,
       IAsyncInsertableRepository<YieldStrength>,
       IAsyncQueryableRepository<YieldStrength>,
       IAsyncUpdatebleRepository<YieldStrength>,
       IAsyncDeletableRepository<YieldStrength>
    {
        Task<YieldStrength?> GetByConditionsAsync(Guid materialFormId, double temperature, double thickness);
        Task<List<YieldStrength>> GetByMaterialFormIdAsync(Guid materialFormId);
    }
}
