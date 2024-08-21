using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Projects.UseCases.Commands.ChangeProjectManager
{
    public record ChangeProjectManagerCommand(
    int EmployeeId,
    int ProjectId
) : ICommand<Result>;

}
