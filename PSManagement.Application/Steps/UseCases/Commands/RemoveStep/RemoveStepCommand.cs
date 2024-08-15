using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Steps.UseCases.Commands.RemoveStep
{
    public record RemoveStepCommand(
        int StepId
    ) : ICommand<Result>;

}
