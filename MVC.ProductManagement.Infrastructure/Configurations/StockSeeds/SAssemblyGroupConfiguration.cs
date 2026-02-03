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
    public class SAssemblyGroupConfiguration : IEntityTypeConfiguration<SAssemblyGroup>
    {
        public void Configure(EntityTypeBuilder<SAssemblyGroup> builder)
        {
            builder.ToTable("SAssemblyGroups");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Step3Letter).HasMaxLength(1).IsRequired(); // A..H,Z
            builder.Property(x => x.Step4Digit).IsRequired(); // 0..9
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();

            builder.HasIndex(x => new { x.Step3Letter, x.Step4Digit }).IsUnique();

            // ✅ SProductGroup’da AssemblyGroups koleksiyonu olmadığı için WithMany()
            builder.HasOne(x => x.SProductGroup)
                   .WithMany()
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
