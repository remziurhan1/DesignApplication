using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.CostingDTOs
{
    public class EN13458CostParameterLookupDTO
    {
        public List<EN13458LaborRateLookupDTO> LaborRates { get; set; } = new();
        public List<EN13458GugHourlyRateLookupDTO> GugHourlyRates { get; set; } = new();
        public List<EN13458OverheadRateLookupDTO> OverheadRates { get; set; } = new();
        public List<EN13458BombeLaborRateLookupDTO> BombeLaborRates { get; set; } = new();
    }

    public class EN13458LaborRateLookupDTO
    {
        public Guid Id { get; set; }
        public double HourlyRate { get; set; }
    }

    public class EN13458GugHourlyRateLookupDTO
    {
        public Guid Id { get; set; }
        public double HourlyRate { get; set; }
    }

    public class EN13458OverheadRateLookupDTO
    {
        public Guid Id { get; set; }
        public string OverheadType { get; set; } = string.Empty;
        public double Percentage { get; set; }
    }

    public class EN13458BombeLaborRateLookupDTO
    {
        public Guid Id { get; set; }
        public string MaterialType { get; set; } = string.Empty;
        public double RatePerKg { get; set; }
    }
}
