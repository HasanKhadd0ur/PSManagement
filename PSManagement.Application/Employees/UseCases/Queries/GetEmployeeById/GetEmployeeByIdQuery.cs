using Ardalis.Result;
using PSManagement.Application.Employees.Common;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(
        int EmployeeId) : IQuery<Result<EmployeeDTO>>;

}
