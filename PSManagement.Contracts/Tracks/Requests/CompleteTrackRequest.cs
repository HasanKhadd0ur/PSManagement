using System;

namespace PSManagement.Contracts.Tracks.Requests
{
    public record CompleteTrackRequest(
        int TrackId,
        DateTime CompletionDate,
        int ProjectId
    ) ;
}
