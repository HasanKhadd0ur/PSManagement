using FluentResults;
using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Identity.DomainErrors
{
    public class AlreadyExistError : IDomainError
    {
        public List<IError> Reasons => new(new[] { new Error("The User Email Already Exist.") });

        public string Message => "The Email Is Already Exist.";

        public Dictionary<string, object> Metadata => new();
    }
}
