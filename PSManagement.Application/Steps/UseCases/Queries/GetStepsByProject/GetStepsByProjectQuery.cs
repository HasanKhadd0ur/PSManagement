using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Steps.UseCases.Queries.GetStepsByProject
{
    public record GetStepsByProjectQuery(
        int ProjectId,
        int? PageSize,
        int? PageNumber
    ) : IQuery<Result<IEnumerable<StepDTO>>>;
}
