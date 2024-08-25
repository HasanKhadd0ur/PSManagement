using Ardalis.Result;
using PSManagement.Application.Employees.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Employees.UseCases.Queries.GetDepartments
{
    public record GetDepartmentsQuery(
        ) : IQuery<Result<IEnumerable<DepartmentDTO>>>;

}

