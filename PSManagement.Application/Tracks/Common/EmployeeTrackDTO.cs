using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.Domain.Employees.Entities;

namespace PSManagement.Application.Tracks.Common
{
    public class EmployeeTrackDTO
    {
        public int Id { get; set; }
        public int EmloyeeId { get; set; }
        public Employee Emloyee { get; set; }
        public int TrackId { get; set; }
        public TrackInfo TrackInfo { get; set; }
        public EmployeeWorkInfo EmployeeWorkInfo { get; set; }
        public EmployeeWork EmployeeWork { get; set; }
        public string Notes { get; set; }
    }
}