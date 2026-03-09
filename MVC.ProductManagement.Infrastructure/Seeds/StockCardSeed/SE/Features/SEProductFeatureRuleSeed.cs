using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SE.Features
{
    public class SEProductFeatureRuleSeed : IEntityTypeConfiguration<SProductFeatureRule>
    {
        public void Configure(EntityTypeBuilder<SProductFeatureRule> builder)
        {
            // ProductFeatureRule kayıtları runtime'da servis fallback'i ile oluşturuluyor.
            // Bu yaklaşım migration sırasında FK çakışmalarını engeller.
            builder.HasData(Array.Empty<SProductFeatureRule>());
        }
    }
}
