using PSManagement.Domain.Projects.Aggregate;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Tracking
{
    public class Track : IAggregateRoot
    {
        public DateTime TrackDate { get; set; }
        public String TrackNote { get; set; }
        public Project Project { get; set; }
        public ICollection<StepTrack> StepsTracks { get; set; }
        public Track()
        {

        }
    }
}
