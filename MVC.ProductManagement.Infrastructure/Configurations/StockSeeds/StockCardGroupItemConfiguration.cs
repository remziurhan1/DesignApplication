using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockCodes
{
    public class StockCardGroupItemConfiguration : IEntityTypeConfiguration<StockCardGroupItem>
    {
        public void Configure(EntityTypeBuilder<StockCardGroupItem> builder)
        {
            builder.ToTable("StockCardGroupItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,4)");
            builder.Property(x => x.LineTotal).HasColumnType("decimal(18,4)");

            builder.HasOne(x => x.StockCardGroup)
                .WithMany(g => g.Items)
                .HasForeignKey(x => x.StockCardGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.StockCard)
                .WithMany(c => c.GroupItems)
                .HasForeignKey(x => x.StockCardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.StockCardGroupId, x.StockCardId });
        }
    }
}
