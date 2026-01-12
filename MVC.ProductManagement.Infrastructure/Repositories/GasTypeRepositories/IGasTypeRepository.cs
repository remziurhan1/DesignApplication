using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.GasTypeRepositories
{
    public interface IGasTypeRepository :
          IAsyncFindableRepository<GasType>,
          IAsyncQueryableRepository<GasType>,
          IAsyncInsertableRepository<GasType>,
          IAsyncUpdatebleRepository<GasType>,
          IAsyncDeletableRepository<GasType>,
          IAsyncRepository
    {
        // Gerekirse GasType'a özel ek metotlar ekleyebilirsiniz.
    }
}
