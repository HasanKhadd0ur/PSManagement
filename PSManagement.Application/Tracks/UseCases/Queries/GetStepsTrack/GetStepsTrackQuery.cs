using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetStepsTrack
{
    public record GetStepsTrackQuery(
        int TrackId
    ) : IQuery<Result<IEnumerable<StepTrackDTO>>>;

}
