using Ardalis.Result;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddEmployeeTrack
{
    public record AddEmployeeTrackCommand(
    int TrackId,
    int EmployeeId,
    EmployeeWorkInfo EmployeeWorkInfo,
    EmployeeWork EmployeeWork,
    string Notes,
    int ProjectId
) : ILoggableCommand<Result<int>>;
}
