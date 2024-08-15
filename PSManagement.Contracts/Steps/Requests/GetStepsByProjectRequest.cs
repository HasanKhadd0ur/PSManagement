namespace PSManagement.Contracts.Steps.Requests
{
    public record GetStepsByProjectRequest(
    int ProjectId,
    int? PageSize,
    int? PageNumber
);

}