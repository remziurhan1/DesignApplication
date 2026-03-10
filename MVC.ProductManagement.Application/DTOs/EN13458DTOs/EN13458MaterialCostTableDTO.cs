using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
    public class EN13458MaterialCostTableDTO
    {
        public List<EN13458MaterialCostRowDTO> Items { get; set; } = new();
        public double TotalMaterialCost { get; set; }
        public double TotalFilmCost { get; set; }
        public double GrandTotalCost { get; set; }
    }
}
