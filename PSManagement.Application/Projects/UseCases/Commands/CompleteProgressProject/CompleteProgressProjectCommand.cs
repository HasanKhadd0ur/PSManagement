using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Projects.UseCases.Commands.CompleteProgressProject
{
    public record CompleteProgressProjectCommand(
        int ProjectId
        ) : ICommand<Result>;

}
