using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class StorageTypePropertiesSeed
    {
        public static List<StorageTypeProperties> Get()
        {
            return new List<StorageTypeProperties>
            {
                // LNG example point
                new StorageTypeProperties
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    StorageTypeId = Guid.Parse("10000000-0000-0000-0000-000000000001"),

                    Temperature_C = -150,
                    Pressure_bar = 2.384,

                    SpecificVolume_Liquid_dm3kg = 2.4674,
                    SpecificVolume_Gas_m3kg = 0.25042,

                    Enthalpy_Liquid_kJkg = 200.0,
                    Enthalpy_Gas_kJkg = 688.0,

                    GasConstant_kJkgK = 488.0,

                    Entropy_Liquid_kJkgK = 1.0000,
                    Entropy_Gas_kJkgK = 4.9627,

                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                // Nitrogen
                new StorageTypeProperties
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    StorageTypeId = Guid.Parse("10000000-0000-0000-0000-000000000002"),

                    Temperature_C = -196,
                    Pressure_bar = 0.99,

                    SpecificVolume_Liquid_dm3kg = 1.2352,
                    SpecificVolume_Gas_m3kg = 0.2215,

                    Enthalpy_Liquid_kJkg = 81.79,
                    Enthalpy_Gas_kJkg = 281.19,

                    GasConstant_kJkgK = 199.40,

                    Entropy_Liquid_kJkgK = -0.1275,
                    Entropy_Gas_kJkgK = 2.4571,

                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                },

                // Oxygen
                new StorageTypeProperties
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    StorageTypeId = Guid.Parse("10000000-0000-0000-0000-000000000003"),

                    Temperature_C = -150,
                    Pressure_bar = 12.214,

                    SpecificVolume_Liquid_dm3kg = 1.0495,
                    SpecificVolume_Gas_m3kg = 0.02129,

                    Enthalpy_Liquid_kJkg = 200.0,
                    Enthalpy_Gas_kJkg = 367.88,

                    GasConstant_kJkgK = 167.88,

                    Entropy_Liquid_kJkgK = 1.000,
                    Entropy_Gas_kJkgK = 2.3632,

                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}