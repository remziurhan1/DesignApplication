using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.ProductManagement.Domain.Entities.StockCodes;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockSeeds
{
    public class SGroupFilterRuleConfiguration : IEntityTypeConfiguration<SGroupFilterRule>
    {
        public void Configure(EntityTypeBuilder<SGroupFilterRule> builder)
        {
            builder.ToTable("SGroupFilterRules");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.FluidId).IsRequired();
            builder.Property(x => x.SProductGroupId).IsRequired();

            builder.HasOne(x => x.Category)
                   .WithMany()
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Fluid)
                   .WithMany()
                   .HasForeignKey(x => x.FluidId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProductGroup)
                   .WithMany()
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Aynı kural 2 kez girilmesin
            builder.HasIndex(x => new { x.CategoryId, x.FluidId, x.SProductGroupId })
                   .IsUnique();
        }
    }
}
