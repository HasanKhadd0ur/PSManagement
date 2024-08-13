using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Projects.UseCases.Commands.CompletePlaningProject
{
    public record CompletePlaningProjectCommand(
        int ProjectId
        ) : ICommand<Result>;

}
