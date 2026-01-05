using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.IAllowableStressRepository
{
    public class AllowableStressRepository : EFBaseRepository<AllowableStress>, IAllowableStressRepository
    {
        private readonly AppDbContext _context;

        public AllowableStressRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // 📌 Belirli koşullara göre (form + sıcaklık)
        public async Task<AllowableStress?> GetByConditionsAsync(Guid materialFormId, double temperature)
        {
            return await _context.AllowableStresses
                                 .FirstOrDefaultAsync(a =>
                                     a.MaterialFormId == materialFormId &&
                                     a.Temperature == temperature);
        }

        // 📌 Belirli bir forma ait tüm AllowableStress kayıtları
        public async Task<List<AllowableStress>> GetByMaterialFormIdAsync(Guid materialFormId)
        {
            return await _context.AllowableStresses
                                 .Where(a => a.MaterialFormId == materialFormId)
                                 .ToListAsync();
        }
    }
}
