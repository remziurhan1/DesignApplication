using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.SF.Features
{
    public class SFFeatureValueSeed : IEntityTypeConfiguration<SFeatureValue>
    {
        public void Configure(EntityTypeBuilder<SFeatureValue> builder)
        {
            var now = new DateTime(2026, 02, 05);
            var pnId = SeedId.From("SFeature:PN");
            var dnId = SeedId.From("SFeature:DN");
            var surfaceId = SeedId.From("SFeature:SURFACE");

            var values = new List<SFeatureValue>();

            // ========== PN (Basınç Sınıfı) Değerleri ==========
            var pnValues = new[] { "PN6", "PN10", "PN16", "PN25", "PN40", "PN63", "PN100", "PN160", "PN250", "PN320" };
            for (int i = 0; i < pnValues.Length; i++)
            {
                values.Add(CreateFeatureValue(
                    featureId: pnId,
                    code: pnValues[i],
                    name: pnValues[i],
                    sortOrder: i,
                    now: now
                ));
            }

            // ========== DN (Anma Çapı) Değerleri ==========
            var dnValues = new[] { "DN10", "DN15", "DN20", "DN25", "DN32", "DN40", "DN50", "DN65", "DN80", "DN100", "DN125", "DN150", "DN200" };
            for (int i = 0; i < dnValues.Length; i++)
            {
                values.Add(CreateFeatureValue(
                    featureId: dnId,
                    code: dnValues[i],
                    name: dnValues[i],
                    sortOrder: i,
                    now: now
                ));
            }

            // ========== SURFACE (Yüzey Tipi) Değerleri ==========
            var surfaceValues = new[]
            {
                ("RF", "Raised Face (Kabarık Yüzey)"),
                ("FF", "Flat Face (Düz Yüzey)"),
                ("RTJ", "Ring Type Joint (Halka Tipli)"),
                ("LJ", "Lap Joint (Gevşek Flanş)"),
                ("TG", "Tongue and Groove (Dil ve Oluk)")
            };
            for (int i = 0; i < surfaceValues.Length; i++)
            {
                values.Add(CreateFeatureValue(
                    featureId: surfaceId,
                    code: surfaceValues[i].Item1,
                    name: surfaceValues[i].Item2,
                    sortOrder: i,
                    now: now
                ));
            }

            builder.HasData(values);
        }

        private static SFeatureValue CreateFeatureValue(
            Guid featureId,
            string code,
            string name,
            int sortOrder,
            DateTime now)
        {
            return new SFeatureValue
            {
                Id = SeedId.From($"SFeatureValue:{code}"),
                SFeatureId = featureId,
                Code = code,
                Name = name,
                SortOrder = sortOrder,
                CreatedBy = "SEED",
                CreatedDate = now,
                Status = Domain.Enums.Status.Added
            };
        }
    }
}
