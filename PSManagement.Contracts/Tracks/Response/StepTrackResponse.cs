using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.Tracking.ValueObjects;
using System;

namespace PSManagement.Contracts.Tracks.Response
{
    public record StepTrackResponse(
        int Id,
        int StepId ,
        int TrackId ,
        StepInfo StepInfo ,
        TrackInfo TrackInfo,
        String ExecutionState,
        DateTime TrackDate ,
        int ExecutionRatio 
    );
}
