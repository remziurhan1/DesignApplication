using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Configurations
{
   public  class EN13458Configuration : IEntityTypeConfiguration<EN13458Calculation>
    {
        public void Configure(EntityTypeBuilder<EN13458Calculation> builder)
        {
            builder.HasKey(x => x.Id);

            // İç Gövde
            builder.HasOne(x => x.InnerShellMaterial)
                .WithMany()
                .HasForeignKey(x => x.InnerShellMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InnerShellMaterialForm)
                .WithMany()
                .HasForeignKey(x => x.InnerShellMaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);

            // İç Bombe
            builder.HasOne(x => x.InnerHeadMaterial)
                .WithMany()
                .HasForeignKey(x => x.InnerHeadMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InnerHeadMaterialForm)
                .WithMany()
                .HasForeignKey(x => x.InnerHeadMaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dış Gövde
            builder.HasOne(x => x.OuterShellMaterial)
                .WithMany()
                .HasForeignKey(x => x.OuterShellMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OuterShellMaterialForm)
                .WithMany()
                .HasForeignKey(x => x.OuterShellMaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dış Bombe
            builder.HasOne(x => x.OuterHeadMaterial)
                .WithMany()
                .HasForeignKey(x => x.OuterHeadMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OuterHeadMaterialForm)
                .WithMany()
                .HasForeignKey(x => x.OuterHeadMaterialFormId)
                .OnDelete(DeleteBehavior.Restrict);


            // ProductType ile ilişki (Many-to-One)
            builder.HasOne(cc => cc.StorageService) // Tank hesaplaması bir ProductType ile ilişkilidir
                .WithMany(pt => pt.EN13458Calculations) // ProductType birçok Tank hesaplaması ile ilişkilidir
                .HasForeignKey(cc => cc.ProductTypeId) // Foreign key tanımı
                .OnDelete(DeleteBehavior.Restrict); // Silme davranışı (ProductType silinemez)


        }
    }
}
