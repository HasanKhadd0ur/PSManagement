using FluentResults;
using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Identity.DomainErrors
{
    public class InvalidLoginDataError : IDomainError
    {
        public List<IError> Reasons => new(new[] { new Error("The User Email Or  Password Wrong.") });

        public string Message => "Invalid Login Attempt.";

        public Dictionary<string, object> Metadata => new();
    }
}
