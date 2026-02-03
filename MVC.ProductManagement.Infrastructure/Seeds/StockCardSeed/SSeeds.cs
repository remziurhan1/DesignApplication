//using Microsoft.EntityFrameworkCore;
//using MVC.ProductManagement.Domain.Entities.StockCodes;
//using MVC.ProductManagement.Domain.Enums;
//using System;

//namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
//{
//    public static class SSeeds
//    {
//        public static void SeedS(ModelBuilder builder)
//        {
//            var seedUser = "SEED";
//            var seedDate = new DateTime(2026, 02, 03);

//            // ===================== GUID SABİTLERİ (8-4-4-4-12) =====================

//            // ===================== FLUIDS (Talimat Kodları) =====================
//            var FLUID_A_LPG = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1");
//            var FLUID_B_LNG = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2");
//            var FLUID_C_LOX = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3");
//            var FLUID_D_LIN = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4");
//            var FLUID_E_CO2 = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5");
//            var FLUID_F_FUEL = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa6");
//            var FLUID_G_GOX = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa7");
//            var FLUID_H_CNG = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa8");

//            builder.Entity<Fluid>().HasData(
//                new Fluid { Id = FLUID_A_LPG, Code = "A", Name = "LPG", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_B_LNG, Code = "B", Name = "LNG", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_C_LOX, Code = "C", Name = "LOX", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_D_LIN, Code = "D", Name = "LIN", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_E_CO2, Code = "E", Name = "CO2", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_F_FUEL, Code = "F", Name = "FUEL", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_G_GOX, Code = "G", Name = "GOX", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new Fluid { Id = FLUID_H_CNG, Code = "H", Name = "CNG", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added }
//            );

//            // ===================== S PRODUCT GROUP (F) =====================
//            var GROUP_F = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbf0");

//            builder.Entity<SProductGroup>().HasData(
//                new SProductGroup
//                {
//                    Id = GROUP_F,
//                    Code = "F",
//                    Name = "Aksesuarlar (Vana, Termometre vs.)",
//                    CreatedBy = seedUser,
//                    CreatedDate = seedDate,
//                    Status = Status.Added
//                }
//            );

//            // ===================== PRODUCTS =====================
//            var P_VALVE = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc01");
//            var P_RELIEF = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc02");
//            var P_REGULATOR = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc03");
//            var P_LEVEL = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc04");
//            var P_CHECK_BYPASS = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc05");
//            var P_METER = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc06");
//            var P_FILTER = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc07");
//            var P_PUMP_COMP = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc08");
//            var P_CONNECTOR = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc09");
//            var P_MANHOLE_COVER = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc0a");

//            var P_WATER_VALVE = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc0b");
//            var P_HYD_VALVE = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc0c");
//            var P_GROUND_REEL = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc0d");
//            var P_HOSE_REEL = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc0e");
//            var P_MANOMETER = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc0f");
//            var P_THERMOMETER = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc10");
//            var P_GASKET = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc11");

//            var P_CYL_UNIT = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc12");
//            var P_GAS_DETECTOR = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc13");
//            var P_REFILL_SCALE = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc14");
//            var P_AIR_COMP = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc15");

//            builder.Entity<SProduct>().HasData(
//                new SProduct { Id = P_VALVE, SProductGroupId = GROUP_F, Code = "VALVE", Name = "Vanalar/Valfler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_RELIEF, SProductGroupId = GROUP_F, Code = "RELIEF", Name = "Emniyet/Relief Valfleri", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_REGULATOR, SProductGroupId = GROUP_F, Code = "REG", Name = "Regülatörler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_LEVEL, SProductGroupId = GROUP_F, Code = "LEVEL", Name = "Seviye/Ölçüm Göstergeleri", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_CHECK_BYPASS, SProductGroupId = GROUP_F, Code = "CHECK", Name = "Aşırı Akış / Check / By-Pass", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_METER, SProductGroupId = GROUP_F, Code = "METER", Name = "Sayaçlar", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_FILTER, SProductGroupId = GROUP_F, Code = "FILTER", Name = "Filtreler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_PUMP_COMP, SProductGroupId = GROUP_F, Code = "PUMP", Name = "Pompalar ve Kompresörler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_CONNECTOR, SProductGroupId = GROUP_F, Code = "CONN", Name = "Adaptör/Konnektör/Bağlantı", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_MANHOLE_COVER, SProductGroupId = GROUP_F, Code = "MH", Name = "Menhol Kapakları", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },

//                new SProduct { Id = P_WATER_VALVE, SProductGroupId = GROUP_F, Code = "WVALVE", Name = "Su Vanaları", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_HYD_VALVE, SProductGroupId = GROUP_F, Code = "HVALVE", Name = "Hidrolik Sistem Vanalar/Valfler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_GROUND_REEL, SProductGroupId = GROUP_F, Code = "GND", Name = "Topraklama Makaraları", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_HOSE_REEL, SProductGroupId = GROUP_F, Code = "HREEL", Name = "Hortum Makaraları", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_MANOMETER, SProductGroupId = GROUP_F, Code = "MANO", Name = "Manometreler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_THERMOMETER, SProductGroupId = GROUP_F, Code = "THERMO", Name = "Termometreler", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_GASKET, SProductGroupId = GROUP_F, Code = "GASKET", Name = "Contalar", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },

//                new SProduct { Id = P_CYL_UNIT, SProductGroupId = GROUP_F, Code = "CYL", Name = "LPG Cylinder Units", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_GAS_DETECTOR, SProductGroupId = GROUP_F, Code = "DETECT", Name = "LPG Gas Detectors", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_REFILL_SCALE, SProductGroupId = GROUP_F, Code = "SCALE", Name = "LPG Refilling Scales", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added },
//                new SProduct { Id = P_AIR_COMP, SProductGroupId = GROUP_F, Code = "AIR", Name = "Air Compressors", CreatedBy = seedUser, CreatedDate = seedDate, Status = Status.Added }
//            );

//            // ===================== 4) PREFIX RULES =====================
//            // A (LPG) -> SFA0..SFA8
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea0"), FLUID_A_LPG, GROUP_F, P_VALVE, "SFA0", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea1"), FLUID_A_LPG, GROUP_F, P_RELIEF, "SFA1", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea2"), FLUID_A_LPG, GROUP_F, P_REGULATOR, "SFA2", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea3"), FLUID_A_LPG, GROUP_F, P_LEVEL, "SFA3", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea4"), FLUID_A_LPG, GROUP_F, P_CHECK_BYPASS, "SFA4", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea5"), FLUID_A_LPG, GROUP_F, P_METER, "SFA5", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea6"), FLUID_A_LPG, GROUP_F, P_FILTER, "SFA6", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea7"), FLUID_A_LPG, GROUP_F, P_PUMP_COMP, "SFA7", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeea8"), FLUID_A_LPG, GROUP_F, P_CONNECTOR, "SFA8", seedUser, seedDate);

//            // C (LOX) -> SFC0..SFC8
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec0"), FLUID_C_LOX, GROUP_F, P_VALVE, "SFC0", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec1"), FLUID_C_LOX, GROUP_F, P_RELIEF, "SFC1", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec2"), FLUID_C_LOX, GROUP_F, P_REGULATOR, "SFC2", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec3"), FLUID_C_LOX, GROUP_F, P_LEVEL, "SFC3", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec4"), FLUID_C_LOX, GROUP_F, P_CHECK_BYPASS, "SFC4", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec5"), FLUID_C_LOX, GROUP_F, P_METER, "SFC5", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec6"), FLUID_C_LOX, GROUP_F, P_FILTER, "SFC6", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec7"), FLUID_C_LOX, GROUP_F, P_PUMP_COMP, "SFC7", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeec8"), FLUID_C_LOX, GROUP_F, P_CONNECTOR, "SFC8", seedUser, seedDate);

//            // F (FUEL) -> SFF0..SFF9
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef0"), FLUID_F_FUEL, GROUP_F, P_VALVE, "SFF0", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef1"), FLUID_F_FUEL, GROUP_F, P_RELIEF, "SFF1", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef2"), FLUID_F_FUEL, GROUP_F, P_REGULATOR, "SFF2", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef3"), FLUID_F_FUEL, GROUP_F, P_LEVEL, "SFF3", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef4"), FLUID_F_FUEL, GROUP_F, P_CHECK_BYPASS, "SFF4", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef5"), FLUID_F_FUEL, GROUP_F, P_METER, "SFF5", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef6"), FLUID_F_FUEL, GROUP_F, P_FILTER, "SFF6", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef7"), FLUID_F_FUEL, GROUP_F, P_PUMP_COMP, "SFF7", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef8"), FLUID_F_FUEL, GROUP_F, P_CONNECTOR, "SFF8", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeef9"), FLUID_F_FUEL, GROUP_F, P_MANHOLE_COVER, "SFF9", seedUser, seedDate);

//            // G (GOX) -> SFG0..SFG6
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed0"), FLUID_G_GOX, GROUP_F, P_WATER_VALVE, "SFG0", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed1"), FLUID_G_GOX, GROUP_F, P_HYD_VALVE, "SFG1", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed2"), FLUID_G_GOX, GROUP_F, P_GROUND_REEL, "SFG2", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed3"), FLUID_G_GOX, GROUP_F, P_HOSE_REEL, "SFG3", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed4"), FLUID_G_GOX, GROUP_F, P_MANOMETER, "SFG4", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed5"), FLUID_G_GOX, GROUP_F, P_THERMOMETER, "SFG5", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeed6"), FLUID_G_GOX, GROUP_F, P_GASKET, "SFG6", seedUser, seedDate);

//            // H (CNG) -> SFH0..SFH3
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeee0"), FLUID_H_CNG, GROUP_F, P_CYL_UNIT, "SFH0", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeee1"), FLUID_H_CNG, GROUP_F, P_GAS_DETECTOR, "SFH1", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeee2"), FLUID_H_CNG, GROUP_F, P_REFILL_SCALE, "SFH2", seedUser, seedDate);
//            SeedRule(builder, Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeee3"), FLUID_H_CNG, GROUP_F, P_AIR_COMP, "SFH3", seedUser, seedDate);

//            // ===================== 5) STOCK SEQUENCES (Prefix4 başına) =====================
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa0"), "SFA0", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa1"), "SFA1", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa2"), "SFA2", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa3"), "SFA3", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa4"), "SFA4", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa5"), "SFA5", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa6"), "SFA6", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa7"), "SFA7", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffa8"), "SFA8", seedUser, seedDate);

//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc0"), "SFC0", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc1"), "SFC1", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc2"), "SFC2", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc3"), "SFC3", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc4"), "SFC4", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc5"), "SFC5", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc6"), "SFC6", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc7"), "SFC7", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffc8"), "SFC8", seedUser, seedDate);

//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff0"), "SFF0", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff1"), "SFF1", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff2"), "SFF2", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff3"), "SFF3", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff4"), "SFF4", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff5"), "SFF5", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff6"), "SFF6", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff7"), "SFF7", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff8"), "SFF8", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-fffffffffff9"), "SFF9", seedUser, seedDate);

//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd0"), "SFG0", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd1"), "SFG1", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd2"), "SFG2", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd3"), "SFG3", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd4"), "SFG4", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd5"), "SFG5", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffd6"), "SFG6", seedUser, seedDate);

//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffe0"), "SFH0", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffe1"), "SFH1", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffe2"), "SFH2", seedUser, seedDate);
//            SeedSequence(builder, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffe3"), "SFH3", seedUser, seedDate);
//        }

//        private static void SeedRule(ModelBuilder builder, Guid id, Guid fluidId, Guid groupId, Guid productId, string prefix4, string seedUser, DateTime seedDate)
//        {
//            builder.Entity<PrefixRule>().HasData(
//                new PrefixRule
//                {
//                    Id = id,
//                    FluidId = fluidId,
//                    SProductGroupId = groupId,
//                    SProductId = productId,
//                    Prefix4 = prefix4,
//                    CreatedBy = seedUser,
//                    CreatedDate = seedDate,
//                    Status = Status.Added
//                }
//            );
//        }

//        private static void SeedSequence(ModelBuilder builder, Guid id, string prefix4, string seedUser, DateTime seedDate)
//        {
//            builder.Entity<StockSequence>().HasData(
//                new StockSequence
//                {
//                    Id = id,
//                    Prefix4 = prefix4,
//                    StartNumber = 1000,
//                    LastNumber = 0,
//                    CreatedBy = seedUser,
//                    CreatedDate = seedDate,
//                    Status = Status.Added
//                }
//            );
//        }
//    }
//}
