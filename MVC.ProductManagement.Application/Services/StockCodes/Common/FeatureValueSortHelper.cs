using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public static class FeatureValueSortHelper
    {
        public static List<FeatureValueDto> SortForUi(IEnumerable<FeatureValueDto> values)
        {
            return values
                .OrderBy(v => GetPrimaryGroup(v.Code))
                .ThenBy(v => GetNumericKey(v.Code))
                .ThenBy(v => v.Code, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static int GetPrimaryGroup(string? code)
        {
            if (string.IsNullOrWhiteSpace(code)) return 99;
            if (code.StartsWith("M", StringComparison.OrdinalIgnoreCase)) return 0;
            if (decimal.TryParse(Normalize(code), NumberStyles.Any, CultureInfo.InvariantCulture, out _)) return 1;
            return 2;
        }

        private static decimal GetNumericKey(string? code)
        {
            if (string.IsNullOrWhiteSpace(code)) return decimal.MaxValue;

            var normalized = Normalize(code);
            if (normalized.StartsWith("M", StringComparison.OrdinalIgnoreCase))
                normalized = normalized[1..];

            if (normalized.Contains('/'))
            {
                var parts = normalized.Split('/');
                if (parts.Length == 2 &&
                    decimal.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var num) &&
                    decimal.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var den) && den != 0)
                    return num / den;
            }

            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return decimal.MaxValue;
        }

        private static string Normalize(string value) => value.Trim().Replace(',', '.');
    }
}
