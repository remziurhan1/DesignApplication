using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.TankCodeService
{
    public interface ITankCodeService
    {
        string GenerateTankCode(TankCodeRequest request);
    }
}
