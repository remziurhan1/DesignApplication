using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices.Interfaces
{
    public interface IPressureCalculator
    {
        (double StaticPressure, double DesignPressure, double TestPressure) Calculate(EN13458CalculateDTO model);
    }
}
