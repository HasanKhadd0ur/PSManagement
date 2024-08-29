using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Contracts.Projects.Response;

namespace PSManagement.Contracts.Tracks.Response
{
    public record EmployeeTrackResponse(
        int EmployeeId,
        int TrackId,
        EmployeeResponse Employee,
        TrackInfo TrackInfo,
        EmployeeWorkInfo EmployeeWorkInfo,
        EmployeeWork EmployeeWork,
        string Notes
    );
}
