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

namespace MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories
{
    public class MaterialFormRepository : EFBaseRepository<MaterialForm>, IMaterialFormRepository
    {
        private readonly AppDbContext _context;

        public MaterialFormRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // 📌 Belirli bir malzemenin tüm formları
        public async Task<List<MaterialForm>> GetByMaterialIdAsync(Guid materialId)
        {
            return await _context.MaterialForms
                                 .Where(f => f.MaterialId == materialId)
                                 .ToListAsync();
        }

        // 📌 Form tipine göre (Sac, Boru vs.)
        public async Task<List<MaterialForm>> GetByFormTypeAsync(MaterialFormType formType)
        {
            return await _context.MaterialForms
                                 .Where(f => f.FormType == formType)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<MaterialForm>> GetAllWithMaterialAsync()
        {
            return await _context.MaterialForms
                .Include(f => f.Material)
                .ToListAsync();
        }

        public async Task<MaterialForm> GetByIdWithMaterialAsync(Guid id)
        {
            return await _context.MaterialForms
                .Include(f => f.Material)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
