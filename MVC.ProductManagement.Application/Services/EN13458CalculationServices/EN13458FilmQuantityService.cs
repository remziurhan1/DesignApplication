using System;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices
{
    public class EN13458FilmQuantityService : IEN13458FilmQuantityService
    {
        private const double DefaultFilmDivisor = 450d;

        public FilmQuantityCalculation Calculate(double totalWeldLengthMm)
        {
            var normalizedWeldLength = totalWeldLengthMm < 0 ? 0 : totalWeldLengthMm;
            var filmQuantity = normalizedWeldLength <= 0 ? 0 : Math.Ceiling(normalizedWeldLength / DefaultFilmDivisor);

            return new FilmQuantityCalculation
            {
                TotalWeldLengthMm = normalizedWeldLength,
                Divisor = DefaultFilmDivisor,
                FilmQuantity = filmQuantity,
                CalculatedAtUtc = DateTime.UtcNow
            };
        }
    }
}
