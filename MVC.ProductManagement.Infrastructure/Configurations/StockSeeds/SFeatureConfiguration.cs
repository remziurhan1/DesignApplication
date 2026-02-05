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
    public class SFeatureConfiguration : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            // Tablo adı
            builder.ToTable("SFeatures");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Code: PN, DN, CONN, STD gibi kısa kodlar (OptionKey üretirken burayı kullanacağız)
            builder.Property(x => x.Code)
                   .HasMaxLength(30)
                   .IsRequired();

            // Name: kullanıcıya görünen ad (Basınç Sınıfı, Anma Çapı...)
            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // SortOrder: UI sıralaması + OptionKey sıralaması için temel sıralama
            builder.Property(x => x.SortOrder)
                   .IsRequired();

            // ✅ Aynı Code iki defa olmasın (PN bir tane olmalı)
            builder.HasIndex(x => x.Code)
                   .IsUnique();

            // İlişki 1: Feature -> Values (SFeatureValue)
            // Bir feature'ın birçok değeri olur (PN -> PN16/PN40..., DN -> DN50...)
            builder.HasMany(x => x.Values)
                   .WithOne(x => x.SFeature)
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İlişki 2: Feature -> ProductFeatures (SProductFeature)
            // Bir feature birçok üründe kullanılabilir (PN hem SFC0 hem SFA0’da zorunlu)
            builder.HasMany(x => x.ProductFeatures)
                   .WithOne(x => x.SFeature)
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
