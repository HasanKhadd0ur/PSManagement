using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Storage
{
    public interface IFileService
    {
        public Task<Result<String>> StoreFile(string fileName,IFormFile file);
        public Task<Result<IFormFile>> RetreiveFile(string fileUrl);
    }
}
