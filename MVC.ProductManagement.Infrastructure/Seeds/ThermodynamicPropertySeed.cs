using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class ThermodynamicPropertySeed
    {
        public static List<ThermodynamicProperty> Get()
        {
            return new List<ThermodynamicProperty>
            {
                new ThermodynamicProperty
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),

                    GasTypeId = Guid.Parse("10000000-0000-0000-0000-000000000001"),

                    Temperature = -150,
                    Pressure = 2.384,

                    VL = 2.4674,
                    VG = 0.25042,

                    HL = 200.0,
                    HG = 688.0,

                    R = 488.0,

                    SL = 1.0000,
                    SG = 4.9627,

                    DataSource = "Reynolds Thermodynamic Tables",

                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}