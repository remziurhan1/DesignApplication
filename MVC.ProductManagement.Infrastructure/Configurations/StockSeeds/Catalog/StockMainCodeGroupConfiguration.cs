using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class StockMainCodeGroupConfiguration : IEntityTypeConfiguration<StockMainCodeGroup>
    {
        public void Configure(EntityTypeBuilder<StockMainCodeGroup> builder)
        {
            builder.ToTable("StockMainCodeGroups");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.IsEnabled).IsRequired();

            builder.HasIndex(x => x.Code).IsUnique();

            builder.HasMany(x => x.SubGroups)
                .WithOne(x => x.StockMainCodeGroup)
                .HasForeignKey(x => x.StockMainCodeGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
