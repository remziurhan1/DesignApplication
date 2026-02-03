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
    public class FluidSeed_SAll : IEntityTypeConfiguration<Fluid>
    {
        public void Configure(EntityTypeBuilder<Fluid> builder)
        {
            var now = new DateTime(2026, 01, 01);

            var fluids = new List<Fluid>
            {
                New("A", "LPG",  now),
                New("B", "LNG",  now),
                New("C", "LOX",  now),
                New("D", "LIN",  now),
                New("E", "CO2",  now),
                New("F", "FUEL", now),
                New("G", "GOX",  now),
                New("H", "CNG",  now),
            };

            builder.HasData(fluids);
        }

        private static Fluid New(string code, string name, DateTime now)
        {
            return new Fluid
            {
                Id = SeedId.From($"Fluid:{code}"),
                Code = code,
                Name = name,
                CreatedBy = "SEED",
                CreatedDate = now
            };
        }
    }
}
