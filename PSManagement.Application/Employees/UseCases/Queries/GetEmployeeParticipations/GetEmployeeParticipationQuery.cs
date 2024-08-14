using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeeById
{
    public record GetEmployeeParticipationQuery(
        int EmployeeId,
        int? PageNumber,
        int? PageSize) : IQuery<Result<IEnumerable<EmployeeParticipateDTO>>>;
}
