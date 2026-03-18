using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Infrastructure.Configurations.Costing
{
    public class OverheadRateConfiguration : IEntityTypeConfiguration<OverheadRate>
    {
        public void Configure(EntityTypeBuilder<OverheadRate> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.OverheadType).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);
        }
    }
}
