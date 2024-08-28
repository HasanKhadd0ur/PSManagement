using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Tracks.UseCaes.Commands.RemoveTrack
{
    public record RemoveTrackCommand(
        int TrackId
    ) : ILoggableCommand<Result>;
}