using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Infrastructure.Configurations.Costing
{
    public class BombeLaborRateConfiguration : IEntityTypeConfiguration<BombeLaborRate>
    {
        public void Configure(EntityTypeBuilder<BombeLaborRate> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.MaterialType).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);
        }
    }
}
