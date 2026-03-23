using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class AD2000CostAnalysisConfiguration : IEntityTypeConfiguration<AD2000CostAnalysis>
    {
        public void Configure(EntityTypeBuilder<AD2000CostAnalysis> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RevisionCode).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(1024).IsRequired();

            builder.HasOne(x => x.AD2000Calculation)
                .WithMany(x => x.CostAnalyses)
                .HasForeignKey(x => x.AD2000CalculationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.HeadBombeLaborRate)
                .WithMany()
                .HasForeignKey(x => x.HeadBombeLaborRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.AD2000CalculationId, x.RevisionNo }).IsUnique();
        }
    }
}
