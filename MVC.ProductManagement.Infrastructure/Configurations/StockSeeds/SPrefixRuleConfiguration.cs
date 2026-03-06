using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.S;

namespace MVC.ProductManagement.Infrastructure.Configurations.StockCodes
{
    public class SPrefixRuleConfiguration : IEntityTypeConfiguration<SPrefixRule>
    {
        public void Configure(EntityTypeBuilder<SPrefixRule> builder)
        {
            builder.ToTable("SPrefixRules");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Prefix)
                   .IsRequired()
                   .HasMaxLength(4);

            builder.Property(x => x.SProductGroupId).IsRequired();
            builder.Property(x => x.SProductId).IsRequired();

            builder.HasOne(x => x.SProductGroup)
                   .WithMany()
                   .HasForeignKey(x => x.SProductGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SProduct)
                   .WithMany()
                   .HasForeignKey(x => x.SProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.SProductGroupId, x.SProductId })
                   .IsUnique();
        }
    }
}
