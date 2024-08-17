using PSManagement.Domain.Tracking.ValueObjects;

namespace PSManagement.Contracts.Tracks.Response
{
    public record EmployeeTrackResponse(
        int EmloyeeId,
        int TrackId,
        TrackInfo TrackInfo,
        EmployeeWorkInfo EmployeeWorkInfo,
        EmployeeWork EmployeeWork,
        string Notes
    );
}
