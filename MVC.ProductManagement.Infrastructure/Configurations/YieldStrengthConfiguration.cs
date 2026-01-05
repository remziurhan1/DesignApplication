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
    public class YieldStrengthConfiguration : IEntityTypeConfiguration<YieldStrength>
    {
        public void Configure(EntityTypeBuilder<YieldStrength> builder)
        {
            builder.HasKey(y => y.Id);

            builder.Property(y => y.Temperature).IsRequired();
            builder.Property(y => y.Rp02).IsRequired();
            builder.Property(y => y.Rm).IsRequired();
        }
    }
}
