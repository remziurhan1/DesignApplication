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
    public class StorageTypeConfiguration : IEntityTypeConfiguration<StorageType>
    {
        public void Configure(EntityTypeBuilder<StorageType> builder)
        {
            // İlişkiler
            // ProductType -> CryogenicsCalculations (One-to-Many)
            builder.HasMany(pt => pt.EN13458Calculations) // Bir ProductType birden fazla CryogenicsCalculation içerir
                .WithOne(cc => cc.StorageService) // CryogenicsCalculation bir ProductType'a aittir
                .HasForeignKey(cc => cc.ProductTypeId) // Foreign key tanımı
                .OnDelete(DeleteBehavior.Restrict); // ProductType silindiğinde CryogenicsCalculation etkilenmez
        }
    }
}
