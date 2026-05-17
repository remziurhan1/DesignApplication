using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.MaterialCatalog;

namespace MVC.ProductManagement.Infrastructure.Configurations.MaterialCatalog
{
    public class MaterialMechanicalPropertyConfiguration : IEntityTypeConfiguration<MaterialMechanicalProperty>
    {
        public void Configure(EntityTypeBuilder<MaterialMechanicalProperty> builder)
        {
            builder.ToTable("MaterialMechanicalProperties");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.YieldStrength).HasPrecision(10, 3);
            builder.Property(x => x.TensileStrengthMin).HasPrecision(10, 3);
            builder.Property(x => x.TensileStrengthMax).HasPrecision(10, 3);
            builder.Property(x => x.Elongation).HasPrecision(10, 3);
            builder.Property(x => x.AllowableStress).HasPrecision(10, 3);
            builder.Property(x => x.SourceNote).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => new { x.MaterialId, x.ThicknessMin, x.ThicknessMax, x.Temperature }).IsUnique();

            builder.HasOne(x => x.Material)
                .WithMany(x => x.MechanicalProperties)
                .HasForeignKey(x => x.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
