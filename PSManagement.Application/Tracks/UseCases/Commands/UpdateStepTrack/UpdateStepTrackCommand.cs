using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.UpdateStepTrack
{
    public record UpdateStepTrackCommand(
        int StepTrackId,
        int TrackId,
        int StepId,
        string ExecutionState,
        DateTime TrackDate,
        int TrackExecutionRatio
     ) : ILoggableCommand<Result>;

}
