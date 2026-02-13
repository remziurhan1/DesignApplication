using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System.Collections.Generic;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA
{
    public class SAStockCardIndexVm
    {
        public PagedResult<SAStockCardListDto> Result { get; set; } = new();
        public SAStockCardFilterDto Filter { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();
    }
}