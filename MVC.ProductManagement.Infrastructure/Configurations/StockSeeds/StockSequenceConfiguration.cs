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
    public class StockSequenceConfiguration : IEntityTypeConfiguration<StockSequence>
    {
        public void Configure(EntityTypeBuilder<StockSequence> builder)
        {
            builder.ToTable("StockSequences");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Prefix4).HasMaxLength(4).IsRequired();
            builder.Property(x => x.StartNumber).IsRequired();
            builder.Property(x => x.LastNumber).IsRequired();

            builder.HasIndex(x => x.Prefix4).IsUnique();
        }
    }
}
