using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Projects.UseCases.Commands.ChangeProjectManager
{
    public record ChangeEmployeeParticipationCommand(
        int ParticipantId,
        int ProjectId,
        int PartialTimeRation,
        string Role 
        ) : ICommand<Result>;

}
