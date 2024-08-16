using System;

namespace PSManagement.Domain.Tracking.ValueObjects
{
    public record TrackInfo(
        DateTime TrackDate,
        bool IsCompleted,
        string StatusDescription
        );
}
