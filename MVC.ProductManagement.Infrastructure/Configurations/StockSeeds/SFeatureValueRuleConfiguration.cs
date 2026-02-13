using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
    public class SFeatureValueRuleConfiguration : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            builder.ToTable("SFeatureValueRules");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SortOrder)
                   .IsRequired();

            // İlişki: SFeatureValueRule -> SProduct
            builder.HasOne(x => x.SProduct)
                   .WithMany()
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeatureValueRule -> SFeature
            builder.HasOne(x => x.SFeature)
                   .WithMany()
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeatureValueRule -> SFeatureValue
            builder.HasOne(x => x.SFeatureValue)
                   .WithMany()
                   .HasForeignKey(x => x.SFeatureValueId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ✅ Index: Aynı ürün + feature + value kombinasyonu bir kez
            builder.HasIndex(x => new { x.SProductId, x.SFeatureId, x.SFeatureValueId })
                   .IsUnique();
        }
    }
}