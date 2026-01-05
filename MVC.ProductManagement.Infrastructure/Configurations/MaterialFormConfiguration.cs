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

            builder.Property(f => f.WeldingFactor)
                   .HasPrecision(5, 2);

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
