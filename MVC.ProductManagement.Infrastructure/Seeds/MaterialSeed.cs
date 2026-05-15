using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class MaterialSeed
    {
        public static List<Material> Get()
        {
            return new List<Material>
            {
                new Material
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "P355GH",
                    MaterialNumber = "1.0565",
                    Density = 7850, // kg/m³
                    Notes = "Pressure vessel plate according to EN10028-2",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },
                new Material
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "X5CrNi18-10",
                    MaterialNumber = "1.4301",
                    Density = 8000,
                    Notes = "EN 10028-7 stainless pressure vessel steel",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
                ,new Material
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "S235JR",
                    MaterialNumber = "1.0038",
                    Density = 7850,
                    Notes = "Profile material for supports/rings",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },
                new Material
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    Name = "P355NH",
                    MaterialNumber = "1.0565",
                    Density = 7850,
                    Notes = "Normalized pressure vessel steel EN10028-3",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },
                new Material
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    Name = "X2CrNi18-9",
                    MaterialNumber = "1.4307",
                    Density = 8000,
                    Notes = "Austenitic stainless steel plate EN10028-7",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
