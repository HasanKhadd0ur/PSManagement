
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.DomainErrors
{
    public class DomainError  :ValidationError
    {
        public DomainError(string errorCode, string errorMessage) :base()
        {
            this.ErrorMessage = errorMessage;
            this.ErrorCode = errorCode;
        }

        
    }
}
