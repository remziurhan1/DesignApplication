using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockCodes
{
    public class StockCardGroupConfiguration : IEntityTypeConfiguration<StockCardGroup>
    {
        public void Configure(EntityTypeBuilder<StockCardGroup> builder)
        {
            builder.ToTable("StockCardGroups");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GroupCode).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CurrencyCode).IsRequired().HasMaxLength(3);
            builder.Property(x => x.TotalAmount).HasColumnType("decimal(18,4)");

            builder.HasIndex(x => x.GroupCode).IsUnique();
            builder.HasIndex(x => x.CreatedDate);
        }
    }
}
