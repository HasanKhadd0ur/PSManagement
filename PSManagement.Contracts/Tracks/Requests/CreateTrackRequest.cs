using PSManagement.Domain.Tracking.ValueObjects;
using System;

namespace PSManagement.Contracts.Tracks.Requests
{
    public record CreateTrackRequest(
        TrackInfo TrackInfo,
        String Notes,
        int ProjectId
    );
}
