using PSManagement.Domain.Customers.DomainEvents;
using PSManagement.SharedKernel.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.Events
{
    public class CustomerCreatedEventHandler : IDomainEventHandler<CutsomerCreatedEvent>
    {
        public  Task Handle(CutsomerCreatedEvent notification, CancellationToken cancellationToken)
        {

            Console.WriteLine("fdgfg");
            return Task.CompletedTask;

        }
    }
}
