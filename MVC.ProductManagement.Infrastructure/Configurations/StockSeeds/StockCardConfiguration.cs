using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
    public class StockCardConfiguration : IEntityTypeConfiguration<StockCard>
    {
        public void Configure(EntityTypeBuilder<StockCard> builder)
        {
            builder.ToTable("StockCards"); // ToTable sorunu yaşıyorsan kapalı kalsın

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StockCode8)
                   .HasMaxLength(8)
                   .IsRequired();

            builder.Property(x => x.Prefix4)
                   .HasMaxLength(4)
                   .IsRequired();

            builder.Property(x => x.Serial4)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.HasIndex(x => x.StockCode8)
                   .IsUnique();

            // ✅ Asıl benzersizlik: aynı seçim tekrar açılmasın
            builder.HasIndex(x => new
            {
                x.FluidId,
                x.SProductGroupId,
                x.SProductId
            }).IsUnique();

            builder.HasOne(x => x.Fluid)
                   .WithMany(x => x.StockCards)
                   .HasForeignKey(x => x.FluidId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProductGroup)
                   .WithMany(x => x.StockCards)
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProduct)
                   .WithMany(x => x.StockCards)
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔹 LEGACY / OPSİYONEL FK
            builder.HasOne(x => x.SAssemblyGroup)
                   .WithMany(x => x.StockCards)
                   .HasForeignKey(x => x.SAssemblyGroupId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasOne(x => x.StockSequence)
                   .WithMany(x => x.StockCards)
                   .HasForeignKey(x => x.StockSequenceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
