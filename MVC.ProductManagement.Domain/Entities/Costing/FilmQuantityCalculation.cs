using System;

namespace MVC.ProductManagement.Domain.Entities.Costing
{
    public class FilmQuantityCalculation
    {
        public double TotalWeldLengthMm { get; set; }
        public double Divisor { get; set; }
        public double FilmQuantity { get; set; }
        public DateTime CalculatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
