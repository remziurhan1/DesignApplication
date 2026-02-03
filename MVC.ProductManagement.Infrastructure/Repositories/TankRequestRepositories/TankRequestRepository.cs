using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.TankRequestRepositories
{
    public class TankRequestRepository : EFBaseRepository<TankRequest>, ITankRequestRepository
    {
        private readonly AppDbContext _context;
        public TankRequestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Örnek özel sorgu (ihtiyaca göre etkinleştir)
        // public async Task<TankRequest?> GetWithRelatedAsync(Guid id)
        // {
        //     return await _context.TankRequests
        //         .Include(t => t.GasType)
        //         .Include(t => t.DesignStandard)
        //         .Include(t => t.ProductCode)
        //         .FirstOrDefaultAsync(t => t.Id == id);
        // }
    }
}
