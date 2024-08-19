using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using PSManagement.Application.Contracts.Storage;
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
        public async Task<Result<String>> StoreFile(string fileName, IFormFile file)
        {
            var allowedExtensions = new string[] { ".pdf", ".png" };
            if (file is null)
            {
                return Result.Invalid(new ValidationError("File couldn't be empty."));

            }
            var extension = Path.GetExtension(file.FileName);
            
            if (!allowedExtensions.Contains(extension.ToLower()))
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
