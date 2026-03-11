using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
    public class AD2000Configuration : IEntityTypeConfiguration<AD2000Calculation>
    {
        public void Configure(EntityTypeBuilder<AD2000Calculation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ShellMaterial)
                .WithMany()
                .HasForeignKey(x => x.ShellMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ShellMaterialForm)
                .WithMany()
                .HasForeignKey(x => x.ShellMaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HeadMaterial)
                .WithMany()
                .HasForeignKey(x => x.HeadMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HeadMaterialForm)
                .WithMany()
                .HasForeignKey(x => x.HeadMaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
