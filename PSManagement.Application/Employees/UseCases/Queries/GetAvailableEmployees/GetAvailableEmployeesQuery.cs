using Ardalis.Result;
using PSManagement.Application.Employees.Common;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Employees.UseCases.Queries.GetAvailableEmployees
{
    public record GetAvailableEmployeesQuery (
        int? PageNumber,
        int? PageSize) : IQuery<Result<IEnumerable<EmployeeDTO>>>;
}
