using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories
{
    public interface IMaterialRepository :
     IAsyncRepository,
     IAsyncFindableRepository<Material>,
     IAsyncInsertableRepository<Material>,
     IAsyncQueryableRepository<Material>,
     IAsyncDeletableRepository<Material>,
     IAsyncUpdatebleRepository<Material>
    {
        Task<Material> GetByNameAsync(string materialName);
        Task<List<Material>> GetByStandardAsync(MaterialStandard standard);
    }
}
