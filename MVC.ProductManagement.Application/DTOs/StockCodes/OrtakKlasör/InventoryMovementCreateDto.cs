using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class InventoryMovementCreateDto
    {
        public Guid StockCardId { get; set; }
        public InventoryMovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public string Location { get; set; }
        public string ReferenceDocument { get; set; }
        public string Description { get; set; }
    }
}
