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
    /// <summary>
    /// Track Class 
    /// </summary>
    /// this class represent the track action 
    /// on a specific project 
    /// 
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

        #region Encapsulation 

        // this method hide the publishing of the domain events 
        public void Complete(DateTime completionDate)
        {
            TrackInfo = new (TrackInfo.TrackDate,true,TrackInfo.StatusDescription);

            AddDomainEvent(new TrackCompletedEvent(ProjectId, Id, completionDate));

        }

        public bool IsCompleted()
        {
            return TrackInfo.IsCompleted;
                
        }

        public bool HasEmployee(int employeeId)
        {
            return EmployeeTracks.Any(e => e.EmployeeId == employeeId);
        }

        public void AddEmployeeTrack(int employeeId, EmployeeWork employeeWork, EmployeeWorkInfo employeeWorkInfo, string notes)
        {

            EmployeeTracks.Add(new EmployeeTrack { 
                EmployeeWork=employeeWork,
                EmployeeWorkInfo=employeeWorkInfo,
                EmployeeId=employeeId,
                TrackId=Id,
                Notes=notes
            
            });

        }
        #endregion Encapsulation 
    }
}
