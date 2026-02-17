using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public class StockCardDatasheetService : IStockCardDatasheetService
    {
        private readonly AppDbContext _context;
        private readonly string _uploadPath;

        public StockCardDatasheetService(AppDbContext context)
        {
            _context = context;
            _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "datasheets");

            if (!Directory.Exists(_uploadPath))
                Directory.CreateDirectory(_uploadPath);
        }

        public async Task<IReadOnlyList<DatasheetDto>> GetDatasheetsByStockCardAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            return await _context.StockCardDatasheets
                .AsNoTracking()
                .Where(d => d.StockCardId == stockCardId && d.Status != Status.Deleted) // ✅ Değişti
                .OrderByDescending(d => d.Version)
                .ThenByDescending(d => d.CreatedDate)
                .Select(d => new DatasheetDto
                {
                    Id = d.Id,
                    StockCardId = d.StockCardId,
                    StockCode = d.StockCard.StockCode8,
                    FileName = d.FileName,
                    FilePath = d.FilePath,
                    FileSize = d.FileSize,
                    ContentType = d.ContentType,
                    Version = d.Version,
                    Description = d.Description,
                    IsActive = d.IsActive,
                    CreatedDate = d.CreatedDate,
                    CreatedBy = d.CreatedBy
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<DatasheetDto> GetDatasheetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.StockCardDatasheets
                .AsNoTracking()
                .Where(d => d.Id == id && d.Status != Status.Deleted) // ✅ Değişti
                .Select(d => new DatasheetDto
                {
                    Id = d.Id,
                    StockCardId = d.StockCardId,
                    StockCode = d.StockCard.StockCode8,
                    FileName = d.FileName,
                    FilePath = d.FilePath,
                    FileSize = d.FileSize,
                    ContentType = d.ContentType,
                    Version = d.Version,
                    Description = d.Description,
                    IsActive = d.IsActive,
                    CreatedDate = d.CreatedDate,
                    CreatedBy = d.CreatedBy
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<DatasheetDto> UploadDatasheetAsync(
            DatasheetUploadDto uploadDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var stockCard = await _context.Set<StockCard>()
                .FirstOrDefaultAsync(sc => sc.Id == uploadDto.StockCardId && sc.Status != Status.Deleted, cancellationToken); // ✅ Değişti

            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            var lastVersion = await _context.StockCardDatasheets
                .Where(d => d.StockCardId == uploadDto.StockCardId)
                .MaxAsync(d => (int?)d.Version, cancellationToken) ?? 0;

            var fileExtension = Path.GetExtension(uploadDto.FileName);
            var uniqueFileName = $"{stockCard.StockCode8}_v{lastVersion + 1}_{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_uploadPath, uniqueFileName);

            await File.WriteAllBytesAsync(filePath, uploadDto.FileContent, cancellationToken);

            var datasheet = new StockCardDatasheet
            {
                Id = Guid.NewGuid(),
                StockCardId = uploadDto.StockCardId,
                FileName = uploadDto.FileName,
                FilePath = filePath,
                FileSize = uploadDto.FileSize,
                ContentType = uploadDto.ContentType,
                Version = lastVersion + 1,
                Description = uploadDto.Description,
                IsActive = true,
                CreatedBy = userName,
                CreatedDate = DateTime.UtcNow,
                Status = Status.Added // ✅ Değişti
            };

            _context.StockCardDatasheets.Add(datasheet);
            await _context.SaveChangesAsync(cancellationToken);

            return new DatasheetDto
            {
                Id = datasheet.Id,
                StockCardId = datasheet.StockCardId,
                StockCode = stockCard.StockCode8,
                FileName = datasheet.FileName,
                FilePath = datasheet.FilePath,
                FileSize = datasheet.FileSize,
                ContentType = datasheet.ContentType,
                Version = datasheet.Version,
                Description = datasheet.Description,
                IsActive = datasheet.IsActive,
                CreatedDate = datasheet.CreatedDate,
                CreatedBy = datasheet.CreatedBy
            };
        }

        public async Task<bool> DeleteDatasheetAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var datasheet = await _context.StockCardDatasheets
                .FirstOrDefaultAsync(d => d.Id == id && d.Status != Status.Deleted, cancellationToken); // ✅ Değişti

            if (datasheet == null)
                return false;

            // Fiziksel dosyayı sil
            if (File.Exists(datasheet.FilePath))
            {
                File.Delete(datasheet.FilePath);
            }

            // Soft delete
            datasheet.Status = Status.Deleted; // ✅ Değişti
            datasheet.DeletedBy = userName;
            datasheet.DeletedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<(byte[] Content, string FileName, string ContentType)> DownloadDatasheetAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var datasheet = await _context.StockCardDatasheets
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id && d.Status != Status.Deleted, cancellationToken); // ✅ Değişti

            if (datasheet == null)
                throw new InvalidOperationException("Datasheet bulunamadı.");

            if (!File.Exists(datasheet.FilePath))
                throw new FileNotFoundException("Dosya fiziksel olarak bulunamadı.");

            var content = await File.ReadAllBytesAsync(datasheet.FilePath, cancellationToken);
            return (content, datasheet.FileName, datasheet.ContentType);
        }
    }
}
