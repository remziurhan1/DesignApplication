using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StorageTypePropertiesRepository
{
    public interface IStorageTypePropertiesRepository :
        IAsyncRepository,
     IAsyncFindableRepository<StorageTypeProperties>,
     IAsyncInsertableRepository<StorageTypeProperties>,
     IAsyncQueryableRepository<StorageTypeProperties>,
     IAsyncDeletableRepository<StorageTypeProperties>,
     IAsyncUpdatebleRepository<StorageTypeProperties>
    {
        Task<List<StorageTypeProperties>> GetByStorageTypeIdAsync(Guid storageTypeId);

        Task<StorageTypeProperties> GetByTemperatureAsync(Guid storageTypeId, double temperatureC);

        Task<StorageTypeProperties> GetNearestLowerTemperatureAsync(Guid storageTypeId, double temperatureC);
        Task<StorageTypeProperties> GetNearestUpperTemperatureAsync(Guid storageTypeId, double temperatureC);

        Task<IEnumerable<StorageTypeProperties>> GetAllWithStorageTypeAsync();
        Task<StorageTypeProperties> GetByIdWithStorageTypeAsync(Guid id);
    }
    
    
}
