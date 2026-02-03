using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.IProductCodeRepositories
{
    public class ProductCodeRepository :  EFBaseRepository<ProductCode>, IProductCodeRepository
    {
        private readonly AppDbContext _context;

        public ProductCodeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
