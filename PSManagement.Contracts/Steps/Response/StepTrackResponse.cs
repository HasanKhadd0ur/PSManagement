using System;

namespace PSManagement.Contracts.Projects.Response
{
    public class StepTrackResponse
    {
        public int StepId { get; set; }
        public int TrackId { get; set; }
        public String ExecutionState { get; set; }
        public DateTime TrackDate { get; set; }

        public int ExecutionRatio { get; set; }

    }
}