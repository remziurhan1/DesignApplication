using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockCodes
{
    public class StockCardPriceConfiguration : IEntityTypeConfiguration<StockCardPrice>
    {
        public void Configure(EntityTypeBuilder<StockCardPrice> builder)
        {
            builder.ToTable("StockCardPrices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Currency)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder.Property(x => x.ValidFrom)
                .IsRequired();

            builder.Property(x => x.ValidTo)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            // ✅ StockCard ilişkisi
            builder.HasOne(x => x.StockCard)
                .WithMany(sc => sc.Prices)
                .HasForeignKey(x => x.StockCardId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Index'ler
            builder.HasIndex(x => x.StockCardId);
            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.Status); // ✅ Ekle
            builder.HasIndex(x => x.ValidFrom);
            builder.HasIndex(x => new { x.StockCardId, x.IsActive, x.ValidFrom });
        }
    }
}