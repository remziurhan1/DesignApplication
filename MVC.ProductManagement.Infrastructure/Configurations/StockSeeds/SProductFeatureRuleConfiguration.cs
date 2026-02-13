using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
    public class SProductFeatureRuleConfiguration : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            builder.ToTable("SProductFeatureRules");

            builder.HasKey(x => x.Id);

            // İlişki: SProductFeatureRule -> SProduct
            builder.HasOne(x => x.SProduct)
                   .WithMany()
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SProductFeatureRule -> SFeature
            builder.HasOne(x => x.SFeature)
                   .WithMany()
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SProductFeatureRule -> SFeatureValue (nullable)
            builder.HasOne(x => x.FixedValue)
                   .WithMany()
                   .HasForeignKey(x => x.FixedValueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.IsFixed)
                   .IsRequired();

            // ✅ Aynı ürün + feature için sadece 1 kural
            builder.HasIndex(x => new { x.SProductId, x.SFeatureId })
                   .IsUnique();
        }
    }
}