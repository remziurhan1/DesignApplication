using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD.Features
{
    public class SDFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var sdProducts = new[]
            {
                "SDA0", "SDA1", "SDA2", "SDA3", "SDA4", "SDA5", "SDA6", "SDA7", "SDA8", "SDA9",
                "SDB0", "SDB1", "SDB2", "SDB3", "SDB4",
                "SDC0", "SDC1", "SDC2", "SDC3", "SDC4",
                "SDD0", "SDD1", "SDD2", "SDD3", "SDD4", "SDD5",
                "SDE0", "SDE1", "SDE2", "SDE3", "SDE4",
                "SDF0", "SDF1", "SDF2", "SDF3", "SDF4", "SDF9",
                "SDG1", "SDG3",
                "SDH0", "SDH1",
                "SDI1"
            };

            var featureValues = new Dictionary<string, string[]>
            {
                ["CONNECTION_TYPE"] = new[] { "Rekor", "Tee", "Dirsek", "Redüksiyon", "Flans", "Boru Boğazı/Bağlayıcı", "Diğer Bağlantı Elemanları", "Fittings" },
                ["SD_MATERIAL"] = new[] { "Hidrolik Çelik", "Pnömatik Çelik", "Karbon Çelik", "Alüminyum", "Paslanmaz Çelik AISI 304", "Paslanmaz Çelik AISI 316", "Pirinç", "PPR", "PE (Polietilen)", "Polyemid", "Galvaniz Çelik", "Bronz" },
                ["SD_STANDARD"] = new[] { "DIN 2353", "ISO 8434-1", "SAE J514", "DIN 3863", "DIN 2566", "ASTM A105", "EN 1092-1", "ASME B16.9", "DIN 2615", "ISO 4144" },
                ["CONNECTION_SIZE"] = new[] { "1/4\"", "3/8\"", "1/2\"", "3/4\"", "1\"", "1 1/4\"", "1 1/2\"", "2\"", "2 1/2\"", "3\"", "4\"", "DN6", "DN8", "DN10", "DN15", "DN20", "DN25", "DN32", "DN40", "DN50", "DN65", "DN80", "DN100" },
                ["ANGLE"] = new[] { "45°", "90°", "180°", "T (Tee)", "Y (Y Bağlantı)" },
                ["SD_COATING"] = new[] { "Doğal (Kaplamasız)", "Nikel Kaplama", "Krom Kaplama", "Çinko Kaplama", "Galvaniz", "Paslanmaz" }
            };

            var rules = new List<SFeatureValueRule>();

            foreach (var productCode in sdProducts)
            {
                var productId = SeedId.From($"SProduct:SD:{productCode}");

                foreach (var (featureCode, values) in featureValues)
                {
                    var featureId = SeedId.From($"SFeature:{featureCode}");
                    var sort = 0;

                    foreach (var valueCode in values)
                    {
                        rules.Add(new SFeatureValueRule
                        {
                            Id = SeedId.From($"SFeatureValueRule:SD:{productCode}:{featureCode}:{valueCode}"),
                            SProductId = productId,
                            SFeatureId = featureId,
                            SFeatureValueId = SeedId.From($"SFeatureValue:{featureCode}:{valueCode}"),
                            SortOrder = sort++,
                            CreatedBy = "SEED",
                            CreatedDate = now,
                            Status = Domain.Enums.Status.Added
                        });
                    }
                }
            }

            builder.HasData(rules);
        }
    }
}
