using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
      public class FluidConfiguration : IEntityTypeConfiguration<Fluid>
    {
        public void Configure(EntityTypeBuilder<Fluid> builder)
        {
            builder.ToTable("Fluids");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(1); // A, B, C...

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50); // LPG, LNG, LIN...

            builder.HasIndex(x => x.Name)
                .IsUnique(false); // İstersen unique yaparız; şimdilik şart değil.
        }
    }
}
