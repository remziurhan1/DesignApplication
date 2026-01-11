using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class DesignStandardConfiguration :IEntityTypeConfiguration<DesignStandard>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DesignStandard> builder)
        {
            builder.ToTable("DesignStandards");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}
