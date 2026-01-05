using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StorageTypeRepositories
{
    public interface IStorageTypeRepositories : IAsyncRepository, IAsyncFindableRepository<StorageType>, IAsyncInsertableRepository<StorageType>, IAsyncQueryableRepository<StorageType>, IAsyncDeletableRepository<StorageType>, IAsyncUpdatebleRepository<StorageType>
    {

    }
}
