using FluentResults;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand (int CustomerId) : ICommand<Result>;
    
}
