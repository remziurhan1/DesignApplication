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
    public class StockSequenceRepository : EFBaseRepository<StockSequence>, IStockSequenceRepositories
    {
        private readonly AppDbContext _context;

        public StockSequenceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
