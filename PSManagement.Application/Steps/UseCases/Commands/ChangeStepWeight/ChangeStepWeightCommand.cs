using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;

namespace PSManagement.Application.Steps.UseCases.Commands.ChangeStepWeight
{
    public record ChangeStepWeightCommand(
        int StepId,
        int Weight
    ) : ICommand<Result>;

}
