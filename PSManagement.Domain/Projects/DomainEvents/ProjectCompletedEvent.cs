using PSManagement.SharedKernel.Events;

namespace PSManagement.Domain.Projects.DomainEvents
{
    public record ProjectCompletedEvent(
        int ProjectId
        ) : IDomainEvent;
}
