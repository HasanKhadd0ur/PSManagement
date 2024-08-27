using Ardalis.Result;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Steps.UseCases.Commands.UpdateStepInformaion
{
    public record UpdateStepInformationCommand(
        int StepId,
        StepInfo StepInfo
        ) : ICommand<Result>;

}
