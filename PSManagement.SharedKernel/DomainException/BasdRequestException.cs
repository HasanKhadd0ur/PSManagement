using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.DomainException
{
    public abstract class BadRequestException : DomainException
    {
        protected BadRequestException(string message)
            : base(message)
        {
        }
    }
}
