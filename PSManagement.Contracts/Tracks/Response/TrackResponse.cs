using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.Domain.Projects.ValueObjects;

using System;

namespace PSManagement.Contracts.Tracks.Response
{
    public record TrackResponse (
        int Id ,
        TrackInfo TrackInfo ,
        String Notes ,
        int ProjectId ,
        ProjectInfo ProjectInfo 
        );
}
