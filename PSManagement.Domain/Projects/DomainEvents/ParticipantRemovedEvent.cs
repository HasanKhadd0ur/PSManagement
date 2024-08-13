using PSManagement.SharedKernel.Events;

namespace PSManagement.Domain.Projects.DomainEvents
{
    public record ParticipantRemovedEvent(
        int EmployeeId,
        int ProjectId
        ) : IDomainEvent;
}
