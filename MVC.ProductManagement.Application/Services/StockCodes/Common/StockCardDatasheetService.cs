using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public class StockCardDatasheetService : IStockCardDatasheetService
    {
        private readonly IStockCardDatasheetRepository _repository;
        private readonly string _uploadPath;

        public StockCardDatasheetService(IStockCardDatasheetRepository repository)
        {
            _repository = repository;
            _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "datasheets");

            if (!Directory.Exists(_uploadPath))
                Directory.CreateDirectory(_uploadPath);
        }

        public async Task<IReadOnlyList<DatasheetDto>> GetDatasheetsByStockCardAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var datasheets = await _repository.GetByStockCardAsync(stockCardId, cancellationToken);
            return datasheets.Select(MapToDto).ToList();
        }

        public async Task<DatasheetDto> GetDatasheetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var datasheet = await _repository.GetByIdAsync(id, tracking: false, cancellationToken);
            return datasheet == null ? null! : MapToDto(datasheet);
        }

        public async Task<DatasheetDto> UploadDatasheetAsync(
            DatasheetUploadDto uploadDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var stockCard = await _repository.GetStockCardAsync(uploadDto.StockCardId, cancellationToken);
            if (stockCard == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            var lastVersion = await _repository.GetLastVersionAsync(uploadDto.StockCardId, cancellationToken);
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
                Status = Status.Added
            };

            await _repository.AddAsync(datasheet, cancellationToken);
            await _repository.CommitAsync(cancellationToken);

            return MapToDto(datasheet, stockCard.StockCode8);
        }

        public async Task<bool> DeleteDatasheetAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var datasheet = await _repository.GetByIdAsync(id, tracking: true, cancellationToken);
            if (datasheet == null)
                return false;

            if (File.Exists(datasheet.FilePath))
            {
                File.Delete(datasheet.FilePath);
            }

            datasheet.Status = Status.Deleted;
            datasheet.DeletedBy = userName;
            datasheet.DeletedDate = DateTime.UtcNow;

            await _repository.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<(byte[] Content, string FileName, string ContentType)> DownloadDatasheetAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var datasheet = await _repository.GetByIdAsync(id, tracking: false, cancellationToken);
            if (datasheet == null)
                throw new InvalidOperationException("Datasheet bulunamadı.");

            if (!File.Exists(datasheet.FilePath))
                throw new FileNotFoundException("Dosya fiziksel olarak bulunamadı.");

            var content = await File.ReadAllBytesAsync(datasheet.FilePath, cancellationToken);
            return (content, datasheet.FileName, datasheet.ContentType);
        }

        private static DatasheetDto MapToDto(StockCardDatasheet datasheet, string? stockCode = null)
        {
            return new DatasheetDto
            {
                Id = datasheet.Id,
                StockCardId = datasheet.StockCardId,
                StockCode = stockCode ?? datasheet.StockCard?.StockCode8 ?? string.Empty,
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
    }
}
