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
    public class AllowableStressConfiguration : IEntityTypeConfiguration<AllowableStress>
    {
        public void Configure(EntityTypeBuilder<AllowableStress> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Temperature).IsRequired();
            builder.Property(a => a.Stress).IsRequired();
        }
    }
}
