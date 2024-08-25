using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Tracking.DomainEvents;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.Domain.Tracking.ValueObjects;
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
        public TrackInfo TrackInfo { get; set; }
        public String Notes { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }        
        public ICollection<StepTrack> StepTracks { get; set; }
        public ICollection<EmployeeTrack> EmployeeTracks { get; set; }
        
        
        #region Association 
        public ICollection<Employee> TrackedEmployees { get; set; }
        #endregion Association 
  
        #region  Constructors
        public Track()
        {

        }

        #endregion  Constructors


        // this method hide the publishing of the domain events 
        public void Complete(DateTime completionDate)
        {
            TrackInfo = new (TrackInfo.TrackDate,true,TrackInfo.StatusDescription);

            AddDomainEvent(new TrackCompletedEvent(ProjectId, Id, completionDate));

        }
    }
}
