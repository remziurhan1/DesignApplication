using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.YieldStrengthRepositories
{
    public class YieldStrengthRepository : EFBaseRepository<YieldStrength>, IYieldStrengthRepository
    {
        private readonly AppDbContext _context;

        public YieldStrengthRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // 📌 Belirli koşullara göre (form + sıcaklık + kalınlık)
        public async Task<YieldStrength?> GetByConditionsAsync(Guid materialFormId, double temperature, double thickness)
        {
            return await _context.YieldStrengths
                                 .FirstOrDefaultAsync(y =>
                                     y.MaterialFormId == materialFormId &&
                                     y.Temperature == temperature &&
                                     y.ThicknessMin <= thickness &&
                                     y.ThicknessMax >= thickness);
        }

        // 📌 Belirli bir forma ait tüm YieldStrength kayıtları
        public async Task<List<YieldStrength>> GetByMaterialFormIdAsync(Guid materialFormId)
        {
            return await _context.YieldStrengths
                                 .Include(y => y.MaterialForm)             // YieldStrength → MaterialForm
                                 .ThenInclude(f => f.Material)             // MaterialForm → Material
                                 .Where(y => y.MaterialFormId == materialFormId)
                                 .ToListAsync();
        }
    }
}
