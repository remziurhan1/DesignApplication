using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StorageTypeRepositories
{
    public class StorageTypeRepository : EFBaseRepository<StorageType>, IStorageTypeRepositories
    {
        private readonly AppDbContext _context;
        public StorageTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task AddStorageTypeAsync(StorageType entity)
        {
            await AddAsync(entity);
        }
    }
}
