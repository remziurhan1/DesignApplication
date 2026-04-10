using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;

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
                    Origin = "Plate",
                    MaterialClass = "Carbon Steel",
                    Norm = "EN10028-2",
                    SymbolicName = "P355GH",
                    StockCode = null,
                    ThicknessMin = 1,
                    ThicknessMax = 250,
                    ProductStandard = "EN 10028-2",
                    WeldingFactor = null,
                    Notes = "Standard plate form for P355GH",
                    UnitPrice = 1.5,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                // 1.4301 Plate (Cold stretch değeri opsiyon olarak tanımlı)
                new MaterialForm
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444441"),
                    MaterialId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FormType = MaterialFormType.Plate,
                    Origin = "Plate",
                    MaterialClass = "Stainless Steel",
                    Norm = "EN10028-7",
                    SymbolicName = "X5CrNi18-10",
                    StockCode = "STK-SS-4301-PL",
                    ThicknessMin = 1,
                    ThicknessMax = 200,
                    ProductStandard = "EN 10028-7",
                    WeldingFactor = null,
                    Notes = "Plate form for X5CrNi18-10 (Cold stretch optional)",
                    UnitPrice = 4.5,
                    ColdStretchYieldStrength = 400,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                // P355NH Pipe
                new MaterialForm
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                    MaterialId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FormType = MaterialFormType.Pipe,
                    Origin = "Seamless Pipe",
                    MaterialClass = "Carbon Steel",
                    Norm = "EN10028-2",
                    SymbolicName = "P355GH",
                    StockCode = "STK-CS-P355GH-SP",
                    ThicknessMin = 2,
                    ThicknessMax = 40,
                    ProductStandard = "EN 10216-3",
                    WeldingFactor = 1,
                    Notes = "Seamless pipe form for P355NH",
                    UnitPrice = 2.3,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                new MaterialForm
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666661"),
                    MaterialId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    FormType = MaterialFormType.Profile,
                    Origin = "Bar",
                    MaterialClass = "Carbon Steel",
                    Norm = "EN10025",
                    SymbolicName = "S235JR",
                    StockCode = "STK-CS-S235JR-PROF",
                    ThicknessMin = 3,
                    ThicknessMax = 30,
                    ProductStandard = "EN 10025-2",
                    Notes = "S235JR kutu profil 40x40x3 mm",
                    UnitPrice = 1.2,
                    SectionArea = 444,
                    MomentOfInertia = 101700,
                    SectionModulus = 5080,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },
                new MaterialForm
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777771"),
                    MaterialId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    FormType = MaterialFormType.Forging,
                    Origin = "Forging",
                    MaterialClass = "Carbon Steel",
                    Norm = "EN10028-3",
                    SymbolicName = "P355NH",
                    StockCode = null,
                    ThicknessMin = 20,
                    ThicknessMax = 300,
                    ProductStandard = "EN 10028-3",
                    Notes = "Forged part seed for P355NH",
                    UnitPrice = 2.8,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },
                new MaterialForm
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888881"),
                    MaterialId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    FormType = MaterialFormType.Plate,
                    Origin = "Plate",
                    MaterialClass = "Stainless Steel",
                    Norm = "EN10028-7",
                    SymbolicName = "X2CrNi18-9",
                    StockCode = null,
                    ThicknessMin = 1,
                    ThicknessMax = 120,
                    ProductStandard = "EN 10028-7",
                    Notes = "Plate seed for X2CrNi18-9",
                    UnitPrice = 4.9,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
