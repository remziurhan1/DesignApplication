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
    public interface IAsyncFindableRepository<TEntity> where TEntity : BaseEntity
    {
        // Any() varsa true yoksa false dönen keyword.
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> exception = null); // koşula göre getir proporti kontrolü için dönüş tipi bool
        Task<TEntity?> GetByIdAsync(Guid id, bool tracking = true); // default olarak true gelecek eğer falase olması gerekirse ayarlayacağız. -- ID ye göre getirecek

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> exception, bool tracking = true); // Koşul gönderiyorum.
    }
}
