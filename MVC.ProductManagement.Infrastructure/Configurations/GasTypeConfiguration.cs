using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class GasTypeConfiguration : IEntityTypeConfiguration<GasType>
    {
        public void Configure(EntityTypeBuilder<GasType> builder)
        {
            builder.ToTable("GasTypes");
            builder.HasKey(gt => gt.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ProductCodePrefix).IsRequired().HasMaxLength(20);
            builder.Property(x => x.GasGroup).IsRequired().HasMaxLength(20);
            builder.Property(x => x.ChemicalFormula).HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasIndex(x => x.Code).IsUnique();

        }
    }
}
