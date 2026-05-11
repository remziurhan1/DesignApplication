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
    public class MaterialFormConfiguration : IEntityTypeConfiguration<MaterialForm>
    {
        public void Configure(EntityTypeBuilder<MaterialForm> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.ProductStandard)
                   .HasMaxLength(100);

            builder.Property(f => f.MaterialClass)
                   .HasMaxLength(50);

            builder.Property(f => f.MaterialFamily)
                   .IsRequired();

            builder.Property(f => f.Norm)
                   .HasMaxLength(50);

            builder.Property(f => f.SymbolicName)
                   .HasMaxLength(100);

            builder.Property(f => f.StockCode)
                   .HasMaxLength(100);

            builder.Property(f => f.WeldingFactor)
                   .HasPrecision(5, 2);

            builder.Property(f => f.TargetPrice)
                   .HasPrecision(10, 3)
                   .IsRequired(false);

            builder.Property(f => f.ColdStretchYieldStrength)
                   .HasPrecision(10, 3);

            builder.Property(f => f.SectionArea)
                   .HasPrecision(12, 3);

            builder.Property(f => f.MomentOfInertia)
                   .HasPrecision(14, 3);

            builder.Property(f => f.SectionModulus)
                   .HasPrecision(14, 3);

            builder.HasIndex(f => new { f.MaterialId, f.FormType, f.Norm, f.ProductStandard, f.ThicknessMin, f.ThicknessMax })
                   .IsUnique();

            builder.HasMany(f => f.YieldStrengths)
                   .WithOne(y => y.MaterialForm)
                   .HasForeignKey(y => y.MaterialFormId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.AllowableStresses)
                   .WithOne(a => a.MaterialForm)
                   .HasForeignKey(a => a.MaterialFormId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
