using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Storage
{
    public interface IFileService
    {
        public Result StoreFile(string fileName);

    }
}
