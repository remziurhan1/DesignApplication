using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class SalesRequestProductGroupSeed
    {
        public static IEnumerable<SalesRequestProductGroup> Get()
        {
            var now = new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc);
            return new[]
            {
                Create("00000000-0000-0000-0000-000000000101", "01", "LPG", "LPG (LIQUID PETROLEUM GAS)", 1, now),
                Create("00000000-0000-0000-0000-000000000102", "02", "LNG", "LNG (LIQUID NATURAL GAS)", 2, now),
                Create("00000000-0000-0000-0000-000000000103", "03", "LOX", "LOX (LIQUID OXYGEN)", 3, now),
                Create("00000000-0000-0000-0000-000000000104", "04", "LIN", "LIN (LIQUID NITROGEN)", 4, now),
                Create("00000000-0000-0000-0000-000000000105", "05", "LAR", "LAR (LIQUID ARGON)", 5, now),
                Create("00000000-0000-0000-0000-000000000106", "06", "LCO2", "LCO2 / LIC (CARBON DIOXIDE)", 6, now),
                Create("00000000-0000-0000-0000-000000000107", "07", "PROSES", "PROSES VE HAVA TANKLARI", 7, now),
                Create("00000000-0000-0000-0000-000000000108", "08", "H2", "HİDROJEN TANKLARI", 8, now),
                Create("00000000-0000-0000-0000-000000000109", "09", "KIM", "KİMYASAL TANKLAR", 9, now),
                Create("00000000-0000-0000-0000-000000000110", "10", "GOX", "GOX (GAZ OKSİJEN)", 10, now)
            };
        }

        private static SalesRequestProductGroup Create(string id, string code, string shortCode, string name, int order, DateTime now)
        {
            return new SalesRequestProductGroup
            {
                Id = Guid.Parse(id),
                Code = code,
                ShortCode = shortCode,
                Name = name,
                DisplayOrder = order,
                IsActive = true,
                CreatedBy = "SeedData",
                CreatedDate = now
            };
        }
    }
}
