using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.DesignStandardRepository
{
    public interface IDesignStandardRepository :
         IAsyncFindableRepository<DesignStandard>,
         IAsyncQueryableRepository<DesignStandard>,
         IAsyncInsertableRepository<DesignStandard>,
         IAsyncUpdatebleRepository<DesignStandard>,
         IAsyncDeletableRepository<DesignStandard>,
         IAsyncRepository
    {
        // Gerekirse DesignStandard'a özel ek metotlar ekleyebilirsiniz.
    }
}
