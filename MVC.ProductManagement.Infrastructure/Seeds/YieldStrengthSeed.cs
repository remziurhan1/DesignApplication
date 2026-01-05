using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class YieldStrengthSeed
    {
        public static List<YieldStrength> Get()
        {
            var formId = Guid.Parse("22222222-2222-2222-2222-222222222222");

            return new List<YieldStrength>
            {
                // t ≤ 16 mm
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1,   ThicknessMax = 16,  Temperature = 20,  Rp02 = 355, Rm = 490 ,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 50, Rp02 = 343, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 100, Rp02 = 323, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 150, Rp02 = 299, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 200, Rp02 = 275, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 250, Rp02 = 252, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 300, Rp02 = 232, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 350, Rp02 = 214, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 1, ThicknessMax = 16, Temperature = 400, Rp02 = 202, Rm = 490, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},

                // 16 < t ≤ 40 mm
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 20,  Rp02 = 345, Rm = 490 ,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow},
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 50,  Rp02 = 334, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 100, Rp02 = 314, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 150, Rp02 = 291, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 200, Rp02 = 267, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 250, Rp02 = 245, Rm = 490 ,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow},
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 300, Rp02 = 225, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 350, Rp02 = 208, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 16,  ThicknessMax = 40,  Temperature = 400, Rp02 = 196, Rm = 490,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },

                // 40 < t ≤ 60 mm
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40,  ThicknessMax = 60,  Temperature = 20,  Rp02 = 335, Rm = 470,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40, ThicknessMax = 60, Temperature = 50, Rp02 = 324, Rm = 470, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40, ThicknessMax = 60, Temperature = 100, Rp02 = 305, Rm = 470, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40, ThicknessMax = 60, Temperature = 150, Rp02 = 282, Rm = 470, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40, ThicknessMax = 60, Temperature = 200, Rp02 = 259, Rm = 470, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow   },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40,  ThicknessMax = 60,  Temperature = 250, Rp02 = 238, Rm = 470,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40,  ThicknessMax = 60,  Temperature = 300, Rp02 = 219, Rm = 470,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40,  ThicknessMax = 60,  Temperature = 350, Rp02 = 202, Rm = 470,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 40, ThicknessMax = 60, Temperature = 400, Rp02 = 190, Rm = 470, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},

                // 60 < t ≤ 100 mm
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 20, Rp02 = 315, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 50, Rp02 = 305, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 100, Rp02 = 287, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 150, Rp02 = 265, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 200, Rp02 = 244, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 250, Rp02 = 224, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 300, Rp02 = 206, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 350, Rp02 = 190, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 60, ThicknessMax = 100, Temperature = 400, Rp02 = 179, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},

                // 100 < t ≤ 150 mm
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 20, Rp02 = 305, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 50, Rp02 = 295, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 100, Rp02 = 277, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 150, Rp02 = 257, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 200, Rp02 = 236, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 250, Rp02 = 216, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 300, Rp02 = 199, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 350, Rp02 = 184, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},
                new YieldStrength {Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 100, ThicknessMax = 150, Temperature = 400, Rp02 = 173, Rm = 460, CreatedBy = "SeedData", CreatedDate = DateTime.UtcNow},

                // 150 < t ≤ 250 mm
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 20,  Rp02 = 295, Rm = 450 ,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow},
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 50,  Rp02 = 285, Rm = 450,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 100, Rp02 = 268, Rm = 450 ,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow},
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 150, Rp02 = 249, Rm = 450,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 200, Rp02 = 228, Rm = 450 ,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow},
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 250, Rp02 = 209, Rm = 450,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 300, Rp02 = 192, Rm = 450,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 350, Rp02 = 178, Rm = 450,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
                new YieldStrength { Id = Guid.NewGuid(), MaterialFormId = formId, ThicknessMin = 150, ThicknessMax = 250, Temperature = 400, Rp02 = 167, Rm = 450,CreatedBy="SeedData" , CreatedDate=DateTime.UtcNow },
            };
        }
    }
}
