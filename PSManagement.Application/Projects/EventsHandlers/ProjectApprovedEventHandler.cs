using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.SharedKernel.DomainEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.EventsHandlers
{
    public class ProjectApprovedEventHandler : IDomainEventHandler<ProjectApprovedEvent>
    {
        public Task Handle(ProjectApprovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }

}
