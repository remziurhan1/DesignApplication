using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.TankRequestRepositories
{
    public interface ITankRequestRepository :
        IAsyncRepository,
        IAsyncFindableRepository<TankRequest>,
        IAsyncInsertableRepository<TankRequest>,
        IAsyncQueryableRepository<TankRequest>,
        IAsyncUpdatebleRepository<TankRequest>,
        IAsyncDeletableRepository<TankRequest>
    {
        // İleride özelleştirilmiş sorgular eklenecekse buraya koy.
        // Örnek:
        // Task<TankRequest?> GetWithRelatedAsync(Guid id);
    }
}
