using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Tracking
{
    public class Track : BaseEntity
    {
        public DateTime TrackDate { get; set; }
        public String TrackNote { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<StepTrack> StepTracks { get; set; }
        public ICollection<Employee> TrackedEmployees { get; set; }
        public ICollection<EmployeeTrack> EmployeeTracks { get; set; }
        public Track()
        {

        }
    }
}
