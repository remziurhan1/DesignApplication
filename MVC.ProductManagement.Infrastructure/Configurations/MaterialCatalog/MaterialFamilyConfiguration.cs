using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.MaterialCatalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.MaterialCatalog
{
    public class MaterialFamilyConfiguration : IEntityTypeConfiguration<MaterialFamily>
    {
        public void Configure(EntityTypeBuilder<MaterialFamily> builder)
        {
            builder.ToTable("MaterialFamilies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
