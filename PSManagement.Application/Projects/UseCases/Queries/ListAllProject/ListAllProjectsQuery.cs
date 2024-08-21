using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.UseCases.Queries.ListAllProject
{
    public record ListAllProjectsQuery(
        int? PageNumber,
        int? PageSize

        ) : IQuery<Result<IEnumerable<ProjectDetailsDTO>>>;

}
