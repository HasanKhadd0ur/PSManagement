using Ardalis.Result;
using PSManagement.Application.Employees.Common;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using System.Collections.Generic;
namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeesByFilter
{
    public record GetEmployeesByFilterQuery(
         string EmployeeFirstName,
         int? HiastId,
         string DepartmentName,
         string WorkType,
         int? PageNumber,
         int? PageSize
    ) : IQuery<Result<IEnumerable<EmployeeDTO>>>;

}
