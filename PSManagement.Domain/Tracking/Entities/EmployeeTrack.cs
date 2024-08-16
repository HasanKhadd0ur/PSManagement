using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.SharedKernel.Entities;

namespace PSManagement.Domain.Tracking
{
    public class EmployeeTrack :BaseEntity
    {
        public int EmloyeeId { get; set; }
        public int TrackId { get; set; }
        public Employee Employee { get; set; }
        public Track Track { get; set; }
        public EmployeeWorkInfo EmployeeWorkInfo { get; set; }
        public EmployeeWork EmployeeWork { get; set; }
        public string Notes { get; set; }
    }
}
