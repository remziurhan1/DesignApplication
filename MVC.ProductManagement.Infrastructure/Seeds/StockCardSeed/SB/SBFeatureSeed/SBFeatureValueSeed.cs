using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SB.Features
{
    public class SBFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var nutTypeId = SeedId.From("SFeature:NUT_TYPE");
            var standardId = SeedId.From("SFeature:STANDARD"); // SA ile paylaşımlı

            var values = new List<SFeatureValue>();

            // ========== 1. NUT_TYPE (Yeni feature, yeni değerler) ==========
            var nutTypes = new[]
            {
                ("AKB",      "Altıgen Başlı Somun"),
                ("SAPKALI",  "Şapkalı Somun"),
                ("FIBERLI",  "Fiberli Somun"),
                ("KONTRALI", "Kontra Somun"),
                ("KAYNAK",   "Kaynak Somunu"),
                ("TACLI",    "Taçlı Somun"),
                ("HALKALI",  "Halkalı Somun"),
                ("KELEBEK",  "Kelebek Somun")
            };
            for (int i = 0; i < nutTypes.Length; i++)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:NUT_TYPE:{nutTypes[i].Item1}"),
                    SFeatureId = nutTypeId,
                    Code = nutTypes[i].Item1,
                    Name = nutTypes[i].Item2,
                    SortOrder = i,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            // ========== 2. STANDARD - Somuna özgü (SA'da olmayan) ==========
            var sbStandards = new[]
            {
                ("DIN 934",  "DIN 934",  100),
                ("DIN 985",  "DIN 985",  101),
                ("DIN 439",  "DIN 439",  102),
                ("DIN 929",  "DIN 929",  103),
                ("DIN 935",  "DIN 935",  104),
                ("DIN 1587", "DIN 1587", 105),
                ("DIN 582",  "DIN 582",  106),
                ("DIN 315",  "DIN 315",  107),
                ("ISO 4032", "ISO 4032", 108),
            };
            foreach (var (code, name, sort) in sbStandards)
            {
                values.Add(new SFeatureValue
                {
                    Id = SeedId.From($"SFeatureValue:STANDARD:{code}"),
                    SFeatureId = standardId,
                    Code = code,
                    Name = name,
                    SortOrder = sort,
                    CreatedBy = "SEED",
                    CreatedDate = now,
                    Status = Domain.Enums.Status.Added
                });
            }

            builder.HasData(values);
        }
    }
}