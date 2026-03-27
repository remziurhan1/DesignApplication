using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.SalesRequests;

namespace MVC.ProductManagement.Infrastructure.Configurations.SalesRequests
{
    public class SalesRequestCommentConfiguration : IEntityTypeConfiguration<SalesRequestComment>
    {
        public void Configure(EntityTypeBuilder<SalesRequestComment> builder)
        {
            builder.ToTable("SalesRequestComments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CommentText).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.CommentedBy).IsRequired().HasMaxLength(150);
        }
    }
}
