using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.CompleteTrack
{
    public record CompleteTrackCommand(
        int TrackId,
        DateTime CompletionDate,
        int ProjectId
    ) : ILoggableCommand<Result>;
}
