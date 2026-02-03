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
    public class SProductGroupConfiguration : IEntityTypeConfiguration<SProductGroup>
    {
        public void Configure(EntityTypeBuilder<SProductGroup> builder)
        {
            builder.ToTable("SProductGroups");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).HasMaxLength(1).IsRequired(); // A..H,Z
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.HasIndex(x => x.Code).IsUnique();

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.SProductGroup)
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
