using Ardalis.Result;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Tracks.UseCaes.Commands.UpdateEmployeeWorkTrack
{
    public record UpdateEmployeeWorkTrackCommand(
        int EmployeeTrackId,
        int TrackId,
        int EmployeeId,
        EmployeeWorkInfo EmployeeWorkInfo,
        EmployeeWork EmployeeWork,
        string Notes
     ) : ILoggableCommand<Result>;
}
