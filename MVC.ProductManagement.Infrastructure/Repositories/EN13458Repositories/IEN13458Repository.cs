using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.EN13458Repositories
{
    public interface IEN13458Repository : IAsyncRepository,
        IAsyncFindableRepository<EN13458Calculation>,
        IAsyncInsertableRepository<EN13458Calculation>,
        IAsyncQueryableRepository<EN13458Calculation>,
        IAsyncUpdatebleRepository<EN13458Calculation>,
        IAsyncDeletableRepository<EN13458Calculation>
    {
    }
}
