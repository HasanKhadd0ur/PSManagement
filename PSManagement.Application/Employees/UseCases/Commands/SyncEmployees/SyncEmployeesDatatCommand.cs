using Ardalis.Result;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Employees.UseCases.Commands.SyncEmployeesData
{
    public record SyncEmployeesCommand():ICommand<Result<SyncResponse>>;

}
