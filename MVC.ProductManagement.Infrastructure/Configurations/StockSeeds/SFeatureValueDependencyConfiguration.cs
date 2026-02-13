using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
    public class SFeatureValueDependencyConfiguration : IEntityTypeConfiguration<SFeatureValueDependency>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueDependency> builder)
        {
            builder.ToTable("SFeatureValueDependencies");

            builder.HasKey(x => x.Id);

            // İlişki: SFeatureValueDependency -> SProduct (nullable)
            builder.HasOne(x => x.SProduct)
                   .WithMany()
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeatureValueDependency -> SourceFeature
            builder.HasOne(x => x.SourceFeature)
                   .WithMany()
                   .HasForeignKey(x => x.SourceFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeatureValueDependency -> SourceValue
            builder.HasOne(x => x.SourceValue)
                   .WithMany()
                   .HasForeignKey(x => x.SourceValueId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeatureValueDependency -> TargetFeature
            builder.HasOne(x => x.TargetFeature)
                   .WithMany()
                   .HasForeignKey(x => x.TargetFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeatureValueDependency -> TargetValue
            builder.HasOne(x => x.TargetValue)
                   .WithMany()
                   .HasForeignKey(x => x.TargetValueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Type)
                   .IsRequired()
                   .HasConversion<int>();

            // ✅ Index: Hızlı sorgu için
            builder.HasIndex(x => new { x.SProductId, x.SourceFeatureId, x.SourceValueId });
        }
    }
}