using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S
{
    public interface IPrefixRuleRepositories : IAsyncRepository,
        IAsyncFindableRepository<PrefixRule>,
        IAsyncInsertableRepository<PrefixRule>,
        IAsyncQueryableRepository<PrefixRule>,
        IAsyncDeletableRepository<PrefixRule>,
        IAsyncUpdatebleRepository<PrefixRule>
    {
    }
}
