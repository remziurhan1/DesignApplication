using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class EN13458CostAnalysisConfiguration : IEntityTypeConfiguration<EN13458CostAnalysis>
    {
        public void Configure(EntityTypeBuilder<EN13458CostAnalysis> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RevisionCode).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(1024).IsRequired();

            builder.HasOne(x => x.EN13458Calculation)
                .WithMany(x => x.CostAnalyses)
                .HasForeignKey(x => x.EN13458CalculationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.InnerHeadBombeLaborRate)
                .WithMany()
                .HasForeignKey(x => x.InnerHeadBombeLaborRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OuterHeadBombeLaborRate)
                .WithMany()
                .HasForeignKey(x => x.OuterHeadBombeLaborRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.EN13458CalculationId, x.RevisionNo }).IsUnique();
        }
    }
}
