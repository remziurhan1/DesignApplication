using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StorageTypePropertiesRepository
{
    public class StorageTypePropertiesRepository : EFBaseRepository<StorageTypeProperties>,IStorageTypePropertiesRepository
    {
        private readonly AppDbContext _context;

        public StorageTypePropertiesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StorageTypeProperties>> GetAllWithStorageTypeAsync()
        {
            return await _context.StorageTypeProperties
                                 .Include(x => x.StorageType)
                                 .ToListAsync();
        }

        public async Task<StorageTypeProperties?> GetByIdWithStorageTypeAsync(Guid id)
        {
            return await _context.StorageTypeProperties
                                 .Include(x => x.StorageType)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<StorageTypeProperties>> GetByStorageTypeIdAsync(Guid storageTypeId)
        {
            return await _context.StorageTypeProperties
                                 .Where(x => x.StorageTypeId == storageTypeId)
                                 .OrderBy(x => x.Temperature_C)
                                 .ToListAsync();
        }

        public async Task<StorageTypeProperties?> GetByTemperatureAsync(Guid storageTypeId, double temperatureC)
        {
            return await _context.StorageTypeProperties
                                 .Where(x => x.StorageTypeId == storageTypeId &&
                                             x.Temperature_C == temperatureC)
                                 .FirstOrDefaultAsync();
        }

        public async Task<StorageTypeProperties?> GetNearestLowerTemperatureAsync(Guid storageTypeId, double temperatureC)
        {
            return await _context.StorageTypeProperties
                                 .Where(x => x.StorageTypeId == storageTypeId &&
                                             x.Temperature_C <= temperatureC)
                                 .OrderByDescending(x => x.Temperature_C)
                                 .FirstOrDefaultAsync();
        }

        public async Task<StorageTypeProperties?> GetNearestUpperTemperatureAsync(Guid storageTypeId, double temperatureC)
        {
            return await _context.StorageTypeProperties
                                 .Where(x => x.StorageTypeId == storageTypeId &&
                                             x.Temperature_C >= temperatureC)
                                 .OrderBy(x => x.Temperature_C)
                                 .FirstOrDefaultAsync();
        }
    }
}
