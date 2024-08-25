using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType
{
    public record CreateNewTypeCommand(
        string TypeName,
        string Description,
        int ExpectedEffort

    ) : ILoggableCommand<Result<int>>;

}
