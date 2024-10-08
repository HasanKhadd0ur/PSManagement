﻿using PSManagement.SharedKernel.Events;
using System;

namespace PSManagement.Domain.Projects.DomainEvents
{
    public record ParticipationChangedEvent(
        int ParticipantId,
        int PartialTimeRatioBefore,
        int PartialTimeRatioAfter,
        string RoleBefore ,
        string RoleAfter ,
        int ProjectId,
        DateTime DateTime
        ) :IDomainEvent;
}
