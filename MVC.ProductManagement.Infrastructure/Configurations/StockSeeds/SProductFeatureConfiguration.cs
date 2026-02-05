using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
    public class SProductFeatureConfiguration : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            // Tablo adı
            builder.ToTable("SProductFeatures");

            // Primary Key
            builder.HasKey(x => x.Id);

            // FK'lar
            builder.Property(x => x.SProductId).IsRequired();
            builder.Property(x => x.SFeatureId).IsRequired();

            // Bu ürün için bu feature zorunlu mu?
            builder.Property(x => x.IsRequired).IsRequired();

            // Ürün bazlı sıralama (null olabilir)
            builder.Property(x => x.SortOrder).IsRequired(false);

            // ✅ Aynı üründe aynı feature ikinci kez tanımlanamasın
            // Örn: SFC0 için PN iki kere eklenemez
            builder.HasIndex(x => new { x.SProductId, x.SFeatureId })
                   .IsUnique();

            // İlişki: SProduct -> SProductFeature
            // (SProduct entity'sinde navigation yoksa sorun değil; WithMany() boş kalabilir)
            builder.HasOne(x => x.SProduct)
                   .WithMany()
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki: SFeature -> SProductFeature
            builder.HasOne(x => x.SFeature)
                   .WithMany(x => x.ProductFeatures)
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
