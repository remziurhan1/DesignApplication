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
                var step3 = prefix[2].ToString();             // 'A' (burayı Code üretmek için kullanıyoruz)
                var digit = int.Parse(prefix[3].ToString());  // 0..9

                var sProductGroupId = SeedId.From($"SProductGroup:{groupCode}");
                var code = $"{groupCode}{digit}";             // ✅ Code: F0, F1... (istersen A0 yerine bu daha anlamlı)
                var name = GetProductTypeName(digit);         // ✅ Name: kullanıcıya görünen

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

            // Aynı grup+digit birden fazla prefix'ten gelebilir (SFA0, SFC0, ...)
            // SProduct'u "grup+digit" bazlı tekilleştirelim:
            var distinct = products
                .GroupBy(x => new { x.SProductGroupId, x.PrefixIndex })
                .Select(g => g.First())
                .ToList();

            builder.HasData(distinct);
        }

        private static string GetProductTypeName(int digit) => digit switch
        {
            0 => "Vana / Valfler (Globe vb.)",
            1 => "Emniyet / Relief Valfleri",
            2 => "Regülatör",
            3 => "Seviye / Gösterge",
            4 => "Check / Excess Flow",
            5 => "Filtre / Strainer",
            6 => "Manometre / Basınç Göstergesi",
            7 => "Termometre / Sıcaklık Göstergesi",
            8 => "Bağlantı Elemanları / Fittings",
            9 => "Diğer",
            _ => "Tanımsız"
        };
    }

}
