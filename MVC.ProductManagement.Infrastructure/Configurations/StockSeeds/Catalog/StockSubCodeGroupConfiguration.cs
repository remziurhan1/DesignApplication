using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class StockSubCodeGroupConfiguration : IEntityTypeConfiguration<StockSubCodeGroup>
    {
        public void Configure(EntityTypeBuilder<StockSubCodeGroup> builder)
        {
            builder.ToTable("StockSubCodeGroups");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.IsEnabled).IsRequired();

            builder.HasIndex(x => new { x.StockMainCodeGroupId, x.Code }).IsUnique();
        }
    }
}
