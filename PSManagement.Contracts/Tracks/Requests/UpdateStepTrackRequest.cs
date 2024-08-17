using System;

namespace PSManagement.Contracts.Tracks.Requests
{
    public record UpdateStepTrackRequest(
      int StepTrackId,
      int TrackId,
      int StepId,
      string ExecutionState,
      DateTime TrackDate,
      int ExecutionRatio
   );
}
