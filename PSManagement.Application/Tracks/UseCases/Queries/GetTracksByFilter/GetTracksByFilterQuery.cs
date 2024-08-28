using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetTracksByFilter
{
    public record GetTracksByFilterQuery(
        int? PageNumber,
        int? PageSize

        ) : IQuery<Result<IEnumerable<TrackDTO>>>;

}
