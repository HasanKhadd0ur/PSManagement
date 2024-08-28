using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.UseCases.Queries.GetProjectCompletion
{
    public record GetProjectCompletionQuery(
        int ProjectId) : IQuery<Result<ProjectCompletionDTO>>;

}
