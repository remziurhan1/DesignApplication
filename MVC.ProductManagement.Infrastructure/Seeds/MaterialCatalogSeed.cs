using MVC.ProductManagement.Domain.Entities.MaterialCatalog;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class MaterialCatalogSeed
    {
        public static readonly Guid CarbonSteelFamilyId = Guid.Parse("10000000-0000-0000-0000-000000000001");
        public static readonly Guid LowTemperatureCarbonSteelFamilyId = Guid.Parse("10000000-0000-0000-0000-000000000002");
        public static readonly Guid StainlessSteelFamilyId = Guid.Parse("10000000-0000-0000-0000-000000000003");
        public static readonly Guid AluminiumFamilyId = Guid.Parse("10000000-0000-0000-0000-000000000004");
        public static readonly Guid CopperAlloyFamilyId = Guid.Parse("10000000-0000-0000-0000-000000000005");
        public static readonly Guid NickelAlloyFamilyId = Guid.Parse("10000000-0000-0000-0000-000000000006");

        public static readonly Guid En100282StandardId = Guid.Parse("20000000-0000-0000-0000-000000000001");
        public static readonly Guid En100283StandardId = Guid.Parse("20000000-0000-0000-0000-000000000002");
        public static readonly Guid AstmA516StandardId = Guid.Parse("20000000-0000-0000-0000-000000000003");
        public static readonly Guid AstmA106StandardId = Guid.Parse("20000000-0000-0000-0000-000000000004");
        public static readonly Guid AstmA333StandardId = Guid.Parse("20000000-0000-0000-0000-000000000005");
        public static readonly Guid En100882StandardId = Guid.Parse("20000000-0000-0000-0000-000000000006");
        public static readonly Guid En102165StandardId = Guid.Parse("20000000-0000-0000-0000-000000000007");
        public static readonly Guid AstmA240StandardId = Guid.Parse("20000000-0000-0000-0000-000000000008");
        public static readonly Guid En485StandardId = Guid.Parse("20000000-0000-0000-0000-000000000009");
        public static readonly Guid En755StandardId = Guid.Parse("20000000-0000-0000-0000-000000000010");

        private static readonly DateTime SeedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static List<MaterialFamily> MaterialFamilies() => new()
        {
            Family(CarbonSteelFamilyId, "Carbon Steel"),
            Family(LowTemperatureCarbonSteelFamilyId, "Low Temperature Carbon Steel"),
            Family(StainlessSteelFamilyId, "Stainless Steel"),
            Family(AluminiumFamilyId, "Aluminium"),
            Family(CopperAlloyFamilyId, "Copper Alloy"),
            Family(NickelAlloyFamilyId, "Nickel Alloy")
        };

        public static List<MaterialStandard> MaterialStandards() => new()
        {
            Standard(En100282StandardId, CarbonSteelFamilyId, Guid.Parse("22222222-2222-2222-2222-222222222222"), "EN 10028-2", "Pressure vessel plate steels"),
            Standard(En100283StandardId, LowTemperatureCarbonSteelFamilyId, Guid.Parse("77777777-7777-7777-7777-777777777771"), "EN 10028-3", "Weldable fine grain pressure vessel steels"),
            Standard(AstmA516StandardId, CarbonSteelFamilyId, Guid.Parse("22222222-2222-2222-2222-222222222222"), "ASTM A516", "Carbon steel pressure vessel plates"),
            Standard(AstmA106StandardId, CarbonSteelFamilyId, Guid.Parse("22222222-2222-2222-2222-222222222223"), "ASTM A106", "Seamless carbon steel pipe"),
            Standard(AstmA333StandardId, LowTemperatureCarbonSteelFamilyId, Guid.Parse("22222222-2222-2222-2222-222222222223"), "ASTM A333", "Low temperature service pipe"),
            Standard(En100882StandardId, StainlessSteelFamilyId, Guid.Parse("44444444-4444-4444-4444-444444444441"), "EN 10088-2", "Stainless steel sheet/plate"),
            Standard(En102165StandardId, StainlessSteelFamilyId, Guid.Parse("22222222-2222-2222-2222-222222222223"), "EN 10216-5", "Stainless seamless steel tubes"),
            Standard(AstmA240StandardId, StainlessSteelFamilyId, Guid.Parse("44444444-4444-4444-4444-444444444441"), "ASTM A240", "Chromium and chromium-nickel stainless steel plate"),
            Standard(En485StandardId, AluminiumFamilyId, Guid.Parse("22222222-2222-2222-2222-222222222222"), "EN 485", "Aluminium and aluminium alloys sheet/plate"),
            Standard(En755StandardId, AluminiumFamilyId, Guid.Parse("66666666-6666-6666-6666-666666666661"), "EN 755", "Aluminium extruded rod/bar/tube/profile")
        };

        public static List<MaterialMechanicalProperty> MechanicalProperties() => new()
        {
            Mechanical(Guid.Parse("30000000-0000-0000-0000-000000000001"), Guid.Parse("11111111-1111-1111-1111-111111111111"), 0, 16, 20, 355, 470, 630, null, null, "Seed: P355GH sample room temperature value"),
            Mechanical(Guid.Parse("30000000-0000-0000-0000-000000000002"), Guid.Parse("11111111-1111-1111-1111-111111111111"), 16, 40, 20, 345, 470, 630, null, null, "Seed: P355GH sample room temperature value"),
            Mechanical(Guid.Parse("30000000-0000-0000-0000-000000000003"), Guid.Parse("33333333-3333-3333-3333-333333333333"), 0, 50, 20, 210, 520, 720, null, null, "Seed: 1.4301 sample room temperature value")
        };

        private static MaterialFamily Family(Guid id, string name) => new()
        {
            Id = id,
            Name = name,
            Description = name,
            IsActive = true,
            CreatedBy = "SeedData",
            CreatedDate = SeedDate
        };

        private static MaterialStandard Standard(Guid id, Guid familyId, Guid formId, string code, string description) => new()
        {
            Id = id,
            MaterialFamilyId = familyId,
            MaterialFormId = formId,
            StandardCode = code,
            Description = description,
            IsActive = true,
            CreatedBy = "SeedData",
            CreatedDate = SeedDate
        };

        private static MaterialMechanicalProperty Mechanical(Guid id, Guid materialId, double thicknessMin, double thicknessMax, double temperature, double yieldStrength, double? tensileMin, double? tensileMax, double? elongation, double? allowableStress, string sourceNote) => new()
        {
            Id = id,
            MaterialId = materialId,
            ThicknessMin = thicknessMin,
            ThicknessMax = thicknessMax,
            Temperature = temperature,
            YieldStrength = yieldStrength,
            TensileStrengthMin = tensileMin,
            TensileStrengthMax = tensileMax,
            Elongation = elongation,
            AllowableStress = allowableStress,
            SourceNote = sourceNote,
            IsActive = true,
            CreatedBy = "SeedData",
            CreatedDate = SeedDate
        };
    }
}
