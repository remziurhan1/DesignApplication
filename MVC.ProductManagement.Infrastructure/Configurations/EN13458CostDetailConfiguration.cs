using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class EN13458CostDetailConfiguration : IEntityTypeConfiguration<EN13458CostDetail>
    {
        public void Configure(EntityTypeBuilder<EN13458CostDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CostGroupCode).HasMaxLength(32).IsRequired();
            builder.Property(x => x.CostGroupName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ItemName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.StockCode).HasMaxLength(32).IsRequired();
            builder.Property(x => x.MaterialName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.FormType).HasMaxLength(64).IsRequired();
            builder.Property(x => x.Unit).HasMaxLength(32).IsRequired();

            builder.HasOne(x => x.EN13458Calculation)
                .WithMany(x => x.CostDetails)
                .HasForeignKey(x => x.EN13458CalculationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.EN13458CalculationId);
        }
    }
}
