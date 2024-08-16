using PSManagement.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Tracking.DomainEvents
{
    public record  TrackCreatedEvent(
        int ProjectId,
        DateTime Date) : IDomainEvent;

}
