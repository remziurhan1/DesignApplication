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
                    UnitPrice = 1.5,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },
                // 1.4301 Plate
                new MaterialForm
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444441"),
                    MaterialId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FormType = MaterialFormType.Plate,
                    ThicknessMin = 1,
                    ThicknessMax = 200,
                    ProductStandard = "EN 10028-7",
                    WeldingFactor = null,
                    Notes = "Standard plate form for X5CrNi18-10",
                    UnitPrice = 4.5,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                // 1.4301 Cold Stretch Plate
                new MaterialForm
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444442"),
                    MaterialId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FormType = MaterialFormType.Plate,
                    ThicknessMin = 1,
                    ThicknessMax = 200,
                    ProductStandard = "EN 10028-7",
                    WeldingFactor = null,
                    Notes = "Cold stretched plate for cryogenic vessels",
                    UnitPrice = 4.5,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
