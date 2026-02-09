using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE
{
    public class SEStockSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var sequences = new List<StockSequence>();

            // ==================== TÜM SE ÜRÜN KODLARI (37 ADET) ====================
            var sePrefixes = new[]
            {
                // SEA Serisi - Kablo, Akü ve Elektrik Elemanları (11 adet)
                "SEA0", "SEA1", "SEA2", "SEA3", "SEA4", "SEA5", "SEA6", "SEA7", "SEA8", "SEA9", "SEAA",
                
                // SEB Serisi - Ampul, Terminal, Makaron (10 adet)
                "SEB0", "SEB1", "SEB2", "SEB3", "SEB4", "SEB5", "SEB6", "SEB7", "SEB8", "SEB9",
                
                // SEC Serisi - Motor, Load Cell, Kablolar (10 adet)
                "SEC0", "SEC1", "SEC2", "SEC3", "SEC4", "SEC5", "SEC6", "SEC7", "SEC8", "SEC9",
                
                // SED Serisi - Algılayıcılar, Haberleşme, Tabela (3 adet)
                "SED0", "SED1", "SED9",
                
                // SEE Serisi - Elektrik Malzemeler (1 adet)
                "SEE0",
                
                // SEF Serisi - Kablo (2 adet)
                "SEF0", "SEF1",
                
                // SEG Serisi - Bağlantı Kutusu (1 adet)
                "SEG0"
            };

            foreach (var prefix in sePrefixes)
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