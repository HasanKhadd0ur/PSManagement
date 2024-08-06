using PSManagement.Domain.Steps.Entities;
using PSManagement.SharedKernel.Entities;
using System.Collections.Generic;

namespace PSManagement.Domain.Tracking.Entities
{
    public class StepTrack : BaseEntity
    {
        public int StepId { get; set; }
        public Step Step { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int ExecutionRatio { get; set; }
        //public ICollection<EmployeeWork> EmployeeWorks { get; set; }
        public StepTrack()
        {
                
        }
    }
}
