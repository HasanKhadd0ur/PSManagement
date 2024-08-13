using System;

namespace PSManagement.Contracts.Projects.Requests
{
    public record AddParticipantRequest(
    int ProjectId,
    int ParticipantId,
    int PartialTimeRatio,
    String Role
    );
}
