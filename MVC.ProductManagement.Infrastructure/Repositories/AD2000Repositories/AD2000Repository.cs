using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;

namespace MVC.ProductManagement.Infrastructure.Repositories.AD2000Repositories
{
    public class AD2000Repository : EFBaseRepository<AD2000Calculation>, IAD2000Repository
    {
        public AD2000Repository(AppDbContext context) : base(context)
        {
        }
    }
}
