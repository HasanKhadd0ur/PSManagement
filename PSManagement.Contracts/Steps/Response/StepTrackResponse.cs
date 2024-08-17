using PSManagement.Domain.Tracking.ValueObjects;
using System;

namespace PSManagement.Contracts.Projects.Response
{
    public class StepTrackResponse
    {
        public int StepId { get; set; }
        public int TrackId { get; set; }
        public String ExecutionState { get; set; }
        public TrackInfo TrackInfo { get; set; }

        public int ExecutionRatio { get; set; }

    }
}