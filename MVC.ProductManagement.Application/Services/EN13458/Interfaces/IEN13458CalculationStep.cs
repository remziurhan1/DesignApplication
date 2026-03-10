using MVC.ProductManagement.Application.Services.EN13458.Engines;

namespace MVC.ProductManagement.Application.Services.EN13458.Interfaces
{
    public interface IEN13458CalculationStep
    {
        void Execute(EN13458DesignContext context);
    }
}
