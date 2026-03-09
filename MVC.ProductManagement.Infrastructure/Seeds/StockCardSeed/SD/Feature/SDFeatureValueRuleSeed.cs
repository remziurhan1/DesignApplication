using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using System;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SD.Features
{
    public class SDFeatureValueRuleSeed : IEntityTypeConfiguration<SFeatureValueRule>
    {
        public void Configure(EntityTypeBuilder<SFeatureValueRule> builder)
        {
            // FeatureValueRule seed'i SD için servis fallback'ine taşındı.
            builder.HasData(Array.Empty<SFeatureValueRule>());
        }
    }
}
