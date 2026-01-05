using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Utilities.Interfaces
{
    public interface IResult
    {
        public string Message { get; }
        public bool IsSuccess { get; }
    }
}
