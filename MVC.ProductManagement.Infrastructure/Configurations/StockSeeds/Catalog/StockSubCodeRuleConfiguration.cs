using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class StockSubCodeRuleConfiguration : IEntityTypeConfiguration<StockSubCodeRule>
    {
        public void Configure(EntityTypeBuilder<StockSubCodeRule> builder)
        {
            builder.ToTable("StockSubCodeRules");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RuleCode).HasMaxLength(50).IsRequired();
            builder.Property(x => x.RuleName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.SortOrder);
            builder.Property(x => x.IsEnabled).IsRequired();

            builder.HasIndex(x => new { x.StockSubCodeGroupId, x.RuleCode }).IsUnique();

            builder.HasOne(x => x.StockSubCodeGroup)
                .WithMany(x => x.Rules)
                .HasForeignKey(x => x.StockSubCodeGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
