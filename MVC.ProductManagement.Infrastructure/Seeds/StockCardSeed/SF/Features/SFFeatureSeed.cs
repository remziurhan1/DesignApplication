using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.SFFeatureSeed
{
    /// <summary>
    /// SF grubu için özellik tanımları (PN, DN, SURFACE)
    /// </summary>
    public class SFFeatureSeed : IEntityTypeConfiguration<SFeature>
    {
        public void Configure(EntityTypeBuilder<SFeature> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                CreateFeature("PN", "Basınç Sınıfı (Pressure Nominal)", 1, now),
                CreateFeature("DN", "Anma Çapı (Nominal Diameter)", 2, now),
                CreateFeature("SURFACE", "Yüzey Tipi (Flange Face)", 3, now)
            );
        }

        private static SFeature CreateFeature(string code, string name, int sortOrder, DateTime now) => new SFeature
        {
            Id = SeedId.From($"SFeature:{code}"),
            Code = code,
            Name = name,
            SortOrder = sortOrder,
            CreatedBy = "SEED",
            CreatedDate = now,
            Status = Domain.Enums.Status.Added
        };
    }
}
