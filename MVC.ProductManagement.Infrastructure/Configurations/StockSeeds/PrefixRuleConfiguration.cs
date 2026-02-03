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
    public class PrefixRuleConfiguration : IEntityTypeConfiguration<PrefixRule>
    {
        public void Configure(EntityTypeBuilder<PrefixRule> builder)
        {
            builder.ToTable("PrefixRules");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Prefix4).HasMaxLength(4).IsRequired();

            builder.HasOne(x => x.Fluid)
                   .WithMany(x => x.PrefixRules)
                   .HasForeignKey(x => x.FluidId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProductGroup)
                   .WithMany(x => x.PrefixRules)
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProduct)
                   .WithMany(x => x.PrefixRules)
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Aynı kombinasyona 2 prefix olmasın
            builder.HasIndex(x => new { x.FluidId, x.SProductGroupId, x.SProductId }).IsUnique();

            // Prefix4 de tekil olsun (prefix çakışmasın)
            builder.HasIndex(x => x.Prefix4).IsUnique();
        }
    }
}
