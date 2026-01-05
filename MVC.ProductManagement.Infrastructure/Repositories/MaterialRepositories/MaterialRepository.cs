using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialRepository : EFBaseRepository<Material>, IMaterialRepository
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Material?> GetByNameAsync(string materialName)
        {
            return await _context.Materials
                                 .FirstOrDefaultAsync(m => m.Name == materialName);
        }

        public async Task<List<Material>> GetByStandardAsync(MaterialStandard standard)
        {
            return await _context.Materials
                                 .Where(m => m.Standard == standard)
                                 .ToListAsync();
        }
    }
}
