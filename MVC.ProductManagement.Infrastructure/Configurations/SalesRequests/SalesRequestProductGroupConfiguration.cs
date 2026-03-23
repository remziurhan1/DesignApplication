using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestProductGroupConfiguration : IEntityTypeConfiguration<SalesRequestProductGroup>
    {
        public void Configure(EntityTypeBuilder<SalesRequestProductGroup> builder)
        {
            builder.ToTable("SalesRequestProductGroups");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(2);
            builder.Property(x => x.ShortCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}
