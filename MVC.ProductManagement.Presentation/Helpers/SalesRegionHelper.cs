using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Helpers
{
    public static class SalesRegionHelper
    {
        private static readonly Dictionary<string, SalesRegion> CountryMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Germany"] = SalesRegion.Europe,
            ["France"] = SalesRegion.Europe,
            ["Italy"] = SalesRegion.Europe,
            ["Spain"] = SalesRegion.Europe,
            ["United Kingdom"] = SalesRegion.Europe,
            ["Iraq"] = SalesRegion.MiddleEast,
            ["Saudi Arabia"] = SalesRegion.MiddleEast,
            ["United Arab Emirates"] = SalesRegion.MiddleEast,
            ["Qatar"] = SalesRegion.MiddleEast,
            ["Kuwait"] = SalesRegion.MiddleEast,
            ["Turkey"] = SalesRegion.Turkey,
            ["Azerbaijan"] = SalesRegion.CIS,
            ["Kazakhstan"] = SalesRegion.CIS,
            ["Uzbekistan"] = SalesRegion.CIS
        };

        public static IReadOnlyList<(string Value, string Text)> RegionOptions =>
            Enum.GetValues<SalesRegion>().Select(x => (x.ToString(), GetLabel(x))).ToList();

        public static string ResolveRegion(string? country, string? explicitRegion)
        {
            if (!string.IsNullOrWhiteSpace(explicitRegion))
            {
                return explicitRegion;
            }

            if (!string.IsNullOrWhiteSpace(country) && CountryMap.TryGetValue(country.Trim(), out var region))
            {
                return region.ToString();
            }

            return SalesRegion.Other.ToString();
        }

        public static string GetLabel(SalesRegion region) => region switch
        {
            SalesRegion.Europe => "Europe",
            SalesRegion.MiddleEast => "Middle East",
            SalesRegion.Turkey => "Turkey",
            SalesRegion.CIS => "CIS",
            SalesRegion.Africa => "Africa",
            SalesRegion.AsiaPacific => "Asia Pacific",
            SalesRegion.Americas => "Americas",
            _ => "Other"
        };
    }
}
