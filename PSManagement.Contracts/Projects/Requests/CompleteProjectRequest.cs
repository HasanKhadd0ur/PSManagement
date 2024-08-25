using System;

namespace PSManagement.Contracts.Projects.Requests
{
    public record CompleteProjectRequest(
    int ProjectId,
    DateTime CompletionDate,
    String CustomerNotes,
    int CustomerRate
       );
}
