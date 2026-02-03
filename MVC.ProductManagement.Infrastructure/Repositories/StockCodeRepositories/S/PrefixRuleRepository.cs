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
    public class PrefixRuleRepository : EFBaseRepository<PrefixRule>, IPrefixRuleRepositories
    {
        private readonly AppDbContext _context;

        public PrefixRuleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
