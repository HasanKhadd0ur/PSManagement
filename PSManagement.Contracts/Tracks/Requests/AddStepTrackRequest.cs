using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Tracks.Requests
{
    public record AddStepTrackRequest(
      int StepId,
      int TrackId,
      string ExecutionState,
      DateTime TrackDate,
      int TrackExecutionRatio
  );
}
