namespace PSManagement.Contracts.Projects.Requests
{
    public record ChangeEmployeeParticipationRequest(
        int ParticipantId,
        int ProjectId,
        int PartialTimeRation,
        string Role
        );
}
