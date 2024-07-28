﻿using FluentResults;
using PSManagement.Application.Customers.Common;
using PSManagement.Domain.Customers.Aggregate;
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
        AddressDTO Address
        ) : ICommand<Result>;
    
}
