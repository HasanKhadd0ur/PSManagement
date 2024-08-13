namespace PSManagement.Contracts.Projects.Requests
{
    public record RemoveParticipantRequest(
            int ProjectId,
            int ParticipantId
     );

}
