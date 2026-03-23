using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestItemConfiguration : IEntityTypeConfiguration<SalesRequestItem>
    {
        public void Configure(EntityTypeBuilder<SalesRequestItem> builder)
        {
            builder.ToTable("SalesRequestItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ItemCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ItemTitle).IsRequired().HasMaxLength(300);
            builder.Property(x => x.CapacityM3).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ConsumptionCapacity).HasColumnType("decimal(18,2)");
            builder.Property(x => x.LinkedCalculationName).HasMaxLength(200);
            builder.Property(x => x.LinkedCostAnalysisRevisionCode).HasMaxLength(32);
            builder.Property(x => x.LinkedCostAnalysisTotal).HasColumnType("decimal(18,2)");
            builder.Property(x => x.EstimatedCost).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MinimumSalesPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ApprovedSalesPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MinimumTechnicalNotes).HasMaxLength(2000);
            builder.Property(x => x.SalesEngineeringNotes).HasMaxLength(2000);
            builder.Property(x => x.DesignDetails).HasMaxLength(4000);

            builder.HasOne(x => x.SalesRequest)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.SalesRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ProductGroup)
                .WithMany(x => x.RequestItems)
                .HasForeignKey(x => x.ProductGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ParentItem)
                .WithMany(x => x.ChildItems)
                .HasForeignKey(x => x.ParentSalesRequestItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
