using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class DatasheetUploadDto
    {
        public Guid StockCardId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public byte[] FileContent { get; set; }
        public string Description { get; set; }
    }
}
