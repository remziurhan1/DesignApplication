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
    public class SProductConfiguration : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            builder.ToTable("SProducts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            // Aynı grup içinde aynı Code olmasın
            builder.HasIndex(x => new { x.SProductGroupId, x.Code }).IsUnique();
        }
    }
}
