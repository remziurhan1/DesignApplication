using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestRevisionConfiguration : IEntityTypeConfiguration<SalesRequestRevision>
    {
        public void Configure(EntityTypeBuilder<SalesRequestRevision> builder)
        {
            builder.ToTable("SalesRequestRevisions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RevisionReason).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.SnapshotJson).IsRequired();
            builder.Property(x => x.RevisedByName).IsRequired().HasMaxLength(150);
            builder.HasIndex(x => new { x.SalesRequestId, x.RevisionNo }).IsUnique();
        }
    }
}
