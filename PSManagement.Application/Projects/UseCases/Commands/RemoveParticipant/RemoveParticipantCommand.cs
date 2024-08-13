using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;


namespace PSManagement.Application.Projects.UseCases.Commands.RemoveParticipant
{
    public record RemoveParticipantCommand(
        int ProjectId,
        int ParticipantId
        ) : ICommand<Result>;

}
