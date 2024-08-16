using Ardalis.Result;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddEmployeesTrack
{
    public record AddEmployeeTrackCommand(
    int TrackId,
    int EmployeeId,
    EmployeeWorkInfo EmployeeWorkInfo ,
    EmployeeWork EmployeeWork,
    String Notes,
    int ProjectId
) : ILoggableCommand<Result>;
}
