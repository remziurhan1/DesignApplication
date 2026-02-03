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
    public class SProductGroupSeed_SAll : IEntityTypeConfiguration<SProductGroup>
    {
        public void Configure(EntityTypeBuilder<SProductGroup> builder)
        {
            var now = new DateTime(2026, 01, 01);

            var groups = new List<SProductGroup>
            {
                New("A", "Cıvatalar, Perçinler", now),
                New("B", "Somunlar", now),
                New("C", "Pul ve Rondelalar", now),
                New("D", "Rekorlar ve Dirsekler", now),
                New("E", "Elektrik Malzemeleri", now),
                New("F", "Aksesuarlar (Vana, Termometre vs.)", now),
                New("G", "Pim, Gresörlük, Gupilya", now),
                New("H", "Hortumlar, Kelepçeler, Klipsler", now),
                New("Z", "Gruplanmamış Standart Parçalar", now),
            };

            builder.HasData(groups);
        }

        private static SProductGroup New(string code, string name, DateTime now)
        {
            return new SProductGroup
            {
                Id = SeedId.From($"SProductGroup:{code}"),
                Code = code,
                Name = name,
                CreatedBy = "SEED",
                CreatedDate = now
            };
        }
    }
}
