using MVC.ProductManagement.Application.DTOs.StorageTypeDTOs;
using MVC.ProductManagement.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StorageTypeServices
{
    public interface IStorageTypeService
    {
        Task<IDataResult<List<StorageTypeListDTO>>> GetAllAsync();
        Task<IDataResult<StorageTypeDTO>> GetByIdAsync(Guid id);
        Task<IResult> AddAsync(StorageTypeCreateDTO dto);
        Task<IResult> UpdateAsync(StorageTypeUpdateDTO dto);
        Task<IResult> DeleteAsync(Guid id);
    }
}
