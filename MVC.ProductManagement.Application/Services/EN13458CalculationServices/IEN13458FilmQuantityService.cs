using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices
{
    public interface IEN13458FilmQuantityService
    {
        FilmQuantityCalculation Calculate(double totalWeldLengthMm);
    }
}
