using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace PSManagement.Domain.Tracking.Entities
{
    public class StepTrack : BaseEntity
    {
        public int StepId { get; set; }
        public Step Step { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public String ExecutionState { get; set; }
        public int ExecutionRatio { get; set; }

        public StepTrack()
        {
                
        }
    }
}
