using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.DataAccess.Interfaces
{
    public interface IRepository
    {
        int SaveChange();
    }
}
