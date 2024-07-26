﻿using FluentResults;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.CreateCustomer
{
    public record  CreateCustomerCommand (
        String CustomerName ,
        Address Address
        ) : ICommand<Result<int>>;
    
}