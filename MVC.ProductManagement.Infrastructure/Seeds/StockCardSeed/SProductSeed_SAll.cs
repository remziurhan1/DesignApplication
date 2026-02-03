using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public class SProductSeed_SAll : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 01, 01);
            var products = new List<SProduct>();

            foreach (var prefix in SAllDefinitions.AllPrefixes())
            {
                // prefix: "SFA0"  => group = 'F', step3='A', digit=0
                var groupCode = prefix[1].ToString();         // 'F'
                var step3 = prefix[2].ToString();             // 'A'
                var digit = int.Parse(prefix[3].ToString());  // 0

                var sProductGroupId = SeedId.From($"SProductGroup:{groupCode}");
                var code = $"{step3}{digit}";                 // A0
                var name = $"S{groupCode}-{code}";            // SA-A0 gibi (gruba göre)

                products.Add(new SProduct
                {
                    Id = SeedId.From($"SProduct:S{groupCode}:{code}"),
                    SProductGroupId = sProductGroupId,
                    Code = code,
                    Name = name,
                    PrefixIndex = digit,
                    CreatedBy = "SEED",
                    CreatedDate = now
                });
            }

            builder.HasData(products);
        }
    }
}
