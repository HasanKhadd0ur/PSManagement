using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Steps.UseCases.Commands.UpdateCompletionRatio
{
    public record UpdateCompletionRatioCommand(
        int StepId,
        int CompletionRatio
    ) : ICommand<Result>;

}
