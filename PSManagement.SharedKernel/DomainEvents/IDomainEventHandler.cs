using MediatR;
using PSManagement.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.DomainEvents
{
    public interface IDomainEventHandler<T> :INotificationHandler<T>  where T : IDomainEvent 
    {
    }
}
