using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetTrackById
{
    public record GetTrackByIdQuery(
        int TrackId
    ) : IQuery<Result<TrackDTO>>;

}
