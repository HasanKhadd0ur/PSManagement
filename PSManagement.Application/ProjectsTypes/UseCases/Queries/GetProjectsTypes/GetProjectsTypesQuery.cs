using Ardalis.Result;
using PSManagement.Application.ProjectsTypes.Common;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;

namespace PSManagement.Application.ProjectsTypes.UseCases.Queries.GetProjectsTypes
{
    public record GetProjectsTypesQuery(
        ) : IQuery<Result<IEnumerable<ProjectTypeDTO>>>;
}
