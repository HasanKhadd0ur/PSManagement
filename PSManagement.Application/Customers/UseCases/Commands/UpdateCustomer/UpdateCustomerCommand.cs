using Ardalis.Result;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer
{
    public record  UpdateCustomerCommand (
        int CustomerId,
        String CustomerName ,
        String Email,
        Address Address
        ) : ICommand<Result>;
    
}
