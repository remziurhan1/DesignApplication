using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class InventoryDto
    {
        public Guid Id { get; set; }
        public Guid StockCardId { get; set; }
        public string StockCode { get; set; }
        public InventoryMovementType MovementType { get; set; }
        public string MovementTypeText => MovementType.ToString();
        public int Quantity { get; set; }
        public int StockBefore { get; set; }
        public int StockAfter { get; set; }
        public DateTime MovementDate { get; set; }
        public string Location { get; set; }
        public string ReferenceDocument { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
