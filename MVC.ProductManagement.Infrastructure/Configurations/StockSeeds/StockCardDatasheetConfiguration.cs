using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockCodes
{
    public class StockCardDatasheetConfiguration : IEntityTypeConfiguration<StockCardDatasheet>
    {
        public void Configure(EntityTypeBuilder<StockCardDatasheet> builder)
        {
            builder.ToTable("StockCardDatasheets");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Version)
                .HasDefaultValue(1);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            // ✅ StockCard ilişkisi
            builder.HasOne(x => x.StockCard)
                .WithMany(sc => sc.Datasheets)
                .HasForeignKey(x => x.StockCardId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Index'ler
            builder.HasIndex(x => x.StockCardId);
            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.Status); // ✅ Ekle
            builder.HasIndex(x => new { x.StockCardId, x.Version });
        }
    }
}