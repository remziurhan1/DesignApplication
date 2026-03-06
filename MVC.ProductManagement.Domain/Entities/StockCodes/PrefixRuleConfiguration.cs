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
            //builder.ToTable("PrefixRules"); // Ensure Microsoft.EntityFrameworkCore is referenced  

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Prefix4).HasMaxLength(4).IsRequired();

            builder.HasOne(x => x.SProductGroup)
                   .WithMany(x => x.PrefixRules)
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProduct)
                   .WithMany(x => x.PrefixRules)
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Ensure unique combinations  
            builder.HasIndex(x => new { x.SProductGroupId, x.SProductId }).IsUnique();

            // Ensure Prefix4 uniqueness  
            builder.HasIndex(x => x.Prefix4).IsUnique();
        }
    }
}
