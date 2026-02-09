using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD
{
    public class SDStockSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var sequences = new List<StockSequence>();

            // ==================== TÜM SD ÜRÜN KODLARI (41 ADET) ====================
            var sdPrefixes = new[]
            {
                // SDA Serisi - Hidrolik
                "SDA0", "SDA1", "SDA2", "SDA3", "SDA4", "SDA5", "SDA6", "SDA7", "SDA8", "SDA9",
                
                // SDB Serisi - Pnömatik
                "SDB0", "SDB1", "SDB2", "SDB3", "SDB4",
                
                // SDC Serisi - Çelik
                "SDC0", "SDC1", "SDC2", "SDC3", "SDC4",
                
                // SDD Serisi - Alüminyum
                "SDD0", "SDD1", "SDD2", "SDD3", "SDD4", "SDD5",
                
                // SDE Serisi - Paslanmaz
                "SDE0", "SDE1", "SDE2", "SDE3", "SDE4",
                
                // SDF Serisi - Pirinç ve Polyemid
                "SDF0", "SDF1", "SDF2", "SDF3", "SDF4", "SDF9",
                
                // SDG Serisi - Polyemid/Polietilen
                "SDG1", "SDG3",
                
                // SDH Serisi - Galvaniz
                "SDH0", "SDH1",
                
                // SDI Serisi - Bronz
                "SDI1"
            };

            foreach (var prefix in sdPrefixes)
            {
                sequences.Add(new StockSequence
                {
                    Id = SeedId.From($"StockSequence:{prefix}"),
                    Prefix4 = prefix,
                    LastNumber = 0,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            builder.HasData(sequences);
        }
    }
}