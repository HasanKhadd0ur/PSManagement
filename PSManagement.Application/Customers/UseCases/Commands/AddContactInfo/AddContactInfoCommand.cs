using FluentResults;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Customers.UseCases.Commands.AddContactInfo
{
    public record  AddContactInfoCommand(int CustomerId,String ContactType,String ContactValue ) : ICommand<Result>;

}
