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
    public class ThermodynamicPropertyConfiguration : IEntityTypeConfiguration<ThermodynamicProperty>
    {
        public void Configure(EntityTypeBuilder<ThermodynamicProperty> builder)
        {
            builder.ToTable("ThermodynamicProperties");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataSource).HasMaxLength(100);

            builder.HasOne(x => x.GasType)
                   .WithMany(x => x.ThermodynamicProperties)
                   .HasForeignKey(x => x.GasTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.GasTypeId, x.Temperature, x.Pressure });
        }
    }
}
