using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.SharedKernel.Entities;
using System;

namespace PSManagement.Domain.Tracking
{
    public class EmployeeTrack :BaseEntity
    {
        public int EmployeeId { get; set; }
        public int TrackId { get; set; }
        public Employee Employee { get; set; }
        public Track Track { get; set; }
        public EmployeeWorkInfo EmployeeWorkInfo { get; set; }
        public EmployeeWork EmployeeWork { get; set; }
        public string Notes { get; set; }

        #region Encapsulation 
        public void UpdateEmployeeWork(EmployeeWork employeeWork)
        {
            EmployeeWork = new(employeeWork.AssignedWorkingHours,employeeWork.WorkedHours,employeeWork.ContributingRatio);
        }


        public void UpdateEmployeeWorkInfo(EmployeeWorkInfo employeeWorkInfo)
        {
            EmployeeWorkInfo = new (employeeWorkInfo.AssignedWork,employeeWorkInfo.PerformedWork,employeeWorkInfo.AssignedWorkEnd);
        }

        public void UpdateNotes(string notes)
        {
            Notes = notes;
        }
        #endregion Encapsulation 
    }
}
