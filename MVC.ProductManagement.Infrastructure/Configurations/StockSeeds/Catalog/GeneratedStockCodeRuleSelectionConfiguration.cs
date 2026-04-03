using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds.Catalog
{
    public class GeneratedStockCodeRuleSelectionConfiguration : IEntityTypeConfiguration<GeneratedStockCodeRuleSelection>
    {
        public void Configure(EntityTypeBuilder<GeneratedStockCodeRuleSelection> builder)
        {
            builder.ToTable("GeneratedStockCodeRuleSelections");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.GeneratedStockCodeId, x.StockSubCodeRuleId }).IsUnique();

            builder.HasOne(x => x.GeneratedStockCode)
                .WithMany(x => x.RuleSelections)
                .HasForeignKey(x => x.GeneratedStockCodeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.StockSubCodeRule)
                .WithMany(x => x.GeneratedCodeSelections)
                .HasForeignKey(x => x.StockSubCodeRuleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
