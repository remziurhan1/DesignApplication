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
    public class SFeatureValueConfiguration : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            // Tablo adı
            builder.ToTable("SFeatureValues");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Feature FK (PN, DN, STD gibi hangi feature'a ait)
            builder.Property(x => x.SFeatureId)
                   .IsRequired();

            // Code: sistem kodu (OptionKey burada üretilir)
            // Örn: PN40, DN50, EN1092, ASME_B16_5
            builder.Property(x => x.Code)
                   .HasMaxLength(50)
                   .IsRequired();

            // Name: kullanıcıya görünen metin
            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // Aynı feature altındaki sıralama
            builder.Property(x => x.SortOrder)
                   .IsRequired();

            // ✅ Aynı feature altında aynı Code iki kez olmasın
            // Örn: PN altında iki tane PN40 olamaz
            builder.HasIndex(x => new { x.SFeatureId, x.Code })
                   .IsUnique();

            // İlişki: Feature -> FeatureValue
            builder.HasOne(x => x.SFeature)
                   .WithMany(x => x.Values)
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
