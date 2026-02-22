using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    public class SFProductFeatureSeed : IEntityTypeConfiguration<SProductFeature>
    {
        public void Configure(EntityTypeBuilder<SProductFeature> builder)
        {
            // SProductFeatureRule seed'i ürün-özellik ilişkilerini zaten tanımlıyor.
            // Bu tabloya ayrıca seed gerekmez.
        }
    }
}