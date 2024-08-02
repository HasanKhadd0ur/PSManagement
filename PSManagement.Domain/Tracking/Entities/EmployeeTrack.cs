using PSManagement.Domain.Employees.Aggregate;
using PSManagement.SharedKernel.Entities;

namespace PSManagement.Domain.Tracking.Entities
{
    public class EmployeeTrack : BaseEntity
    {
        public Employee Employee { get; set; }
        public int WorkingHour { get; set; }
        public EmployeeTrack()
        {

        }
    }
}
