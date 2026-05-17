using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.MaterialCatalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.MaterialCatalog
{
    public class MaterialStandardConfiguration : IEntityTypeConfiguration<MaterialStandard>
    {
        public void Configure(EntityTypeBuilder<MaterialStandard> builder)
        {
            builder.ToTable("MaterialStandards");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StandardCode).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => new { x.MaterialFamilyId, x.MaterialFormId, x.StandardCode }).IsUnique();

            builder.HasOne(x => x.MaterialFamily)
                .WithMany(x => x.MaterialStandards)
                .HasForeignKey(x => x.MaterialFamilyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.MaterialForm)
                .WithMany(x => x.MaterialStandards)
                .HasForeignKey(x => x.MaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
