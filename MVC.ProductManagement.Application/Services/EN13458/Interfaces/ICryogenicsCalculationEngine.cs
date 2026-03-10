using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.Interfaces
{
    public interface ICryogenicsCalculationEngine
    {
        Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO input);
    }
}
