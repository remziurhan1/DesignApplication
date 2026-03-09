using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices
{
   public interface IEN13458CalculationServices
    {
        Task<EN13458MaterialCostTableDTO> BuildMaterialCostTableAsync(EN13458ResultDTO result);
    }
}
