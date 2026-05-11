using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class AD2000CostAnalysisItemConfiguration : IEntityTypeConfiguration<AD2000CostAnalysisItem>
    {
        public void Configure(EntityTypeBuilder<AD2000CostAnalysisItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ItemKey).HasMaxLength(64).IsRequired();
            builder.Property(x => x.ItemSourceType).HasMaxLength(32).IsRequired();
            builder.Property(x => x.CostGroupCode).HasMaxLength(32).IsRequired();
            builder.Property(x => x.CostGroupName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ItemName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.MaterialName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.FormType).HasMaxLength(64).IsRequired();
            builder.Property(x => x.MaterialNumber).HasMaxLength(64).IsRequired();
            builder.Property(x => x.MaterialClass).HasMaxLength(64).IsRequired();
            builder.Property(x => x.MaterialFamily).HasMaxLength(64).IsRequired();
            builder.Property(x => x.Norm).HasMaxLength(64).IsRequired();
            builder.Property(x => x.ProductStandard).HasMaxLength(128).IsRequired();
            builder.Property(x => x.SymbolicName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.DensitySource).HasMaxLength(64).IsRequired();
            builder.Property(x => x.PriceSource).HasMaxLength(64).IsRequired();
            builder.Property(x => x.StockCode).HasMaxLength(32).IsRequired();
            builder.Property(x => x.StockCodeName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Unit).HasMaxLength(32).IsRequired();

            builder.HasOne(x => x.AD2000CostAnalysis)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.AD2000CostAnalysisId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.AD2000CostAnalysisId);
            builder.HasIndex(x => new { x.AD2000CostAnalysisId, x.ItemKey });
        }
    }
}
