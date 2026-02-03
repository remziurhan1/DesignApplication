using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.IProductCodeRepositories
{
    public interface IProductCodeRepository :
         IAsyncFindableRepository<ProductCode>,
         IAsyncQueryableRepository<ProductCode>,
         IAsyncInsertableRepository<ProductCode>,
         IAsyncUpdatebleRepository<ProductCode>,
         IAsyncDeletableRepository<ProductCode>,
         IAsyncRepository
    {
        // Gerekirse ProductCode'a özel ek metotlar ekleyebilirsiniz.
    }
}
