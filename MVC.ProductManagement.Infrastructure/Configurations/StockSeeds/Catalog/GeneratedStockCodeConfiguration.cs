using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class GeneratedStockCodeConfiguration : IEntityTypeConfiguration<GeneratedStockCode>
    {
        public void Configure(EntityTypeBuilder<GeneratedStockCode> builder)
        {
            builder.ToTable("GeneratedStockCodes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GeneratedCode).HasMaxLength(8).IsRequired();
            builder.Property(x => x.RuleName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TargetPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.StockSubCodeGroup)
                .WithMany(x => x.GeneratedCodes)
                .HasForeignKey(x => x.StockSubCodeGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StockSubCodeRule)
                .WithMany(x => x.GeneratedCodes)
                .HasForeignKey(x => x.StockSubCodeRuleId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
