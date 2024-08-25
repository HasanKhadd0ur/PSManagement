using PSManagement.Domain.Tracking.ValueObjects;

using PSManagement.Application.Employees.Common;
namespace PSManagement.Application.Tracks.Common
{
    public class EmployeeTrackDTO
    {
        public int Id { get; set; }
        public int EmloyeeId { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int TrackId { get; set; }
        public TrackInfo TrackInfo { get; set; }
        public EmployeeWorkInfo EmployeeWorkInfo { get; set; }
        public EmployeeWork EmployeeWork { get; set; }
        public string Notes { get; set; }
    }
}