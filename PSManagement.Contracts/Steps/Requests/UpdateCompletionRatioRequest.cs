namespace PSManagement.Contracts.Steps.Requests
{
    public record UpdateCompletionRatioRequest(
        int StepId,
        int CompletionRatio
    );
}