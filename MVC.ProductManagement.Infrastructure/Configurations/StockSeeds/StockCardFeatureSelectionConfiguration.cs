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
    public class StockCardFeatureSelectionConfiguration : IEntityTypeConfiguration<StockCardFeatureSelection>
    {
        public void Configure(EntityTypeBuilder<StockCardFeatureSelection> builder)
        {
            // Tablo adı
            builder.ToTable("StockCardFeatureSelections");

            // Primary Key
            builder.HasKey(x => x.Id);

            // FK alanları
            builder.Property(x => x.StockCardId).IsRequired();
            builder.Property(x => x.SFeatureId).IsRequired();
            builder.Property(x => x.SFeatureValueId).IsRequired();

            // ✅ Aynı StockCard içinde aynı Feature ikinci kez seçilemesin
            // Örn: aynı stok kartında PN iki satır olamaz
            builder.HasIndex(x => new { x.StockCardId, x.SFeatureId })
                   .IsUnique();

            // StockCard ilişkisi
            builder.HasOne(x => x.StockCard)
                   .WithMany(x => x.FeatureSelections)
                   .HasForeignKey(x => x.StockCardId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Feature ilişkisi (silme korumalı)
            builder.HasOne(x => x.SFeature)
                   .WithMany()
                   .HasForeignKey(x => x.SFeatureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // FeatureValue ilişkisi (silme korumalı)
            builder.HasOne(x => x.SFeatureValue)
                   .WithMany()
                   .HasForeignKey(x => x.SFeatureValueId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
