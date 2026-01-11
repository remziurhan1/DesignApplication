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
    class GasTypeDesignStandardConfiguration : IEntityTypeConfiguration<GasTypeDesignStandard>
    {
        public void Configure(EntityTypeBuilder<GasTypeDesignStandard> builder)
        {
            builder.ToTable("GasTypeDesignStandards");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.GasType)
                   .WithMany(g => g.DesignStandards)
                   .HasForeignKey(x => x.GasTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DesignStandard)
                .WithMany(x => x.GasTypes)
                .HasForeignKey(x => x.DesignStandardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.GasTypeId, x.DesignStandardId }).IsUnique();


        }
    }
}
