using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Entities;

namespace PSManagement.Domain.Tracking.Entities
{
    public class EmployeeWork : BaseEntity
    {
        public int EmployeeWorkId { get; set; }
        public int StepTrackId { get; set; }
        public StepTrack StepTrack { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int HoursWorked { get; set; }
        public string Notes { get; set; }
        public int ContributingRatio { get; set; }
    }
}
