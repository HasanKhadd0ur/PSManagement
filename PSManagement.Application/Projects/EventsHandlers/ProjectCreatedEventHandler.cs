using PSManagement.Application.Contracts.Email;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.SharedKernel.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.EventsHandlers
{
    public class ProjectCreatedEventHandler:IDomainEventHandler<ProjectCreatedEvent>
    {
        private readonly IEmailService _emailService;

        public ProjectCreatedEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(ProjectCreatedEvent notification, CancellationToken cancellationToken)
        {
            
            await _emailService.SendAsync(""+notification.ProjectManagerId,"gf h gf ","fg fdg");
            await _emailService.SendAsync("" + notification.TeamLeaderId, "gf h gf ", "fg fdg");

        }
    }
}
