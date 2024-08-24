using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.Domain.Employees.Entities;

namespace PSManagement.Contracts.Tracks.Response
{
    public record EmployeeTrackResponse(
        int EmloyeeId,
        int TrackId,
        Employee Employee,
        TrackInfo TrackInfo,
        EmployeeWorkInfo EmployeeWorkInfo,
        EmployeeWork EmployeeWork,
        string Notes
    );
}
