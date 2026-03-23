using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestAttachmentConfiguration : IEntityTypeConfiguration<SalesRequestAttachment>
    {
        public void Configure(EntityTypeBuilder<SalesRequestAttachment> builder)
        {
            builder.ToTable("SalesRequestAttachments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OriginalFileName).IsRequired().HasMaxLength(260);
            builder.Property(x => x.StoredFileName).IsRequired().HasMaxLength(260);
            builder.Property(x => x.RelativePath).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ContentType).HasMaxLength(150);

            builder.HasOne(x => x.SalesRequest)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.SalesRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
