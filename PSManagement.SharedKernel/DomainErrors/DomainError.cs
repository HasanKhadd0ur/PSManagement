using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.DomainErrors
{
    public class DomainError : Error
    {
        public DomainError(string message) : base(message)
        {
        }

        public DomainError(string message, IError causedBy) : base(message, causedBy)
        {
        }

        protected DomainError()
        {
        }
    }
}
