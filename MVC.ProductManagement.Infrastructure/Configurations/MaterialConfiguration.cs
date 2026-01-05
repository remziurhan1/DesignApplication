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

            builder.Property(m => m.MaterialNumber)
                   .HasMaxLength(50);

            builder.Property(m => m.Group)
                   .HasMaxLength(50);

            builder.Property(m => m.Density)
                   .HasPrecision(10, 3);

            builder.HasMany(m => m.Forms)
                   .WithOne(f => f.Material)
                   .HasForeignKey(f => f.MaterialId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
