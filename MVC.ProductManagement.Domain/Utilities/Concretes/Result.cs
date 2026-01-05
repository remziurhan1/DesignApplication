using MVC.ProductManagement.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Utilities.Concretes
{
    public class Result : IResult
    {
        public string Message { get; }

        public bool IsSuccess { get; }

        public Result()
        {
            IsSuccess = false;
            Message = string.Empty;
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }
    }
}
