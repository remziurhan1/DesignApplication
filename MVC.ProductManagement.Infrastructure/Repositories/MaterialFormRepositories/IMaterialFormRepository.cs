using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories
{
    public interface IMaterialFormRepository :
        IAsyncRepository,
        IAsyncFindableRepository<MaterialForm>,
        IAsyncInsertableRepository<MaterialForm>,
        IAsyncQueryableRepository<MaterialForm>,
        IAsyncUpdatebleRepository<MaterialForm>,
        IAsyncDeletableRepository<MaterialForm>
    {
        Task<List<MaterialForm>> GetByMaterialIdAsync(Guid materialId);
        Task<List<MaterialForm>> GetByFormTypeAsync(MaterialFormType formType);
        Task<IEnumerable<MaterialForm>> GetAllWithMaterialAsync();
        Task<MaterialForm> GetByIdWithMaterialAsync(Guid id);
    }
}
