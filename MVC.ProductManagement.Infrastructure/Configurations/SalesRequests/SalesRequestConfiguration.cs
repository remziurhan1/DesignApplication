using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestConfiguration : IEntityTypeConfiguration<SalesRequest>
    {
        public void Configure(EntityTypeBuilder<SalesRequest> builder)
        {
            builder.ToTable("SalesRequests");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RequestNo).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.RequestedByName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.RequestedByEmail).HasMaxLength(150);
            builder.Property(x => x.RequestedByDepartment).HasMaxLength(100);
            builder.Property(x => x.SummaryNotes).HasMaxLength(2000);
            builder.Property(x => x.InternalNotes).HasMaxLength(2000);
            builder.Property(x => x.RevisionNo).HasDefaultValue(1);
            builder.HasIndex(x => x.RequestNo).IsUnique();

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Revisions)
                .WithOne(x => x.SalesRequest)
                .HasForeignKey(x => x.SalesRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Documents)
                .WithOne(x => x.SalesRequest)
                .HasForeignKey(x => x.SalesRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.SalesRequest)
                .HasForeignKey(x => x.SalesRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
