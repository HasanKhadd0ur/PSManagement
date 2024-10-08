﻿using PSManagement.SharedKernel.Events;
using System;

namespace PSManagement.Domain.Tracking.DomainEvents
{
    public record TrackCompletedEvent(
        int ProjectId,
        int TrackId,
        DateTime Date) : IDomainEvent;

}
