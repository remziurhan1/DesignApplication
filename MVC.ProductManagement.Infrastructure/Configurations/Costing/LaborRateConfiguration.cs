using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Infrastructure.Configurations.Costing
{
    public class LaborRateConfiguration : IEntityTypeConfiguration<LaborRate>
    {
        public void Configure(EntityTypeBuilder<LaborRate> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);
        }
    }
}
