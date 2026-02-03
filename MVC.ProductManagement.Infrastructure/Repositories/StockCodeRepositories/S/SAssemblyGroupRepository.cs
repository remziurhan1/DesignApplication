using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S
{
    public class SAssemblyGroupRepository : EFBaseRepository<SAssemblyGroup>, ISAssemblyGroupRepositories
    {
        private readonly AppDbContext _context;

        public SAssemblyGroupRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
