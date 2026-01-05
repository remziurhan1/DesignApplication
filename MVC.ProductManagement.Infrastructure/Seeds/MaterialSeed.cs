using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
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
                    Name = "P355NH",
                    MaterialNumber = "1.0565",
                    Standard = MaterialStandard.EN,
                    Group = "Fine grain pressure vessel steel",
                    Density = 7850, // kg/m³
                    Notes = "Normalized delivery condition according to EN 10028-3",
                     CreatedBy = "SeedData",
    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
