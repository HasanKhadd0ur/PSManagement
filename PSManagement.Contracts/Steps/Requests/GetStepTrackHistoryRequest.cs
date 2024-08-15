namespace PSManagement.Contracts.Steps.Requests
{
    public record GetStepTrackHistoryRequest(
    int StepId,
    int? PageNumber,
    int? PageSize
);
}