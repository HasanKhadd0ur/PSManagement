using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeeTrackHistory
{
    public record GetEmployeeTrackHistoryQuery(
        int EmployeeId,
        int ProjectId,
        int? PageNumber,
        int? PageSize
    ) : IQuery<Result<IEnumerable<EmployeeTrackDTO>>>;
}
