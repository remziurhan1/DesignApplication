using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF
{
    /// <summary>
    /// SF (F grubu - Aksesuarlar) için ürünler
    /// F0, F1, F2... F9
    /// </summary>
    public class SFProductSeed : IEntityTypeConfiguration<SProduct>
    {
        public void Configure(EntityTypeBuilder<SProduct> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var sfGroupId = SeedId.From("SProductGroup:F");

            var items = new (string Code, string Name)[]
            {
                ("F0", "Vana / Valfler (Globe vb.)"),
                ("F1", "Emniyet / Relief Valfleri"),
                ("F2", "Regülatör"),
                ("F3", "Seviye / Gösterge"),
                ("F4", "Check / Excess Flow"),
                ("F5", "Filtre / Strainer"),
                ("F6", "Manometre / Basınç Göstergesi"),
                ("F7", "Termometre / Sıcaklık Göstergesi"),
                ("F8", "Bağlantı Elemanları / Fittings"),
                ("F9", "Diğer")
            };

            foreach (var (code, name) in items)
            {
                var digit = int.Parse(code[1].ToString());

                builder.HasData(new SProduct
                {
                    Id = SeedId.From($"SProduct:SF:{code}"),
                    SProductGroupId = sfGroupId,
                    Code = code,
                    Name = name,
                    PrefixIndex = digit,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }
        }
    }
}
