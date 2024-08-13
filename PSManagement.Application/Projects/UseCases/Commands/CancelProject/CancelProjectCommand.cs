using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Projects.UseCases.Commands.CancelProject
{
    public record CancelProjectCommand(
        int EmployeeId,
        int ProjectId
        ) : ICommand<Result>;

}
