using PSManagement.SharedKernel.Events;
using System;

namespace PSManagement.Domain.Projects.DomainEvents
{
    public record ParticipantAddedEvent (
        int EmployeeId,
        int ProjectId,
        int PartialTimeRatio,
        String Role
        ):IDomainEvent;
}
