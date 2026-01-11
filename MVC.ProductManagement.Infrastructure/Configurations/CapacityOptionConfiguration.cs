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
    public class CapacityOptionConfiguration : IEntityTypeConfiguration<CapacityOption>
    {
        public void Configure(EntityTypeBuilder<CapacityOption> builder)
        {
            builder.ToTable("CapacityOptions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.CapacityGroup)
                   .WithMany(x => x.CapacityOptions)
                   .HasForeignKey(x => x.CapacityGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
