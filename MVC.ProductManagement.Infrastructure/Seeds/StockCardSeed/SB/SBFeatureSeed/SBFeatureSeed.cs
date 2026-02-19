using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.Features
{
    public class SBFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(new SFeature
            {
                Id = SeedId.From("SFeature:NUT_TYPE"), // ✅ SB: prefix YOK
                Code = "NUT_TYPE",
                Name = "Somun Tipi",
                SortOrder = 10,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            });
        }
    }
}