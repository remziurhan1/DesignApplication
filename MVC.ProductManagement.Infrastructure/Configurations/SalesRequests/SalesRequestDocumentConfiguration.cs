using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestDocumentConfiguration : IEntityTypeConfiguration<SalesRequestDocument>
    {
        public void Configure(EntityTypeBuilder<SalesRequestDocument> builder)
        {
            builder.ToTable("SalesRequestDocuments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RevisionCode).IsRequired().HasMaxLength(16);
            builder.Property(x => x.FilePath).IsRequired().HasMaxLength(500);
            builder.Property(x => x.OriginalFileName).IsRequired().HasMaxLength(260);
            builder.Property(x => x.UploadedBy).HasMaxLength(150);
            builder.Property(x => x.LinkedCostAnalysisRevisionCode).HasMaxLength(16);
            builder.Property(x => x.Notes).HasMaxLength(1000);

            builder.HasOne(x => x.SalesRequest)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.SalesRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SalesRequestItem)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.SalesRequestItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.SalesRequestId, x.DocumentType, x.RevisionCode });
        }
    }
}
