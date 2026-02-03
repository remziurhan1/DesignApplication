using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.ProductCodeServices
{
    public interface IProductCodeService
    {
        string GenerateProductCode(string prefix, int sequence);
    }
}
