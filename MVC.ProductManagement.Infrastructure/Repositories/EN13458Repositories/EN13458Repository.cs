using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.EN13458Repositories
{
    public class EN13458Repository : EFBaseRepository<EN13458Calculation>, IEN13458Repository
    {
        private readonly AppDbContext _context;
        public EN13458Repository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
