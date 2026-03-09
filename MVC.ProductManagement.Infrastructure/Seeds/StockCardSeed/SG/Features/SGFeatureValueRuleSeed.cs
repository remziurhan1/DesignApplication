using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SG.Features
{
    public class SGFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            // FeatureValueRule seed'i SG için servis fallback'ine taşındı.
            builder.HasData(Array.Empty<SFeatureValueRule>());
        }
    }
}
