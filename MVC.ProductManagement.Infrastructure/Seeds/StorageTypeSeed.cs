using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class StorageTypeSeed
    {
        public static List<StorageType> Get()
        {
            return new List<StorageType>
            {
                new StorageType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Name = "Methane / LNG",
                    Density = 460,
                    Description = "Liquefied Natural Gas",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                new StorageType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Name = "Nitrogen / LIN",
                    Density = 808,
                    Description = "Liquid Nitrogen",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                new StorageType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Name = "Oxygen / LOX",
                    Density = 1141,
                    Description = "Liquid Oxygen",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                new StorageType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Name = "Argon / LAR",
                    Density = 1395,
                    Description = "Liquid Argon",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                new StorageType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    Name = "Carbon Dioxide / LCO2",
                    Density = 1070,
                    Description = "Liquid Carbon Dioxide",
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}