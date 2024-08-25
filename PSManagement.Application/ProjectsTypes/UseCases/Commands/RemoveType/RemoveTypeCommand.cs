using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType
{
    public record RemoveTypeCommand(
          int typeId 
    ) : ILoggableCommand<Result>;
}
