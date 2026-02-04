using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Handlers
{
    public interface ISStockCodeGroupHandlerFactory
    {
        ISStockCodeGroupHandler GetByGroupCode(string groupCode);
    }

    public class SStockCodeGroupHandlerFactory : ISStockCodeGroupHandlerFactory
    {
        private readonly IEnumerable<ISStockCodeGroupHandler> _handlers;

        public SStockCodeGroupHandlerFactory(IEnumerable<ISStockCodeGroupHandler> handlers)
        {
            _handlers = handlers;
        }

        public ISStockCodeGroupHandler GetByGroupCode(string groupCode)
        {
            var handler = _handlers.FirstOrDefault(x =>
                string.Equals(x.GroupCode, groupCode, StringComparison.OrdinalIgnoreCase));

            if (handler == null)
                throw new InvalidOperationException($"'{groupCode}' ürün grubu için handler tanımlı değil.");

            return handler;
        }
    }
}

