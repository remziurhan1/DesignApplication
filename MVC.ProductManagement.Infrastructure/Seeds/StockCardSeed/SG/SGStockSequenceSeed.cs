using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG
{
    public class SGStockSequenceSeed : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            var now = new DateTime(2026, 02, 05);

            var sequences = new List<StockSequence>();

            // ==================== TÜM SG ÜRÜN KODLARI (10 ADET) ====================
            var sgPrefixes = new[]
            {
                "SGA0", "SGA1", "SGA2", "SGA3", "SGA4", "SGA5", "SGA6", "SGA7", "SGA8", "SGA9"
            };

            foreach (var prefix in sgPrefixes)
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