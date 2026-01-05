using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncOrderableRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool orderBySDesc, bool tracking = true); // hepsini getir çoklu sorgu koşullu
        Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderBy, bool orderBySDesc, bool tracking = true); // koşula göre getir. Overload çoklu sorgu koşullu // TKey kullanımı orderBy ile alakalı.
    }
}
