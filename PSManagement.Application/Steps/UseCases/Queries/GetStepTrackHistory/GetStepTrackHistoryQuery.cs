using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;
namespace PSManagement.Application.Steps.UseCases.Queries.GetStepTrackHistory
{
    public record GetStepTrackHistoryQuery(
        int StepId,
        int? PageNumber,
        int ? PageSize
    ) : IQuery<Result<IEnumerable<StepTrackDTO>>>;
}
