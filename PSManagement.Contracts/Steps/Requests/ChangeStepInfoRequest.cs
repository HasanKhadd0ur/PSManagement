using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Contracts.Steps.Requests
{
    public record ChangeStepInfoRequest(
        
        int StepId,
        StepInfo StepInfo);
}