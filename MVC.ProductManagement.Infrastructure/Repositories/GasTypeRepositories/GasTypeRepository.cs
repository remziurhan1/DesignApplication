using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;

namespace MVC.ProductManagement.Infrastructure.Repositories.GasTypeRepositories
{
    public class GasTypeRepository : EFBaseRepository<GasType>, IGasTypeRepository
    {
        private readonly AppDbContext _context;

        public GasTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



    }
}
