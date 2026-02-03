using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public static class SSeedIds
    {
        public static readonly Guid Fluid_LPG = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1");
        public static readonly Guid Fluid_LNG = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2");

        public static readonly Guid SPG_A = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbba0");
        public static readonly Guid SPG_F = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbf0");
        public static readonly Guid SPG_H = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbc0"); // H için "c0" verdim (hex)

        public static readonly Guid Prod_Valve_Ball = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc01");
        public static readonly Guid Prod_Valve_Relief = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc02");

        public static readonly Guid Asm_LPG_Valves = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddd10");
        public static readonly Guid Asm_LNG_Hoses = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddd88");

        public static readonly Guid Rule_LPG_Valve_Ball = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee01");
        public static readonly Guid Rule_LNG_Valve_Relief = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee02");

        public static readonly Guid Seq_SFA0 = Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff0");
        public static readonly Guid Seq_SFC1 = Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff1");
    }
}
