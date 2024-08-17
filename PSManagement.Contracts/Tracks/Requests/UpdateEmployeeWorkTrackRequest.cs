using PSManagement.Domain.Tracking.ValueObjects;

namespace PSManagement.Contracts.Tracks.Requests
{
    public record UpdateEmployeeWorkTrackRequest(
          int EmployeeTrackId,
          int TrackId,
          int EmployeeId,
          EmployeeWorkInfo EmployeeWorkInfo,
          EmployeeWork EmployeeWork,
          string Notes
    );
}
