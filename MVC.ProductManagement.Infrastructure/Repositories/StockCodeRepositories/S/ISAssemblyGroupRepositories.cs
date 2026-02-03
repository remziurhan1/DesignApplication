using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S
{
    public interface ISAssemblyGroupRepositories : IAsyncRepository,
        IAsyncFindableRepository<SAssemblyGroup>,
        IAsyncInsertableRepository<SAssemblyGroup>,
        IAsyncQueryableRepository<SAssemblyGroup>,
        IAsyncDeletableRepository<SAssemblyGroup>,
        IAsyncUpdatebleRepository<SAssemblyGroup>
    {
    }
}
