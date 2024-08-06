using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Entities;
using System;

namespace PSManagement.Domain.Tracking
{
    public class EmployeeTrack :BaseEntity
    {
        public int EmloyeeId { get; set; }
        public int TrackId { get; set; }
        public Employee Employee { get; set; }
        public Track Track { get; set; }
        public int WorkingHours { get; set; }
        public String PerformedWork { get; set; }
        public String AssignedWork { get; set; }

        //public ICollection<EmployeeWork> EmployeeWorks { get; set; }

    }
}
