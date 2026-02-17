using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockCodes
{
    public class StockCardInventoryConfiguration : IEntityTypeConfiguration<StockCardInventory>
    {
        public void Configure(EntityTypeBuilder<StockCardInventory> builder)
        {
            builder.ToTable("StockCardInventories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MovementType)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.StockBefore)
                .IsRequired();

            builder.Property(x => x.StockAfter)
                .IsRequired();

            builder.Property(x => x.MovementDate)
                .IsRequired();

            builder.Property(x => x.Location)
                .HasMaxLength(100);

            builder.Property(x => x.ReferenceDocument)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            // ✅ StockCard ilişkisi
            builder.HasOne(x => x.StockCard)
                .WithMany(sc => sc.InventoryMovements)
                .HasForeignKey(x => x.StockCardId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Index'ler
            builder.HasIndex(x => x.StockCardId);
            builder.HasIndex(x => x.MovementDate);
            builder.HasIndex(x => x.MovementType);
            builder.HasIndex(x => x.Status); // ✅ Ekle
            builder.HasIndex(x => new { x.StockCardId, x.MovementDate });
        }
    }
}