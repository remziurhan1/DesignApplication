using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Grade)
                   .HasMaxLength(100);

            builder.Property(m => m.Description)
                   .HasMaxLength(500);

            builder.Property(m => m.IsActive)
                   .HasDefaultValue(true);

            builder.Property(m => m.MaterialNumber)
                   .HasMaxLength(50);

            builder.Property(m => m.Density)
                   .HasPrecision(10, 3);

            builder.HasIndex(m => new { m.MaterialNumber, m.Name })
                   .IsUnique();

            builder.HasIndex(m => new { m.MaterialFamilyId, m.MaterialFormId, m.MaterialStandardId, m.Grade })
                   .IsUnique()
                   .HasFilter("[MaterialFamilyId] IS NOT NULL AND [MaterialFormId] IS NOT NULL AND [MaterialStandardId] IS NOT NULL AND [Grade] IS NOT NULL AND [Grade] <> ''");


            builder.HasOne(m => m.MaterialFamily)
                   .WithMany(f => f.Materials)
                   .HasForeignKey(m => m.MaterialFamilyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasOne(m => m.MaterialForm)
                   .WithMany(f => f.CatalogMaterials)
                   .HasForeignKey(m => m.MaterialFormId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasOne(m => m.MaterialStandard)
                   .WithMany(s => s.Materials)
                   .HasForeignKey(m => m.MaterialStandardId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasMany(m => m.Forms)
                   .WithOne(f => f.Material)
                   .HasForeignKey(f => f.MaterialId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
