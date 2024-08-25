using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType
{
    public record UpdateTypeCommand(
        int Id,
        string TypeName,
        string Description,
        int ExpectedEffort

    ) : ILoggableCommand<Result>;
}
