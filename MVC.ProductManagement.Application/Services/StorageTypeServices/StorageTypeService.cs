using Mapster;
using MVC.ProductManagement.Application.DTOs.StorageTypeDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Utilities.Concretes;
using MVC.ProductManagement.Domain.Utilities.Interfaces;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StorageTypeServices
{
    public class StorageTypeService : IStorageTypeService
    {
        IStorageTypeRepositories _storageTypeRepository;

        public StorageTypeService(IStorageTypeRepositories storageTypeRepository)
        {
            _storageTypeRepository = storageTypeRepository;
        }

        public async Task<IResult> AddAsync(StorageTypeCreateDTO dto)
        {
            if (await _storageTypeRepository.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower()))
            {
                return new ErrorResult("Ürün türü zaten kayıtlı");
            }

            try
            {
                var newProductType = dto.Adapt<StorageType>();
                await _storageTypeRepository.AddAsync(newProductType);
                await _storageTypeRepository.SaveChangeAsync();
                return new SuccessResult("Ürün başarıyla Kaydedildi");

            }
            catch (Exception ex)
            {

                return new ErrorResult("Hata: " + ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingProductType = await _storageTypeRepository.GetByIdAsync(id);
            if (deletingProductType == null)
            {
                return new ErrorResult("Ürün türü bulunamadı");
            }

            try
            {
                await _storageTypeRepository.DeleteAsync(deletingProductType);
                await _storageTypeRepository.SaveChangeAsync();
                return new SuccessResult("Ürün türü başarıyla silindi");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata: " + ex.Message);
            }
        }

        public async Task<IDataResult<List<StorageTypeListDTO>>> GetAllAsync()
        {
            var productTypes = await _storageTypeRepository.GetAllAsync();
            var productTypeListDTOs = productTypes.Adapt<List<StorageTypeListDTO>>();

            if (productTypes.Count() < 0)
            {
                return new ErrorDataResult<List<StorageTypeListDTO>>(productTypeListDTOs, "Listelenecek ürün türü bulunamadı");
            }

            return new SuccessDataResult<List<StorageTypeListDTO>>(productTypeListDTOs, "Ürün türü listeleme başarılı");
        }

        public async Task<IDataResult<StorageTypeDTO>> GetByIdAsync(Guid id)
        {
            var productType = await _storageTypeRepository.GetByIdAsync(id);

            if (productType == null)
            {
                return new ErrorDataResult<StorageTypeDTO>(null, "Gösterilecek ürün türü bulunamadı");
            }

            return new SuccessDataResult<StorageTypeDTO>(productType.Adapt<StorageTypeDTO>(), "Ürün türü başarıyla getirildi");
        }

        public async Task<IResult> UpdateAsync(StorageTypeUpdateDTO dto)
        {
            var updatingProductType = await _storageTypeRepository.GetByIdAsync(dto.Id);

            if (updatingProductType == null)
            {
                return new ErrorResult("Güncellenecek ürün türü bulunamadı");
            }

            try
            {
                dto.Adapt(updatingProductType);
                await _storageTypeRepository.UpdateAsync(updatingProductType);
                await _storageTypeRepository.SaveChangeAsync();
                return new SuccessResult("Ürün türü başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata: " + ex.Message);
            }
        }
    }
}
