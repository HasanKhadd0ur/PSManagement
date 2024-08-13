using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Projects.UseCases.Commands.ChangeProjectTeamLeader
{
    public record ChangeProjectTeamLeaderCommand(
        int EmployeeId,
        int ProjectId
    ) : ICommand<Result>;

}
