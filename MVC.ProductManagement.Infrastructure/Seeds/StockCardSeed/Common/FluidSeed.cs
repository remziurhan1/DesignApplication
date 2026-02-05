using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common
{
    public class FluidSeed : IEntityTypeConfiguration<Fluid>
    {
        public void Configure(EntityTypeBuilder<Fluid> builder)
        {
            var now = new DateTime(2026, 02, 05);

            builder.HasData(
                New("A", "LPG", now),
                New("B", "LNG", now),
                New("C", "LOX", now),
                New("D", "LIN", now),
                New("E", "CO2", now),
                New("F", "FUEL", now),
                New("G", "GOX", now),
                New("H", "CNG", now)
            );
        }

        private static Fluid New(string code, string name, DateTime now) => new Fluid
        {
            Id = SeedId.From($"Fluid:{code}"),
            Code = code,
            Name = name,
            CreatedBy = "SEED",
            CreatedDate = now,
            Status = Domain.Enums.Status.Added
        };
    }
}
