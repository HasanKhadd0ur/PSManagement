using Ardalis.Result;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.CreateTrack
{
    public record CreateTrackCommand(
        TrackInfo TrackInfo,
        String Notes ,
        int ProjectId 
    ) : ILoggableCommand<Result<int>>;
}
