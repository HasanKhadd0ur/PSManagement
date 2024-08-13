using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.SharedKernel.Events;

namespace PSManagement.Domain.Projects.DomainEvents
{
    public record ProjectApprovedEvent(
    int ProjectId,
    Aggreement ProjectAggreement) : IDomainEvent;
}
