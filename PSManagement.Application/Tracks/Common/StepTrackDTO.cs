using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.Tracking.ValueObjects;
using System;

namespace PSManagement.Application.Tracks.Common
{
    public class StepTrackDTO
    {
        public int StepId { get; set; }
        public int TrackId { get; set; }
        public StepInfo StepInfo { get; set; }

        public TrackInfo TrackInfo { get; set; }

        public String ExecutionState { get; set; }
        public DateTime TrackDate { get; set; }
        public int ExecutionRatio { get; set; }

    }
}