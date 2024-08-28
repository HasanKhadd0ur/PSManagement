using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetUncompletedTracks
{
    public record GetUnCompletedTracksQuery(

        ) : IQuery<Result<IEnumerable<TrackDTO>>>;

}
