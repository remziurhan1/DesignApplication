using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using System;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EN13458CalculationController : Controller
    {
        private readonly IEN13458CalculationServices _service;

        public EN13458CalculationController(IEN13458CalculationServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return Json(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] EN13458CalculateDTO dto)
        {
            var result = await _service.CalculateAsync(dto);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] EN13458ResultDTO dto)
        {
            var result = await _service.SaveAsync(dto, User?.Identity?.Name ?? "AdminUser");
            return Json(result);
        }
    }
}
