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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ContactName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(30);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.TaxNumber).HasMaxLength(50);
            builder.Property(x => x.TaxOffice).HasMaxLength(100);
            builder.Property(x => x.Notes).HasMaxLength(1000);
        }
    }
}
