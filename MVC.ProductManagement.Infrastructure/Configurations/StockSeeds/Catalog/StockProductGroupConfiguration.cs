using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class StockProductGroupConfiguration : IEntityTypeConfiguration<StockProductGroup>
    {
        public void Configure(EntityTypeBuilder<StockProductGroup> builder)
        {
            builder.ToTable("StockProductGroups");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.TotalQuantity).IsRequired();
            builder.Property(x => x.TotalCost).HasColumnType("decimal(18,2)");
        }
    }
}
