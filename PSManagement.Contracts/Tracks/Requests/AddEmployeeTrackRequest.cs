using PSManagement.Domain.Tracking.ValueObjects;

namespace PSManagement.Contracts.Tracks.Requests
{
    public record AddEmployeeTrackRequest(
        int TrackId,
        int EmployeeId,
        EmployeeWorkInfo EmployeeWorkInfo,
        EmployeeWork EmployeeWork,
        string Notes,
        int ProjectId
    ) ;
}
