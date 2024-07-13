using System;

namespace PSManagement.SharedKernel.DomainException
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
