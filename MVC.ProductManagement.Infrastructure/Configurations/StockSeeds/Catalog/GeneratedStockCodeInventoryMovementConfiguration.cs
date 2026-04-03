using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class GeneratedStockCodeInventoryMovementConfiguration : IEntityTypeConfiguration<GeneratedStockCodeInventoryMovement>
    {
        public void Configure(EntityTypeBuilder<GeneratedStockCodeInventoryMovement> builder)
        {
            builder.ToTable("GeneratedStockCodeInventoryMovements");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.StockBefore).IsRequired();
            builder.Property(x => x.StockAfter).IsRequired();
            builder.Property(x => x.MovementDate).IsRequired();
            builder.Property(x => x.ReferenceDocument).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.HasIndex(x => new { x.GeneratedStockCodeId, x.MovementDate });

            builder.HasOne(x => x.GeneratedStockCode)
                .WithMany(x => x.InventoryMovements)
                .HasForeignKey(x => x.GeneratedStockCodeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.StockProductGroup)
                .WithMany()
                .HasForeignKey(x => x.StockProductGroupId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
