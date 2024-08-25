using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PSManagement.Application.Contracts.Storage;
using PSManagement.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Storage
{
    public class FileService : IFileService
    {
        private readonly string[] _availableExtension;
        public FileService(IOptions<FileServiceSettings> fileServiceOptions)
        {
            _availableExtension = fileServiceOptions.Value.AvailableExtension;
                
        }
        public async Task<Result<String>> StoreFile(string fileName, IFormFile file)
        {
            if (file is null)
            {
                return Result.Invalid(new ValidationError("File couldn't be empty."));

            }
            var extension = Path.GetExtension(file.FileName);
            
            if (!_availableExtension.Contains(extension.ToLower()))
            {
               return Result.Invalid(new ValidationError("File type not allowed."));
            }
            fileName = fileName  + Path.GetExtension(file.FileName);
            var filePath = Path.Combine("wwwroot\\uploads", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Result.Success(fileName);
        }
    }
}
