using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class StockProductGroupItemConfiguration : IEntityTypeConfiguration<StockProductGroupItem>
    {
        public void Configure(EntityTypeBuilder<StockProductGroupItem> builder)
        {
            builder.ToTable("StockProductGroupItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalCost).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.StockProductGroup)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.StockProductGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GeneratedStockCode)
                .WithMany(x => x.ProductGroupItems)
                .HasForeignKey(x => x.GeneratedStockCodeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.StockProductGroupId, x.GeneratedStockCodeId });
        }
    }
}
