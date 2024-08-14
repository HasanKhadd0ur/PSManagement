using Ardalis.Result;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;

namespace PSManagement.Application.Employees.UseCases.Commands.UpdateEmployeeWorkHours
{
    public record UpdateEmployeeWorkHoursCommand(
        int EmployeeId,
        int WorkingHour) : ICommand<Result>;

}
