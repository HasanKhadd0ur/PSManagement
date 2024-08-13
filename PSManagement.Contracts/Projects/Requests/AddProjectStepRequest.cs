using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Contracts.Projects.Requests
{
    public record AddProjectStepRequest(
        int ProjectId,
        StepInfo StepInfo,
        int CurrentCompletionRatio,
        int Weight
        );

}
