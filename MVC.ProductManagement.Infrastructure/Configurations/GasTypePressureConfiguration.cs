using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class GasTypePressureConfiguration : IEntityTypeConfiguration<GasTypePressure>
    {
        public void Configure(EntityTypeBuilder<GasTypePressure> builder)
        {
            builder.ToTable("GasTypePressures");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.DisplayName).IsRequired().HasMaxLength(50);

            builder.HasOne(x=>x.GasType)
                   .WithMany(g => g.Pressures)
                   .HasForeignKey(x => x.GasTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
