using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed
{
    public static class SAllDefinitions
    {
        public static IEnumerable<string> AllPrefixes()
        {
            // SA
            foreach (var p in Expand("SA", new[]
            {
                ("A", 0, 9), ("B", 0, 9), ("C", 0, 6), ("D", 0, 1), ("E", 0, 6)
            })) yield return p;

            // SB
            foreach (var p in Expand("SB", new[]
            {
                ("A", 0, 9), ("B", 0, 9), ("C", 0, 3), ("D", 0, 1), ("E", 0, 1)
            })) yield return p;

            // SC
            foreach (var p in Expand("SC", new[]
            {
                ("A", 0, 9)
            })) yield return p;
            yield return "SCE1"; // SC: E1 var

            // SD
            foreach (var p in Expand("SD", new[]
            {
                ("A", 0, 7), ("B", 0, 4), ("C", 0, 4), ("D", 0, 4), ("E", 0, 4), ("F", 0, 4)
            })) yield return p;

            // SE
            foreach (var p in Expand("SE", new[]
            {
                ("A", 0, 9), ("B", 0, 9)
            })) yield return p;

            // SF
            foreach (var p in Expand("SF", new[]
            {
                ("A", 0, 8), ("C", 0, 8), ("F", 0, 9), ("G", 0, 6), ("H", 0, 3)
            })) yield return p;

            // SG
            foreach (var p in Expand("SG", new[]
            {
                ("A", 0, 6)
            })) yield return p;

            // SH
            foreach (var p in Expand("SH", new[]
            {
                ("A", 0, 8)
            })) yield return p;
            yield return "SHC1";
            yield return "SHC5";

            // SZ
            foreach (var p in Expand("SZ", new[]
            {
                ("A", 0, 4)
            })) yield return p;
        }

        private static IEnumerable<string> Expand(string group2, (string step3, int from, int to)[] ranges)
        {
            foreach (var (step3, from, to) in ranges)
            {
                for (var d = from; d <= to; d++)
                    yield return $"S{group2[1]}{step3}{d}";
            }
        }
    }
}
