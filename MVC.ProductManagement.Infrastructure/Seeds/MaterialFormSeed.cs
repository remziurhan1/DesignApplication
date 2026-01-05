using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class MaterialFormSeed
    {
        public static List<MaterialForm> Get()
        {
            return new List<MaterialForm>
            {
                new MaterialForm
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    MaterialId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FormType = MaterialFormType.Plate,
                    ThicknessMin = 1,
                    ThicknessMax = 250,
                    ProductStandard = "EN 10028-3",
                    WeldingFactor = null,
                    Notes = "Standard plate form for P355NH",
                    UnitPrice=1.5,
    CreatedBy = "SeedData",
    CreatedDate =  DateTime.UtcNow
                }
            };
        }
    }
}
